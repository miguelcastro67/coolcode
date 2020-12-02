using System;
using System.Linq;

namespace CoolCode.CodeInjectionRecursiveWalk
{
    public class DynoInfo : ObjectBase
    {
        int _Horsepower;
        int _Torque;

        public int Horsepower
        {
            get => _Horsepower;
            set
            {
                if (_Horsepower != value)
                {
                    _Horsepower = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Torque
        {
            get => _Torque;
            set
            {
                if (_Torque != value)
                {
                    _Torque = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
