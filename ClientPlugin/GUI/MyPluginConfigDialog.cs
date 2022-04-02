using System;
using System.Diagnostics;
using System.Text;
using CustomScreenBackgrounds.Utill;
using Sandbox;
using Sandbox.Graphics.GUI;
using Shared.Plugin;
using VRage;
using VRage.Utils;
using VRageMath;

namespace CustomScreenBackgrounds.GUI
{

    public class MyPluginConfigDialog : MyGuiScreenBase
    {
        private const string Caption = "Custom Screen Backgrounds Config";
        public override string GetFriendlyName() => "MyPluginConfigDialog";

        private MyLayoutTable layoutTable;

        private MyGuiControlLabel CleanLoadingMenuLabel;
        private MyGuiControlCheckbox CleanLoadingMenuCheckbox;
        private MyGuiControlLabel LoadingScreenOverlayLabel;
        private MyGuiControlCheckbox LoadingScreenOverlayCheckbox;
        private MyGuiControlLabel MainMenuOverlayLabel;
        private MyGuiControlCheckbox MainMenuOverlayCheckbox;
        private MyGuiControlLabel MainMenuOverlay2Label;
        private MyGuiControlCheckbox MainMenuOverlay2Checkbox;
        private MyGuiControlLabel CustomMainMenuOverlayLabel;
        private MyGuiControlCheckbox CustomMainMenuOverlayCheckbox;
        private MyGuiControlLabel CustomLoadingMenuOverlayLabel;
        private MyGuiControlCheckbox CustomLoadingMenuOverlayCheckbox;

        // TODO: Add member variables for your UI controls here

        private MyGuiControlMultilineText infoText;
        private MyGuiControlButton closeButton;
        private MyGuiControlButton folderButton;

        public MyPluginConfigDialog() : base(new Vector2(0.5f, 0.5f), MyGuiConstants.SCREEN_BACKGROUND_COLOR, new Vector2(0.5f, 0.7f), false, null, MySandboxGame.Config.UIBkOpacity, MySandboxGame.Config.UIOpacity)
        {
            EnabledBackgroundFade = true;
            m_closeOnEsc = true;
            m_drawEvenWithoutFocus = true;
            CanHideOthers = true;
            CanBeHidden = true;
            CloseButtonEnabled = true;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            RecreateControls(true);
        }

        public override void RecreateControls(bool constructor)
        {
            base.RecreateControls(constructor);

            CreateControls();
            LayoutControls();
        }

        private void CreateControls()
        {
            AddCaption(Caption);

            var config = Common.Config;
            CreateCheckbox(out CleanLoadingMenuLabel, out CleanLoadingMenuCheckbox, config.CleanLoadingMenu, value => config.CleanLoadingMenu = value, "Clean Loading Menu", " This enables the cleaner loading menu provided by this plugin.");
            CreateCheckbox(out LoadingScreenOverlayLabel, out LoadingScreenOverlayCheckbox, config.LoadingScreenOverlay, value => config.LoadingScreenOverlay = value, "Loading Screen Overlay", "This overlay shows up in the loading menu when enabled. It is the same overlay as Main Menu Overlay.");
            CreateCheckbox(out MainMenuOverlayLabel, out MainMenuOverlayCheckbox, config.MainMenuOverlay, value => config.MainMenuOverlay = value, "Main Menu Overlay", "This overlay shows up in the main menu when enabled. It is faint lines that go across the screen.");
            CreateCheckbox(out MainMenuOverlay2Label, out MainMenuOverlay2Checkbox, config.MainMenuOverlay2, value => config.MainMenuOverlay2 = value, "Main Menu Overlay 2", "This overlay also shows up in the main menu when enabled. It is more visble than Main Menu Overlay. It is blue bordered squares with fading at the edges of the overlay. Overlays over Main Menu Overlay.");
            CreateCheckbox(out CustomMainMenuOverlayLabel, out CustomMainMenuOverlayCheckbox, config.CustomMainMenuOverlay, value => config.CustomMainMenuOverlay = value, "Custom Main Menu Overlay", "This overlay shows up in the main menu when enabled and when textures are in the CustomOverlays\\MainMenu folder.");
            CreateCheckbox(out CustomLoadingMenuOverlayLabel, out CustomLoadingMenuOverlayCheckbox, config.CustomLoadingMenuOverlay, value => config.CustomLoadingMenuOverlay = value, "Custom Loading Menu Overlay", "This overlay shows up in the loading menu when enabled and when textures are in the CustomOverlays\\LoadingMenu folder.");


            infoText = new MyGuiControlMultilineText
            {
                Name = "InfoText",
                OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_TOP,
                TextAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
                TextBoxAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
                Text = new StringBuilder("\r\nA plugin that allows you to customize the background on the \r\nloading screen and main menu.")
            };

            closeButton = new MyGuiControlButton(originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER, text: MyTexts.Get(MyCommonTexts.Ok), onButtonClick: OnOk);
            folderButton = new MyGuiControlButton(originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER, text: new StringBuilder("Open Plugin Folder"), onButtonClick: OnOpenFolder);
        }

        private void OnOk(MyGuiControlButton _) => CloseScreen();

        private void OnOpenFolder(MyGuiControlButton _)
        {
            Process.Start("explorer.exe", $"/e, \"{FileSystem.RootFolderPath}\"");
        }

        private void CreateCheckbox(out MyGuiControlLabel labelControl, out MyGuiControlCheckbox checkboxControl, bool value, Action<bool> store, string label, string tooltip)
        {
            labelControl = new MyGuiControlLabel
            {
                Text = label,
                OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_TOP
            };

            checkboxControl = new MyGuiControlCheckbox(toolTip: tooltip)
            {
                OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_TOP,
                Enabled = true,
                IsChecked = value
            };
            checkboxControl.IsCheckedChanged += cb => store(cb.IsChecked);
        }

        private void LayoutControls()
        {
            var size = Size ?? Vector2.One;
            layoutTable = new MyLayoutTable(this, new Vector2(-0.2f, -0.25f), 0.7f * size);
            layoutTable.SetColumnWidths(600f, 200f);
            
            layoutTable.SetRowHeights(80f, 80f, 80f, 80f, 80f, 80f, 100f, 1f);

            var row = 0;

            layoutTable.Add(CleanLoadingMenuLabel, MyAlignH.Left, MyAlignV.Center, row, 0);
            layoutTable.Add(CleanLoadingMenuCheckbox, MyAlignH.Left, MyAlignV.Center, row, 1);
            row++;

            layoutTable.Add(LoadingScreenOverlayLabel, MyAlignH.Left, MyAlignV.Center, row, 0);
            layoutTable.Add(LoadingScreenOverlayCheckbox, MyAlignH.Left, MyAlignV.Center, row, 1);
            row++;

            layoutTable.Add(MainMenuOverlayLabel, MyAlignH.Left, MyAlignV.Center, row, 0);
            layoutTable.Add(MainMenuOverlayCheckbox, MyAlignH.Left, MyAlignV.Center, row, 1);
            row++;

            layoutTable.Add(MainMenuOverlay2Label, MyAlignH.Left, MyAlignV.Center, row, 0);
            layoutTable.Add(MainMenuOverlay2Checkbox, MyAlignH.Left, MyAlignV.Center, row, 1);
            row++;

            layoutTable.Add(CustomMainMenuOverlayLabel, MyAlignH.Left, MyAlignV.Center, row, 0);
            layoutTable.Add(CustomMainMenuOverlayCheckbox, MyAlignH.Left, MyAlignV.Center, row, 1);
            row++;

            layoutTable.Add(CustomLoadingMenuOverlayLabel, MyAlignH.Left, MyAlignV.Center, row, 0);
            layoutTable.Add(CustomLoadingMenuOverlayCheckbox, MyAlignH.Left, MyAlignV.Center, row, 1);
            row++;

            layoutTable.Add(infoText, MyAlignH.Left, MyAlignV.Top, row, 0, colSpan: 2);
            row++;

            layoutTable.AddWithSize(closeButton, MyAlignH.Left, MyAlignV.Top, row, 0, 0);

            layoutTable.AddWithSize(folderButton, MyAlignH.Right, MyAlignV.Top, row, 0, 1);
        }
    }
}