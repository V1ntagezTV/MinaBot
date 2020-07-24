using Discord;
using MinaBot.Models;
using MinaBot.Views;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MinaBot
{
    class CommandManager
    {
        AuthorModel model;
        public CommandManager(IMessage message)
        {
            string[] commandOptions = message.Content.Split(' ');
            string commandType = commandOptions[0].Split('!')[1];
            CommandModel commandModel;
            switch (commandOptions.Length)
            {
                case 1:
                    commandModel = new CommandModel(commandType);
                    break;
                case 2:
                    commandModel = new CommandModel(commandType, commandOptions[1]);
                    break;
                default:
                    commandModel = new CommandModel(commandType, commandOptions[1], commandOptions[2..]);
                    break;
            }
            model = new AuthorModel(message, commandModel);
        }
        public MessageResult GetViewResult()
        {
            MessageResult result;
            switch (model.GetCommand.GetPrefix)
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
