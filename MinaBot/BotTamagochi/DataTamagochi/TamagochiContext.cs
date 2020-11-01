using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.Models;
using MinaBot.BotTamagochi.MVC.Tamagochi;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinaBot.BotTamagochi.DataTamagochi
{
    public class TamagochiContext : DbContext
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
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TamagochiData;Trusted_Connection=True;");
        }
        public async Task<TamagochiModel> CreateAndAddTamagochi(ulong discordId)
        {
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
            this.Add(pet);
            await SaveChangesAsync();
            Console.WriteLine("new pet added");
            return pet;
        }

        public TamagochiModel? GetPetOrDefault(ulong discordId)
        {
            return this.Data
                .Include(t => t.Happiness)
                .Include(t => t.Health)
                .Include(t => t.Hungry)
                .Include(t => t.Thirsty)
                .Include(t => t.Backpack)
                .Include(t => t.Hunting)
                .Include(t => t.Level)
                .FirstOrDefault(t => t.DiscordId == discordId);
        }
    }
}
