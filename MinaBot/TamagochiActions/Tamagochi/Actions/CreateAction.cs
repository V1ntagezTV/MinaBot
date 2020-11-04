using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{

    class CreateAction : APetActionCommand
    {
        TamagochiContext context;
        public CreateAction(TamagochiModel pet, CommandModel command, TamagochiContext context) : base(pet, command)
        {
            this.context = context;
        }

        public override string[] Options => new[] { "create" };

        public override MessageResult Invoke()
        {
            Pet = context.GetPetOrDefault(Command.GetMessage.Author.Id);
            if (Pet != null)
            {
                return new ErrorView($"You already have Pet: { Pet.Name }.");
            }
            context.CreateAndGetTamagochi(Command.GetMessage.Author.Id);
            context.SaveChanges();
            return new BooleanView(true);
        }
    }
}
