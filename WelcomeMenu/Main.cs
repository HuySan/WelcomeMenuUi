using WelcomeMenu.Types;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;

namespace WelcomeMenu
{
    public static class Main
    {
        public static void OpenUI(this UnturnedPlayer uPlayer, Button button = null)
        {
            try
            {
                //делаем неактивным дефолтный ui, блочим движение игрока, отображаем мышку
                uPlayer.Player.setPluginWidgetFlag(EPluginWidgetFlags.Modal, true);
                uPlayer.Player.disablePluginWidgetFlag(EPluginWidgetFlags.Default);
                //врубаем эффект
                EffectManager.sendUIEffect(Plugin.Instance.Configuration.Instance.EffectId, Plugin.Instance.Configuration.Instance.EffectKey, uPlayer.CSteamID, true);
                EffectManager.sendUIEffectText(Plugin.Instance.Configuration.Instance.EffectKey, uPlayer.CSteamID, true, "MenuCloseText", Plugin.Instance.Configuration.Instance.CloseText.ToRich());

                // Включаем кнопки и даем им имена
                foreach (var buttonFromConfig in Plugin.Instance.Configuration.Instance.Buttons)
                {
                    EffectManager.sendUIEffectText(Plugin.Instance.Configuration.Instance.EffectKey, uPlayer.CSteamID, true, buttonFromConfig.Id + ".text", buttonFromConfig.Name.ToRich());
                    EffectManager.sendUIEffectVisibility(Plugin.Instance.Configuration.Instance.EffectKey, uPlayer.CSteamID, true, buttonFromConfig.Id, true);
                }

                if (button == null)
                    button = Plugin.Instance.Configuration.Instance.Buttons[0];

                EffectManager.sendUIEffectVisibility(Plugin.Instance.Configuration.Instance.EffectKey, uPlayer.CSteamID, true, button.Type == EButton.Text ? "ScrollAreaText" : "ScrollImage", true);

                if (button.Type == EButton.Text)
                {
                    EffectManager.sendUIEffectText(Plugin.Instance.Configuration.Instance.EffectKey, uPlayer.CSteamID, true, "ScrollText", button.Text.ToRich().Resize());
                    return;
                }

                foreach (var image in button.Images)
                {
                    int index = Array.IndexOf(button.Images, image);
                    
                    EffectManager.sendUIEffectImageURL(Plugin.Instance.Configuration.Instance.EffectKey, uPlayer.CSteamID, true, $"MainImage.{index}", image.Link);
                    EffectManager.sendUIEffectText(Plugin.Instance.Configuration.Instance.EffectKey, uPlayer.CSteamID, true, $"Desc.{index}", image.Desc.ToRich().Resize());

                    EffectManager.sendUIEffectVisibility(Plugin.Instance.Configuration.Instance.EffectKey, uPlayer.CSteamID, true, $"ImageGroup.{index}", true);
                
                }
            }
            catch (Exception ex)
            {
                Rocket.Core.Logging.Logger.LogException(ex, "Exception in OpenUI()");
            }
        }

        public static void CloseUI(this UnturnedPlayer uPlayer)
        {
            try
            {
                uPlayer.Player.setPluginWidgetFlag(EPluginWidgetFlags.Modal, false);
                uPlayer.Player.enablePluginWidgetFlag(EPluginWidgetFlags.Default);
                EffectManager.askEffectClearByID(Plugin.Instance.Configuration.Instance.EffectId, uPlayer.CSteamID);
            }
            catch (Exception ex)
            {
                Rocket.Core.Logging.Logger.LogException(ex, "Exception in CloseUI()");
            }
        }
        //В unturned ограничение на кол-во символов
        private static string Resize(this string text) => text.Length > 2048 ? text.Remove(2048, text.Length - 2048) : text;

        private static string ToRich(this string text) => text.Replace("{", "<").Replace("}", ">");
    }
}
