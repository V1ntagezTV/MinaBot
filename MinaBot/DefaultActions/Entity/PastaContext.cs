using Microsoft.EntityFrameworkCore;
using MinaBot.DefaultActions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinaBot.DefaultActions
{
    class PastaContext : DbContext
    {
        public DbSet<PasteModel> Quotes { get; set; }

        public PastaContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Pastas;Trusted_Connection=True;");
        }

        public PasteModel GetPastaOrDefault(ulong discordId)
        {
            return Quotes.FirstOrDefault(t => t.AuthorId == (long)discordId);
        }

        public PasteModel GetPastaOrDefault(string prefix)
        {
            return Quotes.FirstOrDefault(t => t.Prefix == prefix);
        }
    }
}
