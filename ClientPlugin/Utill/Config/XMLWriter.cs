using System.IO;
using System.Xml;

namespace CustomScreenBackgrounds.Utill.Config
{
    internal static class XMLWriter
    {
        public static void CreateNewConfigIfNeeded()
        {
            if (Directory.GetFiles(FileSystem.ConfigFolderPath, "config.xml").Length == 0)
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = ("    "),
                    CloseOutput = true
                };
                using (XmlWriter writer = XmlWriter.Create(FileSystem.ConfigFolderPath + "\\config.xml", settings))
                {
                    writer.WriteStartElement("Config");
                    writer.WriteElementString("Version", "1.3");
                    writer.WriteStartElement("OverlaySettings");
                    writer.WriteElementString("MainMenuOverlay", "false");
                    writer.WriteElementString("MainMenuOverlay2", "false");
                    writer.WriteElementString("LoadingScreenOverlay", "false");
                    writer.WriteEndElement();
                    writer.WriteElementString("CleanLoadingMenu", "true");
                    writer.WriteEndElement();
                    writer.Flush();
                    writer.Close();
                }
            }
        }

        public static void UpdateTo1_3()
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = ("    "),
                CloseOutput = true
            };
            using (XmlWriter writer = XmlWriter.Create(FileSystem.ConfigFolderPath + "\\config.xml", settings))
            {
                writer.WriteStartElement("Config");
                writer.WriteElementString("Version", "1.3");
                writer.WriteStartElement("OverlaySettings");
                writer.WriteElementString("MainMenuOverlay", XMLReader.MainMenuOverlay.ToString());
                writer.WriteElementString("MainMenuOverlay2", XMLReader.MainMenuOverlay2.ToString());
                writer.WriteElementString("LoadingScreenOverlay", XMLReader.LoadingScreenOverlay.ToString());
                writer.WriteEndElement();
                writer.WriteElementString("CleanLoadingMenu", "true");
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }
        }
    }
}
