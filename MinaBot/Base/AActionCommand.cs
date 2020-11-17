using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    public abstract class AActionCommand
    {
        protected CommandModel Command;
        public abstract string[] Options { get; }
        public AActionCommand(CommandModel command)
        {
            this.Command = command;
        }

        public abstract MessageResult Invoke();
    }
}
