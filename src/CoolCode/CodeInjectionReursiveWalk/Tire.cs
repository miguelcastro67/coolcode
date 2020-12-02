using System;
using System.Linq;

namespace CoolCode.CodeInjectionRecursiveWalk
{
    public class Tire : ObjectBase
    {
        string _Make;
        string _Model;
        TireSize _Dimensions;

        public string Make
        {
            get => _Make;
            set
            {
                if (_Make != value)
                {
                    _Make = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Model
        {
            get => _Model;
            set
            {
                if (_Model != value)
                {
                    _Model = value;
                    OnPropertyChanged();
                }
            }
        }

        public TireSize Dimensions
        {
            get => _Dimensions;
            set
            {
                if (_Dimensions != value)
                {
                    _Dimensions = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
