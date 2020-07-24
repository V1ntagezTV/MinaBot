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

        public AuthorModel(IMessage message, CommandModel command)
        {
            GetCommand = command;
            GetMessage = message;
            //TODO: тянем из датабейз
            GetTamagochi = tamagochi;
        }
        public TamagochiModel GetTamagochi { get; private set; }
        public CommandModel GetCommand { get; private set; } 
        public IMessage GetMessage { get; private set; } 
    }
}
