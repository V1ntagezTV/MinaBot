using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace MinaBot
{
    class Program
    {
        private DiscordSocketClient client;
        private CommandService commands;
        private string token = @"NTY2ODk2NDc2NzU2NjM5NzQ0.XwMDMg.BkEtu1TJoXxIRcgGLBEA8YJ9HZo";

        public static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.Log += Logging;
            client.MessageReceived += MessageReceivedFunction;
            commands = new CommandService();
            await commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task MessageReceivedFunction(SocketMessage message)
        {
            if (!(message is SocketUserMessage msg)) return;
            if (msg.Author.IsBot) return;

            int commandArg = 0;
            if (msg.HasStringPrefix("m!", ref commandArg))
            {
                var context = new SocketCommandContext(client, msg);
                Console.WriteLine("true");
                await commands.ExecuteAsync(
                        context: context,
                        argPos: commandArg,
                        services: null);
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
