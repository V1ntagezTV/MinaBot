using Discord;
using MinaBot.DefaultActions.Models;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Discord.WebSocket;
using static MinaBot.MessageResult;

namespace MinaBot.DefaultActions.Views
{
    class AnswerToQuestionView : IView
    {
        private QuestionModel _question;
        private string _answer;
        public AnswerToQuestionView(QuestionModel question, string answerContent)
        {
            _question = question;
            _answer = answerContent;
        }

        public MessageResult GetView(CommandModel cmdModel)
        {
            return new EmbedView(GetEmbed(Program.client.GetUser((ulong) _question.AuthorId)));
        }

        public Embed GetEmbed(SocketUser author)
        {
            var footer = new EmbedFooterBuilder() 
            {
                IconUrl = author.GetAvatarUrl(),
                Text = $"answered by {author.Username}"
            };
            var embed = new EmbedBuilder()
            {
                Title = $"**Question#{_question.Id}**",
                Color = new Color((uint)Convert.ToInt32("f47e17", 16)),
                Description = $":grey_question: {_question.Content}\n:incoming_envelope: {_answer}",
                Footer = footer
            };
            return embed.Build();
        }
    }
}
