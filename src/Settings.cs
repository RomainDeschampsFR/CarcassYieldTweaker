namespace UseableMeatMod
{
    internal static class Settings
    {
        internal static void OnLoad()
        {
            Settings.options = new UseableMeatModSettings();
            Settings.options.AddToModSettings("Useable Meat Mod Settings");
        }
        internal static UseableMeatModSettings options;
    }
}
