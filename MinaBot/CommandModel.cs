using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Models
{
    class CommandModel
    {
        public CommandModel(string prefix, string options = null)
        {
            GetPrefix = prefix;
            GetOptions = options;
        }

        public string GetPrefix { get; private set; }
        public string GetInfo { get; private set; }
        public string GetOptions { get; private set; }
    }
}
