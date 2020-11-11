﻿using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Models;
using MinaBot.DefaultActions.Views;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MinaBot.MessageResult;

namespace MinaBot.DefaultActions.Actions
{
    public class QuoteViewAction : AActionCommand
    {
        public QuoteViewAction(CommandModel command) : base(command){ }

        public override string[] Options => new[] { "pasta" };

        public override MessageResult Invoke()
        {
            using var data = new DefaultCommandContext();
            var pasta = data.GetPastaOrDefault(Command.GetOptions);
            return new PastView(pasta).GetView(Command);
        }
    }
}