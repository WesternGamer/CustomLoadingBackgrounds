using HarmonyLib;
using Sandbox.Game.Gui;
using Sandbox.Graphics;
using Sandbox.Graphics.GUI;
using SpaceEngineers.Game.GUI;
using System;
using System.IO;
using System.Linq;
using VRageMath;

namespace CustomScreenBackgrounds.Utill
{
    [HarmonyPatch(typeof(MyGuiScreenMainMenu), "AddIntroScreen")]
    internal class Patch_MainMenu
    {
        public static bool DrawBackground = false;
        private static bool Prefix(MyGuiScreenIntroVideo ___m_backgroundScreen, float ___m_transitionAlpha)
        {
            string folderpath = Path.Combine(Main.ImageFolderPath, "MainMenuScreenBackgroundImages");

            if (!Directory.Exists(folderpath))
            { 
                Directory.CreateDirectory(folderpath); 
            }
                
            if (Directory.GetFiles(folderpath,"*.png").Length == 0)
            {
                if (Directory.GetFiles(folderpath, "*.dds").Length == 0)
                {
                    if (Directory.GetFiles(folderpath, "*.wmv").Length == 0)
                    {
                        MyGuiSandbox.AddScreen(___m_backgroundScreen = MyGuiScreenIntroVideo.CreateBackgroundScreen());
                    }
                    else
                    {
                        MyGuiSandbox.AddScreen(___m_backgroundScreen = new MyGuiScreenIntroVideo(GetFileList(), true, true, false, 0f, false, 1500, 0U));
                    }
                }
                else
                {
                    DrawBackground = true;
                }
            }
            else
            {
                DrawBackground = true;
            }
            return false;
        }

        private static string GetRandomFileFromDir(string path)
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
                // probably should only catch specific exceptions
                // throwable by the above methods.
                catch { }
            }
            return file;
        }

        private static string[] GetFileList()
        {
            return Directory.GetFiles(Main.ImageFolderPath);
        }
    }
}
