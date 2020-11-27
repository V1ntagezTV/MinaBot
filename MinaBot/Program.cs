using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using static MinaBot.MessageResult;

namespace MinaBot
{
    class Program
    {
        public static DiscordSocketClient client;
        private const string TOKEN = @"";
        private const string BOT_PREFIX = "m!";
        public static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.Log += Logging;
            client.MessageReceived += MessageReceivedFunction;
            await client.LoginAsync(TokenType.Bot, TOKEN);
            await client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task MessageReceivedFunction(SocketMessage message)
        {
            if (!(message is SocketUserMessage msg)) return;
            if (msg.Author.IsBot) return;

            if (message.Content.ToLower().StartsWith(BOT_PREFIX))
            {
                var manager = new CommandManager(message);
                var view = manager.GetViewResult();
                _ = view switch
                {
                    EmbedView embView => message.Channel.SendMessageAsync(embed: embView.Data),
                    MessageView messView => message.Channel.SendMessageAsync(text: messView.Data),
                    ErrorView errorView => message.Channel.SendMessageAsync(embed: errorView.Exception),
                    BooleanView boolView => boolView.Value ? message.AddReactionAsync(new Emoji("✅")) : message.AddReactionAsync(new Emoji("❌")),
                    _ => throw new NotImplementedException()
                };
            }
            await Task.CompletedTask;
        }

        private Task Logging(LogMessage log)
        {
			Console.WriteLine(log.Message);
            if (log.Exception != null)
            {
                Console.WriteLine(log.Exception.Message);
            }
			return Task.CompletedTask;
        }
	}
}
