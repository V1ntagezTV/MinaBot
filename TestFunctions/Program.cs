using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using TestFunctions.Modules;

namespace MinaBot
{
    class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private const string Token = @"";

        public static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += Logging;
            _client.MessageReceived += MessageReceivedFunction;
            await _client.LoginAsync(TokenType.Bot, Token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task MessageReceivedFunction(SocketMessage message)
        {
            if (!(message is SocketUserMessage msg)) return;
            if (msg.Author.IsBot) return;
            
            if (msg.Content.StartsWith("m!looser"))
            {
                var callback = new GetReactionCallBack(_client, TimeSpan.FromSeconds(15), msg);
                callback.GetFirstReactionAsync();
            }
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
