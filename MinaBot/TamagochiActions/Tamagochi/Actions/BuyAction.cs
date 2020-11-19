using System;
using System.Linq;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.Models;
using MinaBot.TamagochiActions.Shop;

namespace MinaBot.TamagochiActions.Tamagochi.Actions
{
    public class BuyAction : APetActionCommand, IHelper
    {
        public string Title => "m!pet buy <item-id>";
        public string Description => "Buy items from pets Secret Shop.";
        public override string[] Options => new[] {"buy"};
        public BuyAction(TamagochiModel pet, CommandModel command, bool needToSaveInData = true)
            : base(pet, command, needToSaveInData) { }


        public override MessageResult Invoke()
        {
            var shop = ShopJsonController.GetConfigValues();
            var itemId = Convert.ToInt32(Command.GetArgs[0]);
            if (shop.RndItemsId.Contains(itemId))
            {
                var buyItem = ShopJsonController.GetItems().FirstOrDefault(item => item.Id == itemId);
                if (Pet.Money >= buyItem.Price)
                {
                    Pet.Backpack.Add(Command.GetArgs[0]);
                    Pet.Money -= buyItem.Price;
                    return new MessageResult.BooleanView(true);
                }
                return new MessageResult.ErrorView("You dont have enough money!");
            }
            else
            {
                Console.WriteLine(itemId);
                return new MessageResult.BooleanView(false);
            }
        }
    }
}