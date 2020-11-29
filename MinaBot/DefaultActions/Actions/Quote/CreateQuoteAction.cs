using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Models;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Discord;
using Microsoft.EntityFrameworkCore;
using MinaBot.Base.ActionInterfaces;
using MinaBot.Entity;
using static MinaBot.MessageResult;

namespace MinaBot.DefaultActions.Actions.Quote
{
    class CreateQuoteAction : AActionCommand, IHelper
    {
        public string Title => "**m!addpasta <prefix> <content> [imageLink]**";
        public string Description =>
            "Create quote with text or image or together and call it with prefix.\nExample:\nm!pasta <prefix>";
        public override string[] Options => new[] { "addpasta" };
        
        public CreateQuoteAction(CommandModel command) : base(command) { }
        
        public override MessageResult Invoke()
        {
            using var data = new DataContext();
            if (!(Command.GetMessage.Channel is ITextChannel)) { return new BooleanView(false); }
            
            using var data = new DataContext();
            var author = data.GetUserOrNew(Command.GetMessage.Author.Id);
            var text = string.Join(' ', Command.GetArgs);
            var pasta = new QuoteModel()
            {
                Prefix = Command.GetOptions,
                Author = author,
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
