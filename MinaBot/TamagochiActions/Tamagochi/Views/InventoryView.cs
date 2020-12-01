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
        private TamagochiModel _tamagochi;
        public InventoryView(TamagochiModel pet)
        {
            _tamagochi = pet;
        }
        public MessageResult GetView(CommandModel cmdModel=null)
        {
            return new EmbedView(ConstructMainEmbed(_tamagochi, cmdModel));
        }

        private Embed ConstructMainEmbed(TamagochiModel pet, CommandModel message)
        {
            var items = pet.Backpack.GetItems();
            var rarities = "";
            var prices = "";
            for (var ind = 0; ind < pet.Backpack.ItemCount; ind++)
            {
                rarities += Enum.GetName(typeof(ERarity), items[ind].Rarity) + "\n";
                prices += $"{items[ind].Price}/{items[ind].SoldPrice}\n";
            }
            var embed = new EmbedBuilder();
            embed.Title = pet.Name;
            embed.Description = pet.CurrentStatus;
            embed.Color = new Discord.Color((uint)Convert.ToInt32(pet.Color, 16));
            if (items.Data.Count == 0)
            {
                embed.AddField(_GetMainStatsField(pet));
                embed.AddField(_GetEmptyBackpackField());
                return embed.Build();
            }
            embed.AddField(_GetMainStatsField(pet));
            embed.AddField(_GetItemsField(items.ToStringInLine()));
            embed.AddField(_GetPricesField(prices));
            embed.AddField(_GetRarityField(rarities));
            return embed.Build();
        }

        private EmbedFieldBuilder _GetMainStatsField(TamagochiModel pet)
        {
            return new EmbedFieldBuilder()
            {
                Name = "**Info:**",
                Value = $"<a:coins:781827813715869696> `{pet.Money}`\n" +
                        $"<:happines:781836925492264960> `{pet.Level.Level} ({pet.Level.CurrentExp}/{pet.Level.ExpToNextLevel})`\n"
            };
        }
        
        private EmbedFieldBuilder _GetItemsField(string itemsEveryInLive)
        {
            return new EmbedFieldBuilder()
            {
                Name = "**Items**",
                Value = itemsEveryInLive,
                IsInline = true
            };
        }
        
        private EmbedFieldBuilder _GetRarityField(string raritiesEveryInLine)
        {
            return new EmbedFieldBuilder()
            {
                Name = "**Rarity:**", 
                IsInline = true,
                Value = raritiesEveryInLine
            };
        }

        private EmbedFieldBuilder _GetPricesField(string pricesEveryInLine)
        {
            return new EmbedFieldBuilder()
            {
                Name = "**Price/Sold Price:**", 
                IsInline = true,
                Value = pricesEveryInLine
            };
        }
        
        private EmbedFieldBuilder _GetEmptyBackpackField()
        {
            var value = "Send your pet for hunting and get some items!";
            return new EmbedFieldBuilder()
            {
                Name = "Sorry! But your inventory is empty!",
                IsInline = true,
                Value = value
            };
        }
    }
}
