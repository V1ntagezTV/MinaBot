using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Models;

namespace MinaBot.TamagochiActions.Tamagochi.Actions
{
    public class ShopViewAction : APetActionCommand, IHelper
    {
        public string Title => "**m!pet shop**";
        public string Description => "Buy items from shop.\nNew items in shop generated every day";
        public override string[] Options => new[] {"shop"};
        
        public ShopViewAction(TamagochiModel pet, CommandModel command, bool needToSaveInData = false)
            : base(pet, command, needToSaveInData) { }


        public override MessageResult Invoke() => new ShopView().GetView(Command);

    }
}