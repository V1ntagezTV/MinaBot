using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using Discord;
using Microsoft.EntityFrameworkCore;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Models;
using MinaBot.Entity;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Actions.Question
{
    public class AddQuestionAction : AActionCommand, IHelper
    {
        public AddQuestionAction(CommandModel command) : base(command) { }

        public override string[] Options => new[] {"ask"};

        public override MessageResult Invoke()
        {
            using var context = new DataContext();
            var author = context.Users
                .Include(u => u.Questions)
                .FirstOrDefault(u => u.DiscordId == Command.GetMessage.Author.Id);
            
            if (author == null)
            {
                author = new User()
                {
                    DiscordId = Command.GetMessage.Author.Id,
                    Questions = new List<QuestionModel>(),
                };
                context.Add(author);
            }
            
            var question = new QuestionModel()
            {
                Author = author,
                Content = string.Join(" ", Command.GetMessage.Content.Split()[1..]),
                ChannelId = (long)Command.GetMessage.Channel.Id
            };
            author.Questions.Add(question);
            context.SaveChanges();
            return new MessageResult.BooleanView(true);
        }

        public string Title =>  "**m!ask <question>**";
        public string Description => "Ask and get random answer from any servers and people.";
    }
}