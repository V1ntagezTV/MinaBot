using Discord;
using Discord.Rest;
using MinaBot.Main;
using MinaBot.Models;
using MinaBot.Views;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static MinaBot.MessageResult;

namespace MinaBot
{
    class CommandManager
    {
        AuthorModel model;
        public CommandManager(AuthorModel model)
        {
            this.model = model;
        }
        public MessageResult GetViewResult(IMessage message)
        {
            model = new AuthorModel(message);
            MessageResult result;
            switch(model.GetCommand.GetPrefix)
            {
                case "shop":
                    result = new ShopView(model).ChooseMessageResult(model.GetCommand);
                    break;
                case "bot":
                    result = new TamagochiView(model).ChooseMessageResult(model.GetCommand);
                    break;

                default:
                    throw new Exception("unvalueble message");
            }
            return result;
        }

    }
}
