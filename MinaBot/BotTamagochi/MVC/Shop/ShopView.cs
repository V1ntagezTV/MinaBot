using Discord;
using MinaBot.BotPackValues;
using MinaBot.Controllers;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using static MinaBot.MessageResult;
using SystemColor = System.Drawing.Color;

namespace MinaBot.Views
{
    class ShopView: IView
    {
        AuthorModel model;
        ShopController controller;
        EmbedBuilder embed = new EmbedBuilder();
        public ShopView(AuthorModel model)
        {
            this.model = model;
            controller = new ShopController(model);
        }


        public EmbedBuilder ConstructMainEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = controller.GetTitle();
            result.Description = controller.GetDescription();
            result.Color = (Color?)SystemColor.Yellow;
            return result;
        }
        public EmbedBuilder ConstructInfoEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = controller.GetTitle();
            result.Description = controller.GetDescription();
            return result;
        }
        public MessageResult ChooseMessageResult(CommandModel command)
        {
            switch (command.GetOptions)
            {
                case "buy":
                    new BooleanView(controller.BuyItem(command.GetArgs[0], Convert.ToInt32(command.GetArgs[1])));
                    break;
                case "boots":
                case "b":
                    embed.AddField(new EmbedFieldBuilder()
                    {
                        Name = "Boots:",
                        Value = new EBotBoots().ToStringInLine()
                    });
                    break;
                case "hat":
                case "h":
                case "hats":
                    embed.AddField(new EmbedFieldBuilder()
                    {
                        Name = "`Hats:`",
                        Value = new EBotHats().ToStringInLine()
                    });
                    break;
                case "j":
                case "jackets":
                case "jacket":
                    embed.AddField(new EmbedFieldBuilder()
                    {
                        Name = "`Jackets:`",
                        Value = new EBotJackets().ToStringInLine()
                    });
                    break;
                case "pants":
                case "p":
                    embed.AddField(new EmbedFieldBuilder()
                    {
                        Name = "`Pants:`",
                        Value = new EBotPants().ToStringInLine()
                    });
                    break;
                case "info":
                    return new EmbedView<Embed>(ConstructInfoEmbed().Build());
                default:
                    return new EmbedView<Embed>(ConstructMainEmbed().Build());
            }
            return new EmbedView<Embed>(embed.Build());
        }

    }
}
