using ModSettings;
using System.Reflection;
using System;
using MelonLoader;

namespace CarcassYieldTweaker
{
    internal static class Settings
    {
        internal static CarcassYieldTweakerSettings settings = new();

        internal static void OnLoad()
        {
            settings.AddToModSettings("Carcass Yield Tweaker Settings");
            settings.RefreshGUI();
        }
    }

    // Define Vanilla Settings (only once)
    public static class VanillaSettings
    {
        // Rabbit
        public static float VanillaMeatSliderMinRabbit = 0.75f;
        public static float VanillaMeatSliderMaxRabbit = 1.5f;
        public static int VanillaHideSliderRabbit = 1;
        public static int VanillaGutSliderRabbit = 1;
        public static float VanillaHideTimeSliderRabbit = 1.0f;

        // Ptarmigan (DLC)
        public static float VanillaMeatSliderMinPtarmigan = 0.75f;
        public static float VanillaMeatSliderMaxPtarmigan = 1.5f;
        public static int VanillaHideSliderPtarmigan = 4;
        public static float VanillaHideTimeSliderPtarmigan = 1.0f;

        // Doe
        public static float VanillaMeatSliderMinDoe = 7f;
        public static float VanillaMeatSliderMaxDoe = 9f;
        public static int VanillaHideSliderDoe = 1;
        public static int VanillaGutSliderDoe = 2;
        public static float VanillaQuarterSizeSliderDoe = 2.5f;
        public static int VanillaFatToMeatPercentSliderDoe = 20;
        public static float VanillaHideTimeSliderDoe = 1f;
        public static int VanillaQuarterDurationMinutesSliderDoe = 60;

        // Stag
        public static float VanillaMeatSliderMinStag = 11f;
        public static float VanillaMeatSliderMaxStag = 13f;
        public static int VanillaHideSliderStag = 1;
        public static int VanillaGutSliderStag = 2;
        public static float VanillaQuarterSizeSliderStag = 2.5f;
        public static int VanillaFatToMeatPercentSliderStag = 20;
        public static float VanillaHideTimeSliderStag = 1f;
        public static int VanillaQuarterDurationMinutesSliderStag = 75;

        // Moose
        public static float VanillaMeatSliderMinMoose = 30f;
        public static float VanillaMeatSliderMaxMoose = 45f;
        public static int VanillaHideSliderMoose = 1;
        public static int VanillaGutSliderMoose = 12;
        public static float VanillaQuarterSizeSliderMoose = 5f;
        public static float VanillaFrozenMeatTimeSliderMoose = 1.0f;
        public static float VanillaHideTimeSliderMoose = 1.0f;
        public static int VanillaFatToMeatPercentSliderMoose = 15;
        public static int VanillaQuarterDurationMinutesSliderMoose = 120;

        // Wolf
        public static float VanillaMeatSliderMinWolf = 3f;
        public static float VanillaMeatSliderMaxWolf = 6f;
        public static int VanillaHideSliderWolf = 1;
        public static int VanillaGutSliderWolf = 2;
        public static float VanillaQuarterSizeSliderWolf = 2.5f;
        public static int VanillaFatToMeatPercentSliderWolf = 10;
        public static float VanillaHideTimeSliderWolf = 1.0f;
        public static int VanillaQuarterDurationMinutesSliderWolf = 60;

        // TimberWolf
        public static float VanillaMeatSliderMinTimberWolf = 4f;
        public static float VanillaMeatSliderMaxTimberWolf = 7f;
        public static int VanillaHideSliderTimberWolf = 1;
        public static int VanillaGutSliderTimberWolf = 2;
        public static float VanillaQuarterSizeSliderTimberWolf = 2.5f;
        public static int VanillaFatToMeatPercentSliderTimberWolf = 10;
        public static float VanillaHideTimeSliderTimberWolf = 1.0f;
        public static int VanillaQuarterDurationMinutesSliderTimberWolf = 60;

        // Bear
        public static float VanillaMeatSliderMinBear = 25f;
        public static float VanillaMeatSliderMaxBear = 40f;
        public static int VanillaHideSliderBear = 1;
        public static int VanillaGutSliderBear = 10;
        public static float VanillaQuarterSizeSliderBear = 5f;
        public static int VanillaFatToMeatPercentSliderBear = 10;
        public static float VanillaHideTimeSliderBear = 1.0f;
        public static int VanillaQuarterDurationMinutesSliderBear = 120;

        // Cougar (DLC)
        public static float VanillaMeatSliderMinCougar = 4f;
        public static float VanillaMeatSliderMaxCougar = 5f;
        public static int VanillaHideSliderCougar = 1;
        public static int VanillaGutSliderCougar = 2;
        public static float VanillaQuarterSizeSliderCougar = 2.5f;
        public static int VanillaFatToMeatPercentSliderCougar = 10;
        public static float VanillaHideTimeSliderCougar = 1.0f;
        public static int VanillaQuarterDurationMinutesSliderCougar = 120;

