using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Microsoft.VisualBasic;
using MinaBot.Base.ActionInterfaces;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class ChangeNameAction : APetActionCommand, IHelper
    {
        public string Title => "**m!pet name <new_name>**";
        public string Description => "Answer to random questions to real people in other servers.";
        public override string[] Options => new[] { "name" };
        
        public ChangeNameAction(TamagochiModel pet, CommandModel command)
            : base(pet, command, true) { }
        
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
