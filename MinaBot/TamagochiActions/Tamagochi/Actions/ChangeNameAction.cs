using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class ChangeNameAction : APetActionCommand
    {
        public ChangeNameAction(TamagochiModel pet, CommandModel command)
            : base(pet, command, true) { }

        public override string[] Options => new[] { "name", "rename" };

        public override MessageResult Invoke()
        {
            var newName = Strings.Join(Command.GetArgs, " ");
            if (newName.Length <= 10)
            {
                Pet.Name = newName;
                return new BooleanView(true);
            }
            return new ErrorView("Max name length is 10!");
        }
    }
}
