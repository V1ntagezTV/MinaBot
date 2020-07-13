using Discord;
using Discord.Rest;
using MinaBot.Main;
using MinaBot.Models;
using MinaBot.Views;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MinaBot
{
    class CommandManager
    {
        CommandModel model;
        public CommandManager(string prefix, string[] args)
        {
            model = new CommandModel(prefix, args);
        }
        public CommandManager(string prefix)
        {
            model = new CommandModel(prefix);
        }

        public IView GetView(IMessage message)
        {
            IView result;
            switch(model.Prefix)
            {
                case "shop":
                    result = new ShopView(model);
                    break;
                case "bot":
                    result = new BotView(message, model);
                    break;

                default:
                    result = new ExceptionView(message);
                    break;
            }
            return result;
        }
    }
}
