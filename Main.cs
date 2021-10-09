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
            Harmony harmony = new Harmony("CustomScreenBackgrounds");           
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
      
        public void Update()
        {
            
        }
    }
}
