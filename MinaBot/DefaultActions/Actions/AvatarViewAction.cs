using System.Linq;
using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Models;
using MinaBot.DefaultActions.Views;
using MinaBot.Entity;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Actions
{
    public class AvatarViewAction : AActionCommand, IHelper
    {
        public string Title => "**m!avatar [mention]**";
        public string Description => "Get avatar image.";
        public override string[] Options => new[] {"avatar"};
        
        public AvatarViewAction(CommandModel command) : base(command) { }

        public override MessageResult Invoke()
        {
            return new AvatarView();
        }
    }
}