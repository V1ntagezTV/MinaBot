using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Models;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MinaBot.MessageResult;

namespace MinaBot.DefaultActions.Actions.Quote
{
    class CreateQuoteAction : AActionCommand
    {
        public CreateQuoteAction(CommandModel command) : base(command) { }

        public override string[] Options => new[] { "addpasta", "apasta" };

        public override MessageResult Invoke()
        {
            using var data = new DefaultCommandContext();
            var pasta = new QuoteModel();

            pasta.Prefix = Command.GetOptions;
            pasta.Text = String.Join(' ', Command.GetArgs[Command.GetArgs.Length - 1]);
            pasta.Desc = String.Join(' ', Command.GetArgs[..(Command.GetArgs.Length - 1)]);
            pasta.AuthorId = (long)Command.GetMessage.Author.Id;

            data.Add(pasta);
            data.SaveChanges();
            return new BooleanView(true);
        }
    }
}
