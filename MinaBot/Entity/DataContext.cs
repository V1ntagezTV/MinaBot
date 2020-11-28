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
        public DbSet<User> Users { get; set; }
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

        public User GetUser(ulong discordId)
        {
            return Users.FirstOrDefault(u => u.DiscordId == discordId);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BotDatabase;Trusted_Connection=True;");
        }

        public QuoteModel GetPastaOrDefault(string prefix)
        {
            return Quotes.FirstOrDefault(t => t.Prefix == prefix);
        }

        public QuestionModel GetQuestionOrDefault(int id) => Questions
            .Include(q => q.Author)
            .FirstOrDefault(q => q.Id == id);
        
        public TamagochiModel? GetPetOrDefault(ulong discordId)
        {
            return this.Pets
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