using Discord;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace MinaBot
{
    public abstract class MessageResult
    {
        public abstract Task Invoke(SocketUserMessage message);

        private MessageResult() { }

        public class EmbedView: MessageResult
        {
            public Embed Data { get; private set; }
            public EmbedView(Embed data)
            {
                this.Data = data;
            }

            public override async Task Invoke(SocketUserMessage message)
            {
                await message.Channel.SendMessageAsync(embed: Data);
            }
        }

        public class MessageView: MessageResult
        {
            public string Data { get; private set; }
            public MessageView(string data)
            {
                this.Data = data;
            }

            public override async Task Invoke(SocketUserMessage message)
            {
                await message.Channel.SendMessageAsync(text: Data);
            }
        }

        public class ErrorView : MessageResult
        {
            public Embed Exception { get; private set; }
            public ErrorView(string exception)
            {
                Exception = new EmbedBuilder()
                {
                    Description = exception,
                    Color = Color.Red
                }
                .Build();
            }

            public override async Task Invoke(SocketUserMessage message)
            {
                await message.Channel.SendMessageAsync(embed: Exception);
            }
        }

        public class BooleanView: MessageResult
        {
            public bool Value { get; private set; }
            public BooleanView(bool value)
            {
                Value = value;
            }

            public override async Task Invoke(SocketUserMessage message)
            {
                if (Value) await message.AddReactionAsync(new Emoji("✅"));
                else await message.AddReactionAsync(new Emoji("❌"));
            }
        }

        public class EmptyView : MessageResult
        {
            public override Task Invoke(SocketUserMessage message)
            {
                return Task.CompletedTask;
            }
        }
    }
}
