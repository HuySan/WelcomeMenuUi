using Rocket.Unturned.Player;
using System;

namespace WelcomeMenu
{
    class PlayerComponent : UnturnedPlayerComponent
    {
        public DateTime LastClick = DateTime.Now;
        protected override void Load()
        {

        }
    }
}
