﻿using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.IntBackedUnit;
using MelonLoader;
using System;

namespace CarcassYieldTweaker
{
    public static class HarvestState
    {
        public static bool pendingChange = false;
        public static string lastItemChanged = null;
    }

    public static class Patches
    {
        private static bool debug_mode = true; // Set to false to disable debug logging

        private static void LogDebugMessage(string message)
        {
            if (debug_mode)
            {
                MelonLogger.Msg($"[CarcassYieldTweaker:Debug] {message}");
            }
        }

        private static float GetRoundedMultiplier(string itemType)
        {
            float rawMultiplier = 1f;
            switch (itemType)
            {
                case "Meat":
                    rawMultiplier = Settings.settings.MeatTimeMultiplier;
                    break;
                case "Hide":
                    rawMultiplier = Settings.settings.HideTimeMultiplier;
                    break;
                case "Gut":
                    rawMultiplier = Settings.settings.GutTimeMultiplier;
                    break;
            }

            // Round the multiplier from settings to a single decimal place
            return (float)Math.Round(rawMultiplier, 1);
        }

        // Button Press Patches: Set pendingChange and record lastItemChanged
        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnIncreaseMeatHarvest))]
        public class Patch_OnIncreaseMeatHarvest
        {
            static void Postfix()
            {
                HarvestState.lastItemChanged = "Meat";
                HarvestState.pendingChange = true;
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnDecreaseMeatHarvest))]
        public class Patch_OnDecreaseMeatHarvest
        {
            static void Postfix()
            {
                HarvestState.lastItemChanged = "Meat";
                HarvestState.pendingChange = true;
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnIncreaseHideHarvest))]
        public class Patch_OnIncreaseHideHarvest
        {
            static void Postfix()
            {
                HarvestState.lastItemChanged = "Hide";
                HarvestState.pendingChange = true;
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnDecreaseHideHarvest))]
        public class Patch_OnDecreaseHideHarvest
        {
            static void Postfix()
            {
                HarvestState.lastItemChanged = "Hide";
                HarvestState.pendingChange = true;
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnIncreaseGutHarvest))]
        public class Patch_OnIncreaseGutHarvest
        {
            static void Postfix()
            {
                HarvestState.lastItemChanged = "Gut";
                HarvestState.pendingChange = true;
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnDecreaseGutHarvest))]
        public class Patch_OnDecreaseGutHarvest
        {
            static void Postfix()
            {
                HarvestState.lastItemChanged = "Gut";
                HarvestState.pendingChange = true;
            }
        }

        // Patch for Panel_BodyHarvest.Enable(bool, BodyHarvest, bool, ComingFromScreenCategory)
        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), "Enable", new Type[] { typeof(bool), typeof(Il2Cpp.BodyHarvest), typeof(bool), typeof(Il2Cpp.ComingFromScreenCategory) })]
        public class Patch_Panel_Body_Harvest_Enable_Complex
        {
            static void Prefix(Il2Cpp.Panel_BodyHarvest __instance, bool enable)
            {
                if (__instance == null) return;

                if (!enable)
                {
                    __instance.m_HarvestTimeMinutes = 0f;
                    LogDebugMessage("Panel_BodyHarvest closed (complex). Harvest time reset to 0.");
                }
            }
        }

        // Patch GetHarvestDurationMinutes to apply multiplier only when there's a pending change
        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.GetHarvestDurationMinutes))]
        public class Patch_GetHarvestDurationMinutes
        {
            static void Postfix(Il2Cpp.Panel_BodyHarvest __instance, ref float __result)
            {
                if (__instance == null) return;

                try
                {
                    if (HarvestState.pendingChange && !string.IsNullOrEmpty(HarvestState.lastItemChanged))
                    {
                        float multiplier = GetRoundedMultiplier(HarvestState.lastItemChanged);
                        float adjusted = __result * multiplier;

                        __instance.m_HarvestTimeMinutes = adjusted;

                        LogDebugMessage($"[{HarvestState.lastItemChanged}] Harvest time adjusted: {__result:F2} -> {adjusted:F2} (x{multiplier:F1})");

                        HarvestState.pendingChange = false;
                        HarvestState.lastItemChanged = null;

                        __result = adjusted;
                    }
                    else if (__instance.m_HarvestTimeMinutes > 0f)
                    {
                        __result = __instance.m_HarvestTimeMinutes;
                    }
                }
                catch (Exception ex)
                {
                    MelonLogger.Error($"[CarcassYieldTweaker] Error in Patch_GetHarvestDurationMinutes: {ex}");
                }
            }
        }



        //Quantity Patching
        [HarmonyPatch(typeof(Il2Cpp.BodyHarvest), nameof(BodyHarvest.InitializeResourcesAndConditions))]
        internal class BodyHarvest_InitializeResourcesAndConditions
        {
            private static void Prefix(Il2Cpp.BodyHarvest __instance)
            {
                if (__instance == null || string.IsNullOrEmpty(__instance.name)) return;

                try
                {
                    if (__instance.name.StartsWith("WILDLIFE_Rabbit"))
                    {
                     
                        //Todo - Add "[Animal] was plumped up" or "slimmed down" messages to MelonLog
                        __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.RabbitSliderMin);
                        __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.RabbitSliderMax);
                        __instance.m_HideAvailableUnits = Settings.settings.RabbitHideSlider;
                        __instance.m_GutAvailableUnits = Settings.settings.RabbitGutSlider;
                        __instance.m_DecayConditionPerHour = (Settings.settings.RabbitDecayConditionPerDayPercentSlider / 100) / 24;
                    }

                    if (__instance.name.StartsWith("WILDLIFE_Ptarmigan"))
                    {
                        __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.PtarmiganSliderMin);
                        __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.PtarmiganSliderMax);
                        __instance.m_HideAvailableUnits = Settings.settings.PtarmiganHideSlider;
                        __instance.m_DecayConditionPerHour = (Settings.settings.PtarmiganDecayConditionPerDayPercentSlider / 100) / 24;
                    }

                    if (__instance.name.StartsWith("WILDLIFE_Doe"))
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

                    if (__instance.name.StartsWith("WILDLIFE_Stag"))
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

                    if (__instance.name.StartsWith("WILDLIFE_Moose"))
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

                    if (__instance.name.StartsWith("WILDLIFE_Wolf"))
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

                    if (__instance.name.StartsWith("WILDLIFE_StarvingWolf"))
                    {
                        __instance.m_HideAvailableUnits = Settings.settings.PoisonedWolfHideSlider;
                        __instance.m_GutAvailableUnits = Settings.settings.PoisonedWolfGutSlider;
                        __instance.m_DecayConditionPerHour = (Settings.settings.PoisonedWolfDecayConditionPerDayPercentSlider / 100) / 24;
                    }

                    if (__instance.name.StartsWith("WILDLIFE_Bear"))
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

                    if (__instance.name.StartsWith("WILDLIFE_Cougar"))
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
                catch (Exception ex)
                {
                    MelonLogger.Error($"Error in BodyHarvest_InitializeResourcesAndConditions: {ex}");
                }
            }
        }

    }
}
