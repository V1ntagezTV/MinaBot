﻿using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;
using MinaBot.DefaultActions.Actions;
using MinaBot.Models;
using MinaBot.DefaultActions.Actions.Quote;
using MinaBot.DefaultActions.Actions.Question;

namespace MinaBot.DefaultActions
{
    public class DefaultActionsController : IController
    {
        public CommandModel Command { get; }
        public AActionCommand[] Actions { get; set; }
        public DefaultActionsController(CommandModel cmd)
        {
            Command = cmd;
        }

        private AActionCommand[] _GetAllDefaultActions()
        {
            return new AActionCommand[]
            {
                new RoleNameChange(Command),
                new RoleColorChange(Command),
                new AvatarViewAction(Command),
                new QuoteViewAction(Command),
                new CreateQuoteAction(Command),
                new DeleteQuoteAction(Command),
                new AddQuestionAction(Command),
                new AnswerQuestionAction(Command),
                new DeleteQuestionAction(Command)
            };
        }

        public MessageResult GetResult()
        {
            Actions = _GetAllDefaultActions();
            for (int ind = 0; ind < Actions.Length; ind++)
            {
                if (Actions[ind].Options.Contains(Command.GetPrefix))
                {
                    return Actions[ind].Invoke();
                }
            }
            return new MessageResult.EmptyView();
        }
    }
}