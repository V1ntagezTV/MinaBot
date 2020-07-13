using Discord;
using MinaBot.BotPackValues;
using MinaBot.Controllers;
using MinaBot.Main;
using MinaBot.Models;
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
            result.AddField(new EmbedFieldBuilder()
            {
                Name = "`Шапочки:`",
                Value = new EBotHats().ToString()
            });
            result.AddField(new EmbedFieldBuilder()
            {
                Name = "`Курточки:`",
                Value = new EBotJackets().ToString()
            });
            result.AddField(new EmbedFieldBuilder()
            {
                Name = "`Штанишки:`",
                Value = new EBotPants().ToString()
            });
            result.AddField(new EmbedFieldBuilder()
            {
                Name = "`Ботиночки:`",
                Value = new EBotBoots().ToString()
            });
            return result.Build();
        }

        public Embed ConstructInfoEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = controller.GetTitle();
            result.Description = controller.GetDescription();
            return result.Build();
        }
    }
}
