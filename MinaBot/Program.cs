using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Models;
using MinaBot.TamagochiActions.Shop;
using MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes;
using MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes.ItemsJson;
using static MinaBot.MessageResult;

namespace MinaBot
{
    class Program
    {
        public static DiscordSocketClient client;
        private CommandService commands;
        private IServiceProvider services;
        private const string TOKEN = @"NTY2ODk2NDc2NzU2NjM5NzQ0.XLLpfA.HYYGCSOcEbwjfSdmXZC5OUCTqQE";
        private const string BOT_PREFIX = "m!";
        public static void Main(string[] args)
        {
            new Program().TestMainAsync().GetAwaiter().GetResult();
        }

        public async Task TestMainAsync()
        {
            client = new DiscordSocketClient();

            await client.LoginAsync(TokenType.Bot, TOKEN);
            await client.StartAsync();

            services = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton<InteractiveService>()
                .BuildServiceProvider();

            commands = new CommandService();
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), services);

            client.MessageReceived += MessageReceivedFunction;
            client.Log += Logging;
            await Task.Delay(-1);
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

            var context = new SocketCommandContext(client, msg);
            await commands.ExecuteAsync(context, 0, services);
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
    public class SampleModule : InteractiveBase
    {
        // DeleteAfterAsync will send a message and asynchronously delete it after the timeout has popped
        // This method will not block.
        [Command("delete")]
        public async Task<RuntimeResult> Test_DeleteAfterAsync()
        {
            await ReplyAndDeleteAsync("this message will delete in 10 seconds", timeout: TimeSpan.FromSeconds(10));
            return Ok();
        }

        // NextMessageAsync will wait for the next message to come in over the gateway, given certain criteria
        // By default, this will be limited to messages from the source user in the source channel
        // This method will block the gateway, so it should be ran in async mode.
        [Command("next", RunMode = RunMode.Async)]
        public async Task Test_NextMessageAsync()
        {
            await ReplyAsync("What is 2+2?");
            var response = await NextMessageAsync();
            if (response != null)
                await ReplyAsync($"You replied: {response.Content}");
            else
                await ReplyAsync("You did not reply before the timeout");
        }

        // PagedReplyAsync will send a paginated message to the channel
        // You can customize the paginator by creating a PaginatedMessage object
        // You can customize the criteria for the paginator as well, which defaults to restricting to the source user
        // This method will not block.
        [Command("paginator")]
        public async Task Test_Paginator()
        {
            var pages = new[] { "Page 1", "Page 2", "Page 3", "aaaaaa", "Page 5" };
            await PagedReplyAsync(pages);
        }
    }
}
