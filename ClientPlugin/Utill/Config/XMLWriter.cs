using System.IO;
using System.Xml;

namespace CustomScreenBackgrounds.Utill.Config
{
    internal class XMLWriter
    {
        public static void Init()
        {
            if (Directory.GetFiles(FileSystem.ConfigFolderPath, "config.xml").Length == 0)
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = ("    "),
                    CloseOutput = true,
                    OmitXmlDeclaration = true
                };
                using (XmlWriter writer = XmlWriter.Create(FileSystem.ConfigFolderPath + "\\config.xml", settings))
                {
                    writer.WriteStartElement("Overlays");
                    writer.WriteElementString("MainMenuOverlay", "false");
                    writer.WriteElementString("MainMenuOverlay2", "false");
                    writer.WriteElementString("LoadingScreenOverlay", "false");
                    writer.WriteElementString("CleanLoadingMenu", "true");
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }
        }
    }
}
