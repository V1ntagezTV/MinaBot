using Discord;
using MinaBot.Controllers;
using MinaBot.Models;
using System;
using MinaBot.BotTamagochi.DataTamagochi;

namespace MinaBot
{
    class CommandManager
    {
        CommandModel commandModel;
        public CommandManager(IMessage message)
        {
            string[] commandOptions = message.Content.Split(' ');
            string commandType = commandOptions[0].Split('!')[1];
            switch (commandOptions.Length)
            {
                case 1:
                    commandModel = new CommandModel(message, commandType);
                    break;
                case 2:
                    commandModel = new CommandModel(message, commandType, commandOptions[1]);
                    break;
                default:
                    commandModel = new CommandModel(message, commandType, commandOptions[1], commandOptions[2..]);
                    break;
            }
        }
        public MessageResult GetViewResult()
        {
            switch (commandModel.GetPrefix)
            {
                case "bot":
                    using (var context = new TamagochiContext())
                    {
                        return new TamagochiController(commandModel, context).ChooseMessageResult().Result;
                    }
                    break;

                //case "shop":
                //    return new ShopController();

                default:
                    throw new Exception("unvalueble message");
            }
        }
    }
}