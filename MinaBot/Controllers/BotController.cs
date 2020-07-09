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

        public string GetTitle() => model.name;
        public string GetStatus() => model.status;
        public uint GetHealth() => model.health;
        public string GetUrl() => model.avatarUrl;
        public uint GetLevel() => model.level;
        public int GetAge() => model.ageDays;
        public uint GetHungry() => model.hungry;
        public uint GetThirsty() => model.thirsty;
        public DateTime GetBirthday() => model.birthday;
        public string GetHat() => model.clothes.hat;
        public string GetJacket() => model.clothes.jacket;
        public string GetPants() => model.clothes.pants;
        public string GetBoots() => model.clothes.boots;
    }
}
