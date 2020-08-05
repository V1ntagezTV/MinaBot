using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.VisualBasic;
using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Main;
using MinaBot.Models;
using Newtonsoft.Json.Schema;
using System;
using System.Linq;
using System.Threading.Tasks;
using static MinaBot.BotTamagochi.BotPackValues.AItemCollections;
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
            using (var context = new TamagochiContext())
            {
                TamagochiModel tamagochi = context.Data
                    .Include(t => t.Clothes).Include(t => t.Happiness)
                    .Include(t => t.Health).Include(t => t.Hungry)
                    .Include(t => t.Thirsty).Include(t => t.Backpack).ThenInclude(l => l.inventory)
                    .Include(t => t.Hunting)
                    .FirstOrDefault(t => t.DiscordId == command.GetMessage.Author.Id);
                MessageResult result;

                if (command.GetOptions == "create")
                {
                    tamagochi = context.CreateAndAddTamagochi(command.GetMessage.Author.Id).Result;
                    return new TamagochiView().GetView(tamagochi, command);
                } 
                else if (tamagochi == null)
                {
                    return new ErrorView("You need create your pet with `m!bot create` command.");
                }

                switch (command.GetOptions)
                {
                    case "inventory":
                    case "i":
                        result = new InventoryView().GetView(tamagochi, command);
                        break;

                    case "clothes":
                    case "c":
                        result = new ClothesView().GetView(tamagochi, command);
                        break;

                    case "test":
                        tamagochi.Backpack.Add(Item.defaultCleanItem);
                        result = new TamagochiView().GetView(tamagochi, command);
                        context.SaveChanges();
                        break;

                    default:
                        UpdateStats(DateTime.Now, tamagochi);
                        result = new TamagochiView().GetView(tamagochi, command);
                        context.SaveChanges();
                        break;
                }
                return result;
            }
        }

        public bool WearClothes(TamagochiModel tamagochi,int itemInd)
        {
            if (tamagochi.Backpack.AllItems().Count < itemInd && itemInd < 0)
                return false;

            var item = tamagochi.Backpack.AllItems()[itemInd];

            if (item is Hat) tamagochi.Clothes.Hat = item;
            else if (item is Jacket) tamagochi.Clothes.Jacket = item;
            else if (item is Pants) tamagochi.Clothes.Pants = item;
            else if (item is Boots) tamagochi.Clothes.Boots = item;
            else return false; // item not clothes
            item.Equiped = true;
            return true;
        }

        public Item GetItemFromBackpack(int itemInd)
        {
            if (GetModel.Backpack.AllItems().Count < itemInd && itemInd < 0)
            {
                throw new Exception("Index was bigger or lower then your backpack size!");
            }
            return GetModel.Backpack.AllItems()[itemInd];
        }

        public bool SoldItem(int itemInd)
        {
            var item = GetItemFromBackpack(itemInd);
            GetModel.Backpack.Remove(item);
            //model.Money += item.SoldPrice;
            if (item.Equiped)
            {
                if (item is Hat) GetModel.Clothes.Hat = Item.defaultCleanItem;
                else if (item is Jacket) GetModel.Clothes.Jacket = Item.defaultCleanItem;
                else if (item is Pants) GetModel.Clothes.Pants = Item.defaultCleanItem;
                else GetModel.Clothes.Boots = Item.defaultCleanItem;
            }
            return true;
        }

        public bool SendToHunting(TimeSpan timeLength)
        {
            if (GetModel.CurrentStatus == EBotStatus.HUNTING)
            {
                return false;
            }
            GetModel.CurrentStatus = EBotStatus.HUNTING;
            GetModel.Hunting.SendToHunting(timeLength);
            return true;
        }

        public bool Consume(int itemInd)
        {
            var item = GetItemFromBackpack(itemInd);
            if (!(item is Food))
            {
                return false;
            }
            var food = item as Food;
            //UpdateStats(DateTime.Now);
            if (GetModel.Health.Score > 0)
            {
                GetModel.Hungry.Score += food.Satiety;
                GetModel.Thirsty.Score += food.Satiety / 2;
                GetModel.Backpack.Remove(itemInd);
                return true;
            }
            return false;
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

        private void UpdateHuntingStatus(TamagochiModel pet)
        {
            if (pet.CurrentStatus != EBotStatus.HUNTING)
            {
                return;
            }
            if (pet.Hunting.SavedSendTime + pet.Hunting.SendTimeLength < DateTime.Now)
            {
                pet.CurrentStatus = pet.LastStatus;
                //GetModel.Backpack.AddRange(GetModel.Hunting.WaitingItems);
            }
        }
    }
}
