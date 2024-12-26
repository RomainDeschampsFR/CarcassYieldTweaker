using MelonLoader;
using System;
using UnityEngine;

namespace CarcassYieldTweaker
{
    public class Implementation : MelonMod
    {
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg($"Version {Info.Version} loaded!");
            Settings.OnLoad();
        }
    }
}