using Il2CppTLD.IntBackedUnit;

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
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.RabbitSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.RabbitSliderMin);
                }
                if (__instance.name.Contains("WILDLIFE_Ptarmigan"))
                {
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.PtarmiganSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.PtarmiganSliderMin);
                }
                if (__instance.name.Contains("WILDLIFE_Bear"))
                {
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.BearSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.BearSliderMin);
                }
                if (__instance.name.Contains("WILDLIFE_Stag"))
                {
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.StagSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.StagSliderMin);
                }
                if (__instance.name.Contains("WILDLIFE_Doe"))
                {
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.DoeSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.DoeSliderMin);
                }
                if (__instance.name.Contains("WILDLIFE_Wolf"))
                {
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.WolfSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.WolfSliderMin);
                }
                if (__instance.name.Contains("WILDLIFE_Moose"))
                {
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.MooseSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.MooseSliderMin);
                }
                if (__instance.name.Contains("WILDLIFE_Cougar"))
                {
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.CougarSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.CougarSliderMin);
                }
                if (__instance.name.Contains("WILDLIFE_Rabbit"))
                {
                    __instance.m_HideAvailableUnits = Settings.settings.RabbitHideSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Ptarmigan"))
                {
                    __instance.m_HideAvailableUnits = Settings.settings.PtarmiganHideSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Bear"))
                {
                    __instance.m_HideAvailableUnits = Settings.settings.BearHideSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Stag"))
                {
                    __instance.m_HideAvailableUnits = Settings.settings.StagHideSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Doe"))
                {
                    __instance.m_HideAvailableUnits = Settings.settings.DoeHideSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Wolf"))
                {
                    __instance.m_HideAvailableUnits = Settings.settings.WolfHideSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Moose"))
                {
                    __instance.m_HideAvailableUnits = Settings.settings.MooseHideSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Cougar"))
                {
                    __instance.m_HideAvailableUnits = Settings.settings.CougarHideSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Rabbit"))
                {
                    __instance.m_GutAvailableUnits = Settings.settings.RabbitGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Bear"))
                {
                    __instance.m_GutAvailableUnits = Settings.settings.BearGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Stag"))
                {
                    __instance.m_GutAvailableUnits = Settings.settings.StagGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Doe"))
                {
                    __instance.m_GutAvailableUnits = Settings.settings.DoeGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Wolf"))
                {
                    __instance.m_GutAvailableUnits = Settings.settings.WolfGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Moose"))
                {
                    __instance.m_GutAvailableUnits = Settings.settings.MooseGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Cougar"))
                {
                    __instance.m_GutAvailableUnits = Settings.settings.CougarGutSlider;
                }
                if (__instance.name.Contains("WILDLIFE_Bear"))
                {
                    __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.BearQuarterSlider);
                }
                if (__instance.name.Contains("WILDLIFE_Stag"))
                {
                    __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.StagQuarterSlider);
                }
                if (__instance.name.Contains("WILDLIFE_Doe"))
                {
                    __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.DoeQuarterSlider);
                }
                if (__instance.name.Contains("WILDLIFE_Wolf"))
                {
                    __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.WolfQuarterSlider);
                }
                if (__instance.name.Contains("WILDLIFE_Moose"))
                {
                    __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.MooseQuarterSlider);
                }
                if (__instance.name.Contains("WILDLIFE_Cougar"))
                {
                    __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.CougarQuarterSlider);
                }
                __instance.m_QuarterBagWasteMultiplier = Settings.settings.QuarterWasteMultipler;
            }
        }


    }
}
