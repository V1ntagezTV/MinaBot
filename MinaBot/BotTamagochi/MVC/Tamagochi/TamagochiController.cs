using Discord;
using MinaBot.Main;
using MinaBot.Models;
using System;

namespace MinaBot.Controllers
{
    class TamagochiController: IController
    {
        public TamagochiController(AuthorModel model)
        {
            this.model = model;
        }
        private AuthorModel model;
        IModel IController.GetModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Backpack GetBackpack() => model.GetTamagochi.backpack;
        public string GetTitle() => model.GetTamagochi.name;
        public string GetStatus() => model.GetTamagochi.status;
        public uint GetHealth() => model.GetTamagochi.health;
        public string GetUrl() => model.GetTamagochi.avatarUrl;
        public uint GetLevel() => model.GetTamagochi.level;
        public int GetAge() => model.GetTamagochi.AgeDays;
        public uint GetHungry() => model.GetTamagochi.hungry;
        public uint GetThirsty() => model.GetTamagochi.thirsty;
        public DateTime GetBirthday() => model.GetTamagochi.birthday;
        public Clothes GetClothes() => model.GetTamagochi.clothes;
        public int getMoney() => model.GetTamagochi.Money;

        public EmbedFieldBuilder GetFieldClothes => new EmbedFieldBuilder()
        {
            Name = "`Clothes:`",
            Value = model.GetTamagochi.clothes.ToString()
        };

        public EmbedFieldBuilder GetFieldBackpack => new EmbedFieldBuilder()
        {
            Name = "`Backpack:`",
            Value = model.GetTamagochi.backpack.ToString()
        };
        public EmbedFieldBuilder GetFieldStats => new EmbedFieldBuilder()
        {
            Name = "`Stats:`",
            Value = model.GetTamagochi.status + "\n"
                    + model.GetTamagochi.level + "\n"
                    + model.GetTamagochi.Money
        };
    }
}
