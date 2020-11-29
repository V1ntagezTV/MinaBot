using System;
using Discord;
using Microsoft.EntityFrameworkCore.Internal;
using MinaBot.DefaultActions.Models;
using MinaBot.Main;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Views
{
    public class QuestionView : IView
    {
        private QuestionModel _question;

        public QuestionView(QuestionModel question)
        {
            _question = question;
        }
        
        public MessageResult GetView(CommandModel cmdModel)
        {
            return new MessageResult.EmbedView(GetEmbed());
        }

        public Embed GetEmbed()
        {
            var author = Program.client.GetUser((ulong) _question.Author.DiscordId);
            var footer = new EmbedFooterBuilder() {IconUrl = author.GetAvatarUrl(), Text = $"asked by {author.Username}"};
            var builder = new EmbedBuilder()
            {
                Title = $"**Question#{_question.Id}**",
                Color = new Color((uint)Convert.ToInt32("f47e17", 16)),
                Description = $"{_question.Content}",
                Footer = footer
            };
            return builder.Build();
        }
    }
}