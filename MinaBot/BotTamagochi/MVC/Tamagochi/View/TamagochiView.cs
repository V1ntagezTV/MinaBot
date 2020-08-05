using Discord;
using MinaBot.Main;
using MinaBot.Models;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.View
{
    class TamagochiView: IView
    {
        public MessageResult GetView(TamagochiModel model, CommandModel message = null)
        {
            return new EmbedView<Embed>(ConstructMainEmbed(model, message));
        }

        private Embed ConstructMainEmbed(TamagochiModel tamagochi, CommandModel message)
        {
            var embed = new EmbedBuilder();
            embed.Title = tamagochi.Name;
            embed.Description = tamagochi.CurrentStatus;
            embed.Color = Color.DarkRed;
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ХАРАКТЕРИСТИКА:**",
                Value = ":heart:  **Здоровье**: " + tamagochi.Health.Score + " хп\n" +
                    ":meat_on_bone:  **Голод**: " + tamagochi.Hungry.Score + " p\n" +
                    ":sweat_drops:  **Жажда**: " + tamagochi.Thirsty.Score + " p\n" +
                    ":partying_face:   **Счастье**: " + tamagochi.Happiness.Score + " p\n",
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
            return embed.Build();
        }
    }
}
