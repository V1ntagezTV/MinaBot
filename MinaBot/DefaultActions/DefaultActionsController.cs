using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;
using MinaBot.Base;
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
        
        public DefaultActionsController() {}

        public EmbedFieldBuilder GetInfoController()
        {
            return new EmbedFieldBuilder()
            {
                Name = "<:global:781833312742014976> General",
                Value = $"{Icons.Star} *m!<command> [arguments]*\n"
                        + string.Join(" | ", GetAllActions()
                            .Select(a => "`" + string.Join(" / ", a.Options) + "`")),
                IsInline = true
            };
        }

        public AActionCommand[] GetAllActions()
        {
            return new AActionCommand[]
            {
                new RoleNameChange(Command),
                new RoleColorChange(Command),
                new AvatarViewAction(Command),
                new QuoteViewAction(Command),
                new GetQuoteListAction(Command),
                new CreateQuoteAction(Command),
                new DeleteQuoteAction(Command),
                new AddQuestionAction(Command),
                new AnswerQuestionAction(Command),
                new DeleteQuestionAction(Command),
                new GetRandomQuestionAction(Command),
                new ChooseAction(Command), 
            };
        }

        public MessageResult GetResult()
        {
            Actions = GetAllActions();
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