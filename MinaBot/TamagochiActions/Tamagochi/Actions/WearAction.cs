using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MinaBot.BotTamagochi.ItemsPack;
using static MinaBot.BotTamagochi.BotPackValues.ItemTypes;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class WearAction : APetActionCommand
    {
        public WearAction(TamagochiModel pet, CommandModel cmd) 
            : base(pet, cmd, true) { }

        public override string[] Options => new[] { "wear", "w" };

        public override MessageResult Invoke()
        {
            var itemInd = Convert.ToInt32(Command.GetArgs[0]) - 1;
            if (Pet.Backpack.Lenght < itemInd || itemInd < 0)
                return new ErrorView("Item index was wrong!");

            var item = Pet.Backpack.GetItems()[itemInd];
            Pet.Backpack.Remove(itemInd);
            if (item is Hat)
            {
                AddWearItemBackInBackpack(Pet.HatID);
                Pet.HatID = item.ID;
            }
            else if (item is Jacket)
            {
                AddWearItemBackInBackpack(Pet.JacketID);
                Pet.JacketID = item.ID;
            }
            else if (item is Pants)
            {
                AddWearItemBackInBackpack(Pet.PantsID);
                Pet.PantsID = item.ID;
            }
            else if (item is Boots)
            {
                AddWearItemBackInBackpack(Pet.BootsID);
                Pet.BootsID = item.ID;
            }
            else return new ErrorView($"You can't wear this item!\nIndex{itemInd}");
            return new BooleanView(true);
        }

        private void AddWearItemBackInBackpack(int itemId)
        {
            if (Pet.HatID == ItemMocks.defaultCleanItem.ID)
            {
                Pet.Backpack.Add(Pet.HatID.ToString());
            }
        }
    }
}
