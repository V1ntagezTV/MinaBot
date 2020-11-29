using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Views;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinaBot.Entity;

namespace MinaBot.DefaultActions.Actions.Quote
{
    class GetQuoteListAction : AActionCommand, IHelper
    {
        public GetQuoteListAction(CommandModel command) : base(command){ }

        public override string[] Options => new[] { "pastalist" };

        public string Title => "m!pastalist";

        public string Description => "Shows your created pasta list with prefixes.";

        public override MessageResult Invoke()
        {
            using var data = new DataContext();
            var yourQuotes = data.Quotes
                .AsQueryable()
                .Where(q => q.Author.DiscordId == Command.GetMessage.Author.Id)
                .ToArray();
            
            return new PastaListView(yourQuotes).GetView(Command);
        }
    }
}
