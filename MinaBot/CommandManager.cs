using Discord;
using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.DataTamagochi;
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
                    using (var context = new TamagochiContext())
                    {
                        context.Data.Include(t => t.Backpack)
                             .Include(t => t.Clothes)
                             .Include(t => t.Happiness)
                             .Include(t => t.Health)
                             .Include(t => t.Hungry)
                             .Include(t => t.Thirsty)
                             .Include(t => t.Hunting);
                        model.GetTamagochi = context.FindWithDiscordID(model.GetAuthor.Id);
                        model.GetContext = context;
                        result = new TamagochiView(model).ChooseMessageResult(model.GetCommand);
                        context.SaveChanges();
                    }
                    break;

                default:
                    throw new Exception("unvalueble message");
            }
            return result;
        }
    }
}