        // Poisoned Wolf (DLC)
        public static int VanillaHideSliderPoisonedWolf = 1;
        public static int VanillaGutSliderPoisonedWolf = 2;
        public static float VanillaHideTimeSliderPoisonedWolf = 1.0f;

        

        // Quartering Waste Multiplier
        public static float VanillaQuarterWasteMultiplier = 1.0f;
    }


    internal class CarcassYieldTweakerSettings : JsonModSettings
    {
        protected override void OnChange(FieldInfo field, object oldValue, object newValue)
        {
            bool flag = field.Name == "preset" && this.preset != 3;
            if (flag)
            {
                this.UsePreset((int)newValue);
            }
            base.RefreshGUI();
        }

        private void UsePreset(int preset)
        {
            switch (preset)
            {
                case 0:
                    // Set Vanilla Values from the VanillaSettings class
                    // Rabbit
                    this.MeatSliderMinRabbit = VanillaSettings.VanillaMeatSliderMinRabbit;
                    this.MeatSliderMaxRabbit = VanillaSettings.VanillaMeatSliderMaxRabbit;
                    this.HideSliderRabbit = VanillaSettings.VanillaHideSliderRabbit;
                    this.GutSliderRabbit = VanillaSettings.VanillaGutSliderRabbit;
                    this.HideTimeSliderRabbit = VanillaSettings.VanillaHideTimeSliderRabbit;

                    // Ptarmigan (DLC)
                    this.MeatSliderMinPtarmigan = VanillaSettings.VanillaMeatSliderMinPtarmigan;
                    this.MeatSliderMaxPtarmigan = VanillaSettings.VanillaMeatSliderMaxPtarmigan;
                    this.HideSliderPtarmigan = VanillaSettings.VanillaHideSliderPtarmigan;
                    this.HideTimeSliderPtarmigan = VanillaSettings.VanillaHideTimeSliderPtarmigan;

                    // Doe
                    this.MeatSliderMinDoe = VanillaSettings.VanillaMeatSliderMinDoe;
                    this.MeatSliderMaxDoe = VanillaSettings.VanillaMeatSliderMaxDoe;
                    this.HideSliderDoe = VanillaSettings.VanillaHideSliderDoe;
                    this.GutSliderDoe = VanillaSettings.VanillaGutSliderDoe;
                    this.HideTimeSliderDoe = VanillaSettings.VanillaHideTimeSliderDoe;

                    // Stag
                    this.MeatSliderMinStag = VanillaSettings.VanillaMeatSliderMinStag;
                    this.MeatSliderMaxStag = VanillaSettings.VanillaMeatSliderMaxStag;
                    this.HideSliderStag = VanillaSettings.VanillaHideSliderStag;
                    this.GutSliderStag = VanillaSettings.VanillaGutSliderStag;
                    this.HideTimeSliderStag = VanillaSettings.VanillaHideTimeSliderStag;

                    // Moose
                    this.MeatSliderMinMoose = VanillaSettings.VanillaMeatSliderMinMoose;
                    this.MeatSliderMaxMoose = VanillaSettings.VanillaMeatSliderMaxMoose;
                    this.HideSliderMoose = VanillaSettings.VanillaHideSliderMoose;
                    this.GutSliderMoose = VanillaSettings.VanillaGutSliderMoose;
                    this.HideTimeSliderMoose = VanillaSettings.VanillaHideTimeSliderMoose;

                    // Wolf
                    this.MeatSliderMinWolf = VanillaSettings.VanillaMeatSliderMinWolf;
                    this.MeatSliderMaxWolf = VanillaSettings.VanillaMeatSliderMaxWolf;
                    this.HideSliderWolf = VanillaSettings.VanillaHideSliderWolf;
                    this.GutSliderWolf = VanillaSettings.VanillaGutSliderWolf;
                    this.HideTimeSliderWolf = VanillaSettings.VanillaHideTimeSliderWolf;

                    // TimberWolf
                    this.MeatSliderMinTimberWolf = VanillaSettings.VanillaMeatSliderMinTimberWolf;
                    this.MeatSliderMaxTimberWolf = VanillaSettings.VanillaMeatSliderMaxTimberWolf;
                    this.HideSliderTimberWolf = VanillaSettings.VanillaHideSliderTimberWolf;
                    this.GutSliderTimberWolf = VanillaSettings.VanillaGutSliderTimberWolf;
                    this.HideTimeSliderTimberWolf = VanillaSettings.VanillaHideTimeSliderTimberWolf;

                    // Bear
                    this.MeatSliderMinBear = VanillaSettings.VanillaMeatSliderMinBear;
                    this.MeatSliderMaxBear = VanillaSettings.VanillaMeatSliderMaxBear;
                    this.HideSliderBear = VanillaSettings.VanillaHideSliderBear;
                    this.GutSliderBear = VanillaSettings.VanillaGutSliderBear;
                    this.HideTimeSliderBear = VanillaSettings.VanillaHideTimeSliderBear;

                    // Cougar
                    this.MeatSliderMinCougar = VanillaSettings.VanillaMeatSliderMinCougar;
                    this.MeatSliderMaxCougar = VanillaSettings.VanillaMeatSliderMaxCougar;
                    this.HideSliderCougar = VanillaSettings.VanillaHideSliderCougar;
                    this.GutSliderCougar = VanillaSettings.VanillaGutSliderCougar;
                    this.HideTimeSliderCougar = VanillaSettings.VanillaHideTimeSliderCougar;

                    break;

                case 1:
                    // Realistic Preset - Meat values are based on data from Canadian encyclopedia (see DATA.xlsx)

                    // Rabbit
                    this.MeatSliderMinRabbit = 0.75f;
                    this.MeatSliderMaxRabbit = 1.5f;
                    this.HideSliderRabbit = 1;
                    this.GutSliderRabbit = 2;

                    // Ptarmigan (DLC)
                    this.MeatSliderMinPtarmigan = 0.43f;
                    this.MeatSliderMaxPtarmigan = 0.81f;
                    this.HideSliderPtarmigan = 4;

                    // Doe
                    this.MeatSliderMinDoe = 16f;
                    this.MeatSliderMaxDoe = 36f;
                    this.HideSliderDoe = 1;
                    this.GutSliderDoe = 12;
                    this.QuarterSizeSliderDoe = 10f;
                    this.QuarterDurationMinutesSliderDoe = 30;
                    this.FatToMeatPercentSliderDoe = 3; //Doe are very lean

                    //// Stag
                    this.MeatSliderMinStag = 38f;
                    this.MeatSliderMaxStag = 57f;
                    this.HideSliderStag = 1;
                    this.GutSliderStag = 15;
                    this.QuarterSizeSliderStag = 15f;
                    this.QuarterDurationMinutesSliderStag = 60;
                    this.FatToMeatPercentSliderStag = 4; // Stags have a bit more fat

                    // Moose
                    this.MeatSliderMinMoose = 121f;
                    this.MeatSliderMaxMoose = 270f;
                    this.HideSliderMoose = 1;
                    this.GutSliderMoose = 40;
                    this.QuarterSizeSliderMoose = 30f;
                    this.QuarterDurationMinutesSliderMoose = 150;
                    this.FatToMeatPercentSliderMoose = 5;

                    // Wolf
                    this.MeatSliderMinWolf = 7f;
                    this.MeatSliderMaxWolf = 26f;
                    this.HideSliderWolf = 1;
                    this.GutSliderWolf = 6;
                    this.QuarterSizeSliderWolf = 7f;
                    this.QuarterDurationMinutesSliderWolf = 20;
                    this.FatToMeatPercentSliderWolf = 2;

                    //// TimberWolf (all missing variables added, since it wasn't in the original preset)
                    //this.MeatSliderMinTimberWolf = 4f; // Default value
                    //this.MeatSliderMaxTimberWolf = 7f; // Default value
                    //this.HideSliderTimberWolf = 1; // Default value
                    //this.GutSliderTimberWolf = 2; // Default value
                    //this.QuarterSizeSliderTimberWolf = 2.5f; // Default value
                    //this.QuarterDurationMinutesSliderTimberWolf = 30; // Default value
                    //this.FatToMeatPercentSliderTimberWolf = 3; // Default value

                    //// Poisoned Wolf (DLC) (all missing variables added, since it wasn't in the original preset)
                    //this.HideSliderPoisonedWolf = 1; // Default value
                    //this.GutSliderPoisonedWolf = 2; // Default value

                    // Bear
                    this.MeatSliderMinBear = 16f;
                    this.MeatSliderMaxBear = 135f;
                    this.HideSliderBear = 1;
                    this.GutSliderBear = 25;
                    this.QuarterSizeSliderBear = 25f;
                    this.QuarterDurationMinutesSliderBear = 180;
                    this.FatToMeatPercentSliderBear = 25;

                    // Cougar (DLC)
                    this.MeatSliderMinCougar = 13f;
                    this.MeatSliderMaxCougar = 54f;
                    this.HideSliderCougar = 1;
                    this.GutSliderCougar = 6;
                    this.QuarterSizeSliderCougar = 18f;
                    this.QuarterDurationMinutesSliderCougar = 60;
                    this.FatToMeatPercentSliderCougar = 4;

                    // Quarter Waste Multiplier
                    this.QuarterWasteMultipler = 1.2f;


                    break;

                case 2:
                    // Realistic (Balanced) Preset - Meat values are based on data from Canadian encyclopedia (see DATA.xlsx)

                    // Rabbit
                    this.MeatSliderMinRabbit = 0.75f; // Realistic unchanged
                    this.MeatSliderMaxRabbit = 1.5f; // Realistic unchanged
                    this.HideSliderRabbit = 1;
                    this.GutSliderRabbit = 2; // Realistic unchanged

                    // Ptarmigan (DLC)
                    this.MeatSliderMinPtarmigan = 0.43f; // Realistic unchanged
                    this.MeatSliderMaxPtarmigan = 0.81f; // Realistic unchanged
                    this.HideSliderPtarmigan = 4;

                    // Doe
                    this.MeatSliderMinDoe = 11f; // Realistic -33%
                    this.MeatSliderMaxDoe = 18f; // Realistic -50%
                    this.HideSliderDoe = 1;
                    this.GutSliderDoe = 3; // Arbitrary value
                    this.QuarterSizeSliderDoe = 6f; // Arbitrary value
                    this.QuarterDurationMinutesSliderDoe = 30;
                    this.FatToMeatPercentSliderDoe = 6;

                    //// Stag
                    this.MeatSliderMinStag = 25f; // Realistic -33%
                    this.MeatSliderMaxStag = 37f; // Realistic -50%
                    this.HideSliderStag = 1;
                    this.GutSliderStag = 5; // Arbitrary value
                    this.QuarterSizeSliderStag = 8f; // Arbitrary value
                    this.QuarterDurationMinutesSliderStag = 70;
                    this.FatToMeatPercentSliderStag = 8;

                    // Moose
                    this.MeatSliderMinMoose = 80f; // Realistic -33%
                    this.MeatSliderMaxMoose = 135f; // Realistic -50%
                    this.HideSliderMoose = 1;
                    this.GutSliderMoose = 16; // Arbitrary value
                    this.QuarterSizeSliderMoose = 20f; // Arbitrary value
                    this.QuarterDurationMinutesSliderMoose = 120;
                    this.FatToMeatPercentSliderMoose = 15;

                    // Wolf
                    this.MeatSliderMinWolf = 5f; // Realistic -33%
                    this.MeatSliderMaxWolf = 13f; // Realistic -50%
                    this.HideSliderWolf = 1;
                    this.GutSliderWolf = 2; // Arbitrary value
                    this.QuarterSizeSliderWolf = 5f; // Arbitrary value
                    this.QuarterDurationMinutesSliderWolf = 40;
                    this.FatToMeatPercentSliderWolf = 4;

                    // TimberWolf 
                    //this.MeatSliderMinTimberWolf = 4f; // Default value
                    //this.MeatSliderMaxTimberWolf = 7f; // Default value
                    //this.HideSliderTimberWolf = 1; // Default value
                    //this.GutSliderTimberWolf = 2; // Default value
                    //this.QuarterSizeSliderTimberWolf = 2.5f; // Default value
                    this.QuarterDurationMinutesSliderTimberWolf = 45;
                    this.FatToMeatPercentSliderTimberWolf = 5;

                    // Poisoned Wolf (DLC) 
                    //this.HideSliderPoisonedWolf = 1; // Default value
                    //this.GutSliderPoisonedWolf = 2; // Default value

                    // Bear
                    this.MeatSliderMinBear = 16f; // Realistic unchanged
                    this.MeatSliderMaxBear = 68f; // Realistic -50%
                    this.HideSliderBear = 1;
                    this.GutSliderBear = 12; // Vanilla value 12
                    this.QuarterSizeSliderBear = 15f; // Realistic -10
                    this.QuarterDurationMinutesSliderBear = 120;
                    this.FatToMeatPercentSliderBear = 10;

                    // Cougar (DLC)
                    this.MeatSliderMinCougar = 8f; // Realistic -33%
                    this.MeatSliderMaxCougar = 27f; // Realistic -50%
                    this.HideSliderCougar = 1;
                    this.GutSliderCougar = 5; // Arbitrary value
                    this.QuarterSizeSliderCougar = 7f; // Arbitrary value
                    this.QuarterDurationMinutesSliderCougar = 90;
                    this.FatToMeatPercentSliderCougar = 10;

                    // Quarter Waste Multiplier
                    this.QuarterWasteMultipler = 1.2f;

                    break;

            }
        }

