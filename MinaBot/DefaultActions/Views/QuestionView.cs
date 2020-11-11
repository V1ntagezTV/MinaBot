using Discord;
using MinaBot.DefaultActions.Models;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MinaBot.MessageResult;

namespace MinaBot.DefaultActions.Views
{
    class QuestionView : IView
    {
        private QuestionModel _question;
        private string _answer;
        public QuestionView(QuestionModel question, string answerContent)
        {
            _question = question;
            _answer = answerContent;
        }

        public MessageResult GetView(CommandModel cmdModel)
        {
            return new EmbedView(GetEmbed());
        }

        public Embed GetEmbed()
        {
            //var footer = new EmbedFooterBuilder() { IconUrl = paste.Author.GetAvatarUrl(), Text = paste.Author.ToString() };
            var embed = new EmbedBuilder()
            {
                Title = $"**{_question.Id}#Question**",
                Color = new Color((uint)Convert.ToInt32("f47e17", 16)),
                Description = $"**Q:** {_question.Content}\n**A:** {_answer}"
            };
            return embed.Build();
        }
    }
}
