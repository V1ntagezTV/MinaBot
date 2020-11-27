using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;
using MinaBot.Models;

namespace MinaBot.Main
{
    public interface IController
    {
        public AActionCommand[] GetAllActions();
        public EmbedFieldBuilder GetInfoController();
        public CommandModel Command { get; }
        public AActionCommand[] Actions { get; }
        public MessageResult GetResult();
    }
}