        [Section("Global Harvest Time (Multipliers) ")]

        [Name("Meat (Thawed Carcass")]
        [Description("Global Meat harvest time multiplier. Vanilla value is 1")]
        [Slider(0.1f, 2)]
        public float GlobalMeatTimeSlider = 1f;

        [Name("Meat (Frozen Carcass)")]
        [Description("Global Frozen Meat harvest time multiplier. Vanilla value is 1")]
        [Slider(0.1f, 2)]
        public float GlobalFrozenMeatTimeSlider = 1f;

        [Name("Gut")]
        [Description("Global Gut harvest time multiplier. Vanilla value is 1")]
        [Slider(0.1f, 2)]
        public float GlobalGutTimeSlider = 1f;


        [Section("Harvestables")]

        [Name("Presets")]
        [Description("Select preset")]
        [Choice(new string[]
        {
            "Vanilla", // 0
            "Realistic", // 1
            "Realistic (Balanced)", // 2
            "Custom"// 3
        })]
        public int preset = 0;


        [Section("Rabbit")]

        [Name("Minimum Meat (Kg)")]
        [Description("Minimum meat from a freshly killed Rabbit. Vanilla value is 0.75")]
        [Slider(0.75f, 5f)]
        public float MeatSliderMinRabbit = VanillaSettings.VanillaMeatSliderMinRabbit;

