using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using MinaBot.Base.ActionInterfaces;
using MinaBot.BotTamagochi.MVC.Tamagochi.Actions;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Actions
{
    public class RoleNameChange : AActionCommand, IHelper
    {
        public string Title => "**m!rolename <name>**";
        public string Description => "Set new role name to your own role.";
        public override string[] Options => new []{"rolename"};
        
        public RoleNameChange(CommandModel command) : base(command) { }

        public override MessageResult Invoke()
        {
            var role =  Command.GetMessage.MentionedRoles.First();
            // Checking if that role have only you.
            if (role.Members.Count() != 1) return new MessageResult.BooleanView(false);
            if (!role.Members.Contains(Command.GetMessage.Author)) return new MessageResult.BooleanView(false);

            Task.Run(() => role.ModifyAsync(properties =>
                properties.Name = new Optional<string>(Command.GetArgs[0])));
            return new MessageResult.BooleanView(true);
        }
    }
}