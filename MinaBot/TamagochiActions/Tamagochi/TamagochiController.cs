﻿using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using MinaBot.Base;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions.Interfaces;
using MinaBot.Entity;
using MinaBot.TamagochiActions.Tamagochi.Actions;
using static MinaBot.MessageResult;
using MinaBot.TamagochiActions.Tamagochi.Actions.Interfaces;

namespace MinaBot.Controllers
{
    class TamagochiController : IController
    {
	    public CommandModel Command { get; }
		public AActionCommand[] Actions { get; set; }
		public TamagochiModel Pet;
		private DataContext Context;

		public TamagochiController(CommandModel commandModel, DataContext context)
		{
			Command = commandModel;
			Context = context;
		}
		
		public TamagochiController() { }

		public AActionCommand[] GetAllActions()
        {
			return new APetActionCommand[]
			{
				new ChangeColorAction(Pet, Command),
				new ClothesViewAction(Pet, Command),
				new EatAction(Pet, Command),
				new BuyAction(Pet,Command), 
				new HuntingSendAction(Pet, Command),
				new InventoryViewAction(Pet, Command),
				new ChangeNameAction(Pet, Command),
				new SoldItemAction(Pet, Command),
				new WearAction(Pet, Command),
				new TakeOffItemAction(Pet, Command),
				new ChangeStatusAction(Pet, Command),
				new ShopViewAction(Pet, Command),
				new CreateAction(Pet, Command, Context),
				new DeleteAction(Pet, Command, Context),
			};
        }

		public EmbedFieldBuilder GetInfoController()
		{
			return new EmbedFieldBuilder()
			{
				Name = "<a:gifKotRoll:618924584703361035> Tamagochi",
				Value = $"{Icons.Star} *m!pet <command> [arguments]*\n" +
				        string.Join(" | ", GetAllActions()
					        .Select(a => "`" + string.Join(" / ", a.Options) + "`")),
				IsInline = true
			};
		}

		public MessageResult GetResult()
		{
			SocketUser petUser = null;
			if (Command.GetMessage.MentionedUsers.Count == 0)
			{
				petUser = Command.GetMessage.Author;
				Pet = Context.GetPetOrDefault(petUser.Id);
			} else
            {
	            petUser = Command.GetMessage.MentionedUsers.First();
				Pet = Context.GetPetOrDefault(petUser.Id);
			}
			
			Actions = GetAllActions();
			var calledAction = GetActionOrDefault(Command.GetOptions);

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
				return new ErrorView($"{petUser.Mention} need create pet with `m!pet create` command.");
			}
			UpdateStats(DateTime.Now, Pet);
			if (Pet.Health.Score == 0)
			{
				return new ErrorView($"Your pet: {Pet.ID}{Pet.Name} is dead.\n" +
					$" You need to recreate your tamagochi.");
            }
			return InvokeAction(calledAction);
		}

		private MessageResult InvokeAction(APetActionCommand? action)
		{
			if (action == null) return new EmptyView();
			MessageResult result;
			if (Pet.UserModel.DiscordId == Command.GetMessage.Author.Id)
            {
				result = action.Invoke();
			} else
            {
				if (action is ICheckable)
				{
					result = action.Invoke();
				}
				else
				{
					return new EmptyView();
				}
            }
			if (action is IGetExperiance expAction)
			{
				var lastLevel = Pet.Level.Level;
				Pet.Level.CurrentExp += expAction.GetExp();
				if (lastLevel < Pet.Level.Level)
				{
				   Task.Run(() => new LevelUpAction(Pet, Command).SendResultInChannel());
				}
			}
			Context.SaveChanges();
			return result;
		}

		private APetActionCommand GetActionOrDefault(string? actionOptions)
        {
	        if (actionOptions == null) return new PetViewAction(Pet, Command); //message: m!pet
			if (actionOptions.StartsWith("<@!")) return new PetViewAction(Pet, Command); //message m!pet <@!userId>
			for (var ind = 0; ind < Actions.Length; ind++)
			{
				var cmd = Actions[ind] as APetActionCommand;
				if (cmd.Options.Contains(actionOptions))
				{
					return cmd;
				}
			}
	        return null;
        }
		
		private void UpdateStats(DateTime updateTime, TamagochiModel pet)
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
					pet.Backpack.AddRange(pet.Hunting.WaitingItems);
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
