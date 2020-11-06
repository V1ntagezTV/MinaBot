using System.Threading.Tasks;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions.Interfaces
{
    public interface ITrigger
    {
        public Task SendResultInChannel();
    }
}