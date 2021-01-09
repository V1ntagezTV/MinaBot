using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions.Interfaces;
using MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class EatAction : APetActionCommand, IGetExperiance, IHelper
    {
        public string Title => "m!pet eat <item-index>";
        public string Description => "Feed your pet with water and meal.\nItem index from your invetory (1-10).";
        public override string[] Options => new[] { "eat" };
        
        public EatAction(TamagochiModel pet, CommandModel cmd) 
            : base(pet, cmd, true) { }
        
        public override MessageResult Invoke()
        {
            var itemInd = Convert.ToInt32(Command.GetArgs[0]) - 1;
            if (Pet.Backpack.Lenght < itemInd || itemInd < 0)
                return new MessageResult.ErrorView("Item index was wrong!");

            var item = Pet.Backpack.GetItems()[itemInd];
            if (item is Meal meal)
            {
                Pet.Hungry.Score += meal.Satiety;
                Pet.Backpack.Remove(itemInd);
                return new MessageResult.BooleanView(true);
            }
            else if (item is Liquid beverage)
            {
                Pet.Thirsty.Score += beverage.Satiety;
                Pet.Backpack.Remove(itemInd);
                return new MessageResult.BooleanView(true);
            }
            return new MessageResult.ErrorView("This item is not Food!");
        }

        public int GetExp() => new Random().Next(0, 50);
    }
}
