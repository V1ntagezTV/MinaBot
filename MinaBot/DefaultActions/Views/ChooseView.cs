using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace MinaBot.DefaultActions.Actions
{
    public class ChooseView : MessageResult.CustomView
    {
        private readonly string _messageText;
        private uint _delayTimeInSec;
        public ChooseView(string messageText, uint delayTimeInSec)
        {
            _messageText = $"**{messageText}**";
            _delayTimeInSec = delayTimeInSec;
        }

        public override async Task Invoke(SocketUserMessage message)
        {
            var reactorsList = new HashSet<IUser>();
            var text = "React to this message!";
            var toReactMess = await message.Channel.SendMessageAsync(text);
            await toReactMess.AddReactionAsync(new Emoji("🐧"));
            var cancelTrigger = new TaskCompletionSource<bool>();
            
            Program.client.ReactionAdded += Handler;
            async Task Handler(Cacheable<IUserMessage, ulong> arg1, ISocketMessageChannel channel, SocketReaction emote)
            {
                if (toReactMess.Id != emote.MessageId) return;
                if (emote.User.Value.IsBot) return;
                
                reactorsList.Add(emote.User.Value);
                await Task.CompletedTask;
            }

            await Task.Delay(TimeSpan.FromSeconds(_delayTimeInSec));
            Program.client.ReactionAdded -= Handler;
            if (reactorsList.Count == 0) return;
            var rnd = new Random();
            var rndUser = reactorsList.ElementAt(rnd.Next(0, reactorsList.Count - 1));
            await new ApprovedView($"**{_messageText}** is {rndUser.Mention}").Invoke(message);
        }
    }
}