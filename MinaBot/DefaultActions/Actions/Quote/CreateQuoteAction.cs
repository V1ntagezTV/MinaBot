using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Models;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using Discord;
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
            if (!(Command.GetMessage.Channel is ITextChannel)) { return new BooleanView(false); }

            var text = string.Join(' ', Command.GetArgs);
            var pasta = new QuoteModel()
            {
                Prefix = Command.GetOptions,
                AuthorId = (long)Command.GetMessage.Author.Id,
            };
            var lastWord = Command.GetArgs[Command.GetArgs.Length - 1];
            if (lastWord.StartsWith("https://") || lastWord.StartsWith("http://"))
            {
                pasta.Text = lastWord;
                pasta.Desc = string.Join(' ', Command.GetArgs[..(Command.GetArgs.Length-1)]);
            }
            else
            {
                pasta.Text = text;
            }
            data.Add(pasta);
            data.SaveChanges();
            return new BooleanView(true);
        }
    }
}
