using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MinaBot.BotTamagochi.Models;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class CreateAction : APetActionCommand
    {
        TamagochiContext context;
        public CreateAction(TamagochiModel pet, CommandModel command, TamagochiContext context) : base(pet, command)
        {
            this.context = context;
        }

        public override string[] Options => new[] { "create" };

        public override MessageResult Invoke()
        {
            if (Pet != null)
            {
                return new ErrorView($"You already have Pet: { Pet.Name }.");
            }
            context.Add(GetCreatedDefaultPet(Command.GetMessage.Author.Id));
            context.SaveChanges();
            return new BooleanView(true);
        }
        private TamagochiModel GetCreatedDefaultPet(ulong discordId)
        {
            return new TamagochiModel()
            {
                DiscordId = discordId,
                Name = "#Tamagochi",
                Color = "0x89ED61",
                Level = new LevelModel() { Level = 1, ExpToNextLevel = 100 },
                AvatarURL = @"https://i.pinimg.com/736x/16/f9/60/16f960c5ba68b8f0b88f1c571e8bf9ce--kim-taehyung-twice-cute.jpg",
                Money = 150,
                CurrentStatus = "Hi!",
                ToUpLevelScore = 100,
                Birthday = DateTime.Now,
                Backpack = new Backpack(),
                LastCheckDate = DateTime.Now,
                Health = new Health(),
                Thirsty = new Thirsty(),
                Hungry = new Hungry(),
                Happiness = new Happiness(),
                Hunting = new Hunting()
            };
        }
    }
}
