using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class ClothesViewAction : APetActionCommand
    {
        public ClothesViewAction(TamagochiModel pet, CommandModel command)
            : base(pet, command) { }

        public override string[] Options => new[] { "clothes", "c" };

        public override MessageResult Invoke()
        {
            return new ClothesView().GetView(Pet, Command);
        }
    }
}
