#nullable enable

using Discord;

namespace MinaBot.Models
{
    class CommandModel
    {
        public CommandModel(IMessage message, string prefix, string? options = null, string[]? args = null)
        {
            GetMessage = message;
            GetPrefix = prefix;
            GetOptions = options;
            GetArgs = args;
        }

        public string GetPrefix { get; private set; } //type
        public string? GetOptions { get; private set; } //function
        public string[]? GetArgs { get; private set; } // argument
        public IMessage GetMessage { get; private set; }
    }
}
