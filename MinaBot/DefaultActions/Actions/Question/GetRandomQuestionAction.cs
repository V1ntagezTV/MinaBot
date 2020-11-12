using System;
using System.Linq;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Views;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Actions.Question
{
    public class GetRandomQuestionAction : AActionCommand
    {
        private readonly Random rnd = new Random();
        public GetRandomQuestionAction(CommandModel command) : base(command) { }

        public override string[] Options => new[] {"getask", "getask"};
        public override MessageResult Invoke()
        {
            using var data = new DefaultCommandContext();
            var count = data.Questions.Count();
            var rndQ = data.Questions.AsQueryable().Skip(rnd.Next(1, count)).Take(1);
            return new QuestionView(rndQ.First()).GetView(Command);
        }
    }
}