using Discord;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Models;
using MinaBot.DefaultActions.Views;
using MinaBot.Models;
using System;
using System.Threading.Tasks;
using MinaBot.Base.ActionInterfaces;
using MinaBot.Entity;
using static MinaBot.MessageResult;

namespace MinaBot.DefaultActions.Actions.Question
{
    public class AnswerQuestionAction : AActionCommand, IHelper
    {
        public override string[] Options => new[] { "answer" };
        public string Title => "m!answer <ask-id>";
        public string Description => "Answer to random questions to real people in other servers.";
        
        public AnswerQuestionAction(CommandModel command) : base(command) { }

        public override MessageResult Invoke()
        {
            using var data = new DataContext();
            var question = data.GetQuestionOrDefault(Convert.ToInt32(Command.GetOptions));
            if (question == null)
            {
                return new ErrorView("Error question!");
            }
            var channel = Program.client.GetChannel((ulong)question.ChannelId);
            var author = Program.client.GetUser(question.Author.DiscordId);
            if (channel is ITextChannel tChannel)    
            {
                SendMessage(tChannel, question, string.Join(" ", Command.GetArgs));
                data.Questions.Remove(question);
                data.SaveChanges();
                return new MessageResult.BooleanView(true);
            }
            return new MessageResult.BooleanView(false);
        }

        private async void SendMessage(ITextChannel channel, QuestionModel question, string answer)
        {
            var emb = new AnswerToQuestionView(question, answer);
            var askAuthor = Command.GetMessage.Author;
            await channel.SendMessageAsync(text: askAuthor.Mention ,embed: emb.GetEmbed(askAuthor));
        }
    }
}