using System;
using System.Linq;

namespace CoolCode.CodeInjectionRecursiveWalk
{
    public class TireSize : ObjectBase
    {
        int _Width;
        int _AspectRatio;
        int _WheelSize;

        public int Width
        {
            get => _Width;
            set
            {
                if (_Width != value)
                {
                    _Width = value;
                    OnPropertyChanged();
                }
            }
        }

        public int AspectRatio
        {
            get => _AspectRatio;
            set
            {
                if (_AspectRatio != value)
                {
                    _AspectRatio = value;
                    OnPropertyChanged();
                }
            }
        }

        public int WheelSize
        {
            get => _WheelSize;
            set
            {
                if (_WheelSize != value)
                {
                    _WheelSize = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
