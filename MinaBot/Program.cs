using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.BotTamagochi.MVC.Tamagochi;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using MinaBot.Models;
using System;
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
                else if (view is EmbedView<string> EStrView)
                {
                    await message.Channel.SendMessageAsync(text: EStrView.Data);
                }
                else if (view is ErrorView EView)
                {
                    await message.Channel.SendMessageAsync(text: EView.Exception.Message);
                } 
                else if (view is BooleanView BoolView)
                {
                    await message.Channel.SendMessageAsync(text: BoolView.Value.ToString());
                }

            }
            if (message.Content.ToLower().StartsWith("check"))
            {
                var db = new TamagochiDbFacade(new TamagochiContext());
                var tamagochi = db.FindWithDiscordID(message.Author.Id);
                await message.Channel.SendMessageAsync(tamagochi.Hungry.Score.ToString());
            }
            if (message.Content.ToLower().StartsWith("edit2"))
            {
                var db = new TamagochiDbFacade(new TamagochiContext());
                var GetTamagochi = db.FindWithDiscordID(message.Author.Id);
                GetTamagochi.Hungry.Score = 20;
                await message.Channel.SendMessageAsync(GetTamagochi.Hungry.Score.ToString());
                await db.context.SaveChangesAsync();
            }
            if (message.Content.ToLower().StartsWith("edit1"))
            {
                var db = new TamagochiDbFacade(new TamagochiContext());
                var GetTamagochi = db.FindWithDiscordID(message.Author.Id);
                GetTamagochi.Hungry.Score = 40;
                await message.Channel.SendMessageAsync(GetTamagochi.Hungry.Score.ToString());
                await db.context.SaveChangesAsync();
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
