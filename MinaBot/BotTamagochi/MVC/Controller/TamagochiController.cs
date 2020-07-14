using MinaBot.Interfaces;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Controllers
{
    class TamagochiController: IController
    {
        private TamagochiModel model;

        public IModel GetModel { get => model; set => model = (TamagochiModel)value; }

        public TamagochiController(TamagochiModel model)
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
        public int GetAge() => model.AgeDays;
        public uint GetHungry() => model.hungry;
        public uint GetThirsty() => model.thirsty;
        public DateTime GetBirthday() => model.birthday;
        public Clothes GetClothes() => model.clothes;
        public int getMoney() => model.Money;
    }
}
