using Discord;
using System;

namespace MinaBot.DefaultActions.Models
{
    public class QuoteModel
    {
        public int Id { get; set; }
        public User Author { get; set; }
        public string Prefix { get; set; }
        public string Text { get; set; }
        public string Desc { get; set; }
        public bool isLink { get => Text.StartsWith("https://") || Text.StartsWith("http://"); }
    }
}
