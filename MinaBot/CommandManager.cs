using Discord;
using MinaBot.Views;
using System;
using System.Threading.Tasks;

namespace MinaBot
{
    class CommandManager
    {
        AuthorModel model;
        public CommandManager(AuthorModel model)
        {
            this.model = model;
        }
        public MessageResult GetViewResult()
        {
            MessageResult result;
            Console.WriteLine("shop");
            switch (model.GetCommand.GetPrefix)
            {
                case "shop":
                    Console.WriteLine("shop");
                    result = new ShopView(model).ChooseMessageResult(model.GetCommand);
                    break;
                case "bot":
                    Console.WriteLine("bot");
                    result = new TamagochiView(model).ChooseMessageResult(model.GetCommand);
                    break;

                default:
                    throw new Exception("unvalueble message");
            }
            return result;
        }

    }
}
