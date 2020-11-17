using System;
using System.Linq;
using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    public class SoldItemAction : APetActionCommand, IHelper
    {
        public string Title => "**m!pet sold <itemIndex>**";
        public string Description => "Sold recieved items.\nItem index from your invetory (1-10).";
        public override string[] Options => new[] {"sold"};
        public SoldItemAction(TamagochiModel pet, CommandModel command) 
            : base(pet, command, true) { }
        
        public override MessageResult Invoke()
        {
            var itemInd = Command.GetArgs[0];
            return SoldItem(Pet, itemInd);
        }
        
        public MessageResult SoldItem(TamagochiModel pet, string itemsInd)
        {
            var itemsRange = itemsInd.Split('-').Select(num => Convert.ToInt32(num));
            if (itemsRange.Count() == 1)
            {
                var itemIndex = itemsRange.ElementAt(0) - 1;
                if (!pet.Backpack.IsIndexInBackpackRange(itemIndex))
                {
                    return new MessageResult.BooleanView(false);
                }
                var item = pet.Backpack.GetItems()[itemIndex];
                pet.Backpack.Remove(itemIndex);
                pet.Money += item.SoldPrice;
                return new MessageResult.BooleanView(true);
            }
            else if (itemsRange.Count() == 2)
            {
                var start = itemsRange.ElementAt(0) - 1;
                var end = itemsRange.ElementAt(1) - 1;
                if (!pet.Backpack.IsIndexInBackpackRange(start) || !pet.Backpack.IsIndexInBackpackRange(end))
                {
                    return new MessageResult.BooleanView(false);
                }
                for (int ind = start; ind <= end; ind++)
                {
                    pet.Money += pet.Backpack.GetItems()[ind].SoldPrice;
                }
                return new MessageResult.BooleanView(pet.Backpack.RemoveRange(start, end + 1));
            }
            else
            {
                return new MessageResult.BooleanView(false);
            }
        }
    }
}