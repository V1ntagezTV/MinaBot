using Discord;
using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.Controllers;
using MinaBot.Models;
using MinaBot.Views;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
            MessageResult result;
            switch (commandModel.GetPrefix)
            {
                //case "shop":
                //    result = new TamagochiView(commandModel).ChooseMessageResult();//new ShopView().ChooseMessageResult(commandModel);
                //    break;
                case "bot":
                    result = new TamagochiController(commandModel).ChooseMessageResult();
                    break;

                default:
                    throw new Exception("unvalueble message");
            }
            return result;
        }
    }
}