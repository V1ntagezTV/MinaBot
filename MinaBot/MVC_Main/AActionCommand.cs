using Discord;
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

        // TODO: Сделать help команды для контроллеров и Action'ов.
        // m!bot help   /// m!bot eat help
        // ShortHelp для добавления каждой команды в общий список команд контроллера.
        //public abstract EmbedFieldBuilder GetShortHelp();
        //public abstract EmbedFieldBuilder GetLongHelp();
    }
}
