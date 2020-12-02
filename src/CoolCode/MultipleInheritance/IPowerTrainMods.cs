using System;
using System.Collections.Generic;
using System.Linq;

namespace CoolCode.MultipleInheritance
{
    public interface IPowerTrainMods
    {
        List<string> TopEndMods { get; set; }
        List<string> BottomEndMods { get; set; }
    }
}
