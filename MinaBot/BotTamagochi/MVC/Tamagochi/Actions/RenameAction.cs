using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    public class RenameAction : ActionCommand
    {
        private TamagochiModel Pet;
        public RenameAction(TamagochiModel pet, CommandModel command) : base(command) 
        {
            this.Pet = pet;
            this.Options = new[] { "name", "rename" };
        }

        public override MessageResult Invoke()
        {
            var newName = Command.GetArgs[0];
            if (newName.Length <= 10)
            {
                Pet.Name = newName;
                return new BooleanView(true);
            }
            return new ErrorView("Max name length is 10!");
        }
    }
}
