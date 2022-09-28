using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using HarmonyLib;
using UnityEngine;
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
