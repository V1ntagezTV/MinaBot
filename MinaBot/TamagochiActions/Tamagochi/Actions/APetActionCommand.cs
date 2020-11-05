using System;
using System.Collections.Generic;
using System.Text;
using MinaBot.Controllers;
using MinaBot.Models;
#nullable enable
namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    public abstract class APetActionCommand : AActionCommand
    {
        protected TamagochiModel Pet;
        public readonly bool NeedToSaveInData;
        protected APetActionCommand(TamagochiModel pet, CommandModel command, bool needToSaveInData = false) 
            : base(command)
        {
            this.Pet = pet;
            NeedToSaveInData = needToSaveInData;
        }
    }
}
