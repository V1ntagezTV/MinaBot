using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.MVC.Tamagochi;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MinaBot.BotTamagochi.DataTamagochi
{
    class TamagochiContext : DbContext
    {
        public DbSet<TamagochiModel> Data { get; set; }
        public DbSet<Thirsty> Thirsties { get; set; }
        public DbSet<Hungry> Hungries { get; set; }
        public DbSet<Happiness> Happinesses { get; set; }
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Health> Healths { get; set; }
        public DbSet<Hunting> Huntings { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }

        public TamagochiContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TamagochiData;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thirsty>();
            modelBuilder.Entity<Hungry>();
            modelBuilder.Entity<Happiness>();
            modelBuilder.Entity<Clothes>();
            modelBuilder.Entity<Health>();
            modelBuilder.Entity<Hunting>();
            modelBuilder.Entity<Item>();
            modelBuilder.Entity<Backpack>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
