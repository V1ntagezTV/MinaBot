using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    public class InventoryViewAction : APetActionCommand, IHelper
    {
        public string Title => "**m!pet inventory**";
        public string Description => "Delete your pet.\nUse it if your pet was dead or if you wanna restart.";
        public InventoryViewAction(TamagochiModel pet, CommandModel command)
            : base(pet, command) { }

        public override string[] Options => new[] { "inventory"};

        public override MessageResult Invoke()
        {
            return new InventoryView(Pet).GetView(Command);
        }
    }
}