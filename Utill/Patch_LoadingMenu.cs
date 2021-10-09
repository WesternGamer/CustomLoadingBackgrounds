using HarmonyLib;
using Sandbox.Game.Gui;
using System;
using System.IO;
using System.Linq;
using VRage.FileSystem;

namespace CustomScreenBackgrounds.Utill
{

    [HarmonyPatch(typeof(MyGuiScreenLoading), "GetRandomBackgroundTexture")]
    internal class Patch_LoadingMenu
    {
        private static string Postfix(string __result)
        {
            string folderpath = Path.Combine(MyFileSystem.UserDataPath, "LoadingScreenBackgroundImages");
            if (!Directory.Exists(folderpath))
                Directory.CreateDirectory(folderpath);
            string file = GetRandomFileFromDir(folderpath);
            __result = file;
            return __result;
        }

        private static string GetRandomFileFromDir(string path)
        {
            string file = null;
            if (!string.IsNullOrEmpty(path))
            {
                var extensions = new string[] { ".png", ".dds" };
                try
                {
                    var di = new DirectoryInfo(path);
                    var rgFiles = di.GetFiles("*.*");
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                }
                // probably should only catch specific exceptions
                // throwable by the above methods.
                catch { }
            }
            return file;
        }
    }
}
