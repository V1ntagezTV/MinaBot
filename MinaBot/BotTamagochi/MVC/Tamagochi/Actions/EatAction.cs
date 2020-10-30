using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class EatAction : ActionCommand
    {
        private TamagochiModel Pet;
        public EatAction(TamagochiModel pet, CommandModel cmd) : base(cmd)
        {
            this.Pet = pet;
            this.Options = new[] { "eat" };
        }
        public override MessageResult Invoke()
        {
            
        }
    }
}
