﻿using System;
using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Models;
using MinaBot.Entity;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Actions.Question
{
    public class DeleteQuestionAction : AActionCommand, IHelper
    {
        public string Title => "m!delask <ask-id>";
        public string Description => "Delete your question.";
        public override string[] Options => new[] { "delask", "dask" };
        
        public DeleteQuestionAction(CommandModel command) : base(command) { }
        
        public override MessageResult Invoke()
        {
            using var data = new DataContext();
            var question = data.GetQuestionOrDefault(Convert.ToInt32(Command.GetOptions));
            data.Questions.Remove(question);
            data.SaveChanges();
            return new MessageResult.BooleanView(true);
        }
    }
}