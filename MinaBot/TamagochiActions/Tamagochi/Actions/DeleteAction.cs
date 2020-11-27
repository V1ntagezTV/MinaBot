using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using MinaBot.Base.ActionInterfaces;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class DeleteAction : APetActionCommand, IHelper
    {
        public string Title => "**m!pet delete**";
        public string Description => "Delete your pet.\nUse it if your pet was dead.";
        public override string[] Options => new[] { "delete" };
        
        TamagochiContext context;
        public DeleteAction(TamagochiModel pet, CommandModel command, TamagochiContext context) : base(pet, command)
        {
            this.context = context;
        }

        public override MessageResult Invoke()
        {
            Pet = context.GetPetOrDefault(Command.GetMessage.Author.Id);
            if (Pet != null)
            {
                context.Remove(Pet);
                context.SaveChanges();
                return new BooleanView(true);
            }
            return new ErrorView("You didn't have a pet.");
        }
    }
}
