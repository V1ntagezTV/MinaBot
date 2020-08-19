using Discord;
using MinaBot.BotTamagochi.ItemsPack;
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
            return new EmbedView<Embed>(ConstructMainEmbed(pet, message));
        }

        private Embed ConstructMainEmbed(TamagochiModel pet, CommandModel message)
        {
            var rgb = pet.Color.Split(':').Select(s => Convert.ToInt32(s)).ToList();
            var embed = new EmbedBuilder();
            embed.Title = pet.Name;
            embed.Description = pet.CurrentStatus;
            embed.Color = new Discord.Color(rgb[0], rgb[1], rgb[2]);
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "Статы",
                Value = $"Money: {pet.Money}\n" +
                $"Level: {pet.Level.Level} ({pet.Level.CurrentExp}/{pet.Level.ExpToNextLevel})"
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ХАРАКТЕРИСТИКА:**",
                Value = ":heart:  **Здоровье**: " + pet.Health.Score + " хп\n" +
                    ":meat_on_bone:  **Голод**: " + pet.Hungry.Score + " p\n" +
                    ":sweat_drops:  **Жажда**: " + pet.Thirsty.Score + " p\n" +
                    ":partying_face:   **Счастье**: " + pet.Happiness.Score + " p\n",
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ОДЕЖДА:**",
                Value = "**Шляпа**: " + pet.Hat.Name + "\n" +
                    "**Куртка**: " + pet.Jacket.Name + "\n" +
                    "**Штаны**: " + pet.Pants.Name + "\n" +
                    "**Ботинки**: " + pet.Boots.Name,
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ИНВЕНТАРЬ:**",
                Value = pet.Backpack.ToString()
            });
            embed.Footer = new EmbedFooterBuilder()
            {
                Text = "Дата рождения: " + pet.Birthday.ToString()
            };
            return embed.Build();
        }
    }
}
