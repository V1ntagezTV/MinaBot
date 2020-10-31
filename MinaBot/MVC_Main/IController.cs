using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Main
{
    interface IController<T>
    {
        public  ActionCommand[] commands { get; }
    }
}
