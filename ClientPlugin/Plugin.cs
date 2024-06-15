using CustomScreenBackgrounds.Config;
using CustomScreenBackgrounds.GUI;
using CustomScreenBackgrounds.Utill;
using CustomScreenBackgrounds.Patches;
using CustomScreenBackgrounds.Logging;
using HarmonyLib;
using Sandbox.Graphics.GUI;
using System.IO;
using VRage.Plugins;

namespace CustomScreenBackgrounds
{
    public class Plugin : IPlugin
    {
        public const string Name = "CustomMenuBackgrounds";
        public static Plugin Instance { get; private set; }

        public PluginLogger Log => Logger;
        private static readonly PluginLogger Logger = new PluginLogger(Name);

        public PluginConfig Config => config?.Data;
        private PersistentConfig<PluginConfig> config;
        private static readonly string ConfigFileName = $"{Name}.cfg";

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public Plugin()
        {
            Instance = this;

            Log.Info("Loading");

            FileSystem.Init();

            config = PersistentConfig<PluginConfig>.Load(Log, Path.Combine(FileSystem.ConfigFolderPath, ConfigFileName));

            if (!PatchHelpers.HarmonyPatchAll(Log, new Harmony(Name)))
            {
                return;
            }

            Log.Debug("Successfully loaded");
        }
       
        public void Init(object gameInstance)
        {
           // Initialization code moved to constructor. 
        }

        public void Dispose()
        {
            Instance = null;
        }

        public void Update()
        {
            
        }

        // ReSharper disable once UnusedMember.Global
        public void OpenConfigDialog()
        {
            MyGuiSandbox.AddScreen(new MyPluginConfigDialog());
        }
    }
}