using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using UnityEngine;

namespace UsableMeatMod
{
    class Patches
    {
        [HarmonyPatch(typeof(BodyHarvest), "InitializeResourcesAndConditions")]
        internal class BodyHarvest_InitializeResourcesAndConditions
        {

            private static void Prefix(BodyHarvest __instance)
            {
                if (__instance.name.Contains("Bear"))
                {
                    __instance.m_MeatAvailableMaxKG = Settings.options.BearSliderMax;
                    __instance.m_MeatAvailableMinKG = Settings.options.BearSliderMin;
                }
                if (__instance.name.Contains("Stag"))
                {
                    __instance.m_MeatAvailableMaxKG = Settings.options.DeerSliderMax;
                    __instance.m_MeatAvailableMinKG = Settings.options.DeerSliderMin;
                }
                if (__instance.name.Contains("Wolf"))
                {
                    __instance.m_MeatAvailableMaxKG = Settings.options.WolfSliderMax;
                    __instance.m_MeatAvailableMinKG = Settings.options.WolfSliderMin;
                }
                if (__instance.name.Contains("Moose"))
                {
                    __instance.m_MeatAvailableMaxKG = Settings.options.MooseSliderMax;
                    __instance.m_MeatAvailableMinKG = Settings.options.MooseSliderMin;
                }
                if (__instance.name.Contains("Bear"))
                {
                    __instance.m_GutAvailableUnits = Settings.options.BearGutSlider;
                }
                if (__instance.name.Contains("Stag"))
                {
                    __instance.m_GutAvailableUnits = Settings.options.DeerGutSlider;
                }
                if (__instance.name.Contains("Wolf"))
                {
                    __instance.m_GutAvailableUnits = Settings.options.WolfGutSlider;
                }
                if (__instance.name.Contains("Moose"))
                {
                    __instance.m_GutAvailableUnits = Settings.options.MooseGutSlider;
                }

            }
         }


     }

}
