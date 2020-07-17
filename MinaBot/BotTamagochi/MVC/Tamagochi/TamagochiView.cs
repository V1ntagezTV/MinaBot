using Discord;
using MinaBot.BotPackValues;
using MinaBot.Controllers;
using MinaBot.Main;
using MinaBot.Models;
using System;
using static MinaBot.MessageResult;

namespace MinaBot.Views
{
    class TamagochiView: IView
    {
        private TamagochiController controller;
        private AuthorModel authorModel;
        private EmbedBuilder embed;
        public TamagochiView(AuthorModel model)
        {
            this.authorModel = model;
            controller = new TamagochiController(authorModel);
        }

        public MessageResult ConstructMainEmbed()
        {
            controller.GetBackpack().Add(EBotPants.BRIEFS);
            var result = new EmbedBuilder();
            result.Author = new EmbedAuthorBuilder()
            {
                Name = controller.GetTitle(),
                IconUrl = authorModel.GetMessage.Author.GetAvatarUrl()
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
            return new EmbedView<Embed>(result.Build());
        }
        public MessageResult ConstructInfoEmbed()
        {
            throw new NotImplementedException();
        }


        public MessageResult ChooseMessageResult(CommandModel command)
        {
            switch (command.GetOptions)
            {
                case "inventory":
                case "i":
                    embed.AddField(controller.GetFieldBackpack);
                    break;
                case "clothes":
                case "c":
                    embed.AddField(controller.GetFieldClothes);
                    break;
                case "stats":
                case "s":
                    embed.AddField(controller.GetFieldStats);
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
