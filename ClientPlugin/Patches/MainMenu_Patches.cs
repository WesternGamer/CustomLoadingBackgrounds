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
        public static MyGuiScreenIntroVideo Video = null;
        public static BackgroundScreen Image;

        private static bool Prefix()
        {
            if (Directory.GetFiles(FileSystem.MainMenuImagesFolderPath, "*.png").Length == 0)
            {
                if (Directory.GetFiles(FileSystem.MainMenuImagesFolderPath, "*.dds").Length == 0)
                {
                    if (Directory.GetFiles(FileSystem.MainMenuVideosFolderPath, "*.wmv").Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        MyGuiSandbox.AddScreen(Video = new MyGuiScreenIntroVideo(Directory.GetFiles(FileSystem.MainMenuVideosFolderPath), true, true, false, 0f, false, 1500, 0U));
                    }
                }
                else
                {
                    MyGuiSandbox.AddScreen(Image = new BackgroundScreen(FileSystem.GetRandomFileFromDir(FileSystem.MainMenuImagesFolderPath)));
                }
            }
            else
            {
                MyGuiSandbox.AddScreen(Image = new BackgroundScreen(FileSystem.GetRandomFileFromDir(FileSystem.MainMenuImagesFolderPath)));
            }
            return false;
        }
    }

    //Patch to fix issue #2 https://github.com/WesternGamer/CustomLoadingBackgrounds/issues/2
    [HarmonyPatch(typeof(MyGuiScreenMainMenu), "CloseScreenNow")]
    internal class Patch_MainMenuVideoPatch
    {
        private static void Prefix()
        {
            if (Patch_MainMenu.Video != null)
            {
                Patch_MainMenu.Video.CloseScreenNow(false);
            }
            Patch_MainMenu.Video = null;

            if (Patch_MainMenu.Image != null)
            {
                Patch_MainMenu.Image.CloseScreenNow(false);
            }
            Patch_MainMenu.Image = null;
        }
    }

    /*
    [HarmonyPatch(typeof(MyGuiScreenMainMenu), MethodType.Constructor)]
    [HarmonyPatch("MyGuiScreenMainMenu")]
    internal class Patch_MainMenuVideoInit
    {
        private static void Postfix(MyGuiScreenMainMenu __instance, MyBadgeHelper ___m_myBadgeHelper)
        {


        }
    }*/
}

