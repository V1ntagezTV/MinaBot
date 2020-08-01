using Microsoft.EntityFrameworkCore;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinaBot.BotTamagochi.DataTamagochi
{
    class TamagochiDbFacade
    {
        public TamagochiContext context;
        public IEnumerable<TamagochiModel> data; 
        public TamagochiDbFacade(TamagochiContext context)
        {
            this.context = context;
            data = context.Data.Include(t => t.Hungry)
                .Include(t => t.Happiness)
                .Include(t => t.Thirsty)
                .Include(t => t.Clothes)
                .Include(t => t.Health)
                .Include(t => t.Hunting)
                .Include(t => t.Backpack);
        }
        public TamagochiModel FindWithDiscordID(ulong id)
        {
            return data.ToList().Find(t => t.DiscordId == id);
        }
        public void CreateTamagochi(ulong id)
        {
            context.Add(new TamagochiModel() { DiscordId = id });
            this.context.SaveChanges();
        }
    }
}
