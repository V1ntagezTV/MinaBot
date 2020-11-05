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
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TamagochiData;Trusted_Connection=True;");
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
