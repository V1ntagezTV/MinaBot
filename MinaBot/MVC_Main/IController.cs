using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Main
{
    public interface IController
    {
        public AActionCommand[] Actions { get; }
        public MessageResult GetResult();

        // TODO: Сделать helper страницы для каждого контроллера.
        //      public MessageResult GetLongHelper();
        //      public MessageResult GetShortHelper();
    }
}
