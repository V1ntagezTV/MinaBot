using Discord;
using MinaBot.BotPackValues;
using MinaBot.BotTamagochi.MVC.Tamagochi;
using MinaBot.Main;
using MinaBot.Models;
using System;
using static MinaBot.BotTamagochi.BotPackValues.AItemCollections;

namespace MinaBot.Controllers
{
    class TamagochiController: IController
    {
        private StatsController Stats = new StatsController();
        private AuthorModel model;

        public IModel GetModel { get; }

        public TamagochiController(AuthorModel model)
        {
            this.model = model;
            GetModel = (IModel)model;
        }

        public Backpack GetBackpack() => model.GetTamagochi.backpack;
        public string GetName() => model.GetTamagochi.name;
        public string GetStatus() => model.GetTamagochi.status;
        public int GetHealth() => Stats.HP;
        public string GetUrl() => model.GetTamagochi.avatarUrl;
        public uint GetLevel() => model.GetTamagochi.level;
        public int GetAge() => model.GetTamagochi.AgeDays;
        public int GetHappiness()
        {
            Stats.UpdateStats(DateTime.Now);
            return Stats.Happiness.MainPoints;
        }
        public int GetHungry()
        {
            Stats.UpdateStats(DateTime.Now);
            return Stats.Hungry.MainPoints;
        }
        public int GetThirsty()
        {
            Stats.UpdateStats(DateTime.Now);
            return Stats.Thirsty.MainPoints;
        }
        public DateTime GetBirthday() => model.GetTamagochi.Birthday;
        public Clothes GetClothes() => model.GetTamagochi.clothes;
        public int GetMoney() => model.GetTamagochi.Money;
        public bool WearClothes(int itemInd)
        {
            if (GetBackpack().AllClothes().Count < itemInd && itemInd < 0)
                return false;

            var item = GetBackpack().AllClothes()[itemInd];

            if (item is Hat) GetClothes().Hat = item;
            else if (item is Jacket) GetClothes().Jacket = item;
            else if (item is Pants) GetClothes().Pants = item;
            else GetClothes().Boots = item;

            item.Equiped = true;
            return true;
        }
        public bool SoldItem(int itemInd)
        {
            if (GetBackpack().AllClothes().Count < itemInd && itemInd < 0)
                return false;

            var item = GetBackpack().AllClothes()[itemInd];
            GetBackpack().Remove(item);
            model.GetTamagochi.Money += item.SoldPrice;
            if (item.Equiped)
            {
                if (item is Hat) GetClothes().Hat = EBotHats.CLEAR;
                else if (item is Jacket) GetClothes().Jacket = EBotJackets.CLEAR;
                else if (item is Pants) GetClothes().Pants = EBotPants.CLEAR;
                else GetClothes().Boots = EBotBoots.CLEAR;
            }
            return true;
        }
    }
}
