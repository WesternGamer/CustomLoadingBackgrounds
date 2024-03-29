﻿using CustomScreenBackgrounds.Utill;
using Sandbox.Game.Gui;
using Sandbox.Graphics;
using Sandbox.Graphics.GUI;
using VRageMath;

namespace CustomScreenBackgrounds.GUI
{
    internal class BackgroundScreen : MyGuiScreenBase
    {
        private readonly string Image;
        private string CustomImageOverlay;
        private bool IsCustomImageLoaded = false;
        
        public BackgroundScreen(string image, string customOverlay)
        {
            Image = image;
            CustomImageOverlay = customOverlay;
            DrawMouseCursor = false;
            CanHaveFocus = false;
            m_closeOnEsc = false;
            m_drawEvenWithoutFocus = true;
            m_canCloseInCloseAllScreenCalls = false;
        }
        public override string GetFriendlyName()
        {
            return "BackgroundScreen";
        }

        public override bool Draw()
        {
            if (!base.Draw())
            {
                return false;
            }

            // Hides main menu background image when the character customization screen is open.
            if (MyScreenManager.IsScreenOfTypeOpen(typeof(MyGuiScreenLoadInventory)))
            {
                return false;
            }

            MyGuiManager.GetSafeHeightFullScreenPictureSize(MyGuiConstants.LOADING_BACKGROUND_TEXTURE_REAL_SIZE, out Rectangle destinationRectangle);
            MyGuiManager.DrawSpriteBatch(Image, destinationRectangle, new Color(new Vector4(1f, 1f, 1f, m_transitionAlpha)), true, true);

            if (Plugin.Instance.Config.MainMenuOverlay)
            {
                MyGuiManager.DrawSpriteBatch("Textures\\Gui\\Screens\\screen_background_fade.dds", destinationRectangle, new Color(new Vector4(1f, 1f, 1f, m_transitionAlpha)), true, true);
            }

            if (Plugin.Instance.Config.MainMenuOverlay2)
            {
                MyGuiManager.DrawSpriteBatch("Textures\\Gui\\Screens\\main_menu_overlay.dds", destinationRectangle, new Color(new Vector4(1f, 1f, 1f, m_transitionAlpha)), true, true);
            }

            if (Plugin.Instance.Config.CustomMainMenuOverlay)
            {
                MyGuiManager.DrawSpriteBatch(CustomImageOverlay, destinationRectangle, new Color(new Vector4(1f, 1f, 1f, m_transitionAlpha)), true, true);
            }

            return true;
        }
    }
}
