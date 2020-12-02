using System;
using System.Linq;

namespace CoolCode.MultipleInheritance
{
    public static class PowerTrainExtensions
    {
        public static void AddSupercharger(this IPowerTrainMods powerTrainMods)
        {
            if (!powerTrainMods.TopEndMods.Contains("Supercharger"))
                powerTrainMods.TopEndMods.Add("Supercharger");
        }

        public static void AddForgedInternals(this IPowerTrainMods powerTrainMods)
        {
            if (!powerTrainMods.BottomEndMods.Contains("ForgedInternals"))
                powerTrainMods.BottomEndMods.Add("ForgedInternals");
        }
    }
}
