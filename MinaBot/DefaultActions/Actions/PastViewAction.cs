using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Models;
using MinaBot.DefaultActions.Views;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MinaBot.MessageResult;

namespace MinaBot.DefaultActions.Actions
{
    public class PastViewAction : AActionCommand
    {
        public PastViewAction(CommandModel command) : base(command){ }

        public override string[] Options => new[] { "paste" };

        public override MessageResult Invoke()
        {
            return new PastView(new PasteModel() { Prefix="fe"}).GetView(Command);
        }
    }
}
