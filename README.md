# Custom Screen Backgrounds

A plugin that allows you to customize the background on the loading screen and main menu.

![Screenshot (347)](https://user-images.githubusercontent.com/80211714/129464111-b359beb8-8993-400d-8d7b-e9d73e621780.png)
An example of a customized loading screen.

![Screenshot (1730)](https://user-images.githubusercontent.com/80211714/136678865-5035412d-26ae-4403-a0f2-b9f4989acbe7.png)
An example of a customized main menu.

## How it works

The plugin selects random `.png` or `.dds` images in the `LoadingScreenBackgroundImages` folder to show on the loading screen. For the main menu, the plugin cheacks if there are any `.png` or `.dds` images in `LoadingScreenBackgroundImages\MainMenuScreenBackgroundImages` folder. If there are images, then it will pick a random `.png` or `.dds` image to show in the background of the main menu. Else, it will check if there are `.wmv` video files in `LoadingScreenBackgroundImages\MainMenuScreenBackgroundVideos` folder. If there is video files, it will pick a random video to play in the background of the main menu. If there are no new files in any folder in `LoadingScreenBackgroundImages`, then the main menu background will act like normal.

## Plugin Installation
To use the plugin, please install PluginLoader (https://github.com/austinvaness/PluginLoader). After you install PluginLoader successfully, go to the plugins menu from the main menu and select Custom Loading Backgrounds. Click Apply and you will be asked to restart the game. Click Yes to restart the game and you done! Manual Plugin Installation without PluginLoader is not supported!

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
2. Paste your images here. File name does not matter; file name must end in `.wmv`.
3. You are done!

## NEW: How to Enable Overlays

With the release of v1.2.0 of Custom Screen Backgrounds, there is now a option to enable or disable overlays in the main menu or loading menu. Instructions on how to do so are listed below:

1. Go to `C:\Users\[Your Username]\AppData\Roaming\SpaceEngineers\LoadingScreenBackgroundImages\Config`
2. Open `config.xml` with notepad or your preferred text editor.
![Screenshot (1742)](https://user-images.githubusercontent.com/80211714/136844661-68dd3c9f-701d-4db0-a052-6be29c49a62f.png)
3. You should see three config entries: `MainMenuOverlay`, `MainMenuOverlay2`, and `LoadingScreenOverlay`. The value of all of them are false by default. Modify these config entries to your peferences. NOTE: Only `true` or `false` values are accepted. `TRUE` or `FALSE` values will not work and may crash the game.

Config entries:
-`MainMenuOverlay`: This overlay shows up in the main menu when `true`. It is faint lines that go across the screen.
-`MainMenuOverlay2`: This overlay also shows up in the main menu when `true`. It is more visble than `MainMenuOverlay`. It is blue bordered squares with fading at the edges of the overlay. Overlays over `MainMenuOverlay`.
-`LoadingScreenOverlay`: This overlay shows up in the loading menu when `true`. It is the same overlay as `MainMenuOverlay`.

## Manual Plugin Installation With PluginLoader 

WARNING: Use this only if you could not get the normal plugin installation to work in anyway. Local plugins can be dangerous because these plugins are not checked by the authors of PluginLoader and you may accidentally run a virus or malware. USE AT YOUR OWN RISK.

If you need you install manually for any reason, here are the steps to install the plugin manually:

1. Click on this link to download the plugin directly: https://github.com/WesternGamer/CustomLoadingBackgrounds/releases/download/v1.2.0/CustomScreenBackgrounds.dll

2. The browser that you are using may say that the plugin is dangerous. Click keep to keep the plugin. It may be hidden so you may need to click the arrow or dots next to the downloaded plugin.

3. Go to your downloads folder and find the plugin file called `CustomScreenBackgrounds.dll`.

4. Right click and the file and click cut.

5. Now open Steam and go to your Steam library.

6. Right click Space Engineers in the list to the left.

7. Click properties.

9. Go to Local Files and click Browse.

10. Click on the Bin64 folder and then the Plugins folder.

11. Right click in the empty space in the folder and click paste.

12. Right click on the file you just pasted and click properties.

13. At the bottom, click unblock then Apply. You can now close the window.

15. Start Space Engineers and go to the plugins menu from the main menu and select `CustomScreenBackgrounds.dll`. Click Apply and you will be asked to restart the game. Click Yes to restart the game and you done!



