using System;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Models;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Actions.Question
{
    public class DeleteQuestionAction : AActionCommand
    {
        public DeleteQuestionAction(CommandModel command) : base(command)
        {
        }

        public override string[] Options => new[] { "delask", "dask" };
        public override MessageResult Invoke()
        {
            using var data = new DefaultCommandContext();
            var question = data.GetQuestionOrDefault(Command.GetOptions[0]);
            data.Questions.Remove(question);
            data.SaveChanges();
            return new MessageResult.BooleanView(true);
        }
    }
}