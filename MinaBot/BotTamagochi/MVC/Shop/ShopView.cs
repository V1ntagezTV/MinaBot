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
    class ShopView
    {
        AuthorModel model;
        ShopController controller;
        EmbedBuilder embed = new EmbedBuilder();
        CommandModel command;
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
        public EmbedBuilder ConstructHatsEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = controller.GetTitle();
            result.Description = controller.GetDescription();
            result.AddField(new EmbedFieldBuilder()
            {
                Name = "**Hats:**",
                Value = new EBotHats().ToStringInLine(),
                IsInline = true
            });
            result.AddField(new EmbedFieldBuilder()
            {
                Name = "**Prices**",
                Value = new EBotHats().ToStringPricesInLine(),
                IsInline = true
            });
            return result;
        }
        public MessageResult ChooseMessageResult()
        {
            switch (command.GetOptions)
            {
                case "buy":
                    return new BooleanView(controller.BuyItem(command.GetArgs[0], Convert.ToInt32(command.GetArgs[1])));

                case "boots":
                case "b":
                    embed.AddField(new EmbedFieldBuilder()
                    {
                        Name = "**`Boots:`**",
                        Value = new EBotBoots().ToStringWithPriceInLine()
                    });
                    break;

                case "hat":
                case "h":
                case "hats":
                    return new EmbedView<Embed>(ConstructHatsEmbed().Build());

                case "j":
                case "jackets":
                case "jacket":
                    embed.AddField(new EmbedFieldBuilder()
                    {
                        Name = "**`Jackets:`**",
                        Value = new EBotJackets().ToStringWithPriceInLine()
                    });
                    break;

                case "pants":
                case "p":
                    embed.AddField(new EmbedFieldBuilder()
                    {
                        Name = "**`Pants:`**",
                        Value = new EBotPants().ToStringWithPriceInLine()
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
