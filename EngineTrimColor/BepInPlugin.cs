using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace Engine_Trim_Color
{
    internal static class MyPluginInfo
    {
        internal const string PLUGIN_GUID = "id107.enginetrimcolor";
        internal const string PLUGIN_NAME = "Engine Trim Color";
        internal const string PLUGIN_VERSION = "1.0.0";
    }

    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Void Crew.exe")]
    [BepInDependency(VoidManager.MyPluginInfo.PLUGIN_GUID)]
    public class BepinPlugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;
        private void Awake()
        {
            Log = Logger;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), MyPluginInfo.PLUGIN_GUID);
            Configs.Load(this);
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}