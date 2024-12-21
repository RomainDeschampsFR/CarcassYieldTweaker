using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.IntBackedUnit;
using MelonLoader;
using System;


namespace CarcassYieldTweaker
{

    public static class Patches
    {

        public static class HarvestState
        {
            public static bool pendingChange = false;
            public static string lastItemChanged = null;
            public static float savedHarvestTime = 0f; // Holds the last known harvest time before switching tabs
            public static float lastUnmodifiedTime = 0f; // Holds the last unmodified harvest time to use for tool changes

            public static void ClearAll()
            {
                pendingChange = false;
                lastItemChanged = null;
                savedHarvestTime = 0f;
                lastUnmodifiedTime = 0f;
            }
        }

        public static class Time_Patches

        {

            private static bool debug_mode = true; // Set to false to disable debug logging


            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.GetHarvestDurationMinutes))]
            public class Patch_Panel_BodyHarvest_GetHarvestDurationMinutes
            {
                static void Postfix(Il2Cpp.Panel_BodyHarvest __instance, ref float __result)
                {
                    if (__instance == null || string.IsNullOrEmpty(__instance.name)) return;

                    try
                    {
                        // First store unmodified total harvest time for future ratio calculations
                        float newUnmodifiedTime = __result;

                        // Get the animal type
                        string animalType = __instance.m_BodyHarvest.name;

                        // Check if the last change was a tool switch
                        if (HarvestState.pendingChange && HarvestState.lastItemChanged == "ToolSwitch")
                        {
                            if (HarvestState.lastUnmodifiedTime > 0) // Check if we have a previous unmodified time to compare against
                            {
                                float ratio = newUnmodifiedTime / HarvestState.lastUnmodifiedTime;
                                float toolAdjustedTotalHarvestTime = __instance.m_HarvestTimeMinutes * ratio;

                                __result = toolAdjustedTotalHarvestTime;
                                __instance.m_HarvestTimeMinutes = toolAdjustedTotalHarvestTime; // Update the instance variable

                                LogDebugMessage($"[Tool Switch] Ratio: {ratio:F2} - New time: {toolAdjustedTotalHarvestTime:F2}");
                            }

                            HarvestState.lastUnmodifiedTime = newUnmodifiedTime; // Update for next comparison
                        }
                        else if (HarvestState.pendingChange && !string.IsNullOrEmpty(HarvestState.lastItemChanged))
                        {
                            // If the change was an item change (Meat, Gut, Hide), use the item-based multiplier
                            float multiplier = GetRoundedMultiplier(HarvestState.lastItemChanged, animalType); // Pass item type and animal type
                            float itemAdjustedItemHarvestTime = __result * multiplier;

                            __instance.m_HarvestTimeMinutes = itemAdjustedItemHarvestTime;

                            LogDebugMessage($"[{animalType}:{HarvestState.lastItemChanged}] {__result:F2} -> {itemAdjustedItemHarvestTime:F2} (x{multiplier:F1})");

                            __result = itemAdjustedItemHarvestTime;

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

            private static float GetRoundedMultiplier(string itemType, string animalType)
            {
                float rawMultiplier = 1f;  // Default multiplier

                // Use a switch statement for each animal type and item type
                switch (animalType)
                {
                    case "GEAR_RabbitCarcass":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.settings.HideTimeSliderRabbit;
                        //else if (itemType == "Meat")
                        //    rawMultiplier = Settings.settings.MeatTimeSliderRabbit;
                        //else if (itemType == "Gut")
                        //    rawMultiplier = Settings.settings.GutTimeSliderRabbit;
                        break;

                    case "GEAR_PtarmiganCarcass":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.settings.HideTimeSliderPtarmigan;
                        //else if (itemType == "Meat")
                        //    rawMultiplier = Settings.settings.MeatTimeSliderPtarmigan;
                        break;

                    case "WILDLIFE_Doe":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.settings.HideTimeSliderDoe;
                        //else if (itemType == "Meat")
                        //    rawMultiplier = Settings.settings.MeatTimeSliderDoe;
                        //else if (itemType == "Gut")
                        //    rawMultiplier = Settings.settings.GutTimeSliderDoe;
                        break;

                    case "WILDLIFE_Stag":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.settings.HideTimeSliderStag;
                        //else if (itemType == "Meat")
                        //    rawMultiplier = Settings.settings.MeatTimeSliderStag;
                        //else if (itemType == "Gut")
                        //    rawMultiplier = Settings.settings.GutTimeSliderStag;
                        break;

                    case "WILDLIFE_Moose":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.settings.HideTimeSliderMoose;
                        //else if (itemType == "Meat")
                        //    rawMultiplier = Settings.settings.MeatTimeSliderMoose;
                        //else if (itemType == "Gut")
                        //    rawMultiplier = Settings.settings.GutTimeSliderMoose;
                        break;

                    case "WILDLIFE_Wolf":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.settings.HideTimeSliderWolf;
                        //else if (itemType == "Meat")
                        //    rawMultiplier = Settings.settings.MeatTimeSliderWolf;
                        //else if (itemType == "Gut")
                        //    rawMultiplier = Settings.settings.GutTimeSliderWolf;
                        break;

                    case "WILDLIFE_TimberWolf":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.settings.HideTimeSliderTimberWolf;
                        //else if (itemType == "Meat")
                        //    rawMultiplier = Settings.settings.MeatTimeSliderTimberWolf;
                        //else if (itemType == "Gut")
                        //    rawMultiplier = Settings.settings.GutTimeSliderTimberWolf;
                        break;

                    //case "WILDLIFE_PoisonedWolf":
                    //    if (itemType == "Hide")
                    //        rawMultiplier = Settings.settings.MeatTimeSliderPoisonedWolf;
                    //    else if (itemType == "Gut")
                    //        rawMultiplier = Settings.settings.GutTimeSliderPoisonedWolf;
                    //    break;

                    case "WILDLIFE_Bear":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.settings.HideTimeSliderBear;
                        //else if (itemType == "Meat")
                        //    rawMultiplier = Settings.settings.MeatTimeSliderBear;
                        //else if (itemType == "Gut")
                        //    rawMultiplier = Settings.settings.GutTimeSliderBear;
                        break;

                    case "WILDLIFE_Cougar":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.settings.HideTimeSliderCougar;
                        //else if (itemType == "Meat")
                        //    rawMultiplier = Settings.settings.MeatTimeSliderCougar;
                        //else if (itemType == "Gut")
                        //    rawMultiplier = Settings.settings.GutTimeSliderCougar;
                        break;

                    default:
                        // Fallback to global multipliers
                        if (itemType == "Meat")
                            rawMultiplier = Settings.settings.GlobalMeatTimeSlider;
                        else if (itemType == "FrozenMeat")
                            rawMultiplier = Settings.settings.GlobalFrozenMeatTimeSlider;
                        else if (itemType == "Hide")
                            rawMultiplier = 1.0f;
                        else if (itemType == "Gut")
                            rawMultiplier = Settings.settings.GlobalGutTimeSlider;
                        break;
                }

                return (float)Math.Round(rawMultiplier, 1);
            }



            private static void LogDebugMessage(string message)
            {
                if (debug_mode)
                {
                    MelonLogger.Msg($"[CarcassYieldTweaker:Debug] {message}");
                }
            }

            private static string FormatTimeLog(float original, float adjusted, float multiplier)
            {
                return $"{original:F1}m -> {adjusted:F1}m ({multiplier:F1}x)";
            }

            // Button Press Time_Patches: Set pendingChange and record which button
            //
            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnIncreaseMeatHarvest))]
            public class Patch_Panel_BodyHarvest_OnIncreaseMeatHarvest
            {
                static void Postfix()
                {
                    HarvestState.lastItemChanged = "Meat";
                    HarvestState.pendingChange = true;
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnDecreaseMeatHarvest))]
            public class Patch_Panel_BodyHarvest_OnDecreaseMeatHarvest
            {
                static void Postfix()
                {
                    HarvestState.lastItemChanged = "Meat";
                    HarvestState.pendingChange = true;
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnIncreaseHideHarvest))]
            public class Patch_Panel_BodyHarvest_OnIncreaseHideHarvest
            {
                static void Postfix()
                {
                    HarvestState.lastItemChanged = "Hide";
                    HarvestState.pendingChange = true;
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnDecreaseHideHarvest))]
            public class Patch_Panel_BodyHarvest_OnDecreaseHideHarvest
            {
                static void Postfix()
                {
                    HarvestState.lastItemChanged = "Hide";
                    HarvestState.pendingChange = true;
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnIncreaseGutHarvest))]
            public class Patch_Panel_BodyHarvest_OnIncreaseGutHarvest
            {
                static void Postfix()
                {
                    HarvestState.lastItemChanged = "Gut";
                    HarvestState.pendingChange = true;
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnDecreaseGutHarvest))]
            public class Patch_Panel_BodyHarvest_OnDecreaseGutHarvest
            {
                static void Postfix()
                {
                    HarvestState.lastItemChanged = "Gut";
                    HarvestState.pendingChange = true;
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnTabQuarterSelected))]
            public class Patch_Panel_BodyHarvest_OnTabQuarterSelected
            {
                static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
                {
                    if (__instance == null) return;
                    HarvestState.savedHarvestTime = __instance.m_HarvestTimeMinutes;
                    LogDebugMessage($"OnTabQuarterSelected called. Saved harvest time: {HarvestState.savedHarvestTime:F2}");
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnTabHarvestSelected))]
            public class Patch_Panel_BodyHarvest_OnTabHarvestSelected
            {
                static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
                {
                    if (__instance == null) return;
                    __instance.m_HarvestTimeMinutes = HarvestState.savedHarvestTime;
                    LogDebugMessage($"OnTabHarvestSelected called. Restored harvest time: {HarvestState.savedHarvestTime:F2}");
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnToolNext))]
            public class Patch_Panel_BodyHarvest_OnToolNext
            {
                static void Postfix()
                {
                    HarvestState.pendingChange = true;
                    HarvestState.lastItemChanged = "ToolSwitch";
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnToolPrev))]
            public class Patch_Panel_BodyHarvest_OnToolPrev
            {
                static void Postfix()
                {
                    HarvestState.pendingChange = true;
                    HarvestState.lastItemChanged = "ToolSwitch";
                }
            }



            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), "Enable", new Type[] { typeof(bool), typeof(Il2Cpp.BodyHarvest), typeof(bool), typeof(Il2Cpp.ComingFromScreenCategory) })]
            public class Patch_Panel_Body_Harvest_OpenAndClose
            {

                static void Prefix(Il2Cpp.Panel_BodyHarvest __instance, bool enable)
                {
                    if (__instance == null) return;

                    try
                    {
                        if (!enable)
                        {
                            HarvestState.ClearAll();
                            __instance.m_HarvestTimeMinutes = 0f;
                            LogDebugMessage("Panel_BodyHarvest closed. Harvest time cleared.");
                        }
                        else
                        {
                            LogDebugMessage("Panel_BodyHarvest opened.");

                        }
                    }
                    catch (Exception ex)
                    {
                        MelonLogger.Error($"Error in Patch_Panel_Body_Harvest_OpenAndClose: {ex}");
                    }
                }
            }



        }

        public static class Quantity_Patches
        {
            //Quantity Patching
            [HarmonyPatch(typeof(Il2Cpp.BodyHarvest), nameof(BodyHarvest.InitializeResourcesAndConditions))]
            internal class Patch_BodyHarvest_InitializeResourcesAndConditions
            {
                private static void Prefix(Il2Cpp.BodyHarvest __instance)
                {
                    if (__instance == null || string.IsNullOrEmpty(__instance.name)) return;

                    try
                    {
                        if (__instance.name.StartsWith("WILDLIFE_Rabbit"))
                        {
                            //Todo - Add "[Animal] was plumped up" or "slimmed down" messages to MelonLog
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.MeatSliderMinRabbit);
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.MeatSliderMaxRabbit);
                            __instance.m_HideAvailableUnits = Settings.settings.HideSliderRabbit;
                            __instance.m_GutAvailableUnits = Settings.settings.GutSliderRabbit;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Ptarmigan"))
                        {
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.MeatSliderMinPtarmigan);
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.MeatSliderMaxPtarmigan);
                            __instance.m_HideAvailableUnits = Settings.settings.HideSliderPtarmigan;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Doe"))
                        {
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.MeatSliderMinDoe);
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.MeatSliderMaxDoe);
                            __instance.m_HideAvailableUnits = Settings.settings.HideSliderDoe;
                            __instance.m_GutAvailableUnits = Settings.settings.GutSliderDoe;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.QuarterSizeSliderDoe);
                            __instance.m_QuarterDurationMinutes = Settings.settings.QuarterDurationMinutesSliderDoe;
                            __instance.m_FatToMeatRatio = Settings.settings.FatToMeatPercentSliderDoe / 100;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Stag"))
                        {
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.MeatSliderMaxStag);
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.MeatSliderMinStag);
                            __instance.m_HideAvailableUnits = Settings.settings.HideSliderStag;
                            __instance.m_GutAvailableUnits = Settings.settings.GutSliderStag;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.QuarterSizeSliderStag);
                            __instance.m_QuarterDurationMinutes = Settings.settings.QuarterDurationMinutesSliderStag;
                            __instance.m_FatToMeatRatio = Settings.settings.FatToMeatPercentSliderStag / 100;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Moose"))
                        {
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.MeatSliderMaxMoose);
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.MeatSliderMinMoose);
                            __instance.m_HideAvailableUnits = Settings.settings.HideSliderMoose;
                            __instance.m_GutAvailableUnits = Settings.settings.GutSliderMoose;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.QuarterSizeSliderMoose);
                            __instance.m_QuarterDurationMinutes = Settings.settings.QuarterDurationMinutesSliderMoose;
                            __instance.m_FatToMeatRatio = Settings.settings.FatToMeatPercentSliderMoose / 100;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Wolf"))
                        {
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.MeatSliderMaxWolf);
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.MeatSliderMinWolf);
                            __instance.m_HideAvailableUnits = Settings.settings.HideSliderWolf;
                            __instance.m_GutAvailableUnits = Settings.settings.GutSliderWolf;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.QuarterSizeSliderWolf);
                            __instance.m_QuarterDurationMinutes = Settings.settings.QuarterDurationMinutesSliderWolf;
                            __instance.m_FatToMeatRatio = Settings.settings.FatToMeatPercentSliderWolf / 100;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_TimberWolf"))
                        {
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.MeatSliderMaxTimberWolf);
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.MeatSliderMinTimberWolf);
                            __instance.m_HideAvailableUnits = Settings.settings.HideSliderTimberWolf;
                            __instance.m_GutAvailableUnits = Settings.settings.GutSliderTimberWolf;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.QuarterSizeSliderTimberWolf);
                            __instance.m_QuarterDurationMinutes = Settings.settings.QuarterDurationMinutesSliderTimberWolf;
                            __instance.m_FatToMeatRatio = Settings.settings.FatToMeatPercentSliderTimberWolf / 100;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_StarvingWolf"))
                        {
                            __instance.m_HideAvailableUnits = Settings.settings.HideSliderPoisonedWolf;
                            __instance.m_GutAvailableUnits = Settings.settings.GutSliderPoisonedWolf;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Bear"))
                        {
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.MeatSliderMaxBear);
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.MeatSliderMinBear);
                            __instance.m_HideAvailableUnits = Settings.settings.HideSliderBear;
                            __instance.m_GutAvailableUnits = Settings.settings.GutSliderBear;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.QuarterSizeSliderBear);
                            __instance.m_QuarterDurationMinutes = Settings.settings.QuarterDurationMinutesSliderBear;
                            __instance.m_FatToMeatRatio = Settings.settings.FatToMeatPercentSliderBear / 100;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Cougar"))
                        {
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.settings.MeatSliderMaxCougar);
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.settings.MeatSliderMinCougar);
                            __instance.m_HideAvailableUnits = Settings.settings.HideSliderCougar;
                            __instance.m_GutAvailableUnits = Settings.settings.GutSliderCougar;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.settings.QuarterSizeSliderCougar);
                            __instance.m_QuarterDurationMinutes = Settings.settings.QuarterDurationMinutesSliderCougar;
                            __instance.m_FatToMeatRatio = Settings.settings.FatToMeatPercentSliderCougar / 100;
                        }

                        __instance.m_QuarterBagWasteMultiplier = Settings.settings.QuarterWasteSlider;
                    }
                    catch (Exception ex)
                    {
                        MelonLogger.Error($"Error in BodyHarvest_InitializeResourcesAndConditions: {ex}");
                    }
                }
            }
        }
    }
}