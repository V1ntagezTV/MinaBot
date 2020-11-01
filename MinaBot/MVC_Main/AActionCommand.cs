using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    public abstract class AActionCommand
    {
        protected CommandModel Command;
        public string[] Options { get; set; }

        public AActionCommand(CommandModel command)
        {
            this.Command = command;
        }

        public abstract MessageResult Invoke();
        
        // TODO: Create for every action his help view.
        //abstract public MessageResult HelpInvoke();
    }
}
