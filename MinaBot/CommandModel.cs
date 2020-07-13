using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Models
{
    class CommandModel
    {
        public CommandModel(string prefix, string[] options)
        {
            Prefix = prefix;
            Options = options;
        }
        public CommandModel(string prefix)
        {
            Prefix = prefix;
        }
        public string Prefix;
        public string[] Options;
        public string Info;
    }
}
