namespace CarcassYieldTweaker
{
    class Patches
    {
        [HarmonyLib.HarmonyPatch(typeof(Il2Cpp.BodyHarvest), "InitializeResourcesAndConditions")]
        internal class BodyHarvest_InitializeResourcesAndConditions
        {

            private static void Prefix(Il2Cpp.BodyHarvest __instance)
            {
                if (__instance.name.Contains("WILDLIFE_Rabbit"))
                {
                    __instance.m_MeatAvailableMaxKG = Settings.options.RabbitSliderMax;
                    __instance.m_MeatAvailableMinKG = Settings.options.RabbitSliderMin;
                }
                if (__instance.name.Contains("WILDLIFE_Ptarmigan"))
                {
                    __instance.m_MeatAvailableMaxKG = Settings.options.PtarmiganSliderMax;
                    __instance.m_MeatAvailableMinKG = Settings.options.PtarmiganSliderMin;
                }
                if (__instance.name.Contains("WILDLIFE_Bear"))
                {
                    __instance.m_MeatAvailableMaxKG = Settings.options.BearSliderMax;
                    __instance.m_MeatAvailableMinKG = Settings.options.BearSliderMin;
                }
                if (__instance.name.Contains("WILDLIFE_Stag"))
                {
                    __instance.m_MeatAvailableMaxKG = Settings.options.StagSliderMax;
                    __instance.m_MeatAvailableMinKG = Settings.options.StagSliderMin;
                }
                if (__instance.name.Contains("WILDLIFE_Doe"))
                {
                    __instance.m_MeatAvailableMaxKG = Settings.options.DoeSliderMax;
                    __instance.m_MeatAvailableMinKG = Settings.options.DoeSliderMin;
                }
                if (__instance.name.Contains("WILDLIFE_Wolf"))
                {
                    __instance.m_MeatAvailableMaxKG = Settings.options.WolfSliderMax;
                    __instance.m_MeatAvailableMinKG = Settings.options.WolfSliderMin;
                }
                if (__instance.name.Contains("WILDLIFE_Moose"))
                {
                    __instance.m_MeatAvailableMaxKG = Settings.options.MooseSliderMax;
                    __instance.m_MeatAvailableMinKG = Settings.options.MooseSliderMin;
                }
                if (__instance.name.Contains("WILDLIFE_Cougar"))
                {
                    __instance.m_MeatAvailableMaxKG = Settings.options.CougarSliderMax;
                    __instance.m_MeatAvailableMinKG = Settings.options.CougarSliderMin;
                }
                if (__instance.name.Contains("WILDLIFE_Rabbit"))
                {
                    __instance.m_GutAvailableUnits = Settings.options.RabbitGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Bear"))
                {
                    __instance.m_GutAvailableUnits = Settings.options.BearGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Stag"))
                {
                    __instance.m_GutAvailableUnits = Settings.options.StagGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Doe"))
                {
                    __instance.m_GutAvailableUnits = Settings.options.DoeGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Wolf"))
                {
                    __instance.m_GutAvailableUnits = Settings.options.WolfGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Moose"))
                {
                    __instance.m_GutAvailableUnits = Settings.options.MooseGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Cougar"))
                {
                    __instance.m_GutAvailableUnits = Settings.options.CougarGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Bear"))
                {
                    __instance.m_QuarterBagMeatCapacityKG = Settings.options.BearQuarterSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Stag"))
                {
                    __instance.m_QuarterBagMeatCapacityKG = Settings.options.StagQuarterSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Doe"))
                {
                    __instance.m_QuarterBagMeatCapacityKG = Settings.options.DoeQuarterSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Wolf"))
                {
                    __instance.m_QuarterBagMeatCapacityKG = Settings.options.WolfQuarterSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Moose"))
                {
                    __instance.m_QuarterBagMeatCapacityKG = Settings.options.MooseQuarterSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Cougar"))
                {
                    __instance.m_QuarterBagMeatCapacityKG = Settings.options.CougarQuarterSlider;
                }
                __instance.m_QuarterBagWasteMultiplier = Settings.options.QuarterWasteMultipler;
            }
        }


    }
}
