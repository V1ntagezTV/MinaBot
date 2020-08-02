using Discord;
using MinaBot.BotPackValues;
using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.Controllers;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Linq;
using static MinaBot.MessageResult;

namespace MinaBot.Views
{
    class TamagochiView: IView
    {
        private CommandModel command;
        private TamagochiController controller;
        private TamagochiModel tamagochi;
        private EmbedBuilder embed = new EmbedBuilder();
        public TamagochiView(CommandModel commandModel)
        {
            command = commandModel;
        }
        public EmbedBuilder ConstructMainEmbed()
        {
            var embed = new EmbedBuilder();
            embed.Title = tamagochi.Name;
            embed.Description = tamagochi.CurrentStatus;
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
                Name = command.GetMessage.Author.Username,
                IconUrl = command.GetMessage.Author.GetAvatarUrl()
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
        public MessageResult ChooseMessageResult()
        {
            controller = new TamagochiController(command);
            var db = new TamagochiDbFacade(new TamagochiContext());
            TamagochiModel tamagochi = db.FindWithDiscordID(command.GetMessage.Author.Id);
            controller.GetModel = tamagochi;
            this.tamagochi = tamagochi;
            MessageResult result;

            switch (command.GetOptions)
            {
                case "inventory":
                case "i":
                    controller.UpdateStats(DateTime.Now);
                    db.context.SaveChanges();
                    result = new EmbedView<Embed>(ConstructInventoryEmbed().Build());
                    break;

                case "clothes":
                case "c":
                    controller.UpdateStats(DateTime.Now);
                    result = new EmbedView<Embed>(ConstructClothesEmbed().Build());
                    break;

                case "info":
                    controller.UpdateStats(DateTime.Now);
                    db.context.SaveChanges();
                    result = new EmbedView<Embed>(ConstructInfoEmbed().Build());
                    break;

                case "wear":
                case "w":
                    result = new BooleanView(controller.WearClothes(Convert.ToInt32(command.GetArgs[0])));
                    break;

                case "sold":
                case "s":
                    result = new BooleanView(controller.SoldItem(Convert.ToInt32(command.GetArgs[0])));
                    break;

                case "avatar":
                case "a":
                    result = new EmbedView<Embed>(ConstructAvatarEmbed().Build());
                    break;

                case "eat":
                    result = new BooleanView(controller.Consume(Convert.ToInt32(command.GetArgs[0])));
                    break;

                case "hunting":
                    result = new BooleanView(controller.SendToHunting(new TimeSpan(0, 0, 5)));
                    break;

                default:
                    controller.UpdateStats(DateTime.Now);
                    db.context.SaveChanges();
                    result = new EmbedView<Embed>(ConstructMainEmbed().Build());
                    break;
            }
            return result;
            
        }
    }
}
