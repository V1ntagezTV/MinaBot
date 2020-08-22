﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Drawing;
using System.Linq;
using static MinaBot.BotTamagochi.BotPackValues.ItemTypes;
using static MinaBot.MessageResult;

namespace MinaBot.Controllers
{
	class TamagochiController : IController<TamagochiModel>
	{
		private CommandModel command;
		public TamagochiModel GetModel { get; set; }
		public TamagochiController(CommandModel commandModel)
		{
			command = commandModel;
		}

		public MessageResult ChooseMessageResult()
		{
			MessageResult result;
			using (var context = new TamagochiContext())
			{
				TamagochiModel tamagochi = context.Data
					.Include(t => t.Happiness)
					.Include(t => t.Health).Include(t => t.Hungry)
					.Include(t => t.Thirsty).Include(t => t.Backpack)
					.Include(t => t.Hunting).Include(t => t.Level)
					.FirstOrDefault(t => t.DiscordId == command.GetMessage.Author.Id);

				if (command.GetOptions == "create")
				{
					if (tamagochi != null)
                    {
						context.Remove(tamagochi);
						context.SaveChanges();
                    }
					tamagochi = context.CreateAndAddTamagochi(command.GetMessage.Author.Id).Result;
					return new TamagochiView().GetView(tamagochi, command);
				}
				else if (tamagochi == null)
				{
					return new ErrorView("You need create your pet with `m!bot create` command.");
				}
				UpdateStats(DateTime.Now, tamagochi);
				if (tamagochi.Health.Score == 0)
                {
					return new ErrorView($"I'm sorry, but your pet: {tamagochi.ID}#{tamagochi.Name} is dead.\n" +
						$" You need to recreate your tamagochi.");
                }

				switch (command.GetOptions)
				{
					case "name":
						result = ChangeName(tamagochi, command.GetArgs[0]);
						context.SaveChanges();
						break;

					case "clothes":
					case "c":
						result = new ClothesView().GetView(tamagochi, command);
						break;

					case "wear":
						result = WearClothes(tamagochi, Convert.ToInt32(command.GetArgs[0]));
						context.SaveChanges();
						break;

					case "hunting":
						result = SendToHunting(tamagochi, new TimeSpan(0, 0, 20));
						context.SaveChanges();
						break;

					case "eat":
						result = EatItem(tamagochi, Convert.ToInt32(command.GetArgs[0]));
						context.SaveChanges();
						break;

                    case "inventory":
						result = new InventoryView().GetView(tamagochi, command);
						break;

					case "color":
						result = ChangeColor(tamagochi, command.GetArgs[0]);
						context.SaveChanges();
						break;

					case "sold":
						result = SoldItem(tamagochi, command.GetArgs[0]);
						context.SaveChanges();
						break;

					default:
						result = new TamagochiView().GetView(tamagochi, command);
						context.SaveChanges();
						break;
				}
				return result;
			}
		}

		public MessageResult ChangeColor(TamagochiModel pet, string hex)
		{
			pet.Color = "0x" + hex;
			return new BooleanView(true);
		}

		public MessageResult ChangeName(TamagochiModel pet, string newName)
		{
			if (newName.Length <= 10)
			{
				pet.Name = newName;
				return new BooleanView(true);
			}
			return new ErrorView("Max name length is 10!");
		}

		public MessageResult WearClothes(TamagochiModel pet, int itemInd)
		{
			if (pet.Backpack.Lenght < itemInd || itemInd < 0)
				return new ErrorView("Item index was wrong!");

			var item = pet.Backpack.Items[itemInd];
			if (item is Hat) pet.HatID = item.ID;
			else if (item is Jacket) pet.JacketID = item.ID;
			else if (item is Pants) pet.PantsID = item.ID;
			else if (item is Boots) pet.BootsID = item.ID;
			else return new ErrorView($"You can't wear this item!\nIndex{itemInd}");// item not clothes
			pet.Level.CurrentExp += 10;
			return new BooleanView(true);
		}

