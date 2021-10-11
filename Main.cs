using CustomScreenBackgrounds.Utill;
using CustomScreenBackgrounds.Utill.Config;
using HarmonyLib;
using System.Reflection;
using VRage.Plugins;

namespace CustomScreenBackgrounds
{
    public class Main : IPlugin
    {
        public void Dispose()
        {
            
        }
       
        public void Init(object gameInstance)
        {
            FileSystem.Init();
            XMLWriter.Init();
            XMLReader.Init();

            Harmony harmony = new Harmony("CustomScreenBackgrounds");           
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
      
        public void Update()
        {
            
        }
    }
}
