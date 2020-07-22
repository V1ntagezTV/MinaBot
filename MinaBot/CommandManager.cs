using Discord;
using MinaBot.Views;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MinaBot
{
    class CommandManager
    {
        AuthorModel model;
        public CommandManager(IMessage message)
        {
            this.model = new AuthorModel(message);
        }
        public MessageResult GetViewResult()
        {
            MessageResult result;
            switch (model.GetCommand.GetPrefix)
            {
                case "shop":
                    result = new ShopView(model).ChooseMessageResult(model.GetCommand);
                    break;
                case "bot":
                    result = new TamagochiView(model).ChooseMessageResult(model.GetCommand);
                    break;

                default:
                    throw new Exception("unvalueble message");
            }
            return result;
        }

    }
}
