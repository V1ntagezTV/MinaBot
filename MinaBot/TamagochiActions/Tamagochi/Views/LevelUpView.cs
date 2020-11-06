using Discord;
using Microsoft.EntityFrameworkCore.Query;
using MinaBot.Main;
using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.View
{
    public class LevelUpView : IView
    {
        private TamagochiModel Pet;
        public LevelUpView(TamagochiModel pet)
        {
            Pet = pet;
        }
        
        public MessageResult GetView(CommandModel cmdModel)
        {
            return new MessageResult.EmbedView(ConstructEmbed());
        }

        public Embed ConstructEmbed()
        {
            var embed = new EmbedBuilder() { Color = Color.Orange };
            embed.Title = "Level up!";
            embed.Description = $"Congratulations!\nYou earned new level: **{Pet.Level.Level}**.";
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Gifts:**",
                Value = "---"
            });
            return embed.Build();
        }
    }
}