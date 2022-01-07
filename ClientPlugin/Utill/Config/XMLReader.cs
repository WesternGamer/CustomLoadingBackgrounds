using System.Xml;

namespace CustomScreenBackgrounds.Utill.Config
{
    internal class XMLReader
    {
        public static bool MainMenuOverlay;
        public static bool MainMenuOverlay2;
        public static bool LoadingScreenOverlay;
        public static bool CleanLoadingMenu;

        public static void Init()
        {
            using (XmlReader reader = XmlReader.Create(FileSystem.ConfigFolderPath + "\\config.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        //return only when you have START tag  
                        switch (reader.Name.ToString())
                        {
                            case "MainMenuOverlay":
                                MainMenuOverlay = ConvertStringToBool(reader.ReadString());
                                break;
                            case "MainMenuOverlay2":
                                MainMenuOverlay2 = ConvertStringToBool(reader.ReadString());
                                break;
                            case "LoadingScreenOverlay":
                                LoadingScreenOverlay = ConvertStringToBool(reader.ReadString());
                                break;
                            case "CleanLoadingMenu":
                                CleanLoadingMenu = ConvertStringToBool(reader.ReadString());
                                break;
                        }
                    }
                }
            }
        }

        private static bool ConvertStringToBool(string str)
        {
            if (str == "true")
            {
                return true;
            }
            if (str == "false")
            {
                return false;
            }
            return false;
        }
    }
}
