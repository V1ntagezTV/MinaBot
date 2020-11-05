using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    public class ChangeStatusAction : APetActionCommand
    {
        public ChangeStatusAction(TamagochiModel pet, CommandModel command)
            : base(pet, command, true) { }

        public override string[] Options => new[] { "status", "s" };
        public override MessageResult Invoke()
        {
            var newStatus = string.Join(" ", Command.GetArgs);
            if (newStatus.Length >= 20)
            {
                return new MessageResult.ErrorView("Max status length equals 20.");
            }
            Pet.CurrentStatus = newStatus;
            return new MessageResult.BooleanView(true);
        }
    }
}