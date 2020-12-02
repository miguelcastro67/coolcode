using System;
using System.Collections.Generic;
using System.Linq;

namespace CoolCode.MultipleInheritance
{
    public interface IDriveTrainMods
    {
        List<string> TranyMods { get; set; }
        List<string> RearEndMods { get; set; }
    }
}