        [Name("Maximum Meat (Kg)")]
        [Description("Maximum meat from a freshly killed Rabbit. Vanilla value is 1.5")]
        [Slider(0.75f, 5f)]
        public float MeatSliderMaxRabbit = VanillaSettings.VanillaMeatSliderMaxRabbit;

        [Name("Hide Count")]
        [Description("Hides from a freshly killed Rabbit. Vanilla value is 1")]
        [Slider(0, 10)]
        public int HideSliderRabbit = VanillaSettings.VanillaHideSliderRabbit;

        [Name("Gut Count")]
        [Description("Guts from a freshly killed Rabbit. Vanilla value is 1")]
        [Slider(0, 10)]
        public int GutSliderRabbit = VanillaSettings.VanillaGutSliderRabbit;

        [Name("Hide Harvest Time")]
        [Description("Rabbit Hide harvest time multiplier. Vanilla value is 1")]
        [Slider(0.1f, 2.0f)]
        public float HideTimeSliderRabbit = VanillaSettings.VanillaHideTimeSliderRabbit;



        [Section("Ptarmigan (DLC)")]

        [Name("Minimum Meat (Kg)")]
        [Description("Minimum meat from a freshly killed Ptarmigan. Vanilla value is 0.75")]
        [Slider(0.75f, 5f)]
        public float MeatSliderMinPtarmigan = VanillaSettings.VanillaMeatSliderMinPtarmigan;

