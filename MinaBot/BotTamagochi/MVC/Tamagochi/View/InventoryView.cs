using Discord;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.View
{
    class InventoryView : IView
    {
        public MessageResult GetView(TamagochiModel tamagochi, CommandModel message=null)
        {
            return new EmbedView<Embed>(ConstructMainEmbed(tamagochi, message));
        }

        private Embed ConstructMainEmbed(TamagochiModel pet, CommandModel message)
        {
            var items = pet.Backpack.Items;
            var rarityField = new EmbedFieldBuilder() { IsInline = true };
            var priceField = new EmbedFieldBuilder() { IsInline = true };

            rarityField.Name = "**RARITY**";
            priceField.Name = "**PRICE/SALE**";
            for (int ind = 0; ind < pet.Backpack.ItemCount; ind++)
            {
                rarityField.Value += Enum.GetName(typeof(ERarity), items[ind].Rarity) + "\n";
                priceField.Value += $"{items[ind].Price}/{items[ind].SoldPrice}\n";
            }

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
                Name = "**ITEMS**",
                Value = pet.Backpack.Items.ToStringInLine(),
                IsInline = true
            });
            embed.AddField(rarityField);
            embed.AddField(priceField);
            return embed.Build();
        }
    }
}
