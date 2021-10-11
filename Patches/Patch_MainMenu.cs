using CustomScreenBackgrounds.Utill;
using HarmonyLib;
using Sandbox.Game.Gui;
using Sandbox.Graphics.GUI;
using SpaceEngineers.Game.GUI;
using System.IO;

namespace CustomScreenBackgrounds.Patches
{
    [HarmonyPatch(typeof(MyGuiScreenMainMenu), "AddIntroScreen")]
    internal class Patch_MainMenu
    {
        public static bool DrawBackground = false;

        private static bool Prefix(MyGuiScreenIntroVideo ___m_backgroundScreen)
        {
            if (Directory.GetFiles(FileSystem.MainMenuImagesFolderPath, "*.png").Length == 0)
            {
                if (Directory.GetFiles(FileSystem.MainMenuImagesFolderPath, "*.dds").Length == 0)
                {
                    if (Directory.GetFiles(FileSystem.MainMenuVideosFolderPath, "*.wmv").Length == 0)
                    {
                        MyGuiSandbox.AddScreen(___m_backgroundScreen = MyGuiScreenIntroVideo.CreateBackgroundScreen());
                    }
                    else
                    {
                        MyGuiSandbox.AddScreen(___m_backgroundScreen = new MyGuiScreenIntroVideo(Directory.GetFiles(FileSystem.MainMenuVideosFolderPath), true, true, false, 0f, false, 1500, 0U));
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
    }
}
