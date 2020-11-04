using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class DeleteAction : APetActionCommand
    {
        TamagochiContext context;
        public DeleteAction(TamagochiModel pet, CommandModel command, TamagochiContext context) : base(pet, command)
        {
            this.context = context;
        }

        public override string[] Options => new[] { "delete" };

        public override MessageResult Invoke()
        {
            Pet = context.GetPetOrDefault(Command.GetMessage.Author.Id);
            if (Pet != null)
            {
                context.Data.Remove(Pet);
                context.SaveChanges();
                return new BooleanView(true);
            }
            return new ErrorView("You didn't have a pet.");
        }
    }
}
