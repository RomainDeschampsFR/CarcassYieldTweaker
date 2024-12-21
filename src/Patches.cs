using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.Gameplay;
using Il2CppTLD.IntBackedUnit;
using MelonLoader;
using System;
using System.Collections.Generic;
using MonoMod.Cil;
using System.Reflection.Emit;


namespace CarcassYieldTweaker
{
    public static class HarvestState
    {
        public static bool pendingChange = false;
        public static string lastItemChanged = null;
        public static float savedHarvestTime = 0f; // Holds the last known harvest time before switching tabs
        public static float lastUnmodifiedTime = 0f; // NEW: Holds the last unmodified harvest time
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

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnTabQuarterSelected))]
        public class Patch_OnTabQuarterSelected
        {
            static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
            {
                if (__instance == null) return;

                try
                {
                    HarvestState.savedHarvestTime = __instance.m_HarvestTimeMinutes;
                    LogDebugMessage($"OnTabQuarterSelected called. Saved harvest time: {HarvestState.savedHarvestTime:F2}");
                }
                catch (Exception ex)
                {
                    MelonLogger.Error($"Error in Patch_OnTabQuarterSelected: {ex}");
                }
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnTabHarvestSelected))]
        public class Patch_OnTabHarvestSelected
        {
            static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
            {
                if (__instance == null) return;

                try
                {
                    __instance.m_HarvestTimeMinutes = HarvestState.savedHarvestTime;
                    LogDebugMessage($"OnTabHarvestSelected called. Restored harvest time: {HarvestState.savedHarvestTime:F2}");
                }
                catch (Exception ex)
                {
                    MelonLogger.Error($"Error in Patch_OnTabHarvestSelected: {ex}");
                }
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnToolNext))]
        public class Patch_OnToolNext
        {
            static void Postfix()
            {
                HarvestState.pendingChange = true;
                HarvestState.lastItemChanged = "ToolSwitch";
                MelonLogger.Msg("[CarcassYieldTweaker:Debug] Tool switched to next tool.");
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnToolPrev))]
        public class Patch_OnToolPrev
        {
            static void Postfix()
            {
                HarvestState.pendingChange = true;
                HarvestState.lastItemChanged = "ToolSwitch";
                MelonLogger.Msg("[CarcassYieldTweaker:Debug] Tool switched to previous tool.");
            }
        }



        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), "Enable", new Type[] { typeof(bool), typeof(Il2Cpp.BodyHarvest), typeof(bool), typeof(Il2Cpp.ComingFromScreenCategory) })]
        public class Patch_Panel_Body_Harvest_Enable_Complex
        {
            static void Prefix(Il2Cpp.Panel_BodyHarvest __instance, bool enable)
            {
                if (__instance == null) return;

                try
                {
                    if (!enable)
                    {
                        HarvestState.savedHarvestTime = 0f;
                        LogDebugMessage("Panel_BodyHarvest closed. Harvest time cleared.");
                    }
                }
                catch (Exception ex)
                {
                    MelonLogger.Error($"Error in Patch_Panel_Body_Harvest_Enable_Complex: {ex}");
                }
            }
        }

        [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.GetHarvestDurationMinutes))]
        public class Patch_GetHarvestDurationMinutes
        {
            static void Postfix(Il2Cpp.Panel_BodyHarvest __instance, ref float __result)
            {
                if (__instance == null) return;

                try
                {
                    // Store the new unmodified time for future ratio calculations
                    float newUnmodifiedTime = __result;

                    // Check if the last change was a tool switch
                    if (HarvestState.pendingChange && HarvestState.lastItemChanged == "ToolSwitch")
                    {
                        if (HarvestState.lastUnmodifiedTime > 0) // Check if we have a previous unmodified time to compare against
                        {
                            float ratio = newUnmodifiedTime / HarvestState.lastUnmodifiedTime;
                            float adjustedTime = __instance.m_HarvestTimeMinutes * ratio;

                            __result = adjustedTime;
                            __instance.m_HarvestTimeMinutes = adjustedTime; // Update the instance variable

                            LogDebugMessage($"Tool switch detected. Ratio applied: {ratio:F2}. New time: {adjustedTime:F2}");
                        }

                        HarvestState.lastUnmodifiedTime = newUnmodifiedTime; // Update for next comparison
                    }
                    else if (HarvestState.pendingChange && !string.IsNullOrEmpty(HarvestState.lastItemChanged))
                    {
                        // If the change was an item change (Meat, Gut, Hide), use the item-based multiplier
                        float multiplier = GetRoundedMultiplier(HarvestState.lastItemChanged);
                        float adjusted = __result * multiplier;

                        __instance.m_HarvestTimeMinutes = adjusted;

                        LogDebugMessage($"[{HarvestState.lastItemChanged}] Harvest time adjusted: {__result:F2} -> {adjusted:F2} (x{multiplier:F1})");

                        __result = adjusted;

                        HarvestState.lastUnmodifiedTime = newUnmodifiedTime; // Update for next comparison
                    }
                    else if (__instance.m_HarvestTimeMinutes > 0f)
                    {
                        __result = __instance.m_HarvestTimeMinutes;
                    }

                    // Reset pending change and last item changed
                    HarvestState.pendingChange = false;
                    HarvestState.lastItemChanged = null;
                }
                catch (Exception ex)
                {
                    MelonLogger.Error($"Error in Patch_GetHarvestDurationMinutes: {ex}");
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