using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.Main;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.DefaultActions
{
    public class DefaultActionsController : IController
    {
        public AActionCommand[] Actions => throw new NotImplementedException();

        public MessageResult GetResult()
        {
            throw new NotImplementedException();
        }
    }
}