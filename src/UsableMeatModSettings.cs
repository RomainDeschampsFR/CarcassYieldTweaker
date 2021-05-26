using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ModSettings;
using UnityEngine;
using static CustomExperienceModeManager;

namespace UsableMeatMod
{
    internal class UsableMeatModSettings : JsonModSettings
    {
        protected override void OnChange(FieldInfo field, object oldValue, object newValue)
        {
            bool flag = field.Name == "preset" && this.preset != 3;
            if (flag)
            {
                this.UsePreset((int)newValue);
            }
            else
            {
                bool flag2 = field.Name == "BearSliderMax" || field.Name ==
                "BearSliderMin" || field.Name == "BearGutSlider" || field.Name ==
                "DeerSliderMax" || field.Name == "DeerSliderMin" || field.Name == "DeerGutSlider" ||
                field.Name == "WolfSliderMax" || field.Name == "WolfSliderMin" ||
                field.Name == "WolfGutSlider" || field.Name == "MooseSliderMax" ||
                field.Name == "MooseSliderMin" || field.Name == "MooseGutSlider";
                if (flag2)
                { 
                }
            }
            base.RefreshGUI();
        }
        private void UsePreset(int preset)
        {
            switch (preset)
            {
                case 0:
                    this.BearSliderMax = (int)42f;
                    this.BearSliderMin = (int)25f;
                    this.BearGutSlider = (int)10f;
                    this.DeerSliderMax = (int)10f;
                    this.DeerSliderMin = (int)8f;
                    this.DeerGutSlider = (int)2f;
                    this.WolfSliderMax = (int)6f;
                    this.WolfSliderMin = (int)3f;
                    this.WolfGutSlider = (int)2f;
                    this.MooseSliderMax = (int)45f;
                    this.MooseSliderMin = (int)32f;
                    this.MooseGutSlider = (int)12f;
                    break;
                case 1:
                    this.BearSliderMax = (int)130f;
                    this.BearSliderMin = (int)45f;
                    this.BearGutSlider = (int)20f;
                    this.DeerSliderMax = (int)70f;
                    this.DeerSliderMin = (int)22f;
                    this.DeerGutSlider = (int)10f;
                    this.WolfSliderMax = (int)28f;
                    this.WolfSliderMin = (int)14f;
                    this.WolfGutSlider = (int)6f;
                    this.MooseSliderMax = (int)320f;
                    this.MooseSliderMin = (int)86f;
                    this.MooseGutSlider = (int)30f;
                    break;
                case 2:
                    this.BearSliderMax = (int)86f;
                    this.BearSliderMin = (int)40f;
                    this.BearGutSlider = (int)15f;
                    this.DeerSliderMax = (int)36f;
                    this.DeerSliderMin = (int)20f;
                    this.DeerGutSlider = (int)4f;
                    this.WolfSliderMax = (int)24f;
                    this.WolfSliderMin = (int)8f;
                    this.WolfGutSlider = (int)3f;
                    this.MooseSliderMax = (int)125f;
                    this.MooseSliderMin = (int)70f;
                    this.MooseGutSlider = (int)20f;
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

        [Section("Bear")]
        [Name("Maximum Meat (Kg)")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Bear. Vanilla Value is 40")]
        [Slider(1f, 500f)]
        public int BearSliderMax = 1;

        [Name("Minimum Meat (Kg)")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Bear. Vanilla Value is 25")]
        [Slider(1f, 500f)]
        public int BearSliderMin = 1;

        [Name("Gut Count")]
        [Description("Change The Amount Of Guts To Harvest Upon Killing A Bear. Vanilla Value is 10")]
        [Slider(1f, 100f)]
        public int BearGutSlider = 1;

        [Section("Deer")]
        [Name("Maximum Meat (Kg)")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Deer. Vanilla Value is 10")]
        [Slider(1f, 500f)]
        public int DeerSliderMax = 1;

        [Name("Minimum Meat (Kg)")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Deer. Vanilla Value is 8")]
        [Slider(1f, 500f)]
        public int DeerSliderMin = 1;

        [Name("Gut Count")]
        [Description("Change The Amount Of Guts To Harvest Upon Killing A Deer. Vanilla Value is 2")]
        [Slider(1f, 100f)]
        public int DeerGutSlider = 1;

        [Section("Wolf")]
        [Name("Maximum Meat (Kg)")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Wolf. Vanilla Value is 6")]
        [Slider(1f, 500f)]
        public int WolfSliderMax = 1;

        [Name("Minimum Meat (Kg)")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Wolf. Vanilla Value is 3")]
        [Slider(1f, 500f)]
        public int WolfSliderMin = 1;

        [Name("Gut Count")]
        [Description("Change The Amount Of Guts To Harvest Upon Killing A Wolf. Vanilla Value is 2")]
        [Slider(1f, 100f)]
        public int WolfGutSlider = 1;

        [Section("Moose")]
        [Name("Maximum Meat (Kg)")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Moose. Vanilla Value is 45")]
        [Slider(1f, 500f)]
        public int MooseSliderMax = 1;

        [Name("Minimum Meat (Kg)")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Moose. Vanilla Value is 30")]
        [Slider(1f, 500f)]
        public int MooseSliderMin = 1;

        [Name("Gut Count")]
        [Description("Change The Amount Of Guts To Harvest Upon Killing A Moose. Vanilla Value is 12")]
        [Slider(1f, 100f)]
        public int MooseGutSlider = 1; 
    }
}
