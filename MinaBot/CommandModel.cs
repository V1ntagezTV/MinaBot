#nullable enable

using Discord;
using Discord.WebSocket;
#nullable enable
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

        public string GetPrefix { get; private set; }
        public string? GetOptions { get; private set; }
        public string[]? GetArgs { get; private set; }
        public SocketMessage GetMessage { get; private set; }
    }
}
