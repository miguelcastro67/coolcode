using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCode.SingleMethodRecursion
{
    public class Automobile : ObjectBase
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public Tire FrontTires { get; set; }
        public Tire RearTires { get; set; }
        public DynoInfo PowerSpecs { get; set; }
    }
    
    public class Tire : ObjectBase
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public TireSize Dimensions { get; set; }
    }

    public class TireSize : ObjectBase
    {
        public int Width { get; set; }
        public int AspectRatio { get; set; }
        public int WheelSize { get; set; }
    }

    public class DynoInfo : ObjectBase
    {
        public int Horsepower { get; set; }
        public int Torque { get; set; }
    }
}
