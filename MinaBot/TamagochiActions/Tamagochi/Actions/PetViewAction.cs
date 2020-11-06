using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions.Interfaces
{
    public class PetViewAction : APetActionCommand
    {
        public PetViewAction(TamagochiModel pet, CommandModel command, bool needToSaveInData = false)
            : base(pet, command, needToSaveInData) { }

        public override string[] Options { get; } = null;
        public override MessageResult Invoke()
        {
            return new TamagochiView(Pet).GetView(Command);
        }
    }
}