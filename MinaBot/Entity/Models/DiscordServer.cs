namespace MinaBot.DefaultActions.Models
{
    public class DiscordServer
    {
        public int Id { get; set; }
        public string Prefix { get; set; }
        public UserModel[] Users { get; set; }
    }
}