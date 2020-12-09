using System;
using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.Main;
using MinaBot.Models;

namespace MinaBot.HelpActions
{
    public class ActionHelpView : IView
    {
        private IHelper Act;
        public ActionHelpView(IHelper act)
        {
            Act = act;
        }
        public MessageResult GetView(CommandModel cmdModel)
        {
            return new MessageResult.EmbedView(_ConstructEmbed(cmdModel));
        }

        private Embed _ConstructEmbed(CommandModel cmdModel)
        {
            var embed = new EmbedBuilder()
            {
                Title = cmdModel.GetOptions,
                Author = new EmbedAuthorBuilder()
                {
                    Name = "Penguin", 
                    IconUrl = Program.client.Rest.CurrentUser.GetAvatarUrl()
                },
                Description = $"{Act.Description}\n*Example:*```fix\n{Act.Title}```",
                Color = new Color((uint)Convert.ToInt32("f47e17", 16)),
                Footer = new EmbedFooterBuilder()
                {
                    IconUrl = cmdModel.GetMessage.Author.GetAvatarUrl(), 
                    Text = cmdModel.GetMessage.Author.Username+" | "+DateTime.Now.ToShortTimeString()
                }
            };
            return embed.Build();
        }
    }
}