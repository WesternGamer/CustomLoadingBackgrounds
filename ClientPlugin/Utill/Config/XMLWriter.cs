using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CustomScreenBackgrounds.Utill.Config
{
    internal class XMLWriter
    {
        public static void Init()
        {
            if (Directory.GetFiles(FileSystem.ConfigFolderPath, "config.xml").Length == 0)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = ("    ");
                settings.CloseOutput = true;
                settings.OmitXmlDeclaration = true;
                using (XmlWriter writer = XmlWriter.Create(FileSystem.ConfigFolderPath + "\\config.xml", settings))
                {
                    writer.WriteStartElement("Overlays");
                    writer.WriteElementString("MainMenuOverlay", "false");
                    writer.WriteElementString("MainMenuOverlay2", "false");
                    writer.WriteElementString("LoadingScreenOverlay", "false");
                    writer.WriteElementString("MainMenuDlcIcons", "false");
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }
        }
    }
}
