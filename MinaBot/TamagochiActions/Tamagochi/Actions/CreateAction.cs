using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.Models;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions.Interfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using MinaBot.Entity;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class CreateAction : APetActionCommand, IHelper
    {
        public string Title => "**m!pet create [pet_name]**";
        public string Description => "Create new pet.\nYou can't have more pets then one.";
        public override string[] Options => new[] { "create" };
        
        private DataContext _getContext;
        public CreateAction(TamagochiModel pet, CommandModel command, DataContext context) : base(pet, command)
        {
            this._getContext = context;
        }

        public override MessageResult Invoke()
        {
            if (Pet != null)
            {
                return new ErrorView($"You already have Pet: { Pet.Name }.");
            }
            var name = Command.GetArgs == null || Command.GetArgs[0] == null ? "#Tamagochi" : Command.GetArgs[0];
            _getContext.Add(GetPetWithDefaultValues(Command.GetMessage.Author.Id, name));
            _getContext.SaveChanges();
            return new BooleanView(true);
        }
        private TamagochiModel GetPetWithDefaultValues(ulong discordId, string name = "#Tamagochi")
        {
            return new TamagochiModel()
            {
                DiscordId = discordId,
                Name = name,
                Color = "0x89ED61",
                Level = new LevelModel() { Level = 1, ExpToNextLevel = 100 },
                AvatarURL = @"https://i.pinimg.com/736x/16/f9/60/16f960c5ba68b8f0b88f1c571e8bf9ce--kim-taehyung-twice-cute.jpg",
                Money = 150,
                CurrentStatus = "Hello, world!",
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