		public MessageResult SoldItem(TamagochiModel pet, string itemsInd)
		{
			var itemsRange = itemsInd.Split('-').Select(num => Convert.ToInt32(num));
			if (itemsRange.Count() == 1)
            {
				var itemIndex = itemsRange.ElementAt(0) - 1;
				if (!pet.Backpack.isIndexInBackpackRange(itemIndex))
                {
					return new BooleanView(false);
				}
				var item = pet.Backpack.Items[itemIndex];
				pet.Backpack.Remove(itemIndex);
				pet.Money += item.SoldPrice;
				return new BooleanView(true);
			}
			else if (itemsRange.Count() == 2)
            {
				var start = itemsRange.ElementAt(0) - 1;
				var end = itemsRange.ElementAt(1) - 1;
				if (!pet.Backpack.isIndexInBackpackRange(start) || !pet.Backpack.isIndexInBackpackRange(end))
				{
					return new BooleanView(false);
				}
				for (int ind = start; ind < end; ind++)
                {
					pet.Money += pet.Backpack.Items[ind].SoldPrice;
                }
				return new BooleanView(pet.Backpack.RemoveRange(start, end + 1));
			}
			else
            {
				return new BooleanView(false);
			}
		}
		
		public MessageResult EatItem(TamagochiModel pet, int itemInd)
		{
			if (pet.Backpack.Lenght < itemInd || itemInd < 0)
				return new ErrorView("Item index was wrong!");

			var item = pet.Backpack.Items[itemInd];
			if (item is Food food)
			{
				pet.Hungry.Score += food.Satiety;
				pet.Backpack.Remove(itemInd);
				pet.Level.CurrentExp += 10;
				return new BooleanView(true);
			}
			return new ErrorView("This item is not Food!");

		}

		public MessageResult SendToHunting(TamagochiModel pet, TimeSpan timeLength)
		{
			UpdateHuntingStatus(pet);
			if (pet.CurrentStatus == EBotStatus.HUNTING)
			{
				return new BooleanView(false);
			}
			pet.CurrentStatus = EBotStatus.HUNTING;
			pet.Hunting.SavedSendTime = DateTime.Now;
			pet.Hunting.SendTimeLength = timeLength;
			pet.Hunting.SendToHunting(timeLength);
			return new BooleanView(true);
		}

		private void UpdateHuntingStatus(TamagochiModel pet)
		{
			if (pet.CurrentStatus == EBotStatus.HUNTING) 
			{
				if (pet.Hunting.SavedSendTime + pet.Hunting.SendTimeLength < DateTime.Now)
				{
					pet.CurrentStatus = pet.LastStatus;
					pet.Backpack.AddIdString(pet.Hunting.WaitingItems);
					Console.WriteLine(5 * pet.Hunting.WaitingItems.Split(',').Length);
					pet.Level.CurrentExp += 5 * pet.Hunting.WaitingItems.Split(',').Length;
				}
			}
		}

		public void UpdateStats(DateTime updateTime, TamagochiModel pet)
		{
			//pet stats
			var pastTime = updateTime - pet.LastCheckDate;

			if (pastTime.TotalMinutes >= 2)
			{
				pet.LastCheckDate = updateTime;
				pet.Hungry.Score -= pastTime.TotalMinutes * pet.Hungry.MinusEveryMinute;
				pet.Thirsty.Score -= pastTime.TotalMinutes * pet.Thirsty.MinusEveryMinute;
				pet.Happiness.Score -= pastTime.TotalMinutes * pet.Happiness.MinusEveryMinute;
				if (pet.Hungry.Score + pet.Thirsty.Score < 40)
				{
					var pastHealthPoints = 40 - (pet.Hungry.Score + pet.Thirsty.Score);
					pet.Health.Score -= pastHealthPoints / (pet.Hungry.MinusEveryMinute + pet.Thirsty.MinusEveryMinute);
				}
			}
			//hunting
			UpdateHuntingStatus(pet);
		}
	}
}
