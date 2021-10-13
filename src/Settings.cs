using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModSettings;

namespace UseableMeatMod
{
    internal static class Settings
    {
        internal static void OnLoad()
        {
            Settings.options = new UseableMeatModSettings();
            Settings.options.AddToModSettings("Usable Meat Mod Settings");
        }
        internal static UseableMeatModSettings options;
    }
}
