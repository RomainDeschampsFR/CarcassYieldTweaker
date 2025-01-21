using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.IntBackedUnit;
using JetBrains.Annotations;
using MelonLoader;
using System;
using UnityEngine;


namespace CarcassYieldTweaker
{
    internal static class Patches
    {
        internal static class HarvestState
        {
            internal static bool pendingChange = false;
            internal static string lastItemChanged = null;
            internal static float savedHarvestTime = 0f; // Holds the last known harvest time before switching tabs
            internal static float lastUnmodifiedTime = 0f; // Holds the last unmodified harvest time to use for tool changes

            internal static void ClearAll()
            {
                pendingChange = false;
                lastItemChanged = null;
                savedHarvestTime = 0f;
                lastUnmodifiedTime = 0f;
            }

        }
        private static string FormatTimeLog(float original, float adjusted, float multiplier)
        {
            return $"{original:F1}m -> {adjusted:F1}m ({multiplier:F1}x)";
        }
        internal static class Panel_BodyHarvest_Patches
        {

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.GetHarvestDurationMinutes))]
            internal class Patch_HarvestDuration
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

                                Main.DebugLog($"[Tool Switch] Ratio: {ratio:F2} - New time: {toolAdjustedTotalHarvestTime:F2}");
                            }

                            HarvestState.lastUnmodifiedTime = newUnmodifiedTime; // Update for next comparison
                        }
                        else if (HarvestState.pendingChange && !string.IsNullOrEmpty(HarvestState.lastItemChanged))
                        {
                            // If the change was an item change (Meat, Gut, Hide), use the item-based multiplier
                            float multiplier = GetRoundedMultiplier(HarvestState.lastItemChanged, animalType); // Pass item type and animal type
                            float itemAdjustedItemHarvestTime = __result * multiplier;

                            __instance.m_HarvestTimeMinutes = itemAdjustedItemHarvestTime;

                            Main.DebugLog($"[{animalType}:{HarvestState.lastItemChanged}] {__result:F2} -> {itemAdjustedItemHarvestTime:F2} (x{multiplier:F1})");

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
                        MelonLogger.Error($"Error in Patch_HarvestDuration: {ex}");
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
                            rawMultiplier = Settings.instance.HideTimeSliderRabbit;
                        else if (itemType == "Meat")
                            rawMultiplier = Settings.instance.MeatTimeSliderGlobal;
                        else if (itemType == "Gut")
                            rawMultiplier = Settings.instance.GutTimeSliderGlobal;
                        break;

                    case "GEAR_PtarmiganCarcass":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.instance.HideTimeSliderPtarmigan;
                        else if (itemType == "Meat")
                            rawMultiplier = Settings.instance.MeatTimeSliderGlobal;
                        break;

                    case "WILDLIFE_Doe":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.instance.HideTimeSliderDoe;
                        else if (itemType == "Meat")
                            rawMultiplier = Settings.instance.MeatTimeSliderGlobal;
                        else if (itemType == "Gut")
                            rawMultiplier = Settings.instance.GutTimeSliderGlobal;
                        break;

                    case "WILDLIFE_Stag":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.instance.HideTimeSliderStag;
                        else if (itemType == "Meat")
                            rawMultiplier = Settings.instance.MeatTimeSliderGlobal;
                        else if (itemType == "Gut")
                            rawMultiplier = Settings.instance.GutTimeSliderGlobal;
                        break;


                    case "WILDLIFE_Moose":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.instance.HideTimeSliderMoose;
                        else if (itemType == "Meat")
                            rawMultiplier = Settings.instance.MeatTimeSliderGlobal;
                        else if (itemType == "Gut")
                            rawMultiplier = Settings.instance.GutTimeSliderGlobal;
                        break;

                    case "WILDLIFE_Wolf":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.instance.HideTimeSliderWolf;
                        else if (itemType == "Meat")
                            rawMultiplier = Settings.instance.MeatTimeSliderGlobal;
                        else if (itemType == "Gut")
                            rawMultiplier = Settings.instance.GutTimeSliderGlobal;
                        break;

                    case "WILDLIFE_TimberWolf":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.instance.HideTimeSliderTimberWolf;
                        else if (itemType == "Meat")
                            rawMultiplier = Settings.instance.MeatTimeSliderGlobal;
                        else if (itemType == "Gut")
                            rawMultiplier = Settings.instance.GutTimeSliderGlobal;
                        break;

                    case "WILDLIFE_StarvingWolf":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.instance.HideTimeSliderPoisonedWolf;
                        else if (itemType == "Gut")
                            rawMultiplier = Settings.instance.GutTimeSliderGlobal;
                        break;

                    case "WILDLIFE_Bear":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.instance.HideTimeSliderBear;
                        else if (itemType == "Meat")
                            rawMultiplier = Settings.instance.MeatTimeSliderGlobal;
                        else if (itemType == "Gut")
                            rawMultiplier = Settings.instance.GutTimeSliderGlobal;
                        break;

                    case "WILDLIFE_Cougar":
                        if (itemType == "Hide")
                            rawMultiplier = Settings.instance.HideTimeSliderCougar;
                        else if (itemType == "Meat")
                            rawMultiplier = Settings.instance.MeatTimeSliderGlobal;
                        else if (itemType == "Gut")
                            rawMultiplier = Settings.instance.GutTimeSliderGlobal;
                        break;

                    default:
                        // Fallback to global multipliers if animal type not found
                        if (itemType == "Hide")
                            rawMultiplier = 1.0f;
                        else if (itemType == "Meat")
                            rawMultiplier = Settings.instance.MeatTimeSliderGlobal;
                        else if (itemType == "FrozenMeat")
                            rawMultiplier = Settings.instance.FrozenMeatTimeSliderGlobal;
                        else if (itemType == "Gut")
                            rawMultiplier = Settings.instance.GutTimeSliderGlobal;
                        Main.DebugLog($"[UNKNOWN:{animalType}] GLOBAL multiplier: {rawMultiplier:F1}");
                        break;
                }

                return (float)Math.Round(rawMultiplier, 2);
            }

            // Button Press Panel_BodyHarvest_Patches: Set pendingChange and record which button
            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnIncreaseMeatHarvest))]
            internal class Patch_OnIncreaseMeatHarvest
            {
                static void Postfix()
                {
                    HarvestState.lastItemChanged = "Meat";
                    HarvestState.pendingChange = true;
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnDecreaseMeatHarvest))]
            internal class Patch_OnDecreaseMeatHarvest
            {
                static void Postfix()
                {
                    HarvestState.lastItemChanged = "Meat";
                    HarvestState.pendingChange = true;
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnIncreaseHideHarvest))]
            internal class Patch_OnIncreaseHideHarvest
            {
                static void Postfix()
                {
                    HarvestState.lastItemChanged = "Hide";
                    HarvestState.pendingChange = true;
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnDecreaseHideHarvest))]
            internal class Patch_OnDecreaseHideHarvest
            {
                static void Postfix()
                {
                    HarvestState.lastItemChanged = "Hide";
                    HarvestState.pendingChange = true;
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnIncreaseGutHarvest))]
            internal class Patch_OnIncreaseGutHarvest
            {
                static void Postfix()
                {
                    HarvestState.lastItemChanged = "Gut";
                    HarvestState.pendingChange = true;
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnDecreaseGutHarvest))]
            internal class Patch_OnDecreaseGutHarvest
            {
                static void Postfix()
                {
                    HarvestState.lastItemChanged = "Gut";
                    HarvestState.pendingChange = true;
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnTabQuarterSelected))]
            internal class Patch_OnTabQuarterSelected
            {
                static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
                {
                    if (__instance == null) return;
                    HarvestState.savedHarvestTime = __instance.m_HarvestTimeMinutes;
                    Main.DebugLog($"OnTabQuarterSelected called. Saved harvest time: {HarvestState.savedHarvestTime:F2}");
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnTabHarvestSelected))]
            internal class Patch_OnTabHarvestSelected
            {
                static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
                {
                    if (__instance == null) return;
                    __instance.m_HarvestTimeMinutes = HarvestState.savedHarvestTime;
                    Main.DebugLog($"OnTabHarvestSelected called. Restored harvest time: {HarvestState.savedHarvestTime:F2}");
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnToolNext))]
            internal class Patch_OnToolNext
            {
                static void Postfix()
                {
                    HarvestState.pendingChange = true;
                    HarvestState.lastItemChanged = "ToolSwitch";
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.OnToolPrev))]
            internal class Patch_OnToolPrev
            {
                static void Postfix()
                {
                    HarvestState.pendingChange = true;
                    HarvestState.lastItemChanged = "ToolSwitch";
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.Enable), new Type[] { typeof(bool), typeof(Il2Cpp.BodyHarvest), typeof(bool), typeof(Il2Cpp.ComingFromScreenCategory) })]
            internal class Patch_MaxHarvestTime
            {
                static void Prefix(Il2Cpp.Panel_BodyHarvest __instance, bool enable)
                {
                    if (!enable || __instance == null) return;// Only run on Open, exit if null
                    try
                    {
                        Main.DebugLog("Panel_BodyHarvest opened.");
                        // Override the max harvest time if the global setting is not the default value
                        if (__instance.m_MaxTimeHours != Settings.instance.MaxHarvestTimeSliderGlobal)
                        {
                            __instance.m_MaxTimeHours = Settings.instance.MaxHarvestTimeSliderGlobal;
                            Main.DebugLog($"Updated m_MaxTimeHours to {Settings.instance.MaxHarvestTimeSliderGlobal}.");
                        }
                    }
                    catch (Exception ex) { MelonLogger.Error($"Error on Patch_MaxHarvestTime: {ex}"); }
                }
            }

            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.Enable), new Type[] { typeof(bool), typeof(Il2Cpp.BodyHarvest), typeof(bool), typeof(Il2Cpp.ComingFromScreenCategory) })]
            internal class Patch_ClearHarvestSettings
            {
                static void Prefix(Il2Cpp.Panel_BodyHarvest __instance, bool enable)
                {
                    if (enable || __instance == null) return; // Exit if the panel is opening or if null

                    try
                    {
                        // Clear custom state or settings
                        HarvestState.ClearAll();
                        __instance.m_HarvestTimeMinutes = 0f;

                        // Clean up custom UI elements
                        var frozenLabelParent = __instance.m_Label_FrozenInfo?.transform.parent;
                        if (frozenLabelParent != null)
                        {
                            // Destroy custom condition label if it exists
                            var conditionLabel = frozenLabelParent.Find("ConditionLabel");
                            if (conditionLabel != null)
                            {
                                UnityEngine.Object.Destroy(conditionLabel.gameObject);
                                Main.DebugLog("ConditionLabel destroyed during panel close.");
                            }

                            // Destroy custom frozen label if it exists
                            var customFrozenLabel = frozenLabelParent.Find("CustomFrozenLabel");
                            if (customFrozenLabel != null)
                            {
                                UnityEngine.Object.Destroy(customFrozenLabel.gameObject);
                                Main.DebugLog("CustomFrozenLabel destroyed during panel close.");
                            }
                        }

                        Main.DebugLog("Panel_BodyHarvest closed. Custom UI elements and harvest settings cleared.");
                    }
                    catch (Exception ex)
                    {
                        MelonLogger.Error($"Error in ClearSettings: {ex}");
                    }
                }
            }

            /*
            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.RefreshTitle))]
            public class PanelBodyHarvest_ConditionLabel_Patch
            {
                private static readonly UnityEngine.Color Green = new UnityEngine.Color(0, 1, 0, 1);
                private static readonly UnityEngine.Color Yellow = new UnityEngine.Color(1, 1, 0, 1);
                private static readonly UnityEngine.Color Red = new UnityEngine.Color(1, 0, 0, 1);

                private static UnityEngine.Color GetConditionColor(int condition)
                {
                    return condition >= 66 ? Green : (condition >= 33 ? Yellow : Red);
                }

                static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
                {
                    if (!Settings.instance.ShowCarcassCondition) return;

                    var bodyHarvest = __instance.m_BodyHarvest;
                    if (bodyHarvest == null) return;

                    var titleLabel = __instance.m_Label_Title;
                    if (titleLabel == null) return;

                    var parentTransform = titleLabel.transform.parent;
                    var conditionLabel = parentTransform.Find("ConditionLabel")?.GetComponent<UILabel>();

                    if (conditionLabel == null)
                    {
                        // Create the new condition label
                        var newLabelObject = UnityEngine.Object.Instantiate(titleLabel.gameObject, parentTransform);
                        newLabelObject.name = "ConditionLabel";
                        conditionLabel = newLabelObject.GetComponent<UILabel>();
                        conditionLabel.fontSize = 14;
                        conditionLabel.transform.localPosition = titleLabel.transform.localPosition + new UnityEngine.Vector3(0, -25, 0);
                    }

                    // Update condition label only if needed
                    int carcassCondition = Mathf.RoundToInt(bodyHarvest.m_Condition);
                    string newText = $"({carcassCondition}% CONDITION)";
                    if (conditionLabel.text != newText)
                    {
                        conditionLabel.text = newText;
                        conditionLabel.color = GetConditionColor(carcassCondition);
                    }

                    if (!conditionLabel.gameObject.activeSelf)
                    {
                        conditionLabel.gameObject.SetActive(true);
                    }
                }
            }*/
            /*
            [HarmonyPatch(typeof(Il2Cpp.Panel_BodyHarvest), nameof(Panel_BodyHarvest.RefreshTitle))]
            public class PanelBodyHarvest_FrozenLabel_Patch
            {
                private static readonly UnityEngine.Color Blue = new UnityEngine.Color(0, 0, 1, 1);
                private static readonly UnityEngine.Color Cyan = new UnityEngine.Color(0, 1, 1, 1);
                private static readonly UnityEngine.Color White = new UnityEngine.Color(1, 1, 1, 1);
                private static readonly UnityEngine.Color Orange = new UnityEngine.Color(1, 0.5f, 0, 1);

                private static UnityEngine.Color GetFrozenColor(int frozen)
                {
                    return frozen >= 50 ? Cyan : (frozen >= 25 ? White : Orange);
                }

                static void Postfix(Il2Cpp.Panel_BodyHarvest __instance)
                {
                    if (!Settings.instance.AlwaysShowFrozenPercent) return;

                    // Hide the default frozen label only if it's active
                    var frozenInfo = __instance.m_Label_FrozenInfo?.gameObject;
                    if (frozenInfo != null && frozenInfo.activeSelf)
                    {
                        frozenInfo.SetActive(false);
                    }

                    var bodyHarvest = __instance.m_BodyHarvest;
                    if (bodyHarvest == null) return;

                    var titleLabel = __instance.m_Label_Title;
                    if (titleLabel == null) return;

                    var parentTransform = titleLabel.transform.parent;
                    var customFrozenLabel = parentTransform.Find("CustomFrozenLabel")?.GetComponent<UILabel>();

                    if (customFrozenLabel == null)
                    {
                        // Create the new custom frozen label
                        var newLabelObject = UnityEngine.Object.Instantiate(titleLabel.gameObject, parentTransform);
                        newLabelObject.name = "CustomFrozenLabel";
                        customFrozenLabel = newLabelObject.GetComponent<UILabel>();
                        customFrozenLabel.fontSize = 14;
                        customFrozenLabel.transform.localPosition = titleLabel.transform.localPosition + new UnityEngine.Vector3(0, -45, 0);
                    }

                    // Update the custom frozen label's current frozen percentage and color
                    int percentFrozen = Mathf.RoundToInt(bodyHarvest.m_PercentFrozen);
                    if (customFrozenLabel.text != $"({percentFrozen}% FROZEN)")
                    {
                        customFrozenLabel.text = $"({percentFrozen}% FROZEN)";
                        customFrozenLabel.color = GetFrozenColor(percentFrozen);
                    }

                    if (!customFrozenLabel.gameObject.activeSelf)
                    {
                        customFrozenLabel.gameObject.SetActive(true);
                    }
                }
            }*/
        } // End of Panel_BodyHarvest_Patches

        internal static class BodyHarvest_Patches
        {
            //Quantity & Decay Patching
            [HarmonyPatch(typeof(Il2Cpp.BodyHarvest), nameof(BodyHarvest.InitializeResourcesAndConditions))]
            internal class Patch_QuantitiesAndDecay
            {
                internal static float newDecay = 0f;
                private static void Prefix(Il2Cpp.BodyHarvest __instance)
                {
                    if (__instance == null || string.IsNullOrEmpty(__instance.name)) return;
                    try
                    {
                        if (__instance.name.StartsWith("WILDLIFE_Rabbit"))
                        {
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.instance.MeatSliderMinRabbit);
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.instance.MeatSliderMaxRabbit);
                            __instance.m_HideAvailableUnits = Settings.instance.HideCountSliderRabbit;
                            __instance.m_GutAvailableUnits = Settings.instance.GutCountSliderRabbit;
                            __instance.m_DecayConditionPerHour *= Settings.instance.DecayRateSliderRabbit;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Ptarmigan"))
                        {
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.instance.MeatSliderMinPtarmigan);
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.instance.MeatSliderMaxPtarmigan);
                            __instance.m_HideAvailableUnits = Settings.instance.HideCountSliderPtarmigan;
                            __instance.m_DecayConditionPerHour *= Settings.instance.DecayRateSliderPtarmigan;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Doe"))
                        {
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.instance.MeatSliderMinDoe);
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.instance.MeatSliderMaxDoe);
                            __instance.m_HideAvailableUnits = Settings.instance.HideCountSliderDoe;
                            __instance.m_GutAvailableUnits = Settings.instance.GutCountSliderDoe;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.instance.QuarterSizeSliderDoe);
                            __instance.m_QuarterDurationMinutes = Settings.instance.QuarterDurationMinutesSliderDoe;
                            __instance.m_FatToMeatRatio = Settings.instance.FatToMeatPercentSliderDoe / 100;
                            __instance.m_DecayConditionPerHour *= Settings.instance.DecayRateSliderDoe;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Stag"))
                        {
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.instance.MeatSliderMaxStag);
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.instance.MeatSliderMinStag);
                            __instance.m_HideAvailableUnits = Settings.instance.HideCountSliderStag;
                            __instance.m_GutAvailableUnits = Settings.instance.GutCountSliderStag;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.instance.QuarterSizeSliderStag);
                            __instance.m_QuarterDurationMinutes = Settings.instance.QuarterDurationMinutesSliderStag;
                            __instance.m_FatToMeatRatio = Settings.instance.FatToMeatPercentSliderStag / 100;
                            __instance.m_DecayConditionPerHour *= Settings.instance.DecayRateSliderStag;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Moose"))
                        {
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.instance.MeatSliderMaxMoose);
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.instance.MeatSliderMinMoose);
                            __instance.m_HideAvailableUnits = Settings.instance.HideCountSliderMoose;
                            __instance.m_GutAvailableUnits = Settings.instance.GutCountSliderMoose;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.instance.QuarterSizeSliderMoose);
                            __instance.m_QuarterDurationMinutes = Settings.instance.QuarterDurationMinutesSliderMoose;
                            __instance.m_FatToMeatRatio = Settings.instance.FatToMeatPercentSliderMoose / 100;
                            __instance.m_DecayConditionPerHour *= Settings.instance.DecayRateSliderMoose;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Wolf"))
                        {
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.instance.MeatSliderMaxWolf);
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.instance.MeatSliderMinWolf);
                            __instance.m_HideAvailableUnits = Settings.instance.HideCountSliderWolf;
                            __instance.m_GutAvailableUnits = Settings.instance.GutCountSliderWolf;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.instance.QuarterSizeSliderWolf);
                            __instance.m_QuarterDurationMinutes = Settings.instance.QuarterDurationMinutesSliderWolf;
                            __instance.m_FatToMeatRatio = Settings.instance.FatToMeatPercentSliderWolf / 100;
                            __instance.m_DecayConditionPerHour *= Settings.instance.DecayRateSliderWolf;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_TimberWolf"))
                        {
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.instance.MeatSliderMaxTimberWolf);
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.instance.MeatSliderMinTimberWolf);
                            __instance.m_HideAvailableUnits = Settings.instance.HideCountSliderTimberWolf;
                            __instance.m_GutAvailableUnits = Settings.instance.GutCountSliderTimberWolf;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.instance.QuarterSizeSliderTimberWolf);
                            __instance.m_QuarterDurationMinutes = Settings.instance.QuarterDurationMinutesSliderTimberWolf;
                            __instance.m_FatToMeatRatio = Settings.instance.FatToMeatPercentSliderTimberWolf / 100;
                            __instance.m_DecayConditionPerHour *= Settings.instance.DecayRateSliderTimberWolf;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_StarvingWolf"))
                        {
                            __instance.m_HideAvailableUnits = Settings.instance.HideCountSliderPoisonedWolf;
                            __instance.m_GutAvailableUnits = Settings.instance.GutCountSliderPoisonedWolf;
                            __instance.m_DecayConditionPerHour *= Settings.instance.DecayRateSliderPoisonedWolf;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Bear"))
                        {
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.instance.MeatSliderMaxBear);
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.instance.MeatSliderMinBear);
                            __instance.m_HideAvailableUnits = Settings.instance.HideCountSliderBear;
                            __instance.m_GutAvailableUnits = Settings.instance.GutCountSliderBear;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.instance.QuarterSizeSliderBear);
                            __instance.m_QuarterDurationMinutes = Settings.instance.QuarterDurationMinutesSliderBear;
                            __instance.m_FatToMeatRatio = Settings.instance.FatToMeatPercentSliderBear / 100;
                            __instance.m_DecayConditionPerHour *= Settings.instance.DecayRateSliderBear;
                        }

                        if (__instance.name.StartsWith("WILDLIFE_Cougar"))
                        {
                            __instance.m_MeatAvailableMax = ItemWeight.FromKilograms(Settings.instance.MeatSliderMaxCougar);
                            __instance.m_MeatAvailableMin = ItemWeight.FromKilograms(Settings.instance.MeatSliderMinCougar);
                            __instance.m_HideAvailableUnits = Settings.instance.HideCountSliderCougar;
                            __instance.m_GutAvailableUnits = Settings.instance.GutCountSliderCougar;
                            __instance.m_QuarterBagMeatCapacity = ItemWeight.FromKilograms(Settings.instance.QuarterSizeSliderCougar);
                            __instance.m_QuarterDurationMinutes = Settings.instance.QuarterDurationMinutesSliderCougar;
                            __instance.m_FatToMeatRatio = Settings.instance.FatToMeatPercentSliderCougar / 100;
                            __instance.m_DecayConditionPerHour *= Settings.instance.DecayRateSliderCougar;
                        }

                        __instance.m_QuarterBagWasteMultiplier = Settings.instance.QuarterWasteSliderGlobal;
                    }
                    catch (Exception ex)
                    {
                        MelonLogger.Error($"Error in Patch_QuantitiesAndDecay: {ex}");
                    }
                }
            } 

        } // End of BodyHarvest_Patches
    } // End of Patches
} // End of namespace