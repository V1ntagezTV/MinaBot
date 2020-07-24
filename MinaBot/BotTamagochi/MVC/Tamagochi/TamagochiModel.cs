﻿using Discord;
using MinaBot.BotTamagochi.MVC.Tamagochi;
using MinaBot.Main;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Security;
using System.Text;

namespace MinaBot.Models
{
    class TamagochiModel: IModel
    {
        public TamagochiModel()
        {
            Birthday = DateTime.Now;
        }

        public Color color = Color.DarkRed;
        public uint level = 1;
        public string status = EBotStatus.SLIGHT_SMILE;
        public string name { get; private set; } = "Myoui Mina";
        public string avatarUrl = @"https://i.pinimg.com/736x/16/f9/60/16f960c5ba68b8f0b88f1c571e8bf9ce--kim-taehyung-twice-cute.jpg";
        public uint toUpLevelScore = 100;
        public int Money = 200000;
        public int AgeDays { get => (DateTime.Now - Birthday).Days + 1; }
        public Clothes clothes = new Clothes();
        public Backpack backpack = new Backpack(10);
        public DateTime Birthday { get; }
    }
}
