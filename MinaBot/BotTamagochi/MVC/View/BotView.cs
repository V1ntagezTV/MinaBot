using Discord;
using MinaBot.BotPackValues;
using MinaBot.Controllers;
using MinaBot.Interfaces;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;


namespace MinaBot.Views
{
    class BotView: IView
    {
        private BotController controller;
        private IMessage message;
        public BotView(IMessage mess, CommandModel command)
        {
            message = mess;
            controller = new BotController(new BotModel());
        }

        IController IView.GetController 
        {
            get => controller;
            set => controller = (BotController)value;
        }

        public Embed ConstructMainEmbed()
        {
            controller.GetBackpack().Add(EBotPants.BRIEFS);
            var result = new EmbedBuilder();
            result.Author = new EmbedAuthorBuilder()
            {
                Name = controller.GetTitle(),
                IconUrl = message.Author.GetAvatarUrl()
            };
            result.Color = Color.DarkRed;
            result.ThumbnailUrl = controller.GetUrl();
            result.Description =
                "Статус: " + controller.GetStatus() + "\n" +
                "Уровень: " + controller.GetLevel() + "\n" +
                "Деньги: " + controller.getMoney();
            result.ImageUrl = @"https://i.imgur.com/UH85rST.png";
            result.AddField(new EmbedFieldBuilder()
            {
                Name = "`Характеристика:`",
                Value = ":heart:  **Здоровье**: " + controller.GetHealth() + " hp\n" +
                    ":clock4:  **Возраст**: " + controller.GetAge() + " days\n" +
                    ":meat_on_bone:  **Голод**: " + controller.GetHungry() + " p\n" +
                    ":sweat_drops:  **Жажда**: " + controller.GetThirsty() + " p\n",
                IsInline = true
            });
            result.AddField(new EmbedFieldBuilder()
            {
                Name = "`Одежда:`",
                Value = "**Шляпа**: " + controller.GetClothes().Hat.Name + "\n" +
                    "**Куртка**: " + controller.GetClothes().Jacket.Name + "\n" +
                    "**Штаны**: " + controller.GetClothes().Pants.Name + "\n" +
                    "**Ботинки**: " + controller.GetClothes().Boots.Name,
                IsInline = true
            });
            result.AddField(new EmbedFieldBuilder()
            {
                Name = "`Инвентарь:`",
                Value = controller.GetBackpack().ToString()
            });
            result.Footer = new EmbedFooterBuilder()
            {
                Text = "Дата рождения: " + controller.GetBirthday().ToString()
            };
            return result.Build();
        }

        public Embed ConstructInfoEmbed()
        {
            throw new NotImplementedException();
        }
    }
}
