using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Models;

namespace MinaBot.TamagochiActions.Tamagochi.Actions
{
    public class ShopViewAction : APetActionCommand
    {
        public ShopViewAction(TamagochiModel pet, CommandModel command, bool needToSaveInData = false)
            : base(pet, command, needToSaveInData) { }

        public override string[] Options => new[] {"shop"};
        public override MessageResult Invoke() => new ShopView().GetView(Command);
    }
}