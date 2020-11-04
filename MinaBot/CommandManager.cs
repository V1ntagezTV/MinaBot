using Discord;
using MinaBot.Controllers;
using MinaBot.Models;
using System;
using System.Net.Sockets;
using Discord.WebSocket;
using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.DefaultActions;

namespace MinaBot
{
    class CommandManager
    {
        CommandModel commandModel;
        public CommandManager(SocketMessage message)
        {
            var cmdArgList = message.Content.Split();
            var cmdType = cmdArgList[0].ToLower().Split('!')[1];
            switch (cmdArgList.Length)
            {
                case 1:
                    commandModel = new CommandModel(message, cmdType);
                    break;
                case 2:
                    commandModel = 
                        new CommandModel(message, cmdType,cmdArgList[1].ToLower());
                    break;
                default:
                    commandModel =
                        new CommandModel(message, cmdType, cmdArgList[1].ToLower(), cmdArgList[2..]);
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
                        return new TamagochiController(commandModel, context).GetResult();
                    }

                //case "shop":
                //    return new ShopController();

                default:
                    return new DefaultActionsController(commandModel).GetResult();
            }
        }
    }
}