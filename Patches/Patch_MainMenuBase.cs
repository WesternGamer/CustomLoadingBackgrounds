using CustomScreenBackgrounds.Utill;
using CustomScreenBackgrounds.Utill.Config;
using HarmonyLib;
using Sandbox.Game.Gui;
using Sandbox.Game.Screens;
using Sandbox.Graphics;
using Sandbox.Graphics.GUI;
using VRageMath;

namespace CustomScreenBackgrounds.Patches
{
    [HarmonyPatch(typeof(MyGuiScreenMainMenuBase), "Draw")]
    internal class Patch_MainMenuBase
    {
        private static string Image = FileSystem.GetRandomFileFromDir(FileSystem.MainMenuImagesFolderPath);

        private static void Prefix(float ___m_transitionAlpha)
        { 
            if (Patch_MainMenu.DrawBackground == true && MyGuiScreenGamePlay.Static == null)
            {
                Color color = new Color(255, 255, 255, 250);
                color.A = (byte)((float)color.A * ___m_transitionAlpha);
                Rectangle fullscreenRectangle = MyGuiManager.GetFullscreenRectangle();
                MyGuiManager.DrawSpriteBatch("Textures\\GUI\\Blank.dds", fullscreenRectangle, Color.Black, false, true);
                Rectangle destinationRectangle;
                MyGuiManager.GetSafeHeightFullScreenPictureSize(MyGuiConstants.LOADING_BACKGROUND_TEXTURE_REAL_SIZE, out destinationRectangle);
                MyGuiManager.DrawSpriteBatch(Image, destinationRectangle, new Color(new Vector4(1f, 1f, 1f, ___m_transitionAlpha)), true, true);
                if (XMLReader.MainMenuOverlay)
                {
                    MyGuiManager.DrawSpriteBatch("Textures\\Gui\\Screens\\screen_background_fade.dds", destinationRectangle, new Color(new Vector4(1f, 1f, 1f, ___m_transitionAlpha)), true, true);
                }
                if (XMLReader.MainMenuOverlay2)
                {
                    MyGuiManager.DrawSpriteBatch("Textures\\Gui\\Screens\\main_menu_overlay.dds", destinationRectangle, new Color(new Vector4(1f, 1f, 1f, ___m_transitionAlpha)), true, true);
                }
            }
        }
    }
}
