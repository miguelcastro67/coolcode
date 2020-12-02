using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCode.MultipleInheritance
{
    public class CustomCar : IPowerTrainMods, IDriveTrainMods
    {
        public List<string> TopEndMods { get; set; } = new List<string>();
        public List<string> BottomEndMods { get; set; } = new List<string>();
        public List<string> TranyMods { get; set; } = new List<string>();
        public List<string> RearEndMods { get; set; } = new List<string>();
    }
}
