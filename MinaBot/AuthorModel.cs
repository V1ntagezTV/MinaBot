using Discord;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot
{
    class AuthorModel
    {
        CommandModel command;
        TamagochiModel tamagochi;
        public AuthorModel(IMessage message)
        {
            string[] commandOptions = message.Content.Split(' ');
            string commandType = commandOptions[0].Split('.')[1];
            command = new CommandModel(commandType, commandOptions);
            GetTamagochi = new TamagochiModel();
            GetAuthor = message.Author;
        }

        public TamagochiModel GetTamagochi { get; private set; }
        public CommandModel GetCommand { get; private set; } 
        public IUser GetAuthor { get; private set; }
    }
}
