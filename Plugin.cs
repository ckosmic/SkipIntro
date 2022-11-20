using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace SkipIntro
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<int> DefaultSaveSlot;
        private void Awake()
        {
            DefaultSaveSlot = Config.Bind("Default", "SaveSlot", 0, new ConfigDescription
            (
                "The save slot to use, starting from 0. Either 0, 1, 2."
            ));
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
        }
    }
}
