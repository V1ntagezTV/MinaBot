using System;
using Discord;
using MinaBot.Main;
using MinaBot.Models;

namespace MinaBot.HelpActions
{
    public class HelpView : IView
    {
        private IController[] Controllers;
        public HelpView(IController[] controllers)
        {
            Controllers = controllers;
        }
        public MessageResult GetView(CommandModel cmdModel)
        {
            var creator = Program.client.GetUser(236546146477146121);
            var embed = new EmbedBuilder()
            {
                Author = new EmbedAuthorBuilder()
                {
                    Name = Program.client.Rest.CurrentUser.Username, 
                    IconUrl = Program.client.Rest.CurrentUser.GetAvatarUrl()
                },
                Description = "Use m!help <command> to get more information about command.",
                Footer = new EmbedFooterBuilder()
                {
                    IconUrl = creator.GetAvatarUrl(),
                    Text = $"Dev: {creator} | All rights reserved."
                },
                Color = new Color((uint)Convert.ToInt32("f47e17", 16))
            };
            for (int ind = 0; ind < Controllers.Length; ind++)
            {
                embed.AddField(Controllers[ind].GetInfoController());
            }
            return new MessageResult.EmbedView(embed.Build());
        }
    }
}