        [Name("Maximum Meat (Kg)")]
        [Description("Maximum meat from a freshly killed Ptarmigan. Vanilla value is 1.5")]
        [Slider(0.75f, 5f)]
        public float MeatSliderMaxPtarmigan = VanillaSettings.VanillaMeatSliderMaxPtarmigan;

        [Name("Down Feather Count")]
        [Description("Number of harvestable down feathers from a Ptarmigan. Vanilla value is 4")]
        [Slider(1f, 10f)]
        public int HideSliderPtarmigan = VanillaSettings.VanillaHideSliderPtarmigan;

        [Name("Down Feathers Harvest Time")]
        [Description("Ptarmigan down feathers harvest time multiplier. Vanilla value is 1")]
        [Slider(0.1f, 2.0f)]
        public float HideTimeSliderPtarmigan = VanillaSettings.VanillaHideTimeSliderPtarmigan;



        [Section("Doe")]

        [Name("Minimum Meat (Kg)")]
        [Description("Minimum meat from a freshly killed Doe. Vanilla value is 7")]
        [Slider(0f, 300f)]
        public float MeatSliderMinDoe = VanillaSettings.VanillaMeatSliderMinDoe;

        [Name("Maximum Meat (Kg)")]
        [Description("Maximum meat from a freshly killed Doe. Vanilla value is 9")]
        [Slider(0f, 300f)]
        public float MeatSliderMaxDoe = VanillaSettings.VanillaMeatSliderMaxDoe;

        [Name("Hide Count")]
        [Description("Hides from a freshly killed Doe. Vanilla value is 1")]
        [Slider(0, 10)]
        public int HideSliderDoe = VanillaSettings.VanillaHideSliderDoe;

        [Name("Gut Count")]
        [Description("Guts from a freshly killed Doe. Vanilla value is 2")]
        [Slider(0, 20)]
        public int GutSliderDoe = VanillaSettings.VanillaGutSliderDoe;

        [Name("Quarter Size (Kg)")]
        [Description("Size of each quarter in Kg from a Doe. Vanilla value is 2.5")]
        [Slider(1f, 50f)]
        public float QuarterSizeSliderDoe = VanillaSettings.VanillaQuarterSizeSliderDoe;

        [Name("Fat to Meat Percentage (%)")]
        [Description("Fat to meat percentage for a Doe. Vanilla value is 20%")]
        [Slider(0, 40)]
        public float FatToMeatPercentSliderDoe = VanillaSettings.VanillaFatToMeatPercentSliderDoe;

        [Name("Hide Harvest Time")]
        [Description("Doe Hide harvest time multiplier. Vanilla value is 1")]
        [Slider(0.1f, 2.0f)]
        public float HideTimeSliderDoe = VanillaSettings.VanillaHideTimeSliderDoe;

