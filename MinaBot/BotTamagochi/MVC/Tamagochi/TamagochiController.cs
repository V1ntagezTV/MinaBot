using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.DataTamagochi;
using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.BotTamagochi.MVC.Tamagochi.View;
using MinaBot.Main;
using MinaBot.Models;
using System;
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
                    .Include(t => t.Hunting)
                    .FirstOrDefault(t => t.DiscordId == command.GetMessage.Author.Id);

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
                    case "clothes":
                    case "c":
                        result = new ClothesView().GetView(tamagochi, command);
                        break;

                    case "wear":
                        result = new BooleanView(WearClothes(tamagochi, Convert.ToInt32(command.GetArgs[0])));
                        context.SaveChanges();
                        break;

                    case "hunting":
                        result = new BooleanView(SendToHunting(tamagochi, new TimeSpan(0, 0, 20)));
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

        public bool WearClothes(TamagochiModel pet, int itemInd)
        {
            if (pet.Backpack.Items.Data.Count < itemInd && itemInd < 0)
                return false;

            var item = pet.Backpack.Items[itemInd];
            if (item is Hat) pet.HatID = item.ID;
            else if (item is Jacket) pet.JacketID = item.ID;
            else if (item is Pants) pet.PantsID = item.ID;
            else if (item is Boots) pet.BootsID = item.ID;
            else return false; // item not clothes
            return true;
        }

        public bool SendToHunting(TamagochiModel pet, TimeSpan timeLength)
        {
            UpdateHuntingStatus(pet);
            if (pet.CurrentStatus == EBotStatus.HUNTING)
            {
                return false;
            }
            pet.CurrentStatus = EBotStatus.HUNTING;
            pet.Hunting.SavedSendTime = DateTime.Now;
            pet.Hunting.SendTimeLength = timeLength;
            pet.Hunting.SendToHunting(timeLength);
            return true;
        }

        private void UpdateHuntingStatus(TamagochiModel pet)
        {
            if (pet.CurrentStatus == EBotStatus.HUNTING) 
            {
                if (pet.Hunting.SavedSendTime + pet.Hunting.SendTimeLength < DateTime.Now)
                {
                    pet.CurrentStatus = pet.LastStatus;
                    pet.Backpack.AddIdString(pet.Hunting.WaitingItems);
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
