using System;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Models;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Actions.Question
{
    public class AddQuestionAction : AActionCommand
    {
        public AddQuestionAction(CommandModel command) : base(command) { }

        public override string[] Options => new[] {"ask"};
        public override MessageResult Invoke()
        {
            using var data = new DefaultCommandContext();
            var question = new QuestionModel()
            {
                AuthorId = (long)Command.GetMessage.Author.Id,
                Content = String.Join(" ", Command.GetMessage.Content.Split()[1..]),
                ChannelId = (long)Command.GetMessage.Channel.Id
            };
            Console.WriteLine(question.ChannelId);
            data.Questions.Add(question);
            data.SaveChanges();
            return new MessageResult.BooleanView(true);
        }
    }
}