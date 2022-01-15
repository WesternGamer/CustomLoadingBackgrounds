using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace CustomScreenBackgrounds.Utill.Config
{
    internal class XMLReader
    {
        public static bool MainMenuOverlay;
        public static bool MainMenuOverlay2;
        public static bool LoadingScreenOverlay;
        public static bool CleanLoadingMenu;
        private readonly string XmlLocation;

        public XMLReader(string xmlLocation)
        {
            XmlLocation = xmlLocation;
            VerifyVersion();
            LoadData();
        }

        private bool ConvertStringToBool(string str)
        {
            if (str.ToLower() == "true")
            {
                return true;
            }

            if (str.ToLower() == "false")
            {
                return false;
            }

            return false;
        }

        private void LoadData()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlLocation);

            XmlNode MainMenuOverlayNode = doc.SelectSingleNode("//Config//OverlaySettings//MainMenuOverlay");
            MainMenuOverlay = ConvertStringToBool(MainMenuOverlayNode.InnerText);

            XmlNode MainMenuOverlay2Node = doc.SelectSingleNode("//Config//OverlaySettings//MainMenuOverlay2");
            MainMenuOverlay2 = ConvertStringToBool(MainMenuOverlay2Node.InnerText);

            XmlNode LoadingScreenOverlayNode = doc.SelectSingleNode("//Config//OverlaySettings//LoadingScreenOverlay");
            LoadingScreenOverlay = ConvertStringToBool(LoadingScreenOverlayNode.InnerText);

            XmlNode CleanLoadingMenuNode = doc.SelectSingleNode("//Config//CleanLoadingMenu");
            CleanLoadingMenu = ConvertStringToBool(CleanLoadingMenuNode.InnerText);
        }

        private void VerifyVersion()
        {
            string xmlFile = XmlLocation;

            XDocument xml = XDocument.Load(xmlFile);

            if (!xml.Descendants().Elements("Version").Any())
            {
                ReadV1_2Data();
                XMLWriter.UpdateTo1_3();
            }
        }

        private void ReadV1_2Data()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlLocation);

            XmlNode MainMenuOverlayNode = doc.SelectSingleNode("//Overlays//MainMenuOverlay");
            MainMenuOverlay = ConvertStringToBool(MainMenuOverlayNode.InnerText);

            XmlNode MainMenuOverlay2Node = doc.SelectSingleNode("//Overlays//MainMenuOverlay2");
            MainMenuOverlay2 = ConvertStringToBool(MainMenuOverlay2Node.InnerText);

            XmlNode LoadingScreenOverlayNode = doc.SelectSingleNode("//Overlays//LoadingScreenOverlay");
            LoadingScreenOverlay = ConvertStringToBool(LoadingScreenOverlayNode.InnerText);
        }
    }
}
