using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Models;
using MinaBot.TamagochiActions.Tamagochi.Actions.Interfaces;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    public class InventoryViewAction : APetActionCommand, IHelper, ICheckable
    {
        public string Title => "**m!pet inventory**";
        public string Description => "Shows your items information";
        public InventoryViewAction(TamagochiModel pet, CommandModel command)
            : base(pet, command) { }

        public override string[] Options => new[] { "inventory"};

        public override MessageResult Invoke()
        {
            return new InventoryView(Pet).GetView(Command);
        }

        public bool IsCheckable() => true;
    }
}