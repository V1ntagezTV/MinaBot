using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using MinaBot.Base.ActionInterfaces;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class ClothesViewAction : APetActionCommand, IHelper
    {
        public string Title => "m!pet clothes";
        public string Description => "Get info about weared items.";
        public override string[] Options => new[] { "clothes", "c" };
        
        public ClothesViewAction(TamagochiModel pet, CommandModel command)
            : base(pet, command) { }

        public override MessageResult Invoke()
        {
            return new ClothesView(Pet).GetView(Command);
        }

    }
}
