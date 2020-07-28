using Discord;
using MinaBot.BotPackValues;
using MinaBot.BotTamagochi.MVC.Tamagochi;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using static MinaBot.BotTamagochi.BotPackValues.AItemCollections;

namespace MinaBot.Controllers
{
    class TamagochiController : IController<TamagochiModel>
    {
        private AuthorModel model;
        public TamagochiModel GetModel { get => model.GetTamagochi; }

        public TamagochiController(AuthorModel model)
        {
            this.model = model;
        }

        public bool WearClothes(int itemInd)
        {
            if (GetModel.Backpack.AllItems().Count < itemInd && itemInd < 0)
                return false;

            var item = GetModel.Backpack.AllItems()[itemInd];

            if (item is Hat) GetModel.Clothes.Hat = item;
            else if (item is Jacket) GetModel.Clothes.Jacket = item;
            else if (item is Pants) GetModel.Clothes.Pants = item;
            else if (item is Boots) GetModel.Clothes.Boots = item;
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
            model.GetTamagochi.Money += item.SoldPrice;
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
            var calledTime = DateTime.Now;
            UpdateStats(calledTime);
            if (GetModel.HP > 0)
            {
                GetModel.Hungry.MainPoints += food.Satiety;
                GetModel.Thirsty.MainPoints += food.Satiety / 2; 
                return true;
            }
            return false;
        }

        public void UpdateStats(DateTime updateTime)
        {
            //pet stats
            var lastTime = GetModel.LastCheckDate;
            while (GetModel.HP > 0)
            {
                if (GetModel.HP <= 0) break;
                lastTime += GetModel.TickLengthTime;
                if (lastTime > updateTime)
                {
                    GetModel.LastCheckDate = updateTime;
                    break;
                }
                else
                {
                    GetModel.Hungry.MainPoints -= GetModel.Hungry.MinusValueInCycle;
                    GetModel.Thirsty.MainPoints -= GetModel.Hungry.MinusValueInCycle;

                    if (GetModel.Hungry.MainPoints + GetModel.Thirsty.MainPoints < 40)
                    {
                        GetModel.HP -= 20;
                    }
                }
            }
            //hunting
            UpdateHuntingStatus();
        }
        private void UpdateHuntingStatus()
        {
            if (GetModel.CurrentStatus == EBotStatus.HUNTING &&
                GetModel.Hunting.SavedSendTime + GetModel.Hunting.SendTimeLength < DateTime.Now)
            {
                GetModel.CurrentStatus = GetModel.LastStatus;
                GetModel.Backpack.AddRange(GetModel.Hunting.WaitingItems);
            }
        }
    }
}
