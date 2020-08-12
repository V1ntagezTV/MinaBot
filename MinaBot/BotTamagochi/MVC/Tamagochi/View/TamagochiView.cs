using Discord;
using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Main;
using MinaBot.Models;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.View
{
    class TamagochiView: IView
    {
        public MessageResult GetView(TamagochiModel pet, CommandModel message = null)
        {
            return new EmbedView<Embed>(ConstructMainEmbed(pet, message));
        }

        private Embed ConstructMainEmbed(TamagochiModel pet, CommandModel message)
        {
            var embed = new EmbedBuilder();
            embed.Title = pet.Name;
            embed.Description = pet.CurrentStatus;
            embed.Color = Color.DarkRed;
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "Статы",
                Value = $"Money: {pet.Money}\n"
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ХАРАКТЕРИСТИКА:**",
                Value = ":heart:  **Здоровье**: " + pet.Health.Score + " хп\n" +
                    ":meat_on_bone:  **Голод**: " + pet.Hungry.Score + " p\n" +
                    ":sweat_drops:  **Жажда**: " + pet.Thirsty.Score + " p\n" +
                    ":partying_face:   **Счастье**: " + pet.Happiness.Score + " p\n",
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ОДЕЖДА:**",
                Value = "**Шляпа**: " + pet.Hat.Name + "\n" +
                    "**Куртка**: " + pet.Jacket.Name + "\n" +
                    "**Штаны**: " + pet.Pants.Name + "\n" +
                    "**Ботинки**: " + pet.Boots.Name,
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**ИНВЕНТАРЬ:**",
                Value = pet.Backpack.ToString()
            });
            embed.Footer = new EmbedFooterBuilder()
            {
                Text = "Дата рождения: " + pet.Birthday.ToString()
            };
            return embed.Build();
        }
    }
}
