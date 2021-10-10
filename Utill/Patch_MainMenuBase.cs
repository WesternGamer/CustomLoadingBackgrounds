using HarmonyLib;
using Sandbox.Game.Screens;
using Sandbox.Graphics;
using Sandbox.Graphics.GUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRageMath;

namespace CustomScreenBackgrounds.Utill
{
    [HarmonyPatch(typeof(MyGuiScreenMainMenuBase), "Draw")]
    internal class Patch_MainMenuBase
    {
        private static void Prefix(float ___m_transitionAlpha)
        {
            string folderpath = Path.Combine(Main.ImageFolderPath, "MainMenuScreenBackgroundImages");

            if (Patch_MainMenu.DrawBackground == true)
            {
                Color color = new Color(255, 255, 255, 250);
                color.A = (byte)((float)color.A * ___m_transitionAlpha);
                Rectangle fullscreenRectangle = MyGuiManager.GetFullscreenRectangle();
                MyGuiManager.DrawSpriteBatch("Textures\\GUI\\Blank.dds", fullscreenRectangle, Color.Black, false, true);
                Rectangle destinationRectangle;
                MyGuiManager.GetSafeHeightFullScreenPictureSize(MyGuiConstants.LOADING_BACKGROUND_TEXTURE_REAL_SIZE, out destinationRectangle);
                MyGuiManager.DrawSpriteBatch(GetRandomFileFromDir(folderpath), destinationRectangle, new Color(new Vector4(1f, 1f, 1f, ___m_transitionAlpha)), true, true);
            }
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
    }
}
