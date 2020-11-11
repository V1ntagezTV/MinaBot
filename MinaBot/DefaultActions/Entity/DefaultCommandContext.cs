using Microsoft.EntityFrameworkCore;
using MinaBot.DefaultActions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinaBot.DefaultActions
{
    public class DefaultCommandContext : DbContext
    {
        public DbSet<QuoteModel> Quotes { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }

        public DefaultCommandContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CommandData;Trusted_Connection=True;");
        }

        public QuoteModel GetPastaOrDefault(ulong discordId)
        {
            return Quotes.FirstOrDefault(t => t.AuthorId == (long)discordId);
        }

        public QuoteModel GetPastaOrDefault(string prefix)
        {
            return Quotes.FirstOrDefault(t => t.Prefix == prefix);
        }

        public QuestionModel GetQuestionOrDefault(int id) => Questions.FirstOrDefault(q => q.Id == id);
    }
}
