using HarmonyLib;
using SpaceEngineers.Game.GUI;

namespace CustomScreenBackgrounds.Utill
{
    [HarmonyPatch(typeof(MyGuiScreenMainMenu), "AddIntroScreen")]
    internal class Patch_MainMenu
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}