        [Name("Quarter Time")]
        [Description("Minutes to quarter a Doe. Vanilla value is 60")]
        [Slider(1, 180)]
        public int QuarterDurationMinutesSliderDoe = VanillaSettings.VanillaQuarterDurationMinutesSliderDoe;



        [Section("Stag")]

        [Name("Minimum Meat (Kg)")]
        [Description("Minimum amount of harvestable meat in Kg from a Stag. Vanilla value is 11")]
        [Slider(0f, 300f)]
        public float MeatSliderMinStag = VanillaSettings.VanillaMeatSliderMinStag;

        [Name("Maximum Meat (Kg)")]
        [Description("Maximum amount of harvestable meat in Kg from a Stag. Vanilla value is 13")]
        [Slider(0f, 300f)]
        public float MeatSliderMaxStag = VanillaSettings.VanillaMeatSliderMaxStag;

        [Name("Hide Count")]
        [Description("Hides from a freshly killed Stag. Vanilla value is 1")]
        [Slider(0, 10)]
        public int HideSliderStag = VanillaSettings.VanillaHideSliderStag;

        [Name("Gut Count")]
        [Description("Guts from a freshly killed Stag. Vanilla value is 2")]
        [Slider(1, 20)]
        public int GutSliderStag = VanillaSettings.VanillaGutSliderStag;

        [Name("Quarter Size (Kg)")]
        [Description("Size of each quarter in Kg from a Stag. Vanilla value is 2.5")]
        [Slider(1f, 50f)]
        public float QuarterSizeSliderStag = VanillaSettings.VanillaQuarterSizeSliderStag;

        [Name("Fat to Meat Percentage (%)")]
        [Description("Fat to meat percentage for a Stag. Vanilla value is 20%")]
        [Slider(0, 40)]
        public int FatToMeatPercentSliderStag = VanillaSettings.VanillaFatToMeatPercentSliderStag;

        [Name("Hide Harvest Time")]
        [Description("Stag Hide harvest time multiplier. Vanilla value is 1")]
        [Slider(0.1f, 2.0f)]
        public float HideTimeSliderStag = VanillaSettings.VanillaHideTimeSliderStag;

        [Name("Quarter Time")]
        [Description("Minutes to quarter a Stag. Vanilla value is 75")]
        [Slider(1, 180)]
        public int QuarterDurationMinutesSliderStag = VanillaSettings.VanillaQuarterDurationMinutesSliderStag;



        [Section("Moose")]

        [Name("Minimum Meat (Kg)")]
        [Description("Minimum meat from a freshly killed Moose. Vanilla value is 30")]
        [Slider(0f, 300f)]
        public float MeatSliderMinMoose = VanillaSettings.VanillaMeatSliderMinMoose;

        [Name("Maximum Meat (Kg)")]
        [Description("Maximum meat from a freshly killed Moose. Vanilla value is 45")]
        [Slider(0f, 300f)]
        public float MeatSliderMaxMoose = VanillaSettings.VanillaMeatSliderMaxMoose;

        [Name("Hide Count")]
        [Description("Hides from a freshly killed Moose. Vanilla value is 1")]
        [Slider(0, 10)]
        public int HideSliderMoose = VanillaSettings.VanillaHideSliderMoose;

        [Name("Gut Count")]
        [Description("Guts from a freshly killed Moose. Vanilla value is 12")]
        [Slider(1, 48)]
        public int GutSliderMoose = VanillaSettings.VanillaGutSliderMoose;

        [Name("Quarter Size (Kg)")]
        [Description("Size of each quarter in Kg from a Moose. Vanilla value is 5")]
        [Slider(1f, 50f)]
        public float QuarterSizeSliderMoose = VanillaSettings.VanillaQuarterSizeSliderMoose;

        [Name("Fat to Meat Percentage (%)")]
        [Description("Fat to meat percentage for a Moose. Vanilla value is 15%")]
        [Slider(0, 40)]
        public int FatToMeatPercentSliderMoose = VanillaSettings.VanillaFatToMeatPercentSliderMoose;

        [Name("Hide Harvest Time")]
        [Description("Moose Hide harvest time multiplier. Vanilla value is 1")]
        [Slider(0.1f, 2.0f)]
        public float HideTimeSliderMoose = VanillaSettings.VanillaHideTimeSliderMoose;

        [Name("Quarter Time")]
        [Description("Minutes to quarter a Moose. Vanilla value is 120")]
        [Slider(1, 180)]
        public int QuarterDurationMinutesSliderMoose = VanillaSettings.VanillaQuarterDurationMinutesSliderMoose;



        [Section("Wolf")]

        [Name("Minimum Meat (Kg)")]
        [Description("Minimum meat from a freshly killed Wolf. Vanilla value is 3")]
        [Slider(0f, 300f)]
        public float MeatSliderMinWolf = VanillaSettings.VanillaMeatSliderMinWolf;

