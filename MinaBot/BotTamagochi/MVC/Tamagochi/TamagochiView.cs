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
        private TamagochiModel tamagochi;
        private AuthorModel authorModel;
        private EmbedBuilder embed = new EmbedBuilder();
        public TamagochiView(AuthorModel model)
        {
            tamagochi = model.GetTamagochi;
            authorModel = model;
            controller = new TamagochiController(model);
            embed.Title = "**Nickname**";
            embed.Description =
                "**Статус:** " + tamagochi.CurrentStatus + "\n" +
                "**Уровень:** " + tamagochi.Level + "\n" +
                "**Деньги:** " + tamagochi.Money;
        }

        public EmbedBuilder ConstructMainEmbed()
        {
            embed.Color = Color.DarkRed;
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ХАРАКТЕРИСТИКА:**",
                Value = ":heart:  **Здоровье**: " + controller.GetModel.Health.MainPoints + " хп\n" +
                    ":meat_on_bone:  **Голод**: " + controller.GetModel.Hungry.MainPoints + " p\n" +
                    ":sweat_drops:  **Жажда**: " + controller.GetModel.Thirsty.MainPoints + " p\n" +
                    ":partying_face:   **Счастье**: " + controller.GetModel.Happiness.MainPoints + " p\n",
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ОДЕЖДА:**",
                Value = "**Шляпа**: " + tamagochi.Clothes.Hat.Name + "\n" +
                    "**Куртка**: " + tamagochi.Clothes.Jacket.Name + "\n" +
                    "**Штаны**: " + tamagochi.Clothes.Pants.Name + "\n" +
                    "**Ботинки**: " + tamagochi.Clothes.Boots.Name,
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ИНВЕНТАРЬ:**",
                Value = tamagochi.Backpack.ToString()
            });
            embed.Footer = new EmbedFooterBuilder()
            {
                Text = "Дата рождения: " + tamagochi.Birthday.ToString()
            };
            return embed;
        }
        public EmbedBuilder ConstructInfoEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = tamagochi.Name;
            result.Color = new Color(239, 245, 0); //YELLOW RGB
            return result;
        }
        public EmbedBuilder ConstructAvatarEmbed()
        {
            var result = new EmbedBuilder();
            result.Title = tamagochi.Name;
            result.Author = new EmbedAuthorBuilder()
            {
                Name = authorModel.GetMessage.Author.Username,
                IconUrl = authorModel.GetMessage.Author.GetAvatarUrl()
            };
            result.ImageUrl = tamagochi.AvatarURL;
            return result;
        }
        public EmbedBuilder ConstructClothesEmbed()
        {
            embed.Color = Color.Green;
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Clothes**",
                Value = ">>> " + tamagochi.Clothes.ToString(),
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Price**",
                Value = ">>> " + tamagochi.Clothes.Hat.Price + "\n" + tamagochi.Clothes.Jacket.Price + "\n" +
                    tamagochi.Clothes.Pants.Price + "\n" + tamagochi.Clothes.Boots.Price,
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**SoldPrice**",
                Value = ">>> " + tamagochi.Clothes.Hat.SoldPrice + "\n" + tamagochi.Clothes.Jacket.SoldPrice + "\n" +
                    tamagochi.Clothes.Pants.SoldPrice + "\n" + tamagochi.Clothes.Boots.SoldPrice,
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
                Value = ">>> " + tamagochi.Backpack.ToString()
            });
            return embed;
        }
        public MessageResult ChooseMessageResult(CommandModel command)
        {

            switch (command.GetOptions)
            {
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
                    controller.UpdateStats(DateTime.Now);
                    return new EmbedView<Embed>(ConstructMainEmbed().Build());
            }
        }
    }
}
