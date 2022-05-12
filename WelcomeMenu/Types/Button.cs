using System;
using System.Xml.Serialization;

namespace WelcomeMenu.Types
{
    public class Button
    {
        [XmlAttribute]
        public string Id { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public EButton Type { get; set; }
        public string Link { get; set; }
        public string LinkDesc { get; set; }
        public string Command { get; set; }
        public string Text { get; set; }
        public Image[] Images { get; set; }
    }
}
