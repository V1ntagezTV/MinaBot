using Discord;
using MinaBot.Controllers;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace MinaBot.Views
{
    class BotView
    {
        BotController controller;
        public BotView()
        {
            controller = new BotController(new BotModel());
        }

        public Embed CreateBotInfoEmbed(IUser author)
        {
            var result = new EmbedBuilder();
            result.Author = new EmbedAuthorBuilder()
            {
                Name=controller.GetTitle(),
                IconUrl=author.GetAvatarUrl()
            };
            result.Color = Color.DarkRed;
            result.ThumbnailUrl = controller.GetUrl();
            result.Description =
                "Статус: " + controller.GetStatus() + "\n" +
                "Уровень: " + controller.GetLevel();
            result.ImageUrl = @"https://i.imgur.com/UH85rST.png";
            result.AddField(new EmbedFieldBuilder()
            {
                Name="Характеристика:",
                Value=":heart:  **Здоровье**: " + controller.GetHealth() + " hp\n" +
                    ":clock4:  **Возраст**: " + controller.GetAge() + " days\n" +
                    ":meat_on_bone:  **Голод**: " + controller.GetHungry() + " p\n" +
                    ":sweat_drops:  **Жажда**: " + controller.GetThirsty() + " p\n",
                IsInline=true
            });
            result.AddField(new EmbedFieldBuilder()
            {
                Name="Одежда:",
                Value="**Шляпа**: "  + controller.GetHat()    + "\n" +
                    "**Куртка**: "   + controller.GetJacket() + "\n" +
                    "**Штаны**: "    + controller.GetPants()  + "\n" +
                    "**Ботинки**: "  + controller.GetBoots(),
                IsInline = true
            });
            result.AddField(new EmbedFieldBuilder()
            {
                Name = "Инвентарь:",
                Value = ":shirt::necktie::dress::bikini::one_piece_swimsuit::kimono::sari::running_shirt_with_sash::martial_arts_uniform:"
            });
            result.Footer = new EmbedFooterBuilder()
            {
                Text="Дата рождения: " + controller.GetBirthday().ToString(),
            };
            return result.Build();
        }
    }
}
