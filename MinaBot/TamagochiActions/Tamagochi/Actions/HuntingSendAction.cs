using MinaBot.Models;
using System;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions.Interfaces;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class HuntingSendAction : APetActionCommand, IGetExperiance, IHelper
    {
		static readonly TimeSpan Length = new TimeSpan(0, 0, 10);
		public string Title => "m!pet hunt";
	    public string Description =>
		    $"Send your pet on a hunting for items.\nGives experience to your pet.\nLenght: {Length.TotalMinutes} min.";
	    public override string[] Options => new[] { "hunt" };
	    
	    public HuntingSendAction(TamagochiModel pet, CommandModel cmd)
		    : base(pet, cmd, true) { }

	    public override MessageResult Invoke()
        {
			if (Pet.CurrentStatus == EStatus.HUNT)	
			{
				return new BooleanView(false);
			}
			Pet.CurrentStatus = EStatus.HUNT;
			Pet.Hunting.SavedSendTime = DateTime.Now;
			Pet.Hunting.SendTimeLength = Length;
			Pet.Hunting.SendToHunting(Length);
			return new BooleanView(true);
		}

	    public int GetExp() => new Random().Next(25, 50);
    }
}
