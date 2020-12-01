using System;
using System.Linq;
using Discord;
using MinaBot.DefaultActions;
using MinaBot.DefaultActions.Actions.Question;
using MinaBot.Main;
using MinaBot.Models;

namespace MinaBot.HelpActions
{
    public class HelpView : IView
    {
        private const string InviteLink = @"https://discord.com/api/oauth2/authorize?client_id=566896476756639744&permissions=0&scope=bot";
        private const string ServerLink = @"https://discord.gg/ghGMV6n";
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
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = ":link: **Links**",
                Value = $"[`Bot invite`]({InviteLink})\n" +
                        $"[`Server invite]({ServerLink})",
            });
            for (var ind = 0; ind < Controllers.Length; ind++)
            {
                embed.AddField(Controllers[ind].GetInfoController());
                if (ind % 2 == 1 && ind != Controllers.Length - 1)
                {
                    embed.AddField(new EmbedFieldBuilder() {Name = $"-", Value = "-"});
                }
            }
            return new MessageResult.EmbedView(embed.Build());
        }
    }
}