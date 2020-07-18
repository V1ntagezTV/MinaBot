﻿using Discord;
using Discord.WebSocket;
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
                var manager = new CommandManager(new AuthorModel(message));
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
                else if (view is BooleanView)
                {
                    await message.Channel.SendMessageAsync(text: "true");
                }
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
