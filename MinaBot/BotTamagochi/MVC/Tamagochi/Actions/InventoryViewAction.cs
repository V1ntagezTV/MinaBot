﻿using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    public class InventoryViewAction : APetActionCommand
    {
        public InventoryViewAction(TamagochiModel pet, CommandModel command)
            : base(pet, command)
        {
            this.Options = new[] { "inventory", "i" };
        }

        public override MessageResult Invoke()
        {
            return new InventoryView().GetView(Pet, Command);
        }
    }
}