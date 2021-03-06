﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Actions
{
    public class RoleColorChange : AActionCommand, IHelper
    {
        public string Title => "m!rolecolor <role-mention> <hex-color>";
        public string Description => "Change own role color.";
        public override string[] Options => new[] {"rolecolor"};
        
        public RoleColorChange(CommandModel command) : base(command)
        {
            Command = command;
        }
        
        public override MessageResult Invoke()
        {
            var role = Command.GetMessage.MentionedRoles.First();

            if (role.Members.Count() != 1) return new MessageResult.BooleanView(false);
            if (!role.Members.Contains(Command.GetMessage.Author)) return new MessageResult.BooleanView(false);
            
            var colorHex = (uint) Convert.ToInt32("0x" + Command.GetArgs[0], 16);
            var color = new Color(colorHex);
            Task.Run(() => role.ModifyAsync(properties => properties.Color = new Optional<Color>(color)));
            return new MessageResult.BooleanView(true);
        }
    }
}