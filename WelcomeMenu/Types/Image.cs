using System.Xml.Serialization;

namespace WelcomeMenu.Types
{
    public class Image
    {
        [XmlAttribute]
        public string Link { get; set; }
        public string Desc { get; set; }
    }
}
