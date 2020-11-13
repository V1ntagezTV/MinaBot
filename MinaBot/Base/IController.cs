using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using System;
using System.Collections.Generic;
using System.Text;
using MinaBot.Models;

namespace MinaBot.Main
{
    public interface IController
    {
        public CommandModel Command { get; }
        public AActionCommand[] Actions { get; }
        public MessageResult GetResult();

        // TODO: Сделать helper страницы для каждого контроллера.
        //      public MessageResult GetLongHelper();
        //      public MessageResult GetShortHelper();
    }
}
