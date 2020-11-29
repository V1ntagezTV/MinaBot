using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Views;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.Entity;
using static MinaBot.MessageResult;

namespace MinaBot.DefaultActions.Actions.Quote
{
    class DeleteQuoteAction : AActionCommand, IHelper
    {
        public string Title => "**m!delpasta <pasta-prefix>**";
        public string Description => "Remove your pasta.";
        public override string[] Options => new[] { "delpasta"};
        
        public DeleteQuoteAction(CommandModel command) : base(command) { }

        public override MessageResult Invoke()
        {
            using var data = new DataContext();
            var pasta = data.GetPastaOrDefault(Command.GetOptions);
            data.Quotes.Remove(pasta);
            data.SaveChanges();
            return new BooleanView(true);
        }

       
    }
}
