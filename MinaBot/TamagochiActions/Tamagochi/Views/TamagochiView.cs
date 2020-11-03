using Discord;
using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Controllers;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Linq;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.View
{
    class TamagochiView: IView
    {
        public MessageResult GetView(TamagochiModel pet, CommandModel message = null)
        {
            return new EmbedView(ConstructMainEmbed(pet, message));
        }

        private Embed ConstructMainEmbed(TamagochiModel pet, CommandModel message)
        {
            var embed = new EmbedBuilder();
            embed.Title = pet.Name;
            embed.Description = pet.CurrentStatus;
            embed.Color = new Discord.Color((uint)Convert.ToInt32(pet.Color, 16));
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "Статы",
                Value = $"Coins: {pet.Money}\n" +
                        $"Level: {pet.Level.Level} ({pet.Level.CurrentExp}/{pet.Level.ExpToNextLevel})\n" +
                        $"LiveTime: {TamagochiController.NeedTimeToHungryAndThristyScore(pet, 40) + (pet.Health.Score / pet.Health.MinusEveryMinute)}min."
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ХАРАКТЕРИСТИКА:**",
                Value = $":heart:  **Здоровье**: { pet.Health.Score }\n" +
                        $":meat_on_bone:  **Голод**: { pet.Hungry.Score }\n" +
                        $":sweat_drops:  **Жажда**: { pet.Thirsty.Score }\n" +
                        $":partying_face:   **Счастье**: { pet.Happiness.Score }",
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ОДЕЖДА:**",
                Value = $"**Шляпа**: { pet.Hat.Name }\n" +
                        $"**Куртка**: { pet.Jacket.Name }\n" +
                        $"**Штаны**: { pet.Pants.Name }\n" +
                        $"**Ботинки**: { pet.Boots.Name }",
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = $"**ИНВЕНТАРЬ ({ pet.Backpack.ItemCount }/{ Backpack.MAXITEMSCOUNT }):**",
                Value = pet.Backpack.ToString()
            });
            embed.Footer = new EmbedFooterBuilder()
            {
                Text = $"Дата рождения: { pet.Birthday }"
            };
            return embed.Build();
        }
    }
}
