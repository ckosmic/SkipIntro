using HarmonyLib;
using UnityEngine.SceneManagement;

namespace SkipIntro
{
    [HarmonyPatch(typeof(BrandingController), "Start")]
    internal class BrandingControllerPatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            SceneManager.LoadScene("saveslot");
        }
    }
}
