using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.MVC.Tamagochi;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using MinaBot.DefaultActions.Models;
using MinaBot.Models;

namespace MinaBot.Entity
{
    public class DataContext : DbContext
    {
        public DbSet<DiscordServer> Servers { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TamagochiModel> Pets { get; set; }
        public DbSet<QuoteModel> Quotes { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<Thirsty> Thirsty { get; set; }
        public DbSet<Hungry> Hungry { get; set; }
        public DbSet<Happiness> Happiness { get; set; }
        public DbSet<Health> Healths { get; set; }
        public DbSet<Hunting> Hunting { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        public UserModel GetUserOrNew(ulong discordId)
        {
            var user = Users
                .Include(u => u.Quotes)
                .Include(u => u.Questions)
                .FirstOrDefault(u => u.DiscordId == discordId);
            
            if (user == null)
            {
                user = new UserModel()
                {
                    DiscordId = discordId,
                    Questions = new List<QuestionModel>(),
                    Quotes = new List<QuoteModel>()
                };
                this.Add(user);
            }
            return user;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BotDatabase;Trusted_Connection=True;");
        }

        public QuoteModel GetPastaOrDefault(string prefix)
        {
            return Quotes
                .Include(p => p.Author)
                .FirstOrDefault(t => t.Prefix == prefix);
        }

        public QuestionModel GetQuestionOrDefault(int id) => Questions
            .Include(q => q.Author)
            .FirstOrDefault(q => q.Id == id);
        
        public TamagochiModel GetPetOrDefault(ulong discordId)
        {
            return this.Pets
                .Include(p => p.UserModel)
                .Include(t => t.Happiness)
                .Include(t => t.Health)
                .Include(t => t.Hungry)
                .Include(t => t.Thirsty)
                .Include(t => t.Backpack)
                .Include(t => t.Hunting)
                .Include(t => t.Level)
                .FirstOrDefault(t => t.UserModel.DiscordId == discordId);
        }
    }
}