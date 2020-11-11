using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.Main;
using MinaBot.Models;

namespace MinaBot.TamagochiActions.Shop
{
    public class ShopController : IController
    {
        public CommandModel Command { get; }
        public AActionCommand[] Actions { get; }
        public MessageResult GetResult()
        {
            throw new System.NotImplementedException();
        }
    }
}