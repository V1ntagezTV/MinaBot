using MinaBot.Interfaces;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Controllers
{
    class BotController
    {
        private BotModel model;
        public BotController(BotModel model)
        {
            this.model = model;
        }

        public void LevelUp()
        {
            model.level += 1;
            model.toUpLevelScore *= model.level;
        }


        public Backpack GetBackpack() => model.backpack;
        public string GetTitle() => model.name;
        public string GetStatus() => model.status;
        public uint GetHealth() => model.health;
        public string GetUrl() => model.avatarUrl;
        public uint GetLevel() => model.level;
        public int GetAge() => model.ageDays;
        public uint GetHungry() => model.hungry;
        public uint GetThirsty() => model.thirsty;
        public DateTime GetBirthday() => model.birthday;
        public IItem GetHat() => model.clothes.hat;
        public IItem GetJacket() => model.clothes.jacket;
        public IItem GetPants() => model.clothes.pants;
        public IItem GetBoots() => model.clothes.boots;
        public int getMoney() => model.Money;
    }
}
