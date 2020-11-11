using Discord;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.DefaultActions.Models;
using MinaBot.DefaultActions.Views;
using MinaBot.Models;
using System;
using System.Threading.Tasks;
using static MinaBot.MessageResult;

namespace MinaBot.DefaultActions.Actions.Question
{
    public class AnswerQuestionAction : AActionCommand
    {
        public AnswerQuestionAction(CommandModel command) : base(command) { }

        public override string[] Options => new[] { "answ", "answer" };

        public override MessageResult Invoke()
        {
            using var data = new DefaultCommandContext();
            var question = data.GetQuestionOrDefault(Convert.ToInt32(Command.GetOptions));

            if (question == null)
            {
                return new ErrorView("Error question!");
            }
            var channel = Program.client.GetChannel((ulong)question.ChannelId);
            var author = Program.client.GetUser((ulong)question.AuthorId);
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
            var emb = new QuestionView(question, answer);
            await channel.SendMessageAsync(embed: emb.GetEmbed());
        }
    }
}