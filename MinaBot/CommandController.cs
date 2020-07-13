using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Controllers
{
    class CommandController
    {
        CommandModel model;
        public CommandController(CommandModel model)
        {
            this.model = model;
        }
        public string GetPrefix => model.Prefix;
        public string GetInfo => model.Info; 
    }
}
