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
        AuthorModel model;

        public IView GetView(IMessage message)
        {
            model = new AuthorModel(message);
            IView result;
            switch(model.GetCommand.GetPrefix)
            {
                case "shop":
                    result = new ShopView(model.GetCommand);
                    break;
                case "bot":
                    result = new TamagochiView(message, model.GetCommand);
                    break;

                default:
                    result = new ExceptionView();
                    break;
            }
            return result;
        }
    }
}
