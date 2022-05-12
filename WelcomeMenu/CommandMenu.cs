using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using UnityEngine;

namespace WelcomeMenu
{
    class CommandMenu : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "menu";

        public string Help => "";

        public string Syntax => "Just only /menu";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string> { "command.menu" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var uPlayer = (UnturnedPlayer)caller;
            if (command.Length != 0)
            {
                UnturnedChat.Say(uPlayer, Plugin.Instance.Translate("syntax", Syntax), Color.red);
                return;
            }
            uPlayer.OpenUI();
        }
    }
}
