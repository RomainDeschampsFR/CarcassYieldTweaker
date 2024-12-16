using HarmonyLib;
using Il2CppTLD.IntBackedUnit;
using MelonLoader;
using System;

namespace CarcassYieldTweaker
{
    public static class Patches
    {

        // Time Patches

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), "OnIncreaseMeatHarvest")]
        public class Patch_OnIncreaseMeatHarvest
        {
            static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
            {
                RecalculateHarvestDuration(__instance);
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), "OnDecreaseMeatHarvest")]
        public class Patch_OnDecreaseMeatHarvest
        {
            static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
            {
                RecalculateHarvestDuration(__instance);
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), "OnIncreaseHideHarvest")]
        public class Patch_OnIncreaseHideHarvest
        {
            static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
            {
                RecalculateHarvestDuration(__instance);
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), "OnDecreaseHideHarvest")]
        public class Patch_OnDecreaseHideHarvest
        {
            static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
            {
                RecalculateHarvestDuration(__instance);
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), "OnIncreaseGutHarvest")]
        public class Patch_OnIncreaseGutHarvest
        {
            static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
            {
                RecalculateHarvestDuration(__instance);
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), "OnDecreaseGutHarvest")]
        public class Patch_OnDecreaseGutHarvest
        {
            static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
            {
                RecalculateHarvestDuration(__instance);
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), "GetHarvestDurationMinutes")]
        public class Patch_GetHarvestDurationMinutes
        {
            private static void Postfix(ref float __result, Il2Cpp.Panel_BodyHarvest __instance)
            {
                if (__instance.m_HarvestTimeMinutes > 0)
                {
                    __result = __instance.m_HarvestTimeMinutes;
                }
            }
        }

        public static void RecalculateHarvestDuration(Il2Cpp.Panel_BodyHarvest instance)
        {
            if (instance.m_MenuItem_Meat != null || instance.m_MenuItem_Hide != null || instance.m_MenuItem_Gut != null)
            {
                try
                {
                    float totalDuration = 0;

                    // Meat Calculation
                    if (instance.m_MenuItem_Meat != null)
                    {
                        var harvestAmount = instance.m_MenuItem_Meat.HarvestAmount;
                        var rawUnits = harvestAmount.m_Units;
                        float amountKG = rawUnits / 1000000000f;

                        float meatTime = Settings.settings.HarvestMeatMinutesPerKG * amountKG;
                        //MelonLogger.Msg($"Meat Harvest Time: {meatTime:F2} minutes (Amount: {amountKG:F2}kg)");
                        totalDuration += meatTime;
                    }

                    // Hide Calculation
                    if (instance.m_MenuItem_Hide != null)
                    {
                        var hideUnits = instance.m_MenuItem_Hide.HarvestUnits;
                        float hideTime = Settings.settings.HarvestHideMinutesPerUnit * hideUnits;
                        //MelonLogger.Msg($"Hide Harvest Time: {hideTime:F2} minutes (Units: {hideUnits})");
                        totalDuration += hideTime;
                    }

                    // Gut Calculation
                    if (instance.m_MenuItem_Gut != null)
                    {
                        var gutUnits = instance.m_MenuItem_Gut.HarvestUnits;
                        float gutTime = Settings.settings.HarvestGutMinutesPerUnit * gutUnits;
                        //MelonLogger.Msg($"Gut Harvest Time: {gutTime:F2} minutes (Units: {gutUnits})");
                        totalDuration += gutTime;
                    }

                    // Set total duration
                    instance.m_HarvestTimeMinutes = totalDuration;
                    //MelonLogger.Msg($"Total Harvest Duration: {totalDuration:F2} minutes");
                }
                catch (Exception ex)
                {
                    MelonLogger.Error($"Error in RecalculateHarvestDuration: {ex}");
                }
            }
        }



        //Quantity Patching

        [HarmonyPatch(typeof(Il2Cpp.BodyHarvest), "InitializeResourcesAndConditions")]
        internal class BodyHarvest_InitializeResourcesAndConditions
        {
            private static void Prefix(Il2Cpp.BodyHarvest __instance)
            {

                if (__instance.name.Contains("WILDLIFE_Rabbit"))
                {
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.RabbitSliderMin);
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.RabbitSliderMax);
                    __instance.m_HideAvailableUnits = Settings.settings.RabbitHideSlider;
                    __instance.m_GutAvailableUnits = Settings.settings.RabbitGutSlider;
                    __instance.m_DecayConditionPerHour = (Settings.settings.RabbitDecayConditionPerDayPercentSlider / 100) / 24;
                }

                if (__instance.name.Contains("WILDLIFE_Ptarmigan"))
                {
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.PtarmiganSliderMin);
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.PtarmiganSliderMax);
                    __instance.m_HideAvailableUnits = Settings.settings.PtarmiganHideSlider;
                    __instance.m_DecayConditionPerHour = (Settings.settings.PtarmiganDecayConditionPerDayPercentSlider / 100) / 24;
                }

                if (__instance.name.Contains("WILDLIFE_Doe"))
                {
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.DoeSliderMin);
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.DoeSliderMax);
                    __instance.m_HideAvailableUnits = Settings.settings.DoeHideSlider;
                    __instance.m_GutAvailableUnits = Settings.settings.DoeGutSlider;
                    __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.DoeQuarterSizeSlider);
                    __instance.m_QuarterDurationMinutes = Settings.settings.DoeQuarterDurationMinutesSlider;
                    __instance.m_FatToMeatRatio = Settings.settings.DoeFatToMeatPercentSlider / 100;
                    __instance.m_DecayConditionPerHour = (Settings.settings.DoeDecayConditionPerDayPercentSlider / 100) / 24;
                }

                if (__instance.name.Contains("WILDLIFE_Stag"))
                {
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.StagSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.StagSliderMin);
                    __instance.m_HideAvailableUnits = Settings.settings.StagHideSlider;
                    __instance.m_GutAvailableUnits = Settings.settings.StagGutSlider;
                    __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.StagQuarterSizeSlider);
                    __instance.m_QuarterDurationMinutes = Settings.settings.StagQuarterDurationMinutesSlider;
                    __instance.m_FatToMeatRatio = Settings.settings.StagFatToMeatPercentSlider / 100;
                    __instance.m_DecayConditionPerHour = (Settings.settings.StagDecayConditionPerDayPercentSlider / 100) / 24;
                }

                if (__instance.name.Contains("WILDLIFE_Moose"))
                {
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.MooseSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.MooseSliderMin);
                    __instance.m_HideAvailableUnits = Settings.settings.MooseHideSlider;
                    __instance.m_GutAvailableUnits = Settings.settings.MooseGutSlider;
                    __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.MooseQuarterSizeSlider);
                    __instance.m_QuarterDurationMinutes = Settings.settings.MooseQuarterDurationMinutesSlider;
                    __instance.m_FatToMeatRatio = Settings.settings.MooseFatToMeatPercentSlider / 100;
                    __instance.m_DecayConditionPerHour = (Settings.settings.MooseDecayConditionPerDayPercentSlider / 100) / 24;
                }

                if (__instance.name.Contains("WILDLIFE_Wolf"))
                {
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.WolfSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.WolfSliderMin);
                    __instance.m_HideAvailableUnits = Settings.settings.WolfHideSlider;
                    __instance.m_GutAvailableUnits = Settings.settings.WolfGutSlider;
                    __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.WolfQuarterSizeSlider);
                    __instance.m_QuarterDurationMinutes = Settings.settings.WolfQuarterDurationMinutesSlider;
                    __instance.m_FatToMeatRatio = Settings.settings.WolfFatToMeatPercentSlider / 100;
                    __instance.m_DecayConditionPerHour = (Settings.settings.WolfDecayConditionPerDayPercentSlider / 100) / 24;
                }

                if (__instance.name.Contains("WILDLIFE_TimberWolf"))
                {
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.TimberWolfSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.TimberWolfSliderMin);
                    __instance.m_HideAvailableUnits = Settings.settings.TimberWolfHideSlider;
                    __instance.m_GutAvailableUnits = Settings.settings.TimberWolfGutSlider;
                    __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.TimberWolfQuarterSizeSlider);
                    __instance.m_QuarterDurationMinutes = Settings.settings.TimberWolfQuarterDurationMinutesSlider;
                    __instance.m_FatToMeatRatio = Settings.settings.TimberWolfFatToMeatPercentSlider / 100;
                    __instance.m_DecayConditionPerHour = (Settings.settings.TimberWolfDecayConditionPerDayPercentSlider / 100) / 24;
                }

                if (__instance.name.Contains("WILDLIFE_StarvingWolf"))
                {
                    __instance.m_HideAvailableUnits = Settings.settings.PoisonedWolfHideSlider;
                    __instance.m_GutAvailableUnits = Settings.settings.PoisonedWolfGutSlider;
                    __instance.m_DecayConditionPerHour = (Settings.settings.PoisonedWolfDecayConditionPerDayPercentSlider / 100) / 24;
                }

                if (__instance.name.Contains("WILDLIFE_Bear"))
                {
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.BearSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.BearSliderMin);
                    __instance.m_HideAvailableUnits = Settings.settings.BearHideSlider;
                    __instance.m_GutAvailableUnits = Settings.settings.BearGutSlider;
                    __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.BearQuarterSizeSlider);
                    __instance.m_QuarterDurationMinutes = Settings.settings.BearQuarterDurationMinutesSlider;
                    __instance.m_FatToMeatRatio = Settings.settings.BearFatToMeatPercentSlider / 100;
                    __instance.m_DecayConditionPerHour = (Settings.settings.BearDecayConditionPerDayPercentSlider / 100) / 24;
                }

                if (__instance.name.Contains("WILDLIFE_Cougar"))
                {
                    __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.CougarSliderMax);
                    __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.CougarSliderMin);
                    __instance.m_HideAvailableUnits = Settings.settings.CougarHideSlider;
                    __instance.m_GutAvailableUnits = Settings.settings.CougarGutSlider;
                    __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.CougarQuarterSizeSlider);
                    __instance.m_QuarterDurationMinutes = Settings.settings.CougarQuarterDurationMinutesSlider;
                    __instance.m_FatToMeatRatio = Settings.settings.CougarFatToMeatPercentSlider / 100;
                    __instance.m_DecayConditionPerHour = (Settings.settings.CougarDecayConditionPerDayPercentSlider / 100) / 24;
                }

                __instance.m_QuarterBagWasteMultiplier = Settings.settings.QuarterWasteMultipler;

            }
        }
    }
}
