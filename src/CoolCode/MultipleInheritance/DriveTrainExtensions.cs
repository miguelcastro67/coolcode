using System;
using System.Linq;

namespace CoolCode.MultipleInheritance
{
    public static class DriveTrainExtensions
    {
        public static void AddShiftKit(this IDriveTrainMods driveTrainMods)
        {
            if (!driveTrainMods.TranyMods.Contains("ShiftKit"))
                driveTrainMods.TranyMods.Add("ShiftKit");
        }

        public static void AddLimitedSlipDiff(this IDriveTrainMods driveTrainMods)
        {
            if (!driveTrainMods.RearEndMods.Contains("LimitedSlipDiff"))
                driveTrainMods.RearEndMods.Add("LimitedSlipDiff");
        }

        public static void AddGears(this IDriveTrainMods driveTrainMods, string gearing)
        {
            if (!driveTrainMods.RearEndMods.Contains(gearing + "Gears "))
                driveTrainMods.RearEndMods.Add(gearing + " Gears ");
        }
    }
}
