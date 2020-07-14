using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace MinaBot
{
    class Program
    {
        private DiscordSocketClient client;
        private string token = @"NTY2ODk2NDc2NzU2NjM5NzQ0.XwMDMg.BkEtu1TJoXxIRcgGLBEA8YJ9HZo";
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.Log += Logging;
            client.MessageReceived += MessageReceivedFunction;
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task MessageReceivedFunction(SocketMessage message)
        {
            if (message.Content.StartsWith("mina.") || message.Content.StartsWith("m."))
            {
                var model = new AuthorModel(message);
                var view = model.GetCommand.GetView(message);
                await message.Channel.SendMessageAsync(embed: view.ConstructMainEmbed());
            }
        }

        private Task Logging(LogMessage log)
        {
			Console.WriteLine(log.Message);
			return Task.CompletedTask;
        } 

        async Task SendMessage(IMessageChannel channel)
        {
            string text = Console.ReadLine();
            await channel.SendMessageAsync(text);
        }
	}
}
