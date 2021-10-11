using System;
using System.IO;
using System.Linq;
using VRage.FileSystem;

namespace CustomScreenBackgrounds.Utill
{
    internal class FileSystem
    {
        public static string RootFolderPath;
        public static string MainMenuImagesFolderPath;
        public static string MainMenuVideosFolderPath;
        public static string ConfigFolderPath;

        public static void Init()
        {
            RootFolderPath = Path.Combine(MyFileSystem.UserDataPath, "LoadingScreenBackgroundImages");
            if (!Directory.Exists(RootFolderPath))
                Directory.CreateDirectory(RootFolderPath);

            MainMenuImagesFolderPath = Path.Combine(RootFolderPath, "MainMenuScreenBackgroundImages");
            if (!Directory.Exists(MainMenuImagesFolderPath))
                Directory.CreateDirectory(MainMenuImagesFolderPath);

            MainMenuVideosFolderPath = Path.Combine(RootFolderPath, "MainMenuScreenBackgroundVideos");
            if (!Directory.Exists(MainMenuVideosFolderPath))
                Directory.CreateDirectory(MainMenuVideosFolderPath);

            ConfigFolderPath = Path.Combine(RootFolderPath, "Config");
            if (!Directory.Exists(ConfigFolderPath))
                Directory.CreateDirectory(ConfigFolderPath);
        }

        public static string GetRandomFileFromDir(string path)
        {
            string file = null;
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    var di = new DirectoryInfo(path);
                    var rgFiles = di.GetFiles("*.*");
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                }
                catch 
                { 
                }
            }
            return file;
        }
    }
}
