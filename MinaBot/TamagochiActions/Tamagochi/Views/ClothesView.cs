using Discord;
using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.View
{
    class ClothesView : IView
    {
        public MessageResult GetView(TamagochiModel tamagochi, CommandModel message = null)
        {
            return new EmbedView(ConstructMainEmbed(tamagochi, message));
        }

        private Embed ConstructMainEmbed(TamagochiModel pet, CommandModel message)
        {
            var hat = ItemMocks.AllItems[pet.HatID];
            var jacket = ItemMocks.AllItems[pet.JacketID];
            var pants = ItemMocks.AllItems[pet.PantsID];
            var boots = ItemMocks.AllItems[pet.BootsID];

            var embed = new EmbedBuilder();
            embed.Title = pet.Name;
            embed.Description = pet.CurrentStatus;
            embed.Color = new Discord.Color((uint)Convert.ToInt32(pet.Color, 16));
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "Статы",
                Value = $"**Coins:** {pet.Money}\n" +
                        $"**Level:** {pet.Level.Level} ({pet.Level.CurrentExp}/{pet.Level.ExpToNextLevel})"
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ОДЕЖДА**",
                Value = $"{ hat.Name }\n{ jacket.Name }\n" +
                        $"{ pants.Name }\n{ boots.Name }",
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**РЕДКОСТЬ**",
                Value = $"**{ Enum.GetName(typeof(ERarity), (int)hat.Rarity) }\n" +
                        $"{ Enum.GetName(typeof(ERarity), (int)jacket.Rarity) }\n" +
                        $"{ Enum.GetName(typeof(ERarity), (int)pants.Rarity) }\n" +
                        $"{ Enum.GetName(typeof(ERarity), (int)boots.Rarity) }**",
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ЦЕНА**",
                Value = $"**{ hat.Price }\n{ jacket.Price }\n" +
                        $"{ pants.Price }\n{ boots.Price }**",
                IsInline = true
            });
            Console.WriteLine(Enum.GetName(typeof(ERarity), hat.Rarity));
            return embed.Build();
        }
    }
}
