#nullable enable

using Discord;
using Discord.WebSocket;

namespace MinaBot.Models
{
    public class CommandModel
    {
        public CommandModel(SocketMessage message, string prefix, string? options = null, string[]? args = null)
        {
            GetMessage = message;
            GetPrefix = prefix;
            GetOptions = options;
            GetArgs = args;
        }

        public string GetPrefix { get; private set; } //type
        public string? GetOptions { get; private set; } //function
        public string[]? GetArgs { get; private set; } // argument
        public SocketMessage GetMessage { get; private set; }
    }
}
