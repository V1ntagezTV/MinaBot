using MinaBot.Models;
using System;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Actions
{
    class HuntingSendAction : ActionCommand
    {
        private TamagochiModel Pet;
        public HuntingSendAction(TamagochiModel pet, CommandModel cmd) : base(cmd)
        {
            this.Pet = pet;
            this.Options = new[] { "hunting", "hunt" };
        }
        public override MessageResult Invoke()
        {
			var timeLength = new TimeSpan(0, 0, 20);
			UpdateHuntingStatus(Pet);
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

		private void UpdateHuntingStatus(TamagochiModel pet)
		{
			if (pet.CurrentStatus == EStatus.HUNT)
			{
				if (pet.Hunting.SavedSendTime + pet.Hunting.SendTimeLength < DateTime.Now)
				{
					pet.CurrentStatus = pet.LastStatus;
					pet.Backpack.AddIdString(pet.Hunting.WaitingItems);
					pet.Level.CurrentExp += 5 * pet.Hunting.WaitingItems.Split(',').Length;
				}
			}
		}
	}
}
