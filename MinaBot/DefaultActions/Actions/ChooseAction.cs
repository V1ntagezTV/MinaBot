using System;
using System.Linq;
using System.Runtime.InteropServices;
using MinaBot.Base;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.Main;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Actions
{
    public class ChooseAction : AActionCommand, IHelper
    {
        public ChooseAction(CommandModel command) : base(command) { }

        public override string[] Options => new[] { "goose" };
        public override MessageResult Invoke()
        {
            uint delayTimeOut = 20;
            var winnerText = "Winner";
            if (Command.GetOptions != null)
            {
                winnerText = Command.GetOptions;
            }

            if (Command.GetArgs != null)
            {
                delayTimeOut = (uint) Convert.ToInt32(Command.GetArgs[0]);
                if (delayTimeOut > 60)
                {
                    delayTimeOut = 60;
                }
            }
            return new ChooseView(winnerText, delayTimeOut);
        }

        public string Title => "m!goose [text] [time]";
        public string Description => "Choose random person who reacted to emoji" +
                                     "\nTime limit equals `60` seconds.\n" +
                                     "Default values `m!goose [Winner] [20]`";
    }
}