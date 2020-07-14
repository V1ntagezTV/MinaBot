using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Models
{
    class CommandModel
    {
        public CommandModel(string prefix, string[] options)
        {
            GetPrefix = prefix;
            GetOptions = options;
        }

        public string GetPrefix { get; }
        public string GetInfo { get; }
        public string[] GetOptions { get; private set; }
    }
}
