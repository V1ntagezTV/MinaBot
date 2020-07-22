using Discord;
using MinaBot.BotPackValues;
using MinaBot.Main;
using MinaBot.Models;
using System;
using static MinaBot.BotTamagochi.BotPackValues.AClothesType;

namespace MinaBot.Controllers
{
    class TamagochiController: IController
    {
        private AuthorModel model;
        public TamagochiController(AuthorModel model)
        {
            this.model = model;
        }
        IModel IController.GetModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Backpack GetBackpack() => model.GetTamagochi.backpack;
        public string GetName() => model.GetTamagochi.name;
        public string GetStatus() => model.GetTamagochi.status;
        public uint GetHealth() => model.GetTamagochi.health;
        public string GetUrl() => model.GetTamagochi.avatarUrl;
        public uint GetLevel() => model.GetTamagochi.level;
        public int GetAge() => model.GetTamagochi.AgeDays;
        public uint GetHungry() => model.GetTamagochi.hungry;
        public uint GetThirsty() => model.GetTamagochi.thirsty;
        public DateTime GetBirthday() => model.GetTamagochi.birthday;
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
