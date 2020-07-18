using Discord;
using Discord.WebSocket;
using MinaBot.Models;
using System;
using System.Linq;

namespace MinaBot
{

    class AuthorModel
    {   
        //TODO: тянем из датабейз
        static TamagochiModel tamagochi = new TamagochiModel();
        public AuthorModel(IMessage message)
        {
            string[] commandOptions = message.Content.Split(' ');
            string commandType = commandOptions[0].Split('.')[1];
            Console.WriteLine(message.Content);
            switch (commandOptions.Length)
            {
                case 1:
                    GetCommand = new CommandModel(commandType);
                    break;
                case 2:
                    GetCommand = new CommandModel(commandType, commandOptions[1]);
                    break;
                default:
                    Console.WriteLine(commandOptions[2..][0]);
                    GetCommand = new CommandModel(commandType, commandOptions[1], commandOptions[2..]);
                    break;
            }

            GetMessage = message;
            //TODO: тянем из датабейз
            GetTamagochi = tamagochi;
        }
        public TamagochiModel GetTamagochi { get; private set; }
        public CommandModel GetCommand { get; private set; } 
        public IMessage GetMessage { get; private set; } 
    }
}
