using System;

namespace MinaBot.DefaultActions.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public long ChannelId { get; set; }
        public UserModel Author { get; set; }
        public string Content { get; set; }
    }
}