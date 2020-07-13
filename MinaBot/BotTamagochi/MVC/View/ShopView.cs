using Discord;
using MinaBot.BotPackValues;
using MinaBot.Controllers;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using SystemColor = System.Drawing.Color;

namespace MinaBot.Views
{
    class ShopView: IView
    {
        CommandModel command;
        public ShopView(CommandModel command)
        {
            this.command = command;
        }
        ShopController controller = new ShopController(new ShopModel());
        public IController GetController 
        { 
            get => (IController)controller;
            set => controller = (ShopController)value;
        }

        public Embed ConstructMainEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = controller.GetTitle();
            result.Description = controller.GetDescription();
            result.Color = (Discord.Color?)SystemColor.Yellow;
            var fields = this.CommandFieldSettings(command.Options);
            for (int ind = 0; ind < fields.Length - 1; ind++ )
            {
                result.AddField(fields[ind]);
            }
            return result.Build();
        }

        public Embed ConstructInfoEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = controller.GetTitle();
            result.Description = controller.GetDescription();
            return result.Build();
        }

        public EmbedFieldBuilder[] CommandFieldSettings(string[] commandOptions)
        {
            var result = new List<EmbedFieldBuilder>();
            for (int ind = 0; ind < commandOptions.Length; ind++)
            {
                switch (commandOptions[ind])
                {
                    case "boots":
                    case "b":
                        result.Add(
                            new EmbedFieldBuilder()
                            {
                                Name = "`Ботиночки:`",
                                Value = new EBotBoots().ToString()
                            });
                        break;

                    case "hat":
                    case "h":
                    case "hats":
                        result.Add(
                            new EmbedFieldBuilder()
                            {
                                Name = "`Шапочки:`",
                                Value = new EBotHats().ToString()
                            });
                        break;

                    case "j":
                    case "jackets":
                    case "jacket":
                        result.Add(
                            new EmbedFieldBuilder()
                            {
                                Name = "`Курточки:`",
                                Value = new EBotJackets().ToString()
                            });
                        break;

                    case "pants":
                    case "p":
                        result.Add(
                            new EmbedFieldBuilder()
                            {
                                Name = "`Штанишки:`",
                                Value = new EBotPants().ToString()
                            });
                        break;
                    default:
                        break;
                }
            }
            return result.ToArray();
        }
    }
}
