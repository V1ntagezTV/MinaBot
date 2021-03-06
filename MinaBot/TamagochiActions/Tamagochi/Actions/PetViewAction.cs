﻿using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Models;
using MinaBot.TamagochiActions.Tamagochi.Actions.Interfaces;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions.Interfaces
{
    public class PetViewAction : APetActionCommand, IHelper, ICheckable
    {
        public string Title => "m!pet";
        public string Description => "Get information about your pet.";
        public override string[] Options { get; } = null;
        
        public PetViewAction(TamagochiModel pet, CommandModel command, bool needToSaveInData = false)
            : base(pet, command, needToSaveInData) { }

        public override MessageResult Invoke()
        {
            return new TamagochiView(Pet).GetView(Command);
        }

        public bool IsCheckable() => true;
    }
}