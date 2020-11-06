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
                case "j":
                    Pet.Backpack.Add(Pet.JacketID.ToString());
                    Pet.JacketID = ItemMocks.defaultCleanItem.ID;
                    break;
                case "p":
                    Pet.Backpack.Add(Pet.PantsID.ToString());
                    Pet.PantsID = ItemMocks.defaultCleanItem.ID;
                    break;
                case "b":
                    Pet.Backpack.Add(Pet.BootsID.ToString());
                    Pet.BootsID = ItemMocks.defaultCleanItem.ID;
                    break;
                
                default:
                    return new MessageResult.BooleanView(false);
                    break;
            }
            return new MessageResult.BooleanView(true);
        }
    }
}