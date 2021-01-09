using System;
using System.Linq;
using Discord;
using Microsoft.EntityFrameworkCore;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Views;
using MinaBot.Entity;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Actions.Question
{
    public class GetRandomQuestionAction : AActionCommand, IHelper
    {
        public string Title => "m!getask";
        public string Description => "Get random questions.";
        public override string[] Options => new[] {"getask"};
        
        private readonly Random rnd = new Random();
        
        public GetRandomQuestionAction(CommandModel command) : base(command) { }
        
        public override MessageResult Invoke()
        {
            using var data = new DataContext();
            var count = data.Questions.Count();
            var rndQ = data.Questions
                .Include(q => q.Author)
                .Skip(rnd.Next(0, count))
                .Take(1);
            return new QuestionView(rndQ.First()).GetView(Command);
        }
    }
}