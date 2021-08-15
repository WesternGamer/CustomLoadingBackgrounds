using HarmonyLib;
using System.Reflection;
using VRage.Plugins;

namespace CustomLoadingScreenBackgrounds
{
    public class Main : IPlugin
    {
        
        public void Startup()
        {

        }

        
        public void Dispose()
        {
            
        }

        
        public void Init(object gameInstance)
        {
            
            Harmony harmony = new Harmony("CustomLoadingScreenBackgrounds");
            
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        
        public void Update()
        {
            
        }
    }
}
