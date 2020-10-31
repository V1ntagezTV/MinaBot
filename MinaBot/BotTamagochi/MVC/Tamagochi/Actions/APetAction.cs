using System;
using System.Collections.Generic;
using System.Text;
using MinaBot.Controllers;
using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    abstract class APetAction : ActionCommand
    {
        protected TamagochiModel Pet;
        protected APetAction(TamagochiModel pet, CommandModel command) : base(command)
        {
            this.Pet = pet;
        }
    }
}
