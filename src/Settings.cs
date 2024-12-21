using ModSettings;
using System.Reflection;

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
                    //Vanilla Preset - Game Defaults

                    // Rabbit
                    this.RabbitSliderMin = 0.75f;
                    this.RabbitSliderMax = 1.5f;
                    this.RabbitHideSlider = 1;
                    this.RabbitGutSlider = 1;
                    this.RabbitDecayConditionPerDayPercentSlider = 10f;

                    // Ptarmigan (DLC)
                    this.PtarmiganSliderMin = 0.75f;
                    this.PtarmiganSliderMax = 1.5f;
                    this.PtarmiganHideSlider = 4;
                    this.PtarmiganDecayConditionPerDayPercentSlider = 10f;

                    // Doe
                    this.DoeSliderMin = 7f;
                    this.DoeSliderMax = 9f;
                    this.DoeHideSlider = 1;
                    this.DoeGutSlider = 2;
                    this.DoeQuarterSizeSlider = 2.5f;
                    this.DoeQuarterDurationMinutesSlider = 60;
                    this.DoeFatToMeatPercentSlider = 20f;
                    this.DoeDecayConditionPerDayPercentSlider = 33.3f;

                    //// Stag
                    this.StagSliderMin = 11f;
                    this.StagSliderMax = 13f;
                    this.StagHideSlider = 1;
                    this.StagGutSlider = 2;
                    this.StagQuarterSizeSlider = 2.5f;
                    this.StagQuarterDurationMinutesSlider = 75;
                    this.StagFatToMeatPercentSlider = 20;
                    this.StagDecayConditionPerDayPercentSlider = 33.3f;

                    // Moose
                    this.MooseSliderMin = 30f;
                    this.MooseSliderMax = 45f;
                    this.MooseHideSlider = 1;
                    this.MooseGutSlider = 12;
                    this.MooseQuarterSizeSlider = 5f;
                    this.MooseQuarterDurationMinutesSlider = 120;
                    this.MooseFatToMeatPercentSlider = 15;
                    this.MooseDecayConditionPerDayPercentSlider = 33.3f;

                    // Wolf
                    this.WolfSliderMin = 3f;
                    this.WolfSliderMax = 6f;
                    this.WolfHideSlider = 1;
                    this.WolfGutSlider = 2;
                    this.WolfQuarterSizeSlider = 2.5f;
                    this.WolfQuarterDurationMinutesSlider = 60;
                    this.WolfFatToMeatPercentSlider = 10;
                    this.WolfDecayConditionPerDayPercentSlider = 33.3f;

                    // TimberWolf
                    this.TimberWolfSliderMin = 4f;
                    this.TimberWolfSliderMax = 7f;
                    this.TimberWolfHideSlider = 1;
                    this.TimberWolfGutSlider = 2;
                    this.TimberWolfQuarterSizeSlider = 2.5f;
                    this.TimberWolfQuarterDurationMinutesSlider = 60;
                    this.TimberWolfFatToMeatPercentSlider = 10;
                    this.TimberWolfDecayConditionPerDayPercentSlider = 33.3f;

                    // Poisoned Wolf (DLC)
                    this.PoisonedWolfHideSlider = 1;
                    this.PoisonedWolfGutSlider = 2;
                    this.PoisonedWolfDecayConditionPerDayPercentSlider = 33.3f;

                    // Bear
                    this.BearSliderMin = 25f;
                    this.BearSliderMax = 40f;
                    this.BearHideSlider = 1;
                    this.BearGutSlider = 10;
                    this.BearQuarterSizeSlider = 5f;
                    this.BearQuarterDurationMinutesSlider = 120;
                    this.BearFatToMeatPercentSlider = 10;
                    this.BearDecayConditionPerDayPercentSlider = 33.3f;

                    // Cougar (DLC)
                    this.CougarSliderMin = 4f;
                    this.CougarSliderMax = 5f;
                    this.CougarHideSlider = 1;
                    this.CougarGutSlider = 2;
                    this.CougarQuarterSizeSlider = 2.5f;
                    this.CougarQuarterDurationMinutesSlider = 120;
                    this.CougarFatToMeatPercentSlider = 10;
                    this.CougarDecayConditionPerDayPercentSlider = 33.3f;

                    // Quarter Waste Multiplier
                    this.QuarterWasteMultipler = 2f;

                    break;




                case 1:
                    // Realistic Preset - Meat values are based on data from Canadian encyclopedia (see DATA.xlsx)

                    // Rabbit
                    this.RabbitSliderMin = 0.75f;
                    this.RabbitSliderMax = 1.5f;
                    this.RabbitHideSlider = 1;
                    this.RabbitGutSlider = 2;
                    this.RabbitDecayConditionPerDayPercentSlider = 10f;

                    // Ptarmigan (DLC)
                    this.PtarmiganSliderMin = 0.43f;
                    this.PtarmiganSliderMax = 0.81f;
                    this.PtarmiganHideSlider = 4;
                    this.PtarmiganDecayConditionPerDayPercentSlider = 10f;

                    // Doe
                    this.DoeSliderMin = 16f;
                    this.DoeSliderMax = 36f;
                    this.DoeHideSlider = 1;
                    this.DoeGutSlider = 12;
                    this.DoeQuarterSizeSlider = 10f;
                    this.DoeQuarterDurationMinutesSlider = 30;
                    this.DoeFatToMeatPercentSlider = 3f; //Doe are very lean
                    this.DoeDecayConditionPerDayPercentSlider = 7f;

                    //// Stag
                    this.StagSliderMin = 38f;
                    this.StagSliderMax = 57f;
                    this.StagHideSlider = 1;
                    this.StagGutSlider = 15;
                    this.StagQuarterSizeSlider = 15f;
                    this.StagQuarterDurationMinutesSlider = 60;
                    this.StagFatToMeatPercentSlider = 4; // Stags have a bit more fat
                    this.StagDecayConditionPerDayPercentSlider = 7f;

                    // Moose
                    this.MooseSliderMin = 121f;
                    this.MooseSliderMax = 270f;
                    this.MooseHideSlider = 1;
                    this.MooseGutSlider = 40;
                    this.MooseQuarterSizeSlider = 30f;
                    this.MooseQuarterDurationMinutesSlider = 150; 
                    this.MooseFatToMeatPercentSlider = 5; 
                    this.MooseDecayConditionPerDayPercentSlider = 7f; 

                    // Wolf
                    this.WolfSliderMin = 7f;
                    this.WolfSliderMax = 26f;
                    this.WolfHideSlider = 1;
                    this.WolfGutSlider = 6;
                    this.WolfQuarterSizeSlider = 7f;
                    this.WolfQuarterDurationMinutesSlider = 20; 
                    this.WolfFatToMeatPercentSlider = 2; 
                    this.WolfDecayConditionPerDayPercentSlider = 7f;

                    // TimberWolf (all missing variables added, since it wasn't in the original preset)
                    this.TimberWolfSliderMin = 4f; // Default value
                    this.TimberWolfSliderMax = 7f; // Default value
                    this.TimberWolfHideSlider = 1; // Default value
                    this.TimberWolfGutSlider = 2; // Default value
                    this.TimberWolfQuarterSizeSlider = 2.5f; // Default value
                    this.TimberWolfQuarterDurationMinutesSlider = 30; // Default value
                    this.TimberWolfFatToMeatPercentSlider = 3; // Default value
                    this.TimberWolfDecayConditionPerDayPercentSlider = 7f; 

                    // Poisoned Wolf (DLC) (all missing variables added, since it wasn't in the original preset)
                    this.PoisonedWolfHideSlider = 1; // Default value
                    this.PoisonedWolfGutSlider = 2; // Default value
                    this.PoisonedWolfDecayConditionPerDayPercentSlider = 7f; 

                    // Bear
                    this.BearSliderMin = 16f;
                    this.BearSliderMax = 135f;
                    this.BearHideSlider = 1;
                    this.BearGutSlider = 25;
                    this.BearQuarterSizeSlider = 25f;
                    this.BearQuarterDurationMinutesSlider = 180;
                    this.BearFatToMeatPercentSlider = 25;
                    this.BearDecayConditionPerDayPercentSlider = 7f; 

                    // Cougar (DLC)
                    this.CougarSliderMin = 13f;
                    this.CougarSliderMax = 54f;
                    this.CougarHideSlider = 1;
                    this.CougarGutSlider = 6;
                    this.CougarQuarterSizeSlider = 18f;
                    this.CougarQuarterDurationMinutesSlider = 60;
                    this.CougarFatToMeatPercentSlider = 4;
                    this.CougarDecayConditionPerDayPercentSlider = 7f; 

                    // Quarter Waste Multiplier
                    this.QuarterWasteMultipler = 1.2f;


                    break;




                case 2:
                    // Realistic (Balanced) Preset - Meat values are based on data from Canadian encyclopedia (see DATA.xlsx)

                    // Rabbit
                    this.RabbitSliderMin = 0.75f; // Realistic unchanged
                    this.RabbitSliderMax = 1.5f; // Realistic unchanged
                    this.RabbitHideSlider = 1;
                    this.RabbitGutSlider = 2; // Realistic unchanged
                    this.RabbitDecayConditionPerDayPercentSlider = 10f;

                    // Ptarmigan (DLC)
                    this.PtarmiganSliderMin = 0.43f; // Realistic unchanged
                    this.PtarmiganSliderMax = 0.81f; // Realistic unchanged
                    this.PtarmiganHideSlider = 4;
                    this.PtarmiganDecayConditionPerDayPercentSlider = 10f;

                    // Doe
                    this.DoeSliderMin = 11f; // Realistic -33%
                    this.DoeSliderMax = 18f; // Realistic -50%
                    this.DoeHideSlider = 1;
                    this.DoeGutSlider = 3; // Arbitrary value
                    this.DoeQuarterSizeSlider = 6f; // Arbitrary value
                    this.DoeQuarterDurationMinutesSlider = 30;
                    this.DoeFatToMeatPercentSlider = 6;
                    this.DoeDecayConditionPerDayPercentSlider = 3f;

                    //// Stag
                    this.StagSliderMin = 25f; // Realistic -33%
                    this.StagSliderMax = 37f; // Realistic -50%
                    this.StagHideSlider = 1;
                    this.StagGutSlider = 5; // Arbitrary value
                    this.StagQuarterSizeSlider = 8f; // Arbitrary value
                    this.StagQuarterDurationMinutesSlider = 70;
                    this.StagFatToMeatPercentSlider = 8;
                    this.StagDecayConditionPerDayPercentSlider = 3f;

                    // Moose
                    this.MooseSliderMin = 80f; // Realistic -33%
                    this.MooseSliderMax = 135f; // Realistic -50%
                    this.MooseHideSlider = 1;
                    this.MooseGutSlider = 16; // Arbitrary value
                    this.MooseQuarterSizeSlider = 20f; // Arbitrary value
                    this.MooseQuarterDurationMinutesSlider = 120;
                    this.MooseFatToMeatPercentSlider = 15;
                    this.MooseDecayConditionPerDayPercentSlider = 3f;

                    // Wolf
                    this.WolfSliderMin = 5f; // Realistic -33%
                    this.WolfSliderMax = 13f; // Realistic -50%
                    this.WolfHideSlider = 1;
                    this.WolfGutSlider = 2; // Arbitrary value
                    this.WolfQuarterSizeSlider = 5f; // Arbitrary value
                    this.WolfQuarterDurationMinutesSlider = 40;
                    this.WolfFatToMeatPercentSlider = 4;
                    this.WolfDecayConditionPerDayPercentSlider = 3f;

                    // TimberWolf (all missing variables added, since it wasn't in the original preset)
                    this.TimberWolfSliderMin = 4f; // Default value
                    this.TimberWolfSliderMax = 7f; // Default value
                    this.TimberWolfHideSlider = 1; // Default value
                    this.TimberWolfGutSlider = 2; // Default value
                    this.TimberWolfQuarterSizeSlider = 2.5f; // Default value
                    this.TimberWolfQuarterDurationMinutesSlider = 45;
                    this.TimberWolfFatToMeatPercentSlider = 5;
                    this.TimberWolfDecayConditionPerDayPercentSlider = 3f;

                    // Poisoned Wolf (DLC) (all missing variables added, since it wasn't in the original preset)
                    this.PoisonedWolfHideSlider = 1; // Default value
                    this.PoisonedWolfGutSlider = 2; // Default value
                    this.PoisonedWolfDecayConditionPerDayPercentSlider = 3f; 

                    // Bear
                    this.BearSliderMin = 16f; // Realistic unchanged
                    this.BearSliderMax = 68f; // Realistic -50%
                    this.BearHideSlider = 1;
                    this.BearGutSlider = 12; // Vanilla value 12
                    this.BearQuarterSizeSlider = 15f; // Realistic -10
                    this.BearQuarterDurationMinutesSlider = 120;
                    this.BearFatToMeatPercentSlider = 10;
                    this.BearDecayConditionPerDayPercentSlider = 3f;

                    // Cougar (DLC)
                    this.CougarSliderMin = 8f; // Realistic -33%
                    this.CougarSliderMax = 27f; // Realistic -50%
                    this.CougarHideSlider = 1;
                    this.CougarGutSlider = 5; // Arbitrary value
                    this.CougarQuarterSizeSlider = 7f; // Arbitrary value
                    this.CougarQuarterDurationMinutesSlider = 90;
                    this.CougarFatToMeatPercentSlider = 10;
                    this.CougarDecayConditionPerDayPercentSlider = 3f;

                    // Quarter Waste Multiplier
                    this.QuarterWasteMultipler = 1.2f;

                    break;

            }
        }

        [Section("Harvest Times Multipliers")]

            [Name("Meat")]
            [Description("Change Meat harvest time multiplier. Vanilla value is 1")]
            [Slider(0.1f, 2)]
            public float MeatTimeMultiplier = 1f;

            [Name("Frozen Meat")]
            [Description("Change Frozen Meat harvest time multiplier. Vanilla value is 1")]
            [Slider(0.1f, 2)]
            public float FrozenMeatTimeMultiplier = 1f;

            [Name("Hide")]
            [Description("Change Hide/Feathers harvest time multiplier. Vanilla value is 1")]
            [Slider(0.1f, 2)]
            public float HideTimeMultiplier = 1f;

            [Name("Gut")]
            [Description("Change Gut harvest time multiplier. Vanilla value is 1")]
            [Slider(0.1f, 2)]
            public float GutTimeMultiplier = 1f;

        [Section("Harvest Times (minutes)")]

            [Name("Doe Quarters")]
            [Description("Change how many minutes to quarter a Doe. Vanilla value is 60")]
            [Slider(1, 180)]
            public int DoeQuarterDurationMinutesSlider = 60;

            [Name("Stag Quarters")]
            [Description("Change how many minutes to quarter a Stag. Vanilla value is 75")]
            [Slider(1, 180)]
            public int StagQuarterDurationMinutesSlider = 75;

            [Name("Moose Quarters")]
            [Description("Change how many minutes to quarter a Moose. Vanilla value is 120")]
            [Slider(1, 180)]
            public int MooseQuarterDurationMinutesSlider = 120;

            [Name("Wolf Quarters")]
            [Description("Change how many minutes to quarter a Wolf. Vanilla value is 60")]
            [Slider(1, 180)]
            public int WolfQuarterDurationMinutesSlider = 60;

            [Name("TimberWolf Quarters")]
            [Description("Change how many minutes to quarter a TimberWolf. Vanilla value is 60")]
            [Slider(1, 180)]
            public int TimberWolfQuarterDurationMinutesSlider = 60;

            [Name("Bear Quarters")]
            [Description("Change how many minutes to quarter a Bear. Vanilla value is 120")]
            [Slider(1, 180)]
            public int BearQuarterDurationMinutesSlider = 120;

            [Name("Cougar Quarters")]
            [Description("Change how many minutes to quarter a Cougar. Vanilla value is 120")]
            [Slider(1, 180)]
            public int CougarQuarterDurationMinutesSlider = 120;



        [Section("Decay Times")]

            [Name("Rabbit Decay Condition Per Day (%)")]
            [Description("Change the carcass decay percentage per day for a Rabbit. Vanilla value is 10 % ")]
            [Slider(0, 100)]
            public float RabbitDecayConditionPerDayPercentSlider = 10;

            [Name("Ptarmigan Decay Condition Per Day (%)")]
            [Description("Change the carcass decay rate for a Ptarmigan. Vanilla value is 10%")]
            [Slider(0f, 200f)]
            public float PtarmiganDecayConditionPerDayPercentSlider = 10f;

            [Name("Doe Decay Condition Per Day (%)")]
            [Description("Change the carcass decay rate per day for a freshly killed Doe. Vanilla value is 33.3")]
            [Slider(0f, 200f)]
            public float DoeDecayConditionPerDayPercentSlider = 33.3f;

            [Name("Stag carcass Decay Condition Per Day (%)")]
            [Description("Change the carcass decay rate per day for a freshly killed Stag. Vanilla value is 33.3%")]
            [Slider(0f, 200f)]
            public float StagDecayConditionPerDayPercentSlider = 33.3f;

            [Name("Moose carcass Decay Condition Per Day (%)")]
            [Description("Change the carcass decay rate per day for a freshly killed Moose. Vanilla value is 33%")]
            [Slider(0f, 200f)]
            public float MooseDecayConditionPerDayPercentSlider = 33.3f;

            [Name("Wolf carcass Decay Condition Per Day (%)")]
            [Description("Change the carcass decay rate per day for a freshly killed Wolf. Vanilla value is 33%")]
            [Slider(0f, 200f)]
            public float WolfDecayConditionPerDayPercentSlider = 33.3f;

            [Name("Timberwolf Decay Condition Per Day (%)")]
            [Description("Change the carcass decay rate per day for a freshly killed TimberWolf. Vanilla value is 33%")]
            [Slider(0f, 200f)]
            public float TimberWolfDecayConditionPerDayPercentSlider = 33.3f;

            [Name("Poisoned Wolf Decay Condition Per Day (%)")]
            [Description("Change the carcass decay rate per day for a freshly killed Poisoned Wolf. Vanilla value is 33%")]
            [Slider(0f, 200f)]
            public float PoisonedWolfDecayConditionPerDayPercentSlider = 33.3f;

            [Name("Bear Decay Condition Per Day (%)")]
            [Description("Change the carcass decay rate per day for a freshly killed Bear. Vanilla value is 33%")]
            [Slider(0f, 200f)]
            public float BearDecayConditionPerDayPercentSlider = 33.3f;

            [Name("Cougar Decay Condition Per Day (%)")]
            [Description("Change the carcass decay rate per day for a freshly killed Cougar. Vanilla value is 33%")]
            [Slider(0f, 200f)]
            public float CougarDecayConditionPerDayPercentSlider = 33.3f;



        [Section("Harvest Quantites")]
        [Name("Presets")]
        [Description("Select preset")]
        [Choice(new string[]
        {
            "Vanilla",
            "Realistic",
            "Realistic (Balanced)",
            "Custom"
        })]
        public int preset = 0;


        [Section("Rabbit")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change the minimum amount of harvestable meat from a Rabbit. Vanilla value is 0.75")]
            [Slider(0.75f, 5f)]
            public float RabbitSliderMin = 0.75f;

            [Name("Maximum Meat (Kg)")]
            [Description("Change the maximum amount of harvestable meat from a Rabbit. Vanilla value is 1.5")]
            [Slider(0.75f, 5f)]
            public float RabbitSliderMax = 1.5f;

            [Name("Hide Count")]
            [Description("Change the number of harvestable hides from a Rabbit. Vanilla value is 1")]
            [Slider(1, 10)]
            public int RabbitHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change the number of harvestable guts from a Rabbit. Vanilla value is 1")]
            [Slider(1, 10)]
            public int RabbitGutSlider = 1;



        [Section("Ptarmigan (DLC)")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change the minimum amount of harvestable meat from a Ptarmigan. Vanilla value is 0.75")]
            [Slider(0.75f, 5f)]
            public float PtarmiganSliderMin = 0.75f;

            [Name("Maximum Meat (Kg)")]
            [Description("Change the maximum amount of harvestable meat from a Ptarmigan. Vanilla value is 1.5")]
            [Slider(0.75f, 5f)]
            public float PtarmiganSliderMax = 1.5f;

            [Name("Down Feather Count")]
            [Description("Change the number of harvestable down feathers from a Ptarmigan. Vanilla value is 4")]
            [Slider(1f, 10f)]
            public int PtarmiganHideSlider = 4;



        [Section("Doe")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change the minimum amount of harvestable meat from a Doe. Vanilla value is 7")]
            [Slider(0f, 300f)]
            public float DoeSliderMin = 7f;

            [Name("Maximum Meat (Kg)")]
            [Description("Change the maximum amount of harvestable meat from a Doe. Vanilla value is 9")]
            [Slider(0f, 300f)]
            public float DoeSliderMax = 9f;

            [Name("Hide Count")]
            [Description("Change the number of harvestable hides from a Doe. Vanilla value is 1")]
            [Slider(0, 10)]
            public int DoeHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change the number of harvestable guts from a Doe. Vanilla value is 2")]
            [Slider(0, 50)]
            public int DoeGutSlider = 2;

            [Name("Quarter Size (Kg)")]
            [Description("Change the size of each quarter in Kg from a Doe. Vanilla value is 2.5")]
            [Slider(1f, 50f)]
            public float DoeQuarterSizeSlider = 2.5f;

            [Name("Fat to Meat Percentage (%)")]
            [Description("Change the fat to meat percentage for a Doe. Vanilla value is 20%")]
            [Slider(0, 40)]
            public float DoeFatToMeatPercentSlider = 20;



        [Section("Stag")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change the minimum amount of harvestable meat in Kg from a Stag. Vanilla value is 11")]
            [Slider(0f, 300f)]
            public float StagSliderMin = 11f;

            [Name("Maximum Meat (Kg)")]
            [Description("Change the maximum amount of harvestable meat in Kg from a Stag. Vanilla value is 13")]
            [Slider(0f, 300f)]
            public float StagSliderMax = 13f;

            [Name("Hide Count")]
            [Description("Change the number of harvestable hides from a Stag. Vanilla value is 1")]
            [Slider(1, 10)]
            public int StagHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change the number of harvestable guts from a Stag. Vanilla value is 2")]
            [Slider(1, 50)]
            public int StagGutSlider = 2;

            [Name("Quarter Size (Kg)")]
            [Description("Change the size of each quarter in Kg from a Stag. Vanilla value is 2.5")]
            [Slider(1f, 50f)]
            public float StagQuarterSizeSlider = 2.5f;

            [Name("Fat to Meat Percentage (%)")]
            [Description("Change the fat to meat percentage for a Stag. Vanilla value is 20%")]
            [Slider(0, 40)]
            public int StagFatToMeatPercentSlider = 20;



        [Section("Moose")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change the minimum amount of harvestable meat from a Moose. Vanilla value is 30")]
            [Slider(0f, 300f)]
            public float MooseSliderMin = 30f;

            [Name("Maximum Meat (Kg)")]
            [Description("Change the maximum amount of harvestable meat from a Moose. Vanilla value is 45")]
            [Slider(0f, 300f)]
            public float MooseSliderMax = 45f;

            [Name("Hide Count")]
            [Description("Change the number of harvestable hides from a Moose. Vanilla value is 1")]
            [Slider(1, 10)]
            public int MooseHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change the number of harvestable guts from a Moose. Vanilla value is 12")]
            [Slider(1, 50)]
            public int MooseGutSlider = 12;

            [Name("Quarter Size (Kg)")]
            [Description("Change the size of each quarter in Kg from a Moose. Vanilla value is 5")]
            [Slider(1f, 50f)]
            public float MooseQuarterSizeSlider = 5f;

            [Name("Fat to Meat Percentage (%)")]
            [Description("Change the fat to meat percentage for a Moose. Vanilla value is 15%")]
            [Slider(0, 40)]
            public int MooseFatToMeatPercentSlider = 15;



        [Section("Wolf")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change the minimum amount of harvestable meat from a Wolf. Vanilla value is 3")]
            [Slider(0f, 300f)]
            public float WolfSliderMin = 3;

            [Name("Maximum Meat (Kg)")]
            [Description("Change the maximum amount of harvestable meat from a Wolf. Vanilla value is 6")]
            [Slider(0f, 300f)]
            public float WolfSliderMax = 6;

            [Name("Hide Count")]
            [Description("Change the number of harvestable hides from a Wolf. Vanilla value is 1")]
            [Slider(1, 10)]
            public int WolfHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change the number of harvestable guts from a Wolf. Vanilla value is 2")]
            [Slider(1, 50)]
            public int WolfGutSlider = 2;

            [Name("Quarter Size (Kg)")]
            [Description("Change the size of each Quarter in Kg from a Wolf. Vanilla value is 2.5")]
            [Slider(1f, 50f)]
            public float WolfQuarterSizeSlider = 2.5f;

            [Name("Fat to Meat Percentage (%)")]
            [Description("Change the fat to meat percentage for a Wolf. Vanilla value is 10%")]
            [Slider(0, 40)]
            public int WolfFatToMeatPercentSlider = 10;



        [Section("TimberWolf")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change the minimum amount of harvestable meat from a TimberWolf. Vanilla value is 4")]
            [Slider(0f, 300f)]
            public float TimberWolfSliderMin = 4;

            [Name("Maximum Meat (Kg)")]
            [Description("Change the maximum amount of harvestable meat from a TimberWolf. Vanilla value is 7")]
            [Slider(0f, 300f)]
            public float TimberWolfSliderMax = 7;

            [Name("Hide Count")]
            [Description("Change the number of harvestable hides from a TimberWolf. Vanilla value is 1")]
            [Slider(1, 10)]
            public int TimberWolfHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change the number of harvestable guts from a TimberWolf. Vanilla value is 2")]
            [Slider(1, 50)]
            public int TimberWolfGutSlider = 2;

            [Name("Quarter Size (Kg)")]
            [Description("Change the size of each Quarter in Kg from a TimberWolf. Vanilla value is 2.5")]
            [Slider(1f, 50f)]
            public float TimberWolfQuarterSizeSlider = 2.5f;

            [Name("Fat to Meat Percentage (%)")]
            [Description("Change the fat to meat percentage for a TimberWolf. Vanilla value is 10%")]
            [Slider(0, 40)]
            public int TimberWolfFatToMeatPercentSlider = 10;



        [Section("Poisoned Wolf (DLC)")]

            [Name("Hide Count")]
            [Description("Change the number of harvestable hides from a Poisoned Wolf. Vanilla value is 1")]
            [Slider(1, 10)]
            public int PoisonedWolfHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change the number of harvestable guts from a Poisoned Wolf. Vanilla value is 2")]
            [Slider(1, 50)]
            public int PoisonedWolfGutSlider = 2;



        [Section("Bear")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change the minimum amount of harvestable meat from a Bear. Vanilla value is 25")]
            [Slider(0f, 300f)]
            public float BearSliderMin = 25;

            [Name("Maximum Meat (Kg)")]
            [Description("Change the maximum amount of harvestable meat from a Bear. Vanilla value is 40")]
            [Slider(0f, 300f)]
            public float BearSliderMax = 40;

            [Name("Hide Count")]
            [Description("Change the number of harvestable hides from a Bear. Vanilla value is 1")]
            [Slider(1, 10)]
            public int BearHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change the number of harvestable guts from a Bear. Vanilla value is 10")]
            [Slider(1, 50)]
            public int BearGutSlider = 10;

            [Name("Quarter Size (Kg)")]
            [Description("Change the size of each Quarter in Kg from a Bear. Vanilla value is 5")]
            [Slider(1f, 50f)]
            public float BearQuarterSizeSlider = 5f;

            [Name("Fat to Meat Percentage (%)")]
            [Description("Change the fat to meat percentage for a Bear. Vanilla value is 10%")]
            [Slider(0, 40)]
            public int BearFatToMeatPercentSlider = 10;



        [Section("Cougar (DLC)")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change the minimum amount of harvestable meat from a Cougar. Vanilla value is 4")]
            [Slider(0f, 300f)]
            public float CougarSliderMin = 4;

            [Name("Maximum Meat (Kg)")]
            [Description("Change the maximum amount of harvestable meat from a Cougar. Vanilla value is 5")]
            [Slider(0f, 300f)]
            public float CougarSliderMax = 5;

            [Name("Hide Count")]
            [Description("Change the number of harvestable hides from a Cougar. Vanilla value is 1")]
            [Slider(1f, 10f)]
            public int CougarHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change the number of harvestable guts from a Cougar. Vanilla value is 2")]
            [Slider(1, 50)]
            public int CougarGutSlider = 1;

            [Name("Quarter Size (Kg)")]
            [Description("Size Of Each Quarter. Vanilla value is 2.5")]
            [Slider(1f, 50f)]
            public float CougarQuarterSizeSlider = 2.5f;

            [Name("Fat to Meat Percentage (%)")]
            [Description("Change the fat to meat percentage for a Cougar. Vanilla value is 10%")]
            [Slider(0, 40)]
            public int CougarFatToMeatPercentSlider = 10;


        [Section("Quarter Waste Multiplier")]

            [Name("Waste")]
            [Description("Changes the amount of unharvestable waste, e.g. Bones. Vanilla value is 2")]
            [Slider(0f, 4f)]
            public float QuarterWasteMultipler = 2f;


    }



}  
