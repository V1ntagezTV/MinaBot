using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    public class ChangeColorAction : APetActionCommand, IHelper
    {
        public string Title => "m!pet color <hex-color>";
        public string Description => "Change embed-pet color.";
        public override string[] Options => new[] {"color"};
        
        public ChangeColorAction(TamagochiModel pet, CommandModel command)
            : base(pet, command, true) { }

        public override MessageResult Invoke()
        {
            var hex = Command.GetArgs[0];
            Pet.Color = "0x" + hex;
            return new MessageResult.BooleanView(true);
        }

    }
}