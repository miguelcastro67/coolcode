using System;
using System.Linq;

namespace CoolCode.CodeInjectionRecursiveWalk
{
    public class Automobile : ObjectBase
    {
        string _Make;
        string _Model;
        string _Variant;
        int _Year;
        string _Color;
        Tire _FrontTires;
        Tire _RearTires;
        DynoInfo _PowerSpecs;

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

        public string Variant
        {
            get => _Variant;
            set
            {
                if (_Variant != value)
                {
                    _Variant = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Year
        {
            get => _Year;
            set
            {
                if (_Year != value)
                {
                    _Year = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Color
        {
            get => _Color;
            set
            {
                if (_Color != value)
                {
                    _Color = value;
                    OnPropertyChanged();
                }
            }
        }

        public Tire FrontTires
        {
            get => _FrontTires;
            set
            {
                if (_FrontTires != value)
                {
                    _FrontTires = value;
                    OnPropertyChanged();
                }
            }
        }

        public Tire RearTires
        {
            get => _RearTires;
            set
            {
                if (_RearTires != value)
                {
                    _RearTires = value;
                    OnPropertyChanged();
                }
            }
        }

        public DynoInfo PowerSpecs
        {
            get => _PowerSpecs;
            set
            {
                if (_PowerSpecs != value)
                {
                    _PowerSpecs = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
