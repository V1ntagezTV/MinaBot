using Discord;
using Discord.WebSocket;
using MinaBot.Views;
using System;
using System.Threading.Channels;
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
            if (message.Author.Id.ToString() == "236546146477146121" && message.Content == "-bot")
            {
                var view = new BotView();
                await message.Channel.SendMessageAsync(embed: view.CreateBotInfoEmbed(message.Author));
            }
            if (message.Content == "ping")
                await message.Channel.SendMessageAsync(text: "pong!");
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
