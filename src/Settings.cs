using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModSettings;

namespace UsableMeatMod
{
    internal static class Settings
    {
        internal static void OnLoad()
        {
            Settings.options = new UsableMeatModSettings();
            Settings.options.AddToModSettings("Usable Meat Mod Settings");
        }
        internal static UsableMeatModSettings options;
    }
}
