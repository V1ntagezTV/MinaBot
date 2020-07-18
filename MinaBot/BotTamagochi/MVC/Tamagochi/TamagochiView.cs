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
        private EmbedBuilder embed = new EmbedBuilder();
        public TamagochiView(AuthorModel model)
        {
            this.authorModel = model;
            controller = new TamagochiController(model);
            embed.Title = "**Nickname**";
            embed.Description =
                "**Статус:** " + controller.GetStatus() + "\n" +
                "**Уровень:** " + controller.GetLevel() + "\n" +
                "**Деньги:** " + controller.GetMoney();
            embed.ThumbnailUrl = controller.GetUrl();
        }

        public EmbedBuilder ConstructMainEmbed()
        {
            /***delete after***/
            controller.GetBackpack().Add(EBotPants.BRIEFS);
            /***delete after***/
            embed.Color = Color.DarkRed;

            embed.ImageUrl = @"https://i.imgur.com/UH85rST.png";
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "`Характеристика:`",
                Value = ":heart:  **Здоровье**: " + controller.GetHealth() + " hp\n" +
                    ":clock4:  **Возраст**: " + controller.GetAge() + " days\n" +
                    ":meat_on_bone:  **Голод**: " + controller.GetHungry() + " p\n" +
                    ":sweat_drops:  **Жажда**: " + controller.GetThirsty() + " p\n",
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "`Одежда:`",
                Value = "**Шляпа**: " + controller.GetClothes().Hat.Name + "\n" +
                    "**Куртка**: " + controller.GetClothes().Jacket.Name + "\n" +
                    "**Штаны**: " + controller.GetClothes().Pants.Name + "\n" +
                    "**Ботинки**: " + controller.GetClothes().Boots.Name,
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "`Инвентарь:`",
                Value = controller.GetBackpack().ToString()
            });
            embed.Footer = new EmbedFooterBuilder()
            {
                Text = "Дата рождения: " + controller.GetBirthday().ToString()
            };
            return embed;
        }
        public EmbedBuilder ConstructInfoEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = authorModel.GetTamagochi.name;
            result.Color = new Color(239, 245, 0); //YELLOW RGB
            return result;
        }
        public EmbedBuilder ConstructAvatarEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = controller.GetName();
            result.Author = new EmbedAuthorBuilder()
            {
                Name = authorModel.GetMessage.Author.Username,
                IconUrl = authorModel.GetMessage.Author.GetAvatarUrl()
            };
            result.ImageUrl = authorModel.GetTamagochi.avatarUrl;
            return result;
        }
        public EmbedBuilder ConstructClothesEmbed()
        {
            var clothes = controller.GetClothes();
            embed.Color = Color.Green;
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Clothes**",
                Value = ">>> " + clothes.ToString(),
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Price**",
                Value = ">>> " + clothes.Hat.Price + "\n" + clothes.Jacket.Price + "\n" +
                    clothes.Pants.Price + "\n" + clothes.Boots.Price,
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**SoldPrice**",
                Value = ">>> " + clothes.Hat.SoldPrice + "\n" + clothes.Jacket.SoldPrice + "\n" +
                    clothes.Pants.SoldPrice + "\n" + clothes.Boots.SoldPrice,
                IsInline = true
            });
            return embed;
        }
        public EmbedBuilder ConstructInventoryEmbed()
        {
            var inventory = authorModel.GetTamagochi.backpack;
            controller.GetBackpack().Add(EBotBoots.ATHLETIC_SHOE);
            embed.Color = Color.Green;
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Inventory:**",
                Value = ">>> " + inventory.ToString()
            });
            return embed;
        }
        public MessageResult ChooseMessageResult(CommandModel command)
        {
            switch (command.GetOptions)
            {
                case "inventory":
                case "i":
                    return new EmbedView<Embed>(ConstructInventoryEmbed().Build());
                case "clothes":
                case "c":
                    return new EmbedView<Embed>(ConstructClothesEmbed().Build());
                case "info":
                    return new EmbedView<Embed>(ConstructInfoEmbed().Build());
                case "r":
                case "remove":
                    return new BooleanView(controller
                        .GetBackpack()
                        .Remove(Convert.ToInt32(authorModel.GetCommand.GetArgs[0])));
                case "wear":
                case "w":
                case "avatar":
                case "a":
                    return new EmbedView<Embed>(ConstructAvatarEmbed().Build());

                default:
                    return new EmbedView<Embed>(ConstructMainEmbed().Build());
            }
        }
    }
}
