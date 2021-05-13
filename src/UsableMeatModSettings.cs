using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModSettings;
using UnityEngine;
using static CustomExperienceModeManager;

namespace UsableMeatMod
{
    internal class UsableMeatModSettings : ModSettingsBase
    {
        [Section("Meat Sliders- All values are in kilograms, Base Values are Vanilla. P.S. This will only apply to fresh kills.")]

        [Name("Meat Slider Bear Max")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Bear")]
        [Slider(1f, 500f)]
        public int BearSliderMax = 40;

        [Name("Meat Slider Bear Min")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Bear")]
        [Slider(1f, 500f)]
        public int BearSliderMin = 25;

        [Name("Meat Slider Deer Max")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Deer")]
        [Slider(1f, 500f)]
        public int DeerSliderMax = 10;

        [Name("Meat Slider Deer Min")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Deer")]
        [Slider(1f, 500f)]
        public int DeerSliderMin = 8;

        [Name("Meat Slider Wolf Max")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Wolf")]
        [Slider(1f, 500f)]
        public int WolfSliderMax = 6;

        [Name("Meat Slider Wolf Min")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Wolf")]
        [Slider(1f, 500f)]
        public int WolfSliderMin = 3;

        [Name("Meat Slider Moose Max")]
        [Description("Change The Maximum Amount Of Usuable Meat Upon Killing A Moose")]
        [Slider(1f, 500f)]
        public int MooseSliderMax = 45;

        [Name("Meat Slider Moose Min")]
        [Description("Change The Minimum Amount Of Usuable Meat Upon Killing A Moose")]
        [Slider(1f, 500f)]
        public int MooseSliderMin = 30;
    }
}
