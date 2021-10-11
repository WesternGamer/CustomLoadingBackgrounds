using CustomScreenBackgrounds.Utill;
using CustomScreenBackgrounds.Utill.Config;
using HarmonyLib;
using Sandbox.Game.Gui;
using Sandbox.Graphics;
using Sandbox.Graphics.GUI;
using System.Text;
using VRage;
using VRage.Utils;
using VRageMath;

namespace CustomScreenBackgrounds.Patches
{
    [HarmonyPatch(typeof(MyGuiScreenLoading), "DrawInternal")]
    internal class Patch_LoadingMenu
	{
		private static string RandomImage = FileSystem.GetRandomFileFromDir(FileSystem.RootFolderPath);

		private static bool Prefix(
			float ___m_transitionAlpha, 
			string ___m_customTextFromConstructor, 
			MyGuiControlMultilineText ___m_multiTextControl,
			StringBuilder ___m_authorWithDash)
        {
			Color color = new Color(255, 255, 255, 250);
			color.A = (byte)((float)color.A * ___m_transitionAlpha);
			Rectangle fullscreenRectangle = MyGuiManager.GetFullscreenRectangle();
			MyGuiManager.DrawSpriteBatch("Textures\\GUI\\Blank.dds", fullscreenRectangle, Color.Black, false, true);
			Rectangle destinationRectangle;
			MyGuiManager.GetSafeHeightFullScreenPictureSize(MyGuiConstants.LOADING_BACKGROUND_TEXTURE_REAL_SIZE, out destinationRectangle);
			MyGuiManager.DrawSpriteBatch(RandomImage, destinationRectangle, new Color(new Vector4(1f, 1f, 1f, ___m_transitionAlpha)), true, true);
			if (XMLReader.LoadingScreenOverlay)
			{
				MyGuiManager.DrawSpriteBatch("Textures\\Gui\\Screens\\screen_background_fade.dds", destinationRectangle, new Color(new Vector4(1f, 1f, 1f, ___m_transitionAlpha)), true, true);
			}
			MyGuiSandbox.DrawGameLogoHandler(___m_transitionAlpha, MyGuiManager.ComputeFullscreenGuiCoordinate(MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP, 44, 68));
			MyGuiScreenLoading.LastBackgroundTexture = RandomImage;
			MyGuiManager.DrawString("LoadingScreen", MyTexts.GetString(MyCommonTexts.LoadingPleaseWaitUppercase), MyGuiConstants.LOADING_PLEASE_WAIT_POSITION, MyGuiSandbox.GetDefaultTextScaleWithLanguage() * 1.1f, new Color?(new Color(MyGuiConstants.LOADING_PLEASE_WAIT_COLOR * ___m_transitionAlpha)), MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_BOTTOM, false, float.PositiveInfinity, false);
			if (string.IsNullOrEmpty(___m_customTextFromConstructor))
			{
				string font = "LoadingScreen";
				Vector2 positionAbsoluteBottomLeft = ___m_multiTextControl.GetPositionAbsoluteBottomLeft();
				Vector2 textSize = ___m_multiTextControl.TextSize;
				Vector2 size = ___m_multiTextControl.Size;
				Vector2 normalizedCoord = positionAbsoluteBottomLeft + new Vector2((size.X - textSize.X) * 0.5f + 0.025f, 0.025f);
				MyGuiManager.DrawString(font, ___m_authorWithDash.ToString(), normalizedCoord, MyGuiSandbox.GetDefaultTextScaleWithLanguage(), null, MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP, false, float.PositiveInfinity, false);
			}
			___m_multiTextControl.Draw(1f, 1f);
			return false;
        }
    }
}
