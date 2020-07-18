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
            public Exception Exception { get; private set; }
            public ErrorView(Exception exception) {
                this.Exception = exception;
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
    }
}
