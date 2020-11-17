using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
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
        public EmbedFieldBuilder GetInfoController()
        {
            return new EmbedFieldBuilder()
            {
                Name = ":gear: General",
                Value = ":star: *m!<command> [arguments]*\n"
                        + string.Join(" | ", _GetAllActions()
                            .Select(a => "`"+string.Join(" / ",a.Options)+"`")),
                IsInline = true
            };
        }

        public CommandModel Command { get; }
        public AActionCommand[] Actions { get; set; }
        public DefaultActionsController(CommandModel cmd)
        {
            Command = cmd;
        }
        
        public DefaultActionsController() {}

        public AActionCommand[] _GetAllActions()
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
                new DeleteQuestionAction(Command),
                new GetRandomQuestionAction(Command),
            };
        }

        public MessageResult GetResult()
        {
            Actions = _GetAllActions();
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