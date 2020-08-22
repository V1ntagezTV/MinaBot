using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.BotTamagochi.Models;
using MinaBot.BotTamagochi.MVC.Tamagochi;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using static MinaBot.MessageResult;

namespace MinaBot
{
    class Program
    {
        private DiscordSocketClient client;
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
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task MessageReceivedFunction(SocketMessage message)
        {
            if (message.Content.ToLower().StartsWith("m!"))
            {
                var manager = new CommandManager(message);
                var view = manager.GetViewResult();

                if (view is EmbedView<Embed> EmbView)
                {
                    await message.Channel.SendMessageAsync(embed: EmbView.Data);
                }
                else if (view is MessageView EStrView)
                {
                    await message.Channel.SendMessageAsync(text: EStrView.Data);
                }
                else if (view is ErrorView EView)
                {
                    await message.Channel.SendMessageAsync(embed: EView.Exception);
                } 
                else if (view is BooleanView BoolView)
                {
                    if (BoolView.Value)
                    {
                        await message.AddReactionAsync(new Emoji("✅"));
                        return;
                    }
                    await message.AddReactionAsync(new Emoji("❌"));
                }
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
