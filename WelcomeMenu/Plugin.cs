using System;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Rocket.API.Collections;
using Rocket.Core;
using Rocket.Core.Utils;
using Logger = Rocket.Core.Logging.Logger;
namespace WelcomeMenu
{
    public class Plugin : RocketPlugin<Config>
    {
        public override TranslationList DefaultTranslations => new TranslationList
        {
            { "syntax", "Используйте данный синтаксис: {0}" },
        };

        public static Plugin Instance { get; private set; }

        protected override void Load()
        {
            Instance = this;

            if (Configuration.Instance.DownloadWorkshop)
                WorkshopDownloadConfig.getOrLoad().File_IDs.Add(2807049332);

            foreach (var button in Configuration.Instance.Buttons)
            {
                if (button.Images == null)
                    continue;

                foreach (var image in button.Images)
                {
                    Console.WriteLine(Encoding.UTF8.GetBytes(image.Desc).Length);
                }
            }

            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
            EffectManager.onEffectButtonClicked += OnClicked;

            Logger.Log("###########################################", ConsoleColor.Magenta);
            Logger.Log("#    Plugin Created By fucking Lincoln    #", ConsoleColor.Magenta);
            Logger.Log("#          Plugin Version: 1.0.0          #", ConsoleColor.Magenta);
            Logger.Log("###########################################", ConsoleColor.Magenta);
            Logger.Log("WelcomeMenuUi has been loaded!", ConsoleColor.Yellow);
            Logger.Log("");
        }

        //Задержка на вызов ui, когда игрок заходит на серв
        private async void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            if (Configuration.Instance.DelayOnConnected == 0) return;

            await Task.Delay(Configuration.Instance.DelayOnConnected);

            TaskDispatcher.QueueOnMainThread(() => player.OpenUI());
        }

        private void OnClicked(Player player, string buttonName)
        {
            try
            {
                var uPlayer = UnturnedPlayer.FromPlayer(player);

                var component = uPlayer.GetComponent<PlayerComponent>();

                if (buttonName == "BtnMenuClose")
                {
                    uPlayer.CloseUI();
                    return;
                }

                var button = Configuration.Instance.Buttons.Find(x => x.Id == buttonName);

                if (button == null)
                    return;

                if ((DateTime.Now - component.LastClick).TotalSeconds < 0.5)
                    return;

                component.LastClick = DateTime.Now;

                if (button.Type == Types.EButton.Link)
                {
                    uPlayer.Player.sendBrowserRequest(button.LinkDesc, button.Link);
                    return;
                }

                if (button.Type == Types.EButton.Command)
                {
                    R.Commands.Execute(uPlayer, button.Command);
                    return;
                }

                uPlayer.OpenUI(button);
            }
            catch (Exception ex)
            {
                Rocket.Core.Logging.Logger.LogException(ex, "Exception in OnClicked()");
            }
        }

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
            EffectManager.onEffectButtonClicked -= OnClicked;
        }
    }
}
