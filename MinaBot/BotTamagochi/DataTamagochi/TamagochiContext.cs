﻿using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.Models;
using MinaBot.BotTamagochi.MVC.Tamagochi;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinaBot.BotTamagochi.DataTamagochi
{
    class TamagochiContext : DbContext
    {
        public DbSet<Thirsty> Thirsties { get; set; }
        public DbSet<Hungry> Hungries { get; set; }
        public DbSet<Happiness> Happinesses { get; set; }
        public DbSet<Health> Healths { get; set; }
        public DbSet<Hunting> Huntings { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }
        public DbSet<TamagochiModel> Data { get; set; }

        public TamagochiContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TamagochiData;Trusted_Connection=True;");
        }
        public async Task<TamagochiModel> CreateAndAddTamagochi(ulong discordId)
        {
            Console.WriteLine("createFunc");
            var pet = new TamagochiModel()
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
            Console.WriteLine("pet created");
            this.Add(pet);
            await SaveChangesAsync();
            Console.WriteLine("pet added");
            return pet;
        }
    }
}