        [Name("Maximum Meat (Kg)")]
        [Description("Maximum meat from a freshly killed Wolf. Vanilla value is 6")]
        [Slider(0f, 300f)]
        public float MeatSliderMaxWolf = VanillaSettings.VanillaMeatSliderMaxWolf;

        [Name("Hide Count")]
        [Description("Hides from a freshly killed Wolf. Vanilla value is 1")]
        [Slider(0, 10)]
        public int HideSliderWolf = VanillaSettings.VanillaHideSliderWolf;

        [Name("Gut Count")]
        [Description("Guts from a freshly killed Wolf. Vanilla value is 2")]
        [Slider(1, 20)]
        public int GutSliderWolf = VanillaSettings.VanillaGutSliderWolf;

        [Name("Quarter Size (Kg)")]
        [Description("Size of each Quarter in Kg from a Wolf. Vanilla value is 2.5")]
        [Slider(1f, 50f)]
        public float QuarterSizeSliderWolf = VanillaSettings.VanillaQuarterSizeSliderWolf;

        [Name("Fat to Meat Percentage (%)")]
        [Description("Fat to meat percentage for a Wolf. Vanilla value is 10%")]
        [Slider(0, 40)]
        public int FatToMeatPercentSliderWolf = VanillaSettings.VanillaFatToMeatPercentSliderWolf;

        [Name("Hide Harvest Time")]
        [Description("Wolf Hide harvest time multiplier. Vanilla value is 1")]
        [Slider(0.1f, 2.0f)]
        public float HideTimeSliderWolf = VanillaSettings.VanillaHideTimeSliderWolf;

        [Name("Quarter Time")]
        [Description("Minutes to quarter a Wolf. Vanilla value is 60")]
        [Slider(1, 180)]
        public int QuarterDurationMinutesSliderWolf = VanillaSettings.VanillaQuarterDurationMinutesSliderWolf;



        [Section("TimberWolf")]

        [Name("Minimum Meat (Kg)")]
        [Description("Minimum meat from a freshly killed TimberWolf. Vanilla value is 4")]
        [Slider(0f, 300f)]
        public float MeatSliderMinTimberWolf = VanillaSettings.VanillaMeatSliderMinTimberWolf;

        [Name("Maximum Meat (Kg)")]
        [Description("Maximum meat from a freshly killed TimberWolf. Vanilla value is 7")]
        [Slider(0f, 300f)]
        public float MeatSliderMaxTimberWolf = VanillaSettings.VanillaMeatSliderMaxTimberWolf;

        [Name("Hide Count")]
        [Description("Hides from a freshly killed TimberWolf. Vanilla value is 1")]
        [Slider(0, 10)]
        public int HideSliderTimberWolf = VanillaSettings.VanillaHideSliderTimberWolf;

        [Name("Gut Count")]
        [Description("Guts from a freshly killed TimberWolf. Vanilla value is 2")]
        [Slider(1, 20)]
        public int GutSliderTimberWolf = VanillaSettings.VanillaGutSliderTimberWolf;

        [Name("Quarter Size (Kg)")]
        [Description("Size of each Quarter in Kg from a TimberWolf. Vanilla value is 2.5")]
        [Slider(1f, 50f)]
        public float QuarterSizeSliderTimberWolf = VanillaSettings.VanillaQuarterSizeSliderTimberWolf;

        [Name("Fat to Meat Percentage (%)")]
        [Description("Fat to meat percentage for a TimberWolf. Vanilla value is 10%")]
        [Slider(0, 40)]
        public int FatToMeatPercentSliderTimberWolf = VanillaSettings.VanillaFatToMeatPercentSliderTimberWolf;

        [Name("Hide Harvest Time")]
        [Description("TimberWolf Hide harvest time multiplier. Vanilla value is 1")]
        [Slider(0.1f, 2.0f)]
        public float HideTimeSliderTimberWolf = VanillaSettings.VanillaHideTimeSliderTimberWolf;

        [Name("Quarter Time")]
        [Description("Minutes to quarter a TimberWolf. Vanilla value is 60")]
        [Slider(1, 180)]
        public int QuarterDurationMinutesSliderTimberWolf = VanillaSettings.VanillaQuarterDurationMinutesSliderTimberWolf;



        [Section("Poisoned Wolf (DLC)")]

        [Name("Hide Count")]
        [Description("Hides from a freshly killed Poisoned Wolf. Vanilla value is 1")]
        [Slider(0, 10)]
        public int HideSliderPoisonedWolf = VanillaSettings.VanillaHideSliderPoisonedWolf;

        [Name("Gut Count")]
        [Description("Guts from a freshly killed Poisoned Wolf. Vanilla value is 2")]
        [Slider(1, 20)]
        public int GutSliderPoisonedWolf = VanillaSettings.VanillaGutSliderPoisonedWolf;

