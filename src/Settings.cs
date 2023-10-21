namespace CarcassYieldTweaker
{
    internal static class Settings
    {
        internal static void OnLoad()
        {
            Settings.options = new CarcassYieldTweakerSettings();
            Settings.options.AddToModSettings("Useable Meat Mod Settings");
        }
        internal static CarcassYieldTweakerSettings options;
    }
}
