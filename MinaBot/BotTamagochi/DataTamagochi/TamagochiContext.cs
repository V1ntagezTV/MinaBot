using Microsoft.EntityFrameworkCore;
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
        public TamagochiContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TamagochiData;Trusted_Connection=True;");
        }
        public TamagochiModel FindWithDiscordID(ulong id)
        {            
            return Data.ToList().Find(t => t.DiscordId == id);
        }
        public void CreateTamagochi(ulong id)
        {
            Data.Add(new TamagochiModel() { DiscordId = id });
            this.SaveChanges();
        }
    }
}
