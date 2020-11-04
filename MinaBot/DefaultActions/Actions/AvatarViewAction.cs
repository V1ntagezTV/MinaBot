using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Views;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Actions
{
    public class AvatarViewAction : AActionCommand
    {
        public AvatarViewAction(CommandModel command) : base(command) { }
        public override string[] Options => new[] {"avatar"};
        public override MessageResult Invoke() => new AvatarView().GetView(Command);
    }
}