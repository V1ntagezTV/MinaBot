using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace TestFunctions.Modules
{
    public class GetReactionCallBack
    {
        private DiscordSocketClient _client;
        private readonly TimeSpan _waitLenght;
        private readonly SocketUserMessage _message;

        public GetReactionCallBack(DiscordSocketClient client, TimeSpan waitLenght, IMessage message)
        {
            _client = client;
            _waitLenght = waitLenght;
            _message = (SocketUserMessage) message;
        }

        public async Task GetFirstReactionAsync()
        {
            var voteList = new List<ulong>();
            Console.WriteLine("Start get react");
            var delay = Task.Delay(10000);
            var eventTrigger = new TaskCompletionSource<SocketReaction>();
            await _message.AddReactionAsync(new Discord.Emoji("🐧"));
            var loosersList = new List<IUser>();
            _client.ReactionAdded += ReactionHandler;
            
            async Task ReactionHandler(Discord.Cacheable<Discord.IUserMessage, ulong> arg1, ISocketMessageChannel channel, SocketReaction emoji)
            {
                Console.WriteLine($"{emoji.Emote.Name}");
                if (_message.Author == emoji.User.Value)
                {
                    loosersList.Add(emoji.User.Value);
                    //eventTrigger.SetResult(emoji);
                }
                await Task.CompletedTask;
            }

            var result = await Task.WhenAny(delay).ConfigureAwait(false);
            var ind = new Random().Next(0, loosersList.Count);
            await _message.Channel.SendMessageAsync($"Looser was found: {loosersList.ElementAt(ind)}");
            Console.WriteLine("End get react");
            _client.ReactionAdded -= ReactionHandler;
        }
    }
}