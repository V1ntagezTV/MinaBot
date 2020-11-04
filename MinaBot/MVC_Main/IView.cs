using MinaBot.Models;

namespace MinaBot.Main
{
    interface IView
    {
        public MessageResult GetView(CommandModel cmdModel);
    }
}
