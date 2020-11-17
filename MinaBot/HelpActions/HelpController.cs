using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.Controllers;
using MinaBot.DefaultActions;
using MinaBot.Main;
using MinaBot.Models;

namespace MinaBot.HelpActions
{
    public class HelpController : IController
    {
        public HelpController(CommandModel cmd)
        {
            Command = cmd;
        }
        
        public IController[] Controllers = new IController[]
        {
            new DefaultActionsController(),
            new TamagochiController(),
        };
        public AActionCommand[] _GetAllActions()
        {
            var result = new List<AActionCommand>();
            for (var ind = 0; ind < Controllers.Length; ind++)
            {
                result.AddRange(Controllers[ind]._GetAllActions());
            }
            return result.ToArray();
        }

        public EmbedFieldBuilder GetInfoController()
        {
            throw new NotImplementedException();
        }

        public CommandModel Command { get; }
        public AActionCommand[] Actions { get; }
        public MessageResult GetResult()
        {
            if (Command.GetOptions == null)
            {
                return new HelpView(Controllers).GetView(Command);
            }
            else
            {
                var act = _GetAllActions().FirstOrDefault(act=> act.Options.Contains(Command.GetOptions));
                if (act is IHelper actHelper)
                {
                    return new ActionHelpView(actHelper).GetView(Command);
                }
                return new MessageResult.EmptyView();
            }
        }
    }
}