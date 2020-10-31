using MinaBot.Models;

namespace MinaBot.Main
{
    interface IView
    {
        public MessageResult GetView(TamagochiModel tamagochi, CommandModel message);
    }
}
