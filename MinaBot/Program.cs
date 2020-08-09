﻿using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.BotTamagochi.ItemsPack;
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
                    await message.Channel.SendMessageAsync(text: BoolView.Value.ToString());
                }
            }
            if (message.Content.ToLower().StartsWith("test"))
            {
                using (var context = new TamagochiContext())
                {
                    TamagochiModel tamagochi = context.Data.Include(t => t.Happiness)
                        .Include(t => t.Health).Include(t => t.Hungry)
                        .Include(t => t.Thirsty).Include(t => t.Backpack)
                        .Include(t => t.Hunting)
                        .FirstOrDefault(t => t.DiscordId == message.Author.Id);
                    tamagochi.Backpack.Add(1);
                    context.SaveChanges();
                    await message.Channel.SendMessageAsync(embed: ((EmbedView<Embed>)new TamagochiView().GetView(tamagochi)).Data);
                }
                
            }
        }

        private Task Logging(LogMessage log)
        {
			Console.WriteLine(log.Message);
			return Task.CompletedTask;
        }
	}
}
