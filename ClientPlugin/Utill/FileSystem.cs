using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using VRage.FileSystem;

namespace CustomScreenBackgrounds.Utill
{
    internal class FileSystem
    {
        public static string RootFolderPath;
        public static string MainMenuImagesFolderPath;
        public static string MainMenuVideosFolderPath;
        public static string CustomOverlaysFolderPath;
        public static string MainMenuCustomOverlaysFolderPath;
        public static string LoadingMenuCustomOverlaysFolderPath;
        public static string ConfigFolderPath;

        public static void Init()
        {
            RootFolderPath = Path.Combine(MyFileSystem.UserDataPath, "LoadingScreenBackgroundImages");
            if (!Directory.Exists(RootFolderPath))
            {
                Directory.CreateDirectory(RootFolderPath);
            }

            MainMenuImagesFolderPath = Path.Combine(RootFolderPath, "MainMenuScreenBackgroundImages");
            if (!Directory.Exists(MainMenuImagesFolderPath))
            {
                Directory.CreateDirectory(MainMenuImagesFolderPath);
            }

            MainMenuVideosFolderPath = Path.Combine(RootFolderPath, "MainMenuScreenBackgroundVideos");
            if (!Directory.Exists(MainMenuVideosFolderPath))
            {
                Directory.CreateDirectory(MainMenuVideosFolderPath);
            }

            CustomOverlaysFolderPath = Path.Combine(RootFolderPath, "CustomOverlays");
            if (!Directory.Exists(CustomOverlaysFolderPath))
            {
                Directory.CreateDirectory(CustomOverlaysFolderPath);
            }

            MainMenuCustomOverlaysFolderPath = Path.Combine(CustomOverlaysFolderPath, "MainMenu");
            if (!Directory.Exists(MainMenuCustomOverlaysFolderPath))
            {
                Directory.CreateDirectory(MainMenuCustomOverlaysFolderPath);
            }

            LoadingMenuCustomOverlaysFolderPath = Path.Combine(CustomOverlaysFolderPath, "LoadingMenu");
            if (!Directory.Exists(LoadingMenuCustomOverlaysFolderPath))
            {
                Directory.CreateDirectory(LoadingMenuCustomOverlaysFolderPath);
            }

            ConfigFolderPath = Path.Combine(RootFolderPath, "Config");
            if (!Directory.Exists(ConfigFolderPath))
            {
                Directory.CreateDirectory(ConfigFolderPath);
            }
        }

        public static string GetRandomFileFromDir(string path)
        {
            string file = null;
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    FileInfo[] rgFiles = di.GetFiles("*.*");
                    RandomNumberGenerator rng = RandomNumberGenerator.Create();
                    byte[] data = new byte[4];
                    rng.GetBytes(data);
                    int value = BitConverter.ToInt32(data, 0);
                    Random R = new Random(value);
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
