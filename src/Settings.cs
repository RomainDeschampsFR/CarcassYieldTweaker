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

                    this.RabbitSliderMin = 0.75f;
                    this.RabbitSliderMax = 1.5f;
                    this.RabbitGutSlider = (int)1f;
                    this.RabbitHideSlider = (int)1f;

                    this.PtarmiganSliderMin = 0.75f;
                    this.PtarmiganSliderMax = 1.5f;
                    this.PtarmiganHideSlider = (int)4f;

                    this.DoeSliderMin = (int)7f;
                    this.DoeSliderMax = (int)9f;
                    this.DoeHideSlider = (int)1f;
                    this.DoeGutSlider = (int)2f;
                    this.DoeQuarterSlider = 2.5f;

                    this.StagSliderMin = (int)11f;
                    this.StagSliderMax = (int)13f;
                    this.StagHideSlider = (int)1f;
                    this.StagGutSlider = (int)2f;
                    this.StagQuarterSlider = 2.5f;

                    this.MooseSliderMin = (int)30f;
                    this.MooseSliderMax = (int)45f;
                    this.MooseHideSlider = (int)1f;
                    this.MooseGutSlider = (int)12f;
                    this.MooseQuarterSlider = 5f;

                    this.WolfSliderMin = (int)3f;
                    this.WolfSliderMax = (int)6f;
                    this.WolfHideSlider = (int)1f;
                    this.WolfGutSlider = (int)2f;
                    this.WolfQuarterSlider = 2.5f;

                    this.BearSliderMin = (int)25f;
                    this.BearSliderMax = (int)40f;
                    this.BearHideSlider = (int)1f;
                    this.BearGutSlider = (int)10f;
                    this.BearQuarterSlider = 5f;

                    this.CougarSliderMin = (int)4f;
                    this.CougarSliderMax = (int)5f;
                    this.CougarHideSlider = (int)1f;
                    this.CougarGutSlider = (int)2f;
                    this.CougarQuarterSlider = 2.5f;

                    this.QuarterWasteMultipler = 2f;


                    break;
                case 1:
                    //Realistic Preset - Meat values are based on data from canadian encyclopedia (see DATA.xlsx)
                    
                    this.RabbitSliderMin = 0.75f;
                    this.RabbitSliderMax = 1.5f;
                    this.RabbitHideSlider = (int)1f;
                    this.RabbitGutSlider = (int)2f;

                    this.PtarmiganSliderMin = 0.43f;
                    this.PtarmiganSliderMax = 0.81f;
                    this.PtarmiganHideSlider = (int)4f;

                    this.DoeSliderMin = (int)16f;
                    this.DoeSliderMax = (int)36f;
                    this.DoeHideSlider = (int)1f;
                    this.DoeGutSlider = (int)12f;
                    this.DoeQuarterSlider = 10f;

                    this.StagSliderMin = (int)38f;
                    this.StagSliderMax = (int)57f;
                    this.StagHideSlider = (int)1f;
                    this.StagGutSlider = (int)15f;
                    this.StagQuarterSlider = 15f;

                    this.MooseSliderMin = (int)121f;
                    this.MooseSliderMax = (int)270f;
                    this.MooseHideSlider = (int)1f;
                    this.MooseGutSlider = (int)40f;
                    this.MooseQuarterSlider = 30f;

                    this.WolfSliderMin = (int)7f;
                    this.WolfSliderMax = (int)26f;
                    this.WolfHideSlider = (int)1f;
                    this.WolfGutSlider = (int)6f;
                    this.WolfQuarterSlider = 7f;

                    this.BearSliderMin = (int)16f;
                    this.BearSliderMax = (int)135f;
                    this.BearHideSlider = (int)1f;
                    this.BearGutSlider = (int)25f;
                    this.BearQuarterSlider = 25f;

                    this.CougarSliderMin = (int)13f;
                    this.CougarSliderMax = (int)54f;
                    this.CougarHideSlider = (int)1f;
                    this.CougarGutSlider = (int)6f;
                    this.CougarQuarterSlider = 18f;

                    this.QuarterWasteMultipler = 1.2f;

                    
                    break;
                case 2:
                    //Realistic (Balanced) Preset - Meat values are based on data from canadian encyclopedia (see DATA.xlsx)

                    this.RabbitSliderMin = 0.75f;//Realistic unchanged
                    this.RabbitSliderMax = 1.5f;//Realistic unchanged
                    this.RabbitHideSlider = (int)1f;
                    this.RabbitGutSlider = (int)2f;//Realistic unchanged

                    this.PtarmiganSliderMin = 0.43f;//Realistic unchanged
                    this.PtarmiganSliderMax = 0.81f;//Realistic unchanged
                    this.PtarmiganHideSlider = (int)4f;

                    this.DoeSliderMin = (int)11f;//Realistic -33%
                    this.DoeSliderMax = (int)18f;//Realistic -50%
                    this.DoeHideSlider = (int)1f;
                    this.DoeGutSlider = (int)3f;//Arbitrary value
                    this.DoeQuarterSlider = 6f;//Arbitrary value

                    this.StagSliderMin = (int)25f;//Realistic -33%
                    this.StagSliderMax = (int)37f;//Realistic -50%
                    this.StagHideSlider = (int)1f;
                    this.StagGutSlider = (int)5f;//Arbitrary value
                    this.StagQuarterSlider = 8f;//Arbitrary value

                    this.MooseSliderMin = (int)80f;//Realistic -33%
                    this.MooseSliderMax = (int)135f;//Realistic -50%
                    this.MooseHideSlider = (int)1f;
                    this.MooseGutSlider = (int)16f;//Arbitrary value
                    this.MooseQuarterSlider = 20f; //Arbitrary value

                    this.WolfSliderMin = (int)5f;//Realistic -33%
                    this.WolfSliderMax = (int)13f;//Realistic -50%
                    this.WolfHideSlider = (int)1f;
                    this.WolfGutSlider = (int)2f;//Arbitrary value
                    this.WolfQuarterSlider = 5f;//Arbitrary value

                    this.BearSliderMin = (int)16f;//Realistic unchanged
                    this.BearSliderMax = (int)68f;//Realistic -50%
                    this.BearHideSlider = (int)1f;
                    this.BearGutSlider = (int)12f;//Vanilla Value 12
                    this.BearQuarterSlider = 15f;//Realistic -10

                    this.CougarSliderMin = (int)8f;//Realistic -33%
                    this.CougarSliderMax = (int)27f;//Realistic -50%
                    this.CougarHideSlider = (int)1f;
                    this.CougarGutSlider = (int)5f;//Arbitrary value
                    this.CougarQuarterSlider = 7f; //Arbitrary value
                    
                    this.QuarterWasteMultipler = 1.2f;

                    break;

            }
        }
        [Section("Harvestables")]
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
            [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Rabbit. Vanilla Value is 0.75")]
            [Slider(0.75f, 5f)]
            public float RabbitSliderMin = 0.75f;

            [Name("Maximum Meat (Kg)")]
            [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Rabbit. Vanilla Value is 1.5")]
            [Slider(0.75f, 5f)]
            public float RabbitSliderMax = 1.5f;

            [Name("Hide Count")]
            [Description("Change The Amount Of Hides To Harvest Upon Killing A Rabbit. Vanilla Value is 1")]
            [Slider(1f, 10f)]
            public int RabbitHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change The Amount Of Guts To Harvest Upon Killing A Rabbit. Vanilla Value is 1")]
            [Slider(1f, 10f)]
            public int RabbitGutSlider = 1;


        [Section("Ptarmigan (DLC)")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Ptarmigan. Vanilla Value is 0.75")]
            [Slider(0.75f, 5f)]
            public float PtarmiganSliderMin = 0.75f;

            [Name("Maximum Meat (Kg)")]
            [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Ptarmigan. Vanilla Value is 1.5")]
            [Slider(0.75f, 5f)]
            public float PtarmiganSliderMax = 1.5f;

            [Name("Down Feather Count")]
            [Description("Change The Amount Of Down Feathers To Harvest Upon Killing A Ptarmigan. Vanilla Value is 4")]
            [Slider(1f, 10f)]
            public int PtarmiganHideSlider = 4;


        [Section("Doe")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Doe. Vanilla Value is 7")]
            [Slider(1f, 300f)]
            public int DoeSliderMin = 7;

            [Name("Maximum Meat (Kg)")]
            [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Doe. Vanilla Value is 9")]
            [Slider(1f, 300f)]
            public int DoeSliderMax = 9;

            [Name("Hide Count")]
            [Description("Change The Amount Of Hides To Harvest Upon Killing A Doe. Vanilla Value is 1")]
            [Slider(1f, 10f)]
            public int DoeHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change The Amount Of Guts To Harvest Upon Killing A Doe. Vanilla Value is 2")]
            [Slider(1f, 50f)]
            public int DoeGutSlider = 2;

            [Name("Quarter Size")]
            [Description("Change The Size Of Each Quarter. Vanilla Value is 2.5")]
            [Slider(1f, 50f)]
            public float DoeQuarterSlider = 2.5f;


        [Section("Stag")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Stag. Vanilla Value is 11")]
            [Slider(1f, 300f)]
            public int StagSliderMin = 11;

            [Name("Maximum Meat (Kg)")]
            [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Stag. Vanilla Value is 13")]
            [Slider(1f, 300f)]
            public int StagSliderMax = 13;

            [Name("Hide Count")]
            [Description("Change The Amount Of Hides To Harvest Upon Killing A Stag. Vanilla Value is 1")]
            [Slider(1f, 10f)]
            public int StagHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change The Amount Of Guts To Harvest Upon Killing A Stag. Vanilla Value is 2")]
            [Slider(1f, 50f)]
            public int StagGutSlider = 2;

            [Name("Quarter Size")]
            [Description("Change The Size Of Each Quarter. Vanilla Value is 2.5")]
            [Slider(1f, 50f)]
            public float StagQuarterSlider = 2.5f;


        [Section("Moose")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Moose. Vanilla Value is 30")]
            [Slider(1f, 300f)]
            public int MooseSliderMin = 30;

            [Name("Maximum Meat (Kg)")]
            [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Moose. Vanilla Value is 45")]
            [Slider(1f, 300f)]
            public int MooseSliderMax = 45;

            [Name("Hide Count")]
            [Description("Change The Amount Of Hides To Harvest Upon Killing A Moose. Vanilla Value is 1")]
            [Slider(1f, 10f)]
            public int MooseHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change The Amount Of Guts To Harvest Upon Killing A Moose. Vanilla Value is 12")]
            [Slider(1f, 50f)]
            public int MooseGutSlider = 12;

            [Name("Quarter Size")]
            [Description("Change The Size Of Each Quarter. Vanilla Value is 5")]
            [Slider(1f, 50f)]
            public float MooseQuarterSlider = 5f;


        [Section("Wolf")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Wolf. Vanilla Value is 3")]
            [Slider(1f, 300f)]
            public int WolfSliderMin = 3;

            [Name("Maximum Meat (Kg)")]
            [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Wolf. Vanilla Value is 6")]
            [Slider(1f, 300f)]
            public int WolfSliderMax = 6;

            [Name("Hide Count")]
            [Description("Change The Amount Of Hides To Harvest Upon Killing A Wolf. Vanilla Value is 1")]
            [Slider(1f, 10f)]
            public int WolfHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change The Amount Of Guts To Harvest Upon Killing A Wolf. Vanilla Value is 2")]
            [Slider(1f, 50f)]
            public int WolfGutSlider = 2;

            [Name("Quarter Size")]
            [Description("Change The Size Of Each Quarter. Vanilla Value is 2.5")]
            [Slider(1f, 50f)]
            public float WolfQuarterSlider = 2.5f;


        [Section("Bear")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Bear. Vanilla Value is 25")]
            [Slider(1f, 300f)]
            public int BearSliderMin = 25;

            [Name("Maximum Meat (Kg)")]
            [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Bear. Vanilla Value is 40")]
            [Slider(1f, 300f)]
            public int BearSliderMax = 40;

            [Name("Hide Count")]
            [Description("Change The Amount Of Hides To Harvest Upon Killing A Bear. Vanilla Value is 1")]
            [Slider(1f, 10f)]
            public int BearHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change The Amount Of Guts To Harvest Upon Killing A Bear. Vanilla Value is 10")]
            [Slider(1f, 50f)]
            public int BearGutSlider = 10;

            [Name("Quarter Size")]
            [Description("Change The Size Of Each Quarter. Vanilla Value is 5")]
            [Slider(1f, 50f)]
            public float BearQuarterSlider = 5f;


        [Section("Cougar (DLC)")]

            [Name("Minimum Meat (Kg)")]
            [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Cougar. Vanilla Value is 4")]
            [Slider(1f, 300f)]
            public int CougarSliderMin = 4;

            [Name("Maximum Meat (Kg)")]
            [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Cougar. Vanilla Value is 5")]
            [Slider(1f, 300f)]
            public int CougarSliderMax = 5;

            [Name("Hide Count")]
            [Description("Change The Amount Of Hides To Harvest Upon Killing A Cougar. Vanilla Value is 1")]
            [Slider(1f, 10f)]
            public int CougarHideSlider = 1;

            [Name("Gut Count")]
            [Description("Change The Amount Of Guts To Harvest Upon Killing A Cougar. Vanilla Value is 2")]
            [Slider(1f, 50f)]
            public int CougarGutSlider = 1;

            [Name("Quarter Size")]
            [Description("Change The Size Of Each Quarter. Vanilla Value is 2.5")]
            [Slider(1f, 50f)]
            public float CougarQuarterSlider = 2.5f;


        [Section("Quarter Waste Multiplier")]

            [Name("Waste")]
            [Description("Changes the Amount of Waste, e.g. Bones. Vanilla Value is 2")]
            [Slider(0f, 2f)]
            public float QuarterWasteMultipler = 2f;

    }
}