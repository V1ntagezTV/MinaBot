﻿using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Linq;
using static MinaBot.MessageResult;

namespace MinaBot.Controllers
{
    class TamagochiController : IController
	{
		public CommandModel Command { get; }
		public AActionCommand[] Actions { get; set; }
		public TamagochiModel Pet;
		private TamagochiContext Context;

		public TamagochiController(CommandModel commandModel, TamagochiContext context)
		{
			Command = commandModel;
			Context = context;
		}
        private APetActionCommand[] _GetAllPetActions()
        {
			return new APetActionCommand[]
			{
				new ChangeColorAction(Pet, Command),
				new ClothesViewAction(Pet, Command),
				new EatAction(Pet, Command),
				new HuntingSendAction(Pet, Command),
				new InventoryViewAction(Pet, Command),
				new ChangeNameAction(Pet, Command),
				new SoldItemAction(Pet, Command),
				new WearAction(Pet, Command),
				new TakeOffItemAction(Pet, Command),
				new ChangeStatusAction(Pet, Command), 
	        };
        }

		public MessageResult GetResult()
		{
			Pet = Context.GetPetOrDefault(Command.GetMessage.Author.Id);
			if (Command.GetOptions == "create")
			{
				return new CreateAction(Pet, Command, Context).Invoke();
			}
			else if (Command.GetOptions == "delete")
            {
				return new DeleteAction(Pet, Command, Context).Invoke();
            }
			if (Pet == null)
			{
				return new ErrorView("You need create your pet with `m!bot create` command.");
			}
			UpdateStats(DateTime.Now, Pet);
			if (Pet.Health.Score == 0)
			{
				return new ErrorView($"I'm sorry, but your pet: {Pet.ID}{Pet.Name} is dead.\n" +
					$" You need to recreate your tamagochi.");
            }
			// TODO: Не забыдь после выполнения команд нужно ли сохранить изменения.
			// TODO: Проверка на наличие Pet'a в базе должна быть выше.
			Actions = _GetAllPetActions();
			return ChooseActionType(Command.GetOptions);
		}

		public MessageResult ChooseActionType(string? messageOptions)
        {
			if (messageOptions == null) return new TamagochiView(Pet).GetView(Command);

			for (int ind = 0; ind < Actions.Length; ind++)
			{
				var cmd = Actions[ind] as APetActionCommand;
				if (cmd.Options.Contains(messageOptions))
				{
					var resultMessage = cmd.Invoke();
					if (cmd.NeedToSaveInData)
					{
						Context.SaveChanges();
					}
					return resultMessage;
				}
			}
			return new EmptyView();
		}
		
		public void UpdateStats(DateTime updateTime, TamagochiModel pet)
		{
			var pastTime = updateTime - pet.LastCheckDate;
			if (pastTime.TotalMinutes >= 2)
			{
				pet.LastCheckDate = updateTime;
				double timeTo40 = NeedTimeToHungryAndThristyScore(pet, 100);
				pet.Hungry.Score -= pastTime.TotalMinutes * pet.Hungry.MinusEveryMinute;
				pet.Thirsty.Score -= pastTime.TotalMinutes * pet.Thirsty.MinusEveryMinute;
				pet.Happiness.Score -= pastTime.TotalMinutes * pet.Happiness.MinusEveryMinute;
				if (timeTo40 < pastTime.TotalMinutes)
				{
					pet.Health.Score -= (pastTime.TotalMinutes - timeTo40) * pet.Health.MinusEveryMinute;
				}
			}
			UpdateHuntingStatus(pet);
		}
		
		public static void UpdateHuntingStatus(TamagochiModel pet)
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

		public static double NeedTimeToHungryAndThristyScore(TamagochiModel pet, double score)
		{
			double currentScore = pet.Hungry.Score + pet.Thirsty.Score;
			if (currentScore < score)
			{
				return 0.0;
			}
			double timeToScoreHungry = pet.Hungry.Score / pet.Hungry.MinusEveryMinute;
			double timeToScoreThristy = pet.Thirsty.Score / pet.Thirsty.MinusEveryMinute;
			double expectedTimeToScore = (currentScore - score) / (pet.Hungry.MinusEveryMinute + pet.Thirsty.MinusEveryMinute);
			if (expectedTimeToScore < timeToScoreHungry && expectedTimeToScore < timeToScoreThristy)
			{
				return expectedTimeToScore;
			}
			expectedTimeToScore = Math.Min(timeToScoreHungry, timeToScoreThristy);
			double tempScore = currentScore - (pet.Hungry.MinusEveryMinute + pet.Thirsty.MinusEveryMinute) * expectedTimeToScore;
			bool existHungry = (timeToScoreHungry > timeToScoreThristy);
			double existVelocity = existHungry ? pet.Hungry.MinusEveryMinute : pet.Thirsty.MinusEveryMinute;
			return expectedTimeToScore + (tempScore - score) / existVelocity;
		}
	}
}
