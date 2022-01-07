using CustomScreenBackgrounds.Utill;
using CustomScreenBackgrounds.Utill.Config;
using HarmonyLib;
using NLog;
using System.Reflection;
using VRage.Plugins;

namespace CustomScreenBackgrounds
{
    public class Plugin : IPlugin
    {
        public const string Name = "CustomScreenBackgrounds";

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private static bool initialized;

        private static Harmony Harmony => new Harmony(Name);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public void Init(object gameInstance)
        {
            Log.Debug($"{Name}: Patching");
            Harmony.PatchAll(Assembly.GetExecutingAssembly());
            Log.Info($"{Name}: Patches applied");
        }

        public void Dispose()
        {

        }

        public void Update()
        {
            if (initialized)
            {
                return;
            }

            Initialize();

            initialized = true;
        }

        private void Initialize()
        {
            Log.Debug($"{Name}: Initializing");

            FileSystem.Init();
            XMLWriter.Init();
            XMLReader.Init();

            Log.Info($"{Name}: Initialized");
        }
    }
}