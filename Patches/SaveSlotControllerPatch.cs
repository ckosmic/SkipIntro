using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace SkipIntro.Patches
{
    [HarmonyPatch(typeof(SaveSlotController), "Start")]
    internal class SaveSlotControllerPatch
    {
        [HarmonyPostfix]
        public static void Postfix(SaveSlotController __instance)
        {
            //__instance.clickBtn1();
            SaverLoader.global_saveindex = 0;
            SaverLoader.loadSavedGame();
            MethodInfo mi = __instance.GetType().GetMethod("checkScores", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(__instance, null);
            AchievementSetter.checkAllCheevos();
            SceneManager.LoadScene("home");
        }
    }
}
