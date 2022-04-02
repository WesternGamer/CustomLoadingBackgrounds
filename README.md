# Custom Screen Backgrounds

A plugin that allows you to customize the background on the loading screen and main menu.

![Screenshot (347)](https://user-images.githubusercontent.com/80211714/129464111-b359beb8-8993-400d-8d7b-e9d73e621780.png)
An example of a customized loading screen.

![Screenshot (1730)](https://user-images.githubusercontent.com/80211714/136678865-5035412d-26ae-4403-a0f2-b9f4989acbe7.png)
An example of a customized main menu. (Yes that is my Red Dead Online character.)

![Screenshot (2279)](https://user-images.githubusercontent.com/80211714/149607236-ee604295-f5ae-4c26-a134-5877444d9458.png)
An example of the clean loading menu feature.

## How it works

The plugin selects random `.png` or `.dds` images in the `LoadingScreenBackgroundImages` folder to show on the loading screen. For the main menu, the plugin cheacks if there are any `.png` or `.dds` images in `LoadingScreenBackgroundImages\MainMenuScreenBackgroundImages` folder. If there are images, then it will pick a random `.png` or `.dds` image to show in the background of the main menu. Else, it will check if there are `.wmv` video files in `LoadingScreenBackgroundImages\MainMenuScreenBackgroundVideos` folder. If there is video files, it will pick a random video to play in the background of the main menu. If there are no new files in any folder in `LoadingScreenBackgroundImages`, then the main menu background will act like normal.

## Plugin Installation
To use the plugin, please install [PluginLoader](https://github.com/austinvaness/PluginLoader). After you install PluginLoader successfully, go to the plugins menu from the main menu and select Custom Loading Backgrounds. Click Apply and you will be asked to restart the game. Click Yes to restart the game and you done! Manual Plugin Installation without PluginLoader is not supported!

## How to add Custom Images to Loading Menu

NOTE: Only `.png` and `.dds` files are accepted. Any other files not ending in `.png` or `.dds` will be ignored. `.PNG` or `.DDS` will not work.

1. Go to `C:\Users\[Your Username]\AppData\Roaming\SpaceEngineers\LoadingScreenBackgroundImages`.
2. Paste your images here. File name does not matter; file name must end in `.png` or `.dds`.
3. You are done!

## How to add Custom Images to Main Menu

NOTE: Only `.png` and `.dds` files are accepted. Any other files not ending in `.png` or `.dds` will be ignored. `.PNG` or `.DDS` will not work.

1. Go to `C:\Users\[Your Username]\AppData\Roaming\SpaceEngineers\LoadingScreenBackgroundImages\MainMenuScreenBackgroundImages`.
2. Paste your images here. File name does not matter; file name must end in `.png` or `.dds`.
3. You are done!

## How to add Custom Videos to Main Menu

NOTE: Only `.wmv` files are accepted. Any other files not ending in `.wmv` will be ignored. `.WMV` will not work.

NOTE: Remove all image files in `LoadingScreenBackgroundImages\MainMenuScreenBackgroundImages` or custom videos will not work.

1. Go to `C:\Users\[Your Username]\AppData\Roaming\SpaceEngineers\LoadingScreenBackgroundImages\MainMenuScreenBackgroundVideos`.
2. Paste your images here. File name does not matter; file name must end in `.wmv`. Image resolution does not matter, any images that is not 16:9 aspect ratio will be streched/squashed.
3. You are done!

## Configuration

There are configuration options for this plugin in the plugins configurations menu in the plugins menu.

-Clean Loading Menu: This enables the cleaner loading menu provided by this plugin when enabled.

-Loading Screen Overlay: This overlay shows up in the loading menu when enabled. It is the same overlay as the Main Menu Overlay.

-Main Menu Overlay: This overlay shows up in the main menu when enabled. It is faint lines that go across the screen.

-Main Menu Overlay 2: This overlay also shows up in the main menu when enabled. It is more visble than Main Menu Overlay. It is blue bordered squares with fading at the edges of the overlay. Overlays over Main Menu Overlay.

-Custom Main Menu Overlay: This overlay shows up in the main menu when enabled and when textures are in the `CustomOverlays\MainMenu` folder.

-Custom Loading Menu Overlay: This overlay shows up in the loading menu when enabled and when textures are in the `CustomOverlays\LoadingMenu` folder.

