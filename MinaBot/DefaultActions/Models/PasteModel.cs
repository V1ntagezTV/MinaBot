using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.DefaultActions.Models
{
    class PasteModel
    {
        public int Id { get; set; }
        public IUser Author { get; set; }
        public string Prefix { get; set; }
        public string Text { get; set; }
    }
}
