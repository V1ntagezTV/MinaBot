﻿using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.MVC_Main;
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
