using Discord;
using System;

namespace MinaBot
{
    class MessageResult
    {
        private MessageResult() { }
        public class EmbedView<T>: MessageResult
        {
            public T Data { get; private set; }
            public EmbedView(T data): base()
            {
                this.Data = data;
            }
        }

        public class MessageView: MessageResult
        {
            public string Data { get; private set; }
            public MessageView(string data)
            {
                this.Data = data;
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
        }

        public class BooleanView: MessageResult
        {
            public bool Value { get; private set; }
            public BooleanView(bool value)
            {
                Value = value;
            }
        }

        public class EmptyView: MessageResult { }
    }
}