        [Name("Hide Harvest Time")]
        [Description("Poisoned Wolf Hide harvest time multiplier. Vanilla value is 1")]
        [Slider(0.1f, 2.0f)]
        public float HideTimeSliderPoisonedWolf = VanillaSettings.VanillaHideTimeSliderPoisonedWolf;



        [Section("Bear")]

        [Name("Minimum Meat (Kg)")]
        [Description("Minimum meat from a freshly killed Bear. Vanilla value is 25")]
        [Slider(0f, 300f)]
        public float MeatSliderMinBear = VanillaSettings.VanillaMeatSliderMinBear;

        [Name("Maximum Meat (Kg)")]
        [Description("Maximum meat from a freshly killed Bear. Vanilla value is 40")]
        [Slider(0f, 300f)]
        public float MeatSliderMaxBear = VanillaSettings.VanillaMeatSliderMaxBear;

        [Name("Hide Count")]
        [Description("Hides from a freshly killed Bear. Vanilla value is 1")]
        [Slider(0, 10)]
        public int HideSliderBear = VanillaSettings.VanillaHideSliderBear;

        [Name("Gut Count")]
        [Description("Guts from a freshly killed Bear. Vanilla value is 10")]
        [Slider(1, 40)]
        public int GutSliderBear = VanillaSettings.VanillaGutSliderBear;

        [Name("Quarter Size (Kg)")]
        [Description("Size of each Quarter in Kg from a Bear. Vanilla value is 5")]
        [Slider(1f, 50f)]
        public float QuarterSizeSliderBear = VanillaSettings.VanillaQuarterSizeSliderBear;

        [Name("Fat to Meat Percentage (%)")]
        [Description("Fat to meat percentage for a Bear. Vanilla value is 10%")]
        [Slider(0, 40)]
        public int FatToMeatPercentSliderBear = VanillaSettings.VanillaFatToMeatPercentSliderBear;

        [Name("Hide Harvest Time")]
        [Description("Bear Hide harvest time multiplier. Vanilla value is 1")]
        [Slider(0.1f, 2.0f)]
        public float HideTimeSliderBear = VanillaSettings.VanillaHideTimeSliderBear;

        [Name("Quarter Time")]
        [Description("Minutes to quarter a Bear. Vanilla value is 120")]
        [Slider(1, 180)]
        public int QuarterDurationMinutesSliderBear = VanillaSettings.VanillaQuarterDurationMinutesSliderBear;



        [Section("Cougar (DLC)")]

        [Name("Minimum Meat (Kg)")]
        [Description("Minimum meat from a freshly killed Cougar. Vanilla value is 4")]
        [Slider(0f, 300f)]
        public float MeatSliderMinCougar = VanillaSettings.VanillaMeatSliderMinCougar;

        [Name("Maximum Meat (Kg)")]
        [Description("Maximum meat from a freshly killed Cougar. Vanilla value is 5")]
        [Slider(0f, 300f)]
        public float MeatSliderMaxCougar = VanillaSettings.VanillaMeatSliderMaxCougar;

        [Name("Hide Count")]
        [Description("Hides from a freshly killed Cougar. Vanilla value is 1")]
        [Slider(1f, 10f)]
        public int HideSliderCougar = VanillaSettings.VanillaHideSliderCougar;

        [Name("Gut Count")]
        [Description("Guts from a freshly killed Cougar. Vanilla value is 2")]
        [Slider(1, 50)]
        public int GutSliderCougar = VanillaSettings.VanillaGutSliderCougar;

        [Name("Quarter Size (Kg)")]
        [Description("Size of each Quarter in Kg from a Cougar. Vanilla value is 2.5")]
        [Slider(1f, 50f)]
        public float QuarterSizeSliderCougar = VanillaSettings.VanillaQuarterSizeSliderCougar;

        [Name("Fat to Meat Percentage (%)")]
        [Description("Fat to meat percentage for a Cougar. Vanilla value is 10%")]
        [Slider(0, 40)]
        public int FatToMeatPercentSliderCougar = VanillaSettings.VanillaFatToMeatPercentSliderCougar;

        [Name("Hide Harvest Time")]
        [Description($"Cougar Hide harvest time multiplier. Vanilla value is 1")]
        [Slider(0.1f, 2.0f)]
        public float HideTimeSliderCougar = VanillaSettings.VanillaHideTimeSliderCougar;

        [Name("Quarter Time")]
        [Description("Minutes to quarter a Cougar. Vanilla value is 120")]
        [Slider(1, 180)]
        public int QuarterDurationMinutesSliderCougar = VanillaSettings.VanillaQuarterDurationMinutesSliderCougar;



        [Section("Quarter Waste (Multiplier)")]

        [Name("Waste")]
        [Description("Changes the amount of unharvestable waste, e.g. Bones. Vanilla value is 2")]
        [Slider(0f, 4f)]
        public float QuarterWasteMultipler = VanillaSettings.VanillaQuarterWasteMultiplier;

    }
}
