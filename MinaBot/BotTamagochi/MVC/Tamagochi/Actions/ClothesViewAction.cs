using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class ClothesViewAction : ActionCommand
    {
        private TamagochiModel Pet;
        public ClothesViewAction(TamagochiModel pet, CommandModel command) : base(command)
        {
            this.Pet = pet;
            this.Options = new[] { "clothes", "c" };
        }
        public override MessageResult Invoke()
        {
            return new ClothesView().GetView(Pet, Command);
        }
    }
}
