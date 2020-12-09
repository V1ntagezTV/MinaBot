using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using static MinaBot.MessageResult;

namespace MinaBot
{
    class Program
    {
        public static DiscordSocketClient client;
        private const string TOKEN = @"NTY2ODk2NDc2NzU2NjM5NzQ0.XLLpfA.jljA2cNl1PIkywzTrG1M-jBUOU8";
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
                view.Invoke(msg);
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
