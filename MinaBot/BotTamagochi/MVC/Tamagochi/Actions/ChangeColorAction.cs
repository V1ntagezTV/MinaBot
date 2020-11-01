using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    public class ChangeColorAction : APetActionCommand
    {
        public ChangeColorAction(TamagochiModel pet, CommandModel command)
            : base(pet, command, true)
        {
            Options = new[] {"color"};
        }

        public override MessageResult Invoke()
        {
            var hex = Command.GetArgs[0];
            Pet.Color = "0x" + hex;
            return new MessageResult.BooleanView(true);
        }
    }
}