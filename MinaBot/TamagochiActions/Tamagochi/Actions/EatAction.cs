using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions.Interfaces;
using MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class EatAction : APetActionCommand, IGetExperiance
    {
        public EatAction(TamagochiModel pet, CommandModel cmd) 
            : base(pet, cmd, true) { }

        public override string[] Options => new[] { "eat" };

        public override MessageResult Invoke()
        {
            var itemInd = Convert.ToInt32(Command.GetArgs[0]) - 1;
            if (Pet.Backpack.Lenght < itemInd || itemInd < 0)
                return new MessageResult.ErrorView("Item index was wrong!");

            var item = Pet.Backpack.GetItems()[itemInd];
            if (item is Meal food)
            {
                Pet.Hungry.Score += food.Satiety;
                Pet.Backpack.Remove(itemInd);
                return new MessageResult.BooleanView(true);
            }
            return new MessageResult.ErrorView("This item is not Food!");
        }

        public int GetExp() => new Random().Next(0, 50);
    }
}
