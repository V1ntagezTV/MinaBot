using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    abstract public class ActionCommand
    {
        protected CommandModel Command;
        protected string[] Options;

        public ActionCommand(CommandModel command)
        {
            this.Command = command;
        }

        abstract public MessageResult Invoke();
    }
}
