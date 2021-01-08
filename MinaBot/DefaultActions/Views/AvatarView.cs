using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Rest;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using MinaBot.DefaultActions.Models;
using MinaBot.Entity;
using MinaBot.Main;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Views
{
    public class AvatarView : MessageResult.CustomView
    {
        private DataContext Data = new DataContext();


        public override async Task Invoke(SocketUserMessage message)
        {
            var discordTargetUser = GetTargetDiscordUser(message);
            var entityTargetUser = GetTargetEntityUser(message, discordTargetUser);
            var embed = CreateEmbed(discordTargetUser, entityTargetUser);
            var messageEmbed = await message.Channel.SendMessageAsync(embed: embed);
            await messageEmbed.AddReactionAsync(new Emoji("👍"));
            await messageEmbed.AddReactionAsync(new Emoji("👎"));
            
            var likes = 0;
            var dislikes = 0;
            Program.client.ReactionAdded += AvatarReaction;
            async Task AvatarReaction(Cacheable<IUserMessage, ulong> arg1, ISocketMessageChannel arg2, SocketReaction arg3)
            {
                if (arg3.MessageId != messageEmbed.Id) return;
                if (arg3.UserId == Program.client.CurrentUser.Id) return;
                if ($"{arg3.Emote}" == "👍")
                    likes++;
                else if ($"{arg3.Emote}" == "👎")
                    dislikes++;
                await Task.CompletedTask;
            }
            var delay = Task.Delay(TimeSpan.FromSeconds(15));
            var task = await Task.WhenAny(delay).ConfigureAwait(false);
            Program.client.ReactionAdded -= AvatarReaction;

            entityTargetUser.AvatarLikesCount += likes;
            entityTargetUser.AvatarDislikesCount += dislikes;
            Data.Update(entityTargetUser);
            Data.SaveChanges();
        }

        private UserModel GetTargetEntityUser(SocketUserMessage message, IUser targetDiscordUser)
        {
            var user = Data.Users.FirstOrDefault(u => u.DiscordId == targetDiscordUser.Id);
            if (user == null)
            {
                user = new UserModel() { DiscordId = targetDiscordUser.Id };
                Data.Add(user);
                Data.SaveChanges();
            }
            return user;
        }

        private IUser GetTargetDiscordUser(SocketUserMessage message)
        {
            var targetUser = message.Author;
            if (message.MentionedUsers.Count != 0)
            {
                targetUser = message.MentionedUsers.First();
            }
            return targetUser;
        }

        private Embed CreateEmbed(IUser discordUser, UserModel entityUser)
        {
            var fullSizeAvatarUrl = discordUser.GetAvatarUrl().Replace("size=128", "size=1024");
            var embed = new EmbedBuilder();
            embed.ImageUrl = fullSizeAvatarUrl;
            embed.Url = discordUser.GetAvatarUrl();
            embed.Title = $"{discordUser}";
            embed.WithDescription($":thumbsup: **{entityUser.AvatarLikesCount} :thumbsdown: {entityUser.AvatarDislikesCount}**");
            return embed.Build();
        }
    }
}