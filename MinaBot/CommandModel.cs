using System;
using System.Collections.Generic;
using System.Text;
#nullable enable

namespace MinaBot.Models
{
    class CommandModel
    {
        public CommandModel(string prefix, string? options = null, string[]? args = null)
        {
            GetPrefix = prefix;
            GetOptions = options;
            GetArgs = args;
        }

        public string GetPrefix { get; private set; } //type
        public string GetOptions { get; private set; } //function
        public string[]? GetArgs { get; private set; } // argument
        public string GetInfo { get; private set; }
    }
}
