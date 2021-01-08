using System.Collections.Generic;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public TamagochiModel Pet { get; set; }
        public ulong DiscordId { get; set; }
        public List<QuestionModel> Questions { get; set; }
        public List<QuoteModel> Quotes { get; set; }
        public int AvatarLikesCount { get; set; }
        public int AvatarDislikesCount { get; set; }
    }
}