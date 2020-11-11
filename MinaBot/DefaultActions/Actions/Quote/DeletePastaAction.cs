using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Views;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MinaBot.MessageResult;

namespace MinaBot.DefaultActions.Actions.Quote
{
    class DeletePastaAction : AActionCommand
    {
        public DeletePastaAction(CommandModel command) : base(command)
        {
        }

        public override string[] Options => new[] { "delpasta" };

        public override MessageResult Invoke()
        {
            using var data = new PastaContext();
            var pasta = data.GetPastaOrDefault(Command.GetOptions);
            data.Quotes.Remove(pasta);
            data.SaveChanges();
            return new BooleanView(true);
        }
    }
}
