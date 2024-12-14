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
                    this.RabbitSliderMax = 1.5f;
                    this.RabbitSliderMin = 0.75f;
                    this.RabbitGutSlider = (int)2f;
                    this.PtarmiganSliderMax = 1.5f;
                    this.PtarmiganSliderMin = 0.75f;
                    this.BearSliderMax = (int)40f;
                    this.BearSliderMin = (int)25f;
                    this.BearGutSlider = (int)10f;
                    this.BearQuarterSlider = 5f;
                    this.StagSliderMax = (int)13f;
                    this.StagSliderMin = (int)11f;
                    this.StagGutSlider = (int)2f;
                    this.StagQuarterSlider = 2.5f;
                    this.DoeSliderMax = (int)9f;
                    this.DoeSliderMin = (int)7f;
                    this.DoeGutSlider = (int)2f;
                    this.DoeQuarterSlider = 2.5f;
                    this.WolfSliderMax = (int)6f;
                    this.WolfSliderMin = (int)3f;
                    this.WolfGutSlider = (int)2f;
                    this.WolfQuarterSlider = 2.5f;
                    this.MooseSliderMax = (int)45f;
                    this.MooseSliderMin = (int)30f;
                    this.MooseGutSlider = (int)12f;
                    this.MooseQuarterSlider = 5f;
                    this.CougarSliderMax = (int)1f;
                    this.CougarSliderMin = (int)1f;
                    this.CougarGutSlider = (int)1f;
                    this.CougarQuarterSlider = 2.5f;
                    this.QuarterWasteMultipler = 2f;

                    this.RabbitHideSlider = (int)1f;
                    this.PtarmiganHideSlider = (int)4f;
                    this.BearHideSlider = (int)1f;
                    this.StagHideSlider = (int)1f;
                    this.DoeHideSlider = (int)1f;
                    this.WolfHideSlider = (int)1f;
                    this.MooseHideSlider = (int)1f;
                    this.CougarHideSlider = (int)1f;
                    break;
                case 1:
                    //Meat values are based on data from canadian encyclopedia (see DATA.xlsx)
                    this.RabbitSliderMax = 1.5f;
                    this.RabbitSliderMin = 0.75f;
                    this.RabbitGutSlider = (int)2f;
                    this.PtarmiganSliderMax = 0.81f;
                    this.PtarmiganSliderMin = 0.43f;
                    this.BearSliderMax = (int)135f;
                    this.BearSliderMin = (int)16f;
                    this.BearGutSlider = (int)25f;
                    this.BearQuarterSlider = 25f;
                    this.StagSliderMax = (int)57f;
                    this.StagSliderMin = (int)38f;
                    this.StagGutSlider = (int)15f;
                    this.StagQuarterSlider = 15f;
                    this.DoeSliderMax = (int)36f;
                    this.DoeSliderMin = (int)16f;
                    this.DoeGutSlider = (int)12f;
                    this.DoeQuarterSlider = 10f;
                    this.WolfSliderMax = (int)26f;
                    this.WolfSliderMin = (int)7f;
                    this.WolfGutSlider = (int)6f;
                    this.WolfQuarterSlider = 7f;
                    this.MooseSliderMax = (int)270f;
                    this.MooseSliderMin = (int)121f;
                    this.MooseGutSlider = (int)40f;
                    this.MooseQuarterSlider = 30f;
                    this.CougarSliderMax = (int)54f;
                    this.CougarSliderMin = (int)13f;
                    this.CougarGutSlider = (int)6f;
                    this.CougarQuarterSlider = 18f;
                    this.QuarterWasteMultipler = 1.2f;

                    this.RabbitHideSlider = (int)1f;
                    this.PtarmiganHideSlider = (int)4f;
                    this.BearHideSlider = (int)1f;
                    this.StagHideSlider = (int)1f;
                    this.DoeHideSlider = (int)1f;
                    this.WolfHideSlider = (int)1f;
                    this.MooseHideSlider = (int)1f;
                    this.CougarHideSlider = (int)1f;
                    break;
                case 2:
                    this.RabbitSliderMax = 1.5f;//Realistic unchanged
                    this.RabbitSliderMin = 0.75f;//Realistic unchanged
                    this.RabbitGutSlider = (int)2f;//Realistic unchanged
                    this.PtarmiganSliderMax = 0.81f;//Realistic unchanged
                    this.PtarmiganSliderMin = 0.43f;//Realistic unchanged
                    this.BearSliderMax = (int)68f;//Realistic -50%
                    this.BearSliderMin = (int)16f;//Realistic unchanged
                    this.BearGutSlider = (int)12f;//Vanilla Value 12
                    this.BearQuarterSlider = 15f;//Realistic -10
                    this.StagSliderMax = (int)37f;//Realistic -50%
                    this.StagSliderMin = (int)25f;//Realistic -33%
                    this.StagGutSlider = (int)5f;//Arbitrary value
                    this.StagQuarterSlider = 8f;//Arbitrary value
                    this.DoeSliderMax = (int)18f;//Realistic -50%
                    this.DoeSliderMin = (int)11f;//Realistic -33%
                    this.DoeGutSlider = (int)3f;//Arbitrary value
                    this.DoeQuarterSlider = 6f;//Arbitrary value
                    this.WolfSliderMax = (int)13f;//Realistic -50%
                    this.WolfSliderMin = (int)5f;//Realistic -33%
                    this.WolfGutSlider = (int)2f;//Arbitrary value
                    this.WolfQuarterSlider = 5f;//Arbitrary value
                    this.MooseSliderMax = (int)135f;//Realistic -50%
                    this.MooseSliderMin = (int)80f;//Realistic -33%
                    this.MooseGutSlider = (int)16f;//Arbitrary value
                    this.MooseQuarterSlider = 20f; //Arbitrary value
                    this.CougarSliderMax = (int)27f;//Realistic -50%
                    this.CougarSliderMin = (int)8f;//Realistic -33%
                    this.CougarGutSlider = (int)5f;//Arbitrary value
                    this.CougarQuarterSlider = 7f; //Arbitrary value
                    this.QuarterWasteMultipler = 1.2f;

                    this.RabbitHideSlider = (int)1f;
                    this.PtarmiganHideSlider = (int)4f;
                    this.BearHideSlider = (int)1f;
                    this.StagHideSlider = (int)1f;
                    this.DoeHideSlider = (int)1f;
                    this.WolfHideSlider = (int)1f;
                    this.MooseHideSlider = (int)1f;
                    this.CougarHideSlider = (int)1f;
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
        [Name("Maximum Meat (Kg)")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Rabbit. Vanilla Value is 1.5")]
        [Slider(0.75f, 5f)]
        public float RabbitSliderMax = 1.5f;

        [Name("Minimum Meat (Kg)")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Rabbit. Vanilla Value is 0.75")]
        [Slider(0.75f, 5f)]
        public float RabbitSliderMin = 0.75f;

        [Name("Hide Count")]
        [Description("Change The Amount Of Hides To Harvest Upon Killing A Rabbit. Vanilla Value is 1")]
        [Slider(1f, 10f)]
        public int RabbitHideSlider = 1;

        [Name("Gut Count")]
        [Description("Change The Amount Of Guts To Harvest Upon Killing A Rabbit. Vanilla Value is 1")]
        [Slider(1f, 10f)]
        public int RabbitGutSlider = 1;

        [Section("Ptarmigan (DLC)")]
        [Name("Maximum Meat (Kg)")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Ptarmigan. Vanilla Value is 1.5")]
        [Slider(0.75f, 5f)]
        public float PtarmiganSliderMax = 1.5f;

        [Name("Minimum Meat (Kg)")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Ptarmigan. Vanilla Value is 0.75")]
        [Slider(0.75f, 5f)]
        public float PtarmiganSliderMin = 0.75f;

        [Name("Hide Count")]
        [Description("Change The Amount Of Hides To Harvest Upon Killing A Ptarmigan. Vanilla Value is 4")]
        [Slider(1f, 10f)]
        public int PtarmiganHideSlider = 4;

        [Section("Bear")]
        [Name("Maximum Meat (Kg)")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Bear. Vanilla Value is 40")]
        [Slider(1f, 300f)]
        public int BearSliderMax = 40;

        [Name("Minimum Meat (Kg)")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Bear. Vanilla Value is 25")]
        [Slider(1f, 300f)]
        public int BearSliderMin = 25;

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

        [Section("Stag")]
        [Name("Maximum Meat (Kg)")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Stag. Vanilla Value is 13")]
        [Slider(1f, 300f)]
        public int StagSliderMax = 13;

        [Name("Minimum Meat (Kg)")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Stag. Vanilla Value is 11")]
        [Slider(1f, 300f)]
        public int StagSliderMin = 11;

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

        [Section("Doe")]
        [Name("Maximum Meat (Kg)")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Doe. Vanilla Value is 9")]
        [Slider(1f, 300f)]
        public int DoeSliderMax = 9;

        [Name("Minimum Meat (Kg)")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Doe. Vanilla Value is 7")]
        [Slider(1f, 300f)]
        public int DoeSliderMin = 7;

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

        [Section("Wolf")]
        [Name("Maximum Meat (Kg)")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Wolf. Vanilla Value is 6")]
        [Slider(1f, 300f)]
        public int WolfSliderMax = 6;

        [Name("Minimum Meat (Kg)")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Wolf. Vanilla Value is 3")]
        [Slider(1f, 300f)]
        public int WolfSliderMin = 3;

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

        [Section("Moose")]
        [Name("Maximum Meat (Kg)")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Moose. Vanilla Value is 45")]
        [Slider(1f, 300f)]
        public int MooseSliderMax = 45;

        [Name("Minimum Meat (Kg)")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Moose. Vanilla Value is 30")]
        [Slider(1f, 300f)]
        public int MooseSliderMin = 30;

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

        [Section("Cougar (DLC)")]
        [Name("Maximum Meat (Kg)")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Cougar. Vanilla Value is ?")]
        [Slider(1f, 300f)]
        public int CougarSliderMax = 1;

        [Name("Minimum Meat (Kg)")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Cougar. Vanilla Value is ?")]
        [Slider(1f, 300f)]
        public int CougarSliderMin = 1;

        [Name("Hide Count")]
        [Description("Change The Amount Of Hides To Harvest Upon Killing A Cougar. Vanilla Value is 1")]
        [Slider(1f, 10f)]
        public int CougarHideSlider = 1;

        [Name("Gut Count")]
        [Description("Change The Amount Of Guts To Harvest Upon Killing A Cougar. Vanilla Value is ?")]
        [Slider(1f, 50f)]
        public int CougarGutSlider = 1;

        [Name("Quarter Size")]
        [Description("Change The Size Of Each Quarter. Vanilla Value is ?")]
        [Slider(1f, 50f)]
        public float CougarQuarterSlider = 1;

        [Section("Quarter Waste Multiplier")]
        [Name("Waste")]
        [Description("Changes the Amount of Waste, e.g. Bones. Vanilla Value is 2")]
        [Slider(0f, 2f)]
        public float QuarterWasteMultipler = 2;

    }
}