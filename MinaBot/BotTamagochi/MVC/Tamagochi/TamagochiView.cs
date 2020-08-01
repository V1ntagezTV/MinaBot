using Discord;
using MinaBot.BotPackValues;
using MinaBot.BotTamagochi.DataTamagochi;
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
        private EmbedBuilder embed = new EmbedBuilder();
        public TamagochiView(AuthorModel model)
        {
            controller = new TamagochiController(model);
            authorModel = model;
        }

        public EmbedBuilder ConstructMainEmbed()
        {
            var embed = new EmbedBuilder();
            embed.Title = authorModel.GetTamagochi.Name;
            embed.Description = authorModel.GetTamagochi.CurrentStatus;
            controller.UpdateStats(DateTime.Now);
            embed.Color = Color.DarkRed;
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ХАРАКТЕРИСТИКА:**",
                Value = ":heart:  **Здоровье**: " + controller.GetModel.Health.Score + " хп\n" +
                    ":meat_on_bone:  **Голод**: " + controller.GetModel.Hungry.Score + " p\n" +
                    ":sweat_drops:  **Жажда**: " + controller.GetModel.Thirsty.Score + " p\n" +
                    ":partying_face:   **Счастье**: " + controller.GetModel.Happiness.Score + " p\n",
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ОДЕЖДА:**",
                Value = "**Шляпа**: " + authorModel.GetTamagochi.Clothes.Hat.Name + "\n" +
                    "**Куртка**: " + authorModel.GetTamagochi.Clothes.Jacket.Name + "\n" +
                    "**Штаны**: " + authorModel.GetTamagochi.Clothes.Pants.Name + "\n" +
                    "**Ботинки**: " + authorModel.GetTamagochi.Clothes.Boots.Name,
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ИНВЕНТАРЬ:**",
                Value = authorModel.GetTamagochi.Backpack.ToString()
            });
            embed.Footer = new EmbedFooterBuilder()
            {
                Text = "Дата рождения: " + authorModel.GetTamagochi.Birthday.ToString()
            };
            return embed;
        }
        public EmbedBuilder ConstructInfoEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = authorModel.GetTamagochi.Name;
            result.Color = new Color(239, 245, 0); //YELLOW RGB
            return result;
        }
        public EmbedBuilder ConstructAvatarEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = authorModel.GetTamagochi.Name;
            result.Author = new EmbedAuthorBuilder()
            {
                Name = authorModel.GetMessage.Author.Username,
                IconUrl = authorModel.GetMessage.Author.GetAvatarUrl()
            };
            result.ImageUrl = authorModel.GetTamagochi.AvatarURL;
            return result;
        }
        public EmbedBuilder ConstructClothesEmbed()
        {
            embed.Color = Color.Green;
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Clothes**",
                Value = ">>> " + authorModel.GetTamagochi.Clothes.ToString(),
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Price**",
                Value = ">>> " + authorModel.GetTamagochi.Clothes.Hat.Price + "\n" + authorModel.GetTamagochi.Clothes.Jacket.Price + "\n" +
                    authorModel.GetTamagochi.Clothes.Pants.Price + "\n" + authorModel.GetTamagochi.Clothes.Boots.Price,
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**SoldPrice**",
                Value = ">>> " + authorModel.GetTamagochi.Clothes.Hat.SoldPrice + "\n" + authorModel.GetTamagochi.Clothes.Jacket.SoldPrice + "\n" +
                    authorModel.GetTamagochi.Clothes.Pants.SoldPrice + "\n" + authorModel.GetTamagochi.Clothes.Boots.SoldPrice,
                IsInline = true
            });
            return embed;
        }
        public EmbedBuilder ConstructInventoryEmbed()
        {
            embed.Color = Color.Green;
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Inventory:**",
                Value = ">>> " + authorModel.GetTamagochi.Backpack.ToString()
            });
            return embed;
        }
        public MessageResult ChooseMessageResult(CommandModel command)
        {
            switch (command.GetOptions)
            {
                case "create":
                    authorModel.GetContext.CreateTamagochi(authorModel.GetAuthor.Id);
                    return new BooleanView(true);

                case "nickname":
                    authorModel.GetTamagochi.Name = "fe";
                    return new EmbedView<Embed>(ConstructMainEmbed().Build());

                case "inventory":
                case "i":
                    controller.UpdateStats(DateTime.Now);
                    return new EmbedView<Embed>(ConstructInventoryEmbed().Build());

                case "clothes":
                case "c":
                    controller.UpdateStats(DateTime.Now);
                    return new EmbedView<Embed>(ConstructClothesEmbed().Build());

                case "info":
                    controller.UpdateStats(DateTime.Now);
                    return new EmbedView<Embed>(ConstructInfoEmbed().Build());

                case "wear":
                case "w":
                    return new BooleanView(controller.WearClothes(Convert.ToInt32(command.GetArgs[0])));

                case "sold":
                case "s":
                    return new BooleanView(controller.SoldItem(Convert.ToInt32(command.GetArgs[0])));

                case "avatar":
                case "a":
                    return new EmbedView<Embed>(ConstructAvatarEmbed().Build());

                case "eat":
                    return new BooleanView(controller.Consume(Convert.ToInt32(command.GetArgs[0])));

                case "hunting":
                    return new BooleanView(controller.SendToHunting(new TimeSpan(0, 0, 5)));

                default:
                    return new EmbedView<Embed>(ConstructMainEmbed().Build());
            }
        }
    }
}
