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
        EmbedBuilder embed;
        public ShopView(AuthorModel command)
        {
            this.model = command;
        }
        ShopController controller = new ShopController(new ShopModel());
        public IController GetController 
        { 
            get => (IController)controller;
            set => controller = (ShopController)value;
        }

        public MessageResult ConstructMainEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = controller.GetTitle();
            result.Description = controller.GetDescription();
            result.Color = (Color?)SystemColor.Yellow;
            return new EmbedView<Embed>(result.Build());
        }

        public MessageResult ConstructInfoEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = controller.GetTitle();
            result.Description = controller.GetDescription();
            return new EmbedView<Embed>(result.Build());
        }
        public MessageResult ChooseMessageResult(CommandModel command)
        {
            switch (command.GetOptions)
            {
                case "boots":
                case "b":
                    embed.AddField(
                        new EmbedFieldBuilder() 
                        { 
                            Name = "Boots:", 
                            Value = new EBotBoots().ToStringWithPrices() 
                        });
                    break;
                case "hat":
                case "h":
                case "hats":
                    embed.AddField(new EmbedFieldBuilder()
                    {
                        Name = "`Hats:`",
                        Value = new EBotHats().ToString()
                    });
                    break;
                case "j":
                case "jackets":
                case "jacket":
                    embed.AddField(new EmbedFieldBuilder()
                    {
                        Name = "`Jackets:`",
                        Value = new EBotJackets().ToString()
                    });
                    break;
                case "pants":
                case "p":
                    embed.AddField(new EmbedFieldBuilder()
                    {
                        Name = "`Jackets:`",
                        Value = new EBotJackets().ToString()
                    });
                        break;
                    case "info":
                        return ConstructInfoEmbed();
                    default:
                        return ConstructMainEmbed();
            }
            return new EmbedView<Embed>(embed.Build());
        }

}
}
