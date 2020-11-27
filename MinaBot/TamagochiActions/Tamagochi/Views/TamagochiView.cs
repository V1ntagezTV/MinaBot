using Discord;
using MinaBot.Base;
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
        private TamagochiModel _tamagochi;

        public TamagochiView(TamagochiModel pet)
        {
            _tamagochi = pet;
        }
        public MessageResult GetView(CommandModel cmdModel = null)
        {
            return new EmbedView(ConstructMainEmbed(_tamagochi, cmdModel));
        }

        private Embed ConstructMainEmbed(TamagochiModel pet, CommandModel message)
        {
            var petToDeath = TamagochiController.NeedTimeToHungryAndThristyScore(pet, 40) +
                             (pet.Health.Score / pet.Health.MinusEveryMinute);
            var embed = new EmbedBuilder();
            embed.Title = pet.Name;
            embed.Description = pet.CurrentStatus;
            embed.Color = new Discord.Color((uint)Convert.ToInt32(pet.Color, 16));
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Info:**",
                Value = $"{Icons.Coins} `{pet.Money}`\n" +
                        $"{Icons.Level} `{pet.Level.Level} ({pet.Level.CurrentExp}/{pet.Level.ExpToNextLevel})`\n" +
                        $"LiveTime: {Math.Round(petToDeath, 2)} min."
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Stats:**",
                Value = $":heart:  Health: `{ pet.Health.Score }`\n" +
                        $":meat_on_bone:  Hungry: `{ pet.Hungry.Score }`\n" +
                        $":sweat_drops:  Thirsty: `{ pet.Thirsty.Score }`\n" +
                        $":partying_face:   Happines: `{ pet.Happiness.Score }`",
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Clothes:**",
                Value = $"Hat: { pet.Hat.Name }\n" +
                        $"Jacket: { pet.Jacket.Name }\n" +
                        $"Pants: { pet.Pants.Name }\n" +
                        $"Boots: { pet.Boots.Name }",
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = $"Inventory **({ pet.Backpack.ItemCount }/{ Backpack.MAXITEMSCOUNT }):**",
                Value = pet.Backpack.ToString()
            });
            embed.Footer = new EmbedFooterBuilder()
            {
                Text = $"Birthday: { pet.Birthday }"
            };
            return embed.Build();
        }
    }
}
