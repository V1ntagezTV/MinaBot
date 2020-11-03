using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MinaBot.BotTamagochi.BotPackValues.ItemTypes;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class WearAction : APetActionCommand
    {
        public WearAction(TamagochiModel pet, CommandModel cmd) 
            : base(pet, cmd, true)
        {
            this.Options = new[] { "wear", "w" };
        }

        public override MessageResult Invoke()
        {
            var itemInd = Convert.ToInt32(Command.GetArgs[0]);
            if (Pet.Backpack.Lenght < itemInd || itemInd < 0)
                return new ErrorView("Item index was wrong!");

            var item = Pet.Backpack.Items[itemInd];
            if (item is Hat) Pet.HatID = item.ID;
            else if (item is Jacket) Pet.JacketID = item.ID;
            else if (item is Pants) Pet.PantsID = item.ID;
            else if (item is Boots) Pet.BootsID = item.ID;
            else return new ErrorView($"You can't wear this item!\nIndex{itemInd}");
            Pet.Level.CurrentExp += 10;
            return new BooleanView(true);
        }
    }
}
