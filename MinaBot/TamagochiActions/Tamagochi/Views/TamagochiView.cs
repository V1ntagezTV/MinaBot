using Discord;
using MinaBot.Base;
using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Controllers;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.View
{
    class TamagochiView: IView
    {
        private TamagochiModel _tamagochi;

        public TamagochiView(TamagochiModel pet)
        {
            _tamagochi = pet;
        }
        public MessageResult GetView(CommandModel cmdModel = null)
        {
            return new EmbedView(ConstructMainEmbed(_tamagochi, cmdModel));
        }

        private Embed ConstructMainEmbed(TamagochiModel pet, CommandModel message)
        {
            var petToDeath = TamagochiController.NeedTimeToHungryAndThristyScore(pet, 40) +
                             (pet.Health.Score / pet.Health.MinusEveryMinute);
            var embed = new EmbedBuilder();
            embed.Title = pet.Name;
            embed.Description = pet.CurrentStatus;
            embed.Color = new Discord.Color((uint)Convert.ToInt32(pet.Color, 16));
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Info:**",
                Value = $"{Icons.Coins} `{pet.Money}`\n" +
                        $"{Icons.Level} `{pet.Level.Level} ({pet.Level.CurrentExp}/{pet.Level.ExpToNextLevel})`\n" +
                        $"LiveTime: {Math.Round(petToDeath, 2)} min."
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Stats:**",
                Value = $":heart: { GetPetStatBar("health", pet.Health.Score) }\n" +
                        $":meat_on_bone: { GetPetStatBar("meal", pet.Hungry.Score) }\n" +
                        $":sweat_drops: { GetPetStatBar("water", pet.Thirsty.Score) }\n" +
                        $":partying_face: `{ pet.Happiness.Score }`",
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Clothes:**",
                Value = $"Hat: { pet.Hat.Name }\n" +
                        $"Jacket: { pet.Jacket.Name }\n" +
                        $"Pants: { pet.Pants.Name }\n" +
                        $"Boots: { pet.Boots.Name }",
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = $"Inventory **({ pet.Backpack.ItemCount }/{ Backpack.MAXITEMSCOUNT }):**",
                Value = pet.Backpack.ToString()
            });
            embed.Footer = new EmbedFooterBuilder()
            {
                Text = $"Birthday: { pet.Birthday }"
            };
            return embed.Build();
        }
        // Types: meal, water, health.
        private string GetPetStatBar(string barType, double score)
        {
            var barCount = 5;
            var showedBarCount = 0;
            var result = new StringBuilder();
            var usedBars = GetTypeBar(barType);
            var fullCount = (int)(score / 20);
            showedBarCount += fullCount;
            var partBar = GetPartBarOrDefault((int)(score % 20), usedBars);
            for (var i = 0; i < fullCount; i++)
            {
                result.Append(usedBars[0]);
            }

            if (partBar != null)
            {
                result.Append(partBar);
                fullCount++;
            }

            for (int i = 0; i < barCount - fullCount; i++)
            {
                result.Append(Icons.EmptyBar);
            }
            return result.ToString();
        }

        private string GetPartBarOrDefault(int score, string[] usedBars)
        {
            string barIcon = null;
            for (int i = 0, ind = 4; ind >= 0; i += 4, ind--)
            {
                if (score > i && score <= i + 4)
                {
                    barIcon = usedBars[ind];
                }
            }
            return barIcon;
        }

        private string[] GetTypeBar(string barType)
        {
            string[] result;
            if (barType == "health") result =
                new[] { Icons.Hp100Bar,Icons.Hp80Bar, Icons.Hp60Bar, Icons.Hp40Bar, Icons.Hp20Bar };
            else if (barType == "water") result = 
                new[] {Icons.Water100Bar, Icons.Water80Bar, Icons.Water60Bar, Icons.Water40Bar, Icons.Water20Bar };
            else if (barType == "meal") result =
                new[] {Icons.Meal100Bar,Icons.Meal80Bar, Icons.Meal60Bar, Icons.Meal40Bar, Icons.Meal20Bar };
            else throw new Exception($"barType: {barType} was undefinite.");
            return result;
        }
    }
}
