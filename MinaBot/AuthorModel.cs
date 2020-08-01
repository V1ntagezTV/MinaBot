using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.Models;
using System;
using System.Linq;

namespace MinaBot
{

    class AuthorModel
    {
        public AuthorModel(IMessage message, CommandModel command)
        {
            GetCommand = command;
            GetMessage = message;
            GetAuthor = message.Author;
        }
        public  TamagochiModel GetTamagochi { get; set; }
        public TamagochiContext GetContext { get; set; }
        public IUser GetAuthor { get; private set; }
        public CommandModel GetCommand { get; private set; } 
        public IMessage GetMessage { get; private set; } 
    }
}
