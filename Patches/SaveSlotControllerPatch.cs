using HarmonyLib;
using System.Reflection;
using UnityEngine.SceneManagement;

namespace SkipIntro.Patches
{
    [HarmonyPatch(typeof(SaveSlotController), "Start")]
    internal class SaveSlotControllerPatch
    {
        [HarmonyPostfix]
        public static void Postfix(SaveSlotController __instance)
        {
            SaverLoader.global_saveindex = Plugin.DefaultSaveSlot.Value;
            SaverLoader.loadSavedGame();
            MethodInfo mi = __instance.GetType().GetMethod("checkScores", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(__instance, null);
            AchievementSetter.checkAllCheevos();
            SceneManager.LoadScene("home");
        }
    }
}
