using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    public class TakeOffItemAction : APetActionCommand
    {
        public TakeOffItemAction(TamagochiModel pet, CommandModel command)
            : base(pet, command, true) { }
        
        public override string[] Options => new[] { "takeoff", "to" };
        public override MessageResult Invoke()
        {
            var clothesType = Command.GetArgs[0];
            switch (clothesType)
            {
                case "h":
                    Pet.Backpack.Add(Pet.HatID.ToString());
                    Pet.HatID = ItemMocks.defaultCleanItem.ID;
                    break;
                default:
                    break;
            }

            return new MessageResult.BooleanView(true);
        }
    }
}