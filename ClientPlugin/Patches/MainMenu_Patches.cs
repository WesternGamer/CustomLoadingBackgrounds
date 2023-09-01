using CustomScreenBackgrounds.GUI;
using CustomScreenBackgrounds.Utill;
using HarmonyLib;
using Sandbox.Game.Gui;
using Sandbox.Graphics.GUI;
using SpaceEngineers.Game.GUI;
using System.IO;
using System.Linq;

namespace CustomScreenBackgrounds.Patches
{
    [HarmonyPatch(typeof(MyGuiScreenMainMenu), "AddIntroScreen")]
    internal class Patch_MainMenu
    {
        public static MyGuiScreenIntroVideo Video = null;
        public static BackgroundScreen Image;

        private static bool Prefix()
        {
            if (FileSystem.GetAllMainMenuScreenImageFiles().Count() != 0)
            {
                MyGuiSandbox.AddScreen(Image = new BackgroundScreen(FileSystem.GetRandomFileFromDir(FileSystem.MainMenuImagesFolderPath), FileSystem.GetRandomFileFromDir(FileSystem.MainMenuCustomOverlaysFolderPath)));
                return false;
            }

            if (FileSystem.GetAllMainMenuScreenVideoFiles().Count() != 0) 
            {
                MyGuiSandbox.AddScreen(Video = new MyGuiScreenIntroVideo(Directory.GetFiles(FileSystem.MainMenuVideosFolderPath), true, true, false, 0f, false, 1500, 0U));
                return false;
            }

            return true;
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
}

