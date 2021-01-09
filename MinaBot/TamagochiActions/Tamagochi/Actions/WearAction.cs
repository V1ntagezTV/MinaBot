using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class WearAction : APetActionCommand, IHelper
    {
        public string Title => "m!pet wear <itemIndex>";
        public string Description => "Wear items on your pet.\nItem index from your invetory (1-10).";
        public override string[] Options => new[] {"wear"};
        public WearAction(TamagochiModel pet, CommandModel cmd) 
            : base(pet, cmd, true) { }

        public override MessageResult Invoke()
        {
            var itemInd = Convert.ToInt32(Command.GetArgs[0]) - 1;    
            if (Pet.Backpack.Lenght < itemInd || itemInd < 0)
                return new ErrorView("Item index was wrong!");
            
            var item = Pet.Backpack.GetItems()[itemInd];
            Console.WriteLine($"item id to wear: {item.Id}");
            Pet.Backpack.Remove(itemInd);
            if (item is Hat)
            {
                AddWearItemBackInBackpack(Pet.HatID);
                Pet.HatID = item.Id;
            }
            else if (item is Jacket)
            {
                AddWearItemBackInBackpack(Pet.JacketID);
                Pet.JacketID = item.Id;
            }
            else if (item is Pants)
            {
                AddWearItemBackInBackpack(Pet.PantsID);
                Pet.PantsID = item.Id;
            }
            else if (item is Boots)
            {
                AddWearItemBackInBackpack(Pet.BootsID);
                Pet.BootsID = item.Id;
            }
            else return new ErrorView($"You can't wear this item!\nIndex{itemInd}");
            return new BooleanView(true);
        }

        private void AddWearItemBackInBackpack(int itemId)
        {
            if (Pet.HatID == ItemMocks.DefaultItem.Id) return;
            
            Pet.Backpack.Add(Pet.HatID.ToString());
        }
    }
}
