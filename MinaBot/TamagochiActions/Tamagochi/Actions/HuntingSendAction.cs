using MinaBot.Models;
using System;
using Microsoft.EntityFrameworkCore.Update;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions.Interfaces;
using MinaBot.Controllers;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class HuntingSendAction : APetActionCommand, IGetExperiance
    {
	    public HuntingSendAction(TamagochiModel pet, CommandModel cmd)
		    : base(pet, cmd, true) { }

	    public override string[] Options => new[] { "hunting", "hunt" };

	    public override MessageResult Invoke()
        {
			var timeLength = new TimeSpan(0, 0, 20);
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
