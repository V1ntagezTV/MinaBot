using MinaBot.Models;
using System;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.Models;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using MinaBot.Entity;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class CreateAction : APetActionCommand, IHelper
    {
        public string Title => "m!pet create [pet_name]";
        public string Description => "Create new pet.\nYou can't have more pets then one.";
        public override string[] Options => new[] { "create" };
        
        private DataContext _context;
        public CreateAction(TamagochiModel pet, CommandModel command, DataContext context) : base(pet, command)
        {
            this._context = context;
        }

        public override MessageResult Invoke()
        {
            if (Pet != null)
            {
                return new ErrorView($"You already have Pet: { Pet.Name }.");
            }
            
            var name = Command.GetArgs == null || Command.GetArgs[0] == null ? "#Tamagochi" : Command.GetArgs[0];
            var user = _context.GetUserOrNew(Command.GetMessage.Author.Id);
            var pet = GetPetWithDefaultValues(name);
            user.Pet = pet;
            _context.Add(pet);
            _context.SaveChanges();
            return new BooleanView(true);
        }
        private TamagochiModel GetPetWithDefaultValues(string name = "#Tamagochi")
        {
            return new TamagochiModel()
            {
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
