﻿using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.Models;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class CreateAction : APetActionCommand, IHelper
    {
        public string Title => "**m!pet create [pet_name]**";
        public string Description => "Create new pet.\nYou can't have more pets then one.";
        public override string[] Options => new[] { "create" };
        
        TamagochiContext context;
        public CreateAction(TamagochiModel pet, CommandModel command, TamagochiContext context) : base(pet, command)
        {
            this.context = context;
        }

        public override MessageResult Invoke()
        {
            if (Pet != null)
            {
                return new ErrorView($"You already have Pet: { Pet.Name }.");
            }
            var name = Command.GetArgs == null || Command.GetArgs[0] == null ? "#Tamagochi" : Command.GetArgs[0];
            context.Add(GetCreatedDefaultPet(Command.GetMessage.Author.Id, name));
            context.SaveChanges();
            return new BooleanView(true);
        }
        private TamagochiModel GetCreatedDefaultPet(ulong discordId, string name = "#Tamagochi")
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
