using System;
using System.Collections.Generic;
using WelcomeMenu.Types;
using Rocket.API;

namespace WelcomeMenu
{
    public class Config : IRocketPluginConfiguration
    {
        public bool DownloadWorkshop;
        public ushort EffectId;
        public short EffectKey;
        public int DelayOnConnected;
        public string CloseText;
        public List<Button> Buttons;
        public void LoadDefaults()
        {
            DownloadWorkshop = true;
            EffectId = 23461;
            EffectKey = 23461;
            DelayOnConnected = 4;
            CloseText = "Закрыть";
            Buttons = new List<Button>
            {
                new Button
                {
                    Id = "btn.0",
                    Name = "WELCOME",
                    Type = EButton.Text,
                    Link = null,
                    Command = null,
                    Text = @"orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the indu
stry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. 
It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the releas
e of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the indu
stry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. 
It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the releas
e of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum
orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the indu
stry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. 
It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the releas
e of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum
orem ",
                    Images = null,
                },

                new Button
                {
                    Id = "btn.1",
                    Name = "UPDATE",
                    Type = EButton.Images,
                    Images = new Image[]
                    {
                        new Image
                        {
                            Desc = @"orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the indu
stry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. 
It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the releas
e of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the indu
stry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. 
It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the releas
e of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum
orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the indu
stry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. 
It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the releas
e of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum
orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the indu
stry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. ",
                            Link = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fwww.xbox-gamer.net%2Fscreens%2F5870_118357_unturned.jpg&f=1&nofb=1"
                        },
                        new Image
                        {
                            Desc = @"orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            Link = "https://tabletadam.com/wp-content/uploads/2019/12/unturned-yukle.png"
                        },
                    }
                },

                new Button
                {
                    Id = "btn.2",
                    Name = "HISTORY",
                    Type = EButton.Images,
                    Images = new Image[]
                    {
                        new Image
                        {
                            Desc = @"Lorem Ipsum is simply dummy text of the printing and typesetting industry simply dummy text of the printing and typesetting industry. simply dummy text of the printing and typesetting industry. simply dummy text of the printing and typesetting industry. simply dummy text of the printing and typesetting industry.. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            Link = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fwww.xbox-gamer.net%2Fscreens%2F5870_118357_unturned.jpg&f=1&nofb=1"
                        },
                    }
                },

                new Button
                {
                    Id = "btn.3",
                    Name = "{color=#FFFFFF}KIT START{/color}",
                    Type = EButton.Command,
                    Command = "/kit start"
                },

                new Button
                {
                    Id = "btn.4",
                    Name = "{color=cyan}DISCORD{/color}",
                    Link = "https://discord.gg/bugG8u6MBX",
                    LinkDesc = "Our discord",
                    Type = EButton.Link,
                }

            };
        }
    }
}