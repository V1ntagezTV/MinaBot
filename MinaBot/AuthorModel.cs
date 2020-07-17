using Discord;
using MinaBot.Models;

namespace MinaBot
{
    class AuthorModel
    {
        public AuthorModel(IMessage message)
        {
            string[] commandOptions = message.Content.Split(' ');
            string commandType = commandOptions[0].Split('.')[1];
            GetCommand = new CommandModel(commandType, commandOptions[2]);
            GetMessage = message;

            //TODO: тянем из датабейз 
            GetTamagochi = new TamagochiModel();
        }
        public TamagochiModel GetTamagochi { get; private set; }
        public CommandModel GetCommand { get; private set; } 
        public IMessage GetMessage { get; private set; } 
    }
}
