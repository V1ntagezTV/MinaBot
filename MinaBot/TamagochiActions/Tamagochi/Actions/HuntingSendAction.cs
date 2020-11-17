using MinaBot.Models;
using System;
using Discord;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Update;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions.Interfaces;
using MinaBot.Controllers;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class HuntingSendAction : APetActionCommand, IGetExperiance, IHelper
    {
	    public string Title => "**m!pet hunt**";
	    public string Description =>
		    "Send your pet on a hunting for items.\nGives experience to your pet.\nLenght: 2:30h";
	    public override string[] Options => new[] { "hunt" };
	    
	    public HuntingSendAction(TamagochiModel pet, CommandModel cmd)
		    : base(pet, cmd, true) { }

	    public override MessageResult Invoke()
        {
			var timeLength = new TimeSpan(2, 30, 0);
			TamagochiController.UpdateHuntingStatus(Pet);
			if (Pet.CurrentStatus == EStatus.HUNT)
			{
				return new BooleanView(false);
			}
			Pet.CurrentStatus = EStatus.HUNT;
			Pet.Hunting.SavedSendTime = DateTime.Now;
			Pet.Hunting.SendTimeLength = timeLength;
			Pet.Hunting.SendToHunting(timeLength);
			return new BooleanView(true);
		}

	    public int GetExp() => new Random().Next(25, 50);
    }
}
