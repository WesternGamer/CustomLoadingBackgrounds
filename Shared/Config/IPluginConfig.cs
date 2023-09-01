using System.ComponentModel;

namespace Shared.Config
{
    public interface IPluginConfig : INotifyPropertyChanged
    {
        bool MainMenuOverlay { get; set; }

        bool MainMenuOverlay2 { get; set; }

        bool LoadingScreenOverlay { get; set; }

        bool CleanLoadingMenu { get; set; }

        bool CustomMainMenuOverlay { get; set; }

        bool CustomLoadingMenuOverlay { get; set; }

        bool ShowLoadingMenuPercent { get; set; }
    }
}