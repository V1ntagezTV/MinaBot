using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Models;
using MinaBot.Models;

namespace MinaBot.TamagochiActions.Tamagochi.Actions
{
    public class TradeAction : APetActionCommand
    {
        public TradeAction(TamagochiModel pet, CommandModel command, bool needToSaveInData = false)
            : base(pet, command, needToSaveInData) { }

        public override string[] Options => new[] {"trade"};
        public override MessageResult Invoke()
        {
            return new CustomTradeView();
        }
    }

    class CustomTradeView : MessageResult.CustomViewToGet
    {
        public override async Task Invoke(SocketUserMessage message)
        {
            UserModel resultUser;
            var delay = Task.Delay(10000);
            var eventTrigger = new TaskCompletionSource<SocketReaction>();
            message.Channel.SendMessageAsync("Get reaction.");
            Program.client.ReactionAdded += ReactionHandler;

            async Task ReactionHandler(Discord.Cacheable<Discord.IUserMessage, ulong> arg1, ISocketMessageChannel channel, SocketReaction emoji)
            {
                Console.WriteLine($"{emoji.Emote.Name}");
            }

            var result = await Task
                .WhenAny(delay, eventTrigger.Task);

            Console.WriteLine("End.");
            Program.client.ReactionAdded -= ReactionHandler;
        }
    }
}