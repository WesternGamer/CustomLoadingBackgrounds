using HarmonyLib;
using System.IO;
using System.Reflection;
using VRage.FileSystem;
using VRage.Plugins;

namespace CustomScreenBackgrounds
{
    public class Main : IPlugin
    {
        public static string ImageFolderPath;

        public void Dispose()
        {
            
        }
       
        public void Init(object gameInstance)
        {
            ImageFolderPath = Path.Combine(MyFileSystem.UserDataPath, "LoadingScreenBackgroundImages");
            if (!Directory.Exists(ImageFolderPath))
                Directory.CreateDirectory(ImageFolderPath);

            Harmony harmony = new Harmony("CustomScreenBackgrounds");           
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
      
        public void Update()
        {
            
        }
    }
}
