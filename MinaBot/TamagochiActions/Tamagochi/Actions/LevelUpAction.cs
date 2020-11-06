using System.Threading.Tasks;
using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions.Interfaces
{
    public class LevelUpAction : APetActionCommand, ITrigger
    {
        public LevelUpAction(TamagochiModel pet, CommandModel command, bool needToSaveInData = false)
            : base(pet, command, needToSaveInData) { }

        public override string[] Options { get; }
        public override MessageResult Invoke()
        {
            return new LevelUpView(Pet).GetView(Command);
        }

        public async Task SendResultInChannel()
        {
            var embed = Invoke() as MessageResult.EmbedView;
            await Command.GetMessage.Channel.SendMessageAsync(embed: embed.Data);
        }
    }
}