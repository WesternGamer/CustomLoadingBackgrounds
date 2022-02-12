using System;
using System.Text;
using Sandbox;
using Sandbox.Graphics.GUI;
using Shared.Plugin;
using VRage;
using VRage.Utils;
using VRageMath;

namespace ClientPlugin.GUI
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

        // TODO: Add member variables for your UI controls here

        private MyGuiControlMultilineText infoText;
        private MyGuiControlButton closeButton;

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
            CreateCheckbox(out LoadingScreenOverlayLabel, out LoadingScreenOverlayCheckbox, config.LoadingScreenOverlay, value => config.LoadingScreenOverlay = value, "Loading Screen Overlay", "This overlay shows up in the loading menu when true. It is the same overlay as Main Menu Overlay.");
            CreateCheckbox(out MainMenuOverlayLabel, out MainMenuOverlayCheckbox, config.MainMenuOverlay, value => config.MainMenuOverlay = value, "Main Menu Overlay", "This overlay shows up in the main menu when true. It is faint lines that go across the screen.");
            CreateCheckbox(out MainMenuOverlay2Label, out MainMenuOverlay2Checkbox, config.MainMenuOverlay2, value => config.MainMenuOverlay2 = value, "Main Menu Overlay 2", "This overlay also shows up in the main menu when true. It is more visble than Main Menu Overlay. It is blue bordered squares with fading at the edges of the overlay. Overlays over Main Menu Overlay.");

            infoText = new MyGuiControlMultilineText
            {
                Name = "InfoText",
                OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_TOP,
                TextAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
                TextBoxAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
                Text = new StringBuilder("\r\nA plugin that allows you to customize the \r\nbackground on the loading screen \r\nand main menu.")
            };

            closeButton = new MyGuiControlButton(originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER, text: MyTexts.Get(MyCommonTexts.Ok), onButtonClick: OnOk);
        }

        private void OnOk(MyGuiControlButton _) => CloseScreen();

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
            layoutTable = new MyLayoutTable(this, -0.3f * size, 0.6f * size);
            layoutTable.SetColumnWidths(400f, 100f);
            
            layoutTable.SetRowHeights(90f, 90f, 90f, 90f, 150f, 60f);

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

            layoutTable.Add(infoText, MyAlignH.Left, MyAlignV.Top, row, 0, colSpan: 2);
            row++;

            layoutTable.Add(closeButton, MyAlignH.Center, MyAlignV.Center, row, 0, colSpan: 2);
        }
    }
}