using CoolCode.EventSubscriberCollections;
using CoolCode.MultipleInheritance;
using CoolCode.SingleMethodRecursion;
using System;
using System.Collections.Generic;
using System.Linq;
using rw = CoolCode.CodeInjectionRecursiveWalk;

namespace CoolCode
{
    class Program
    {
        static void Main(string[] args)
        {
            OldEngine _OldEngine = new OldEngine();
            NewEngine _NewEngine = new NewEngine();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to Cool Code!");
                Console.WriteLine("1 - Multiple inheritance");
                Console.WriteLine("2 - Events (without dupe failsafe)");
                Console.WriteLine("3 - Events (with dupe failsafe)");
                Console.WriteLine("4 - Multi-Method recursion");
                Console.WriteLine("5 - Single-Method recursion - technique 1");
                Console.WriteLine("6 - Single-Method recursion - technique 2");
                Console.WriteLine("7 - Code Injection");
                Console.WriteLine("8 - Code Injection Recursive Walk");
                Console.WriteLine("0 - Exit");
                Console.Write("--> ");
                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        #region Multiple inheritance

                        CustomCar customCar = new CustomCar();

                        customCar.AddSupercharger();
                        customCar.AddGears("3:73");
                        customCar.AddShiftKit();

                        if (customCar.TopEndMods.Count == 0 && customCar.BottomEndMods.Count == 0)
                        {
                            Console.WriteLine("No Power Train Modifications made.");
                        }
                        else
                        {
                            if (customCar.TopEndMods.Count > 0)
                            {
                                Console.WriteLine("Top-End Modifications:");
                                customCar.TopEndMods.ForEach(item => Console.WriteLine("   {0}", item));
                            }

                            if (customCar.BottomEndMods.Count > 0)
                            {
                                Console.WriteLine("Bottom-End Modifications:");
                                customCar.BottomEndMods.ForEach(item => Console.WriteLine("   {0}", item));
                            }
                        }

                        if (customCar.TranyMods.Count == 0 && customCar.RearEndMods.Count == 0)
                        {
                            Console.WriteLine("No Drive Train Modifications made.");
                        }
                        else
                        {
                            if (customCar.TranyMods.Count > 0)
                            {
                                Console.WriteLine("Transmission Modifications:");
                                customCar.TranyMods.ForEach(item => Console.WriteLine("   {0}", item));
                            }

                            if (customCar.RearEndMods.Count > 0)
                            {
                                Console.WriteLine("Rear-End Modifications:");
                                customCar.RearEndMods.ForEach(item => Console.WriteLine("   {0}", item));
                            }
                        }

                        break;

                    #endregion
                    case "2":
                        #region Events (without dupe failsafe)

                        _OldEngine.TurningOver += (s, e) =>
                        {
                            Console.WriteLine("Engine oil pressure is {0} and temperature is {1}.", e.OilPressure, e.Temperature);
                            Console.WriteLine("Engine turning over...");
                        };                       

                        _OldEngine.TurnedOver += (s, e) =>
                        {
                            Console.WriteLine("Engine oil pressure is {0} and temperature is {1}.", e.OilPressure, e.Temperature);
                            Console.WriteLine("Engine started.");
                        };

                        _OldEngine.Start();
                        
                        break;

                        #endregion
                    case "3":
                        #region Events (with dupe failsafe)

                        _NewEngine.TurningOver += (s, e) =>
                        {
                            Console.WriteLine("Engine oil pressure is {0} and temperature is {1}.", e.OilPressure, e.Temperature);
                            Console.WriteLine("Engine turning over...");
                        };

                        _NewEngine.TurnedOver += (s, e) =>
                        {
                            Console.WriteLine("Engine oil pressure is {0} and temperature is {1}.", e.OilPressure, e.Temperature);
                            Console.WriteLine("Engine started.");
                        };

                        _NewEngine.Start();

                        break;

                    #endregion
                    case "4":
                        #region Multi-Method recursion
                        {
                            Console.WriteLine("Multi-Method Recursion");
                            Console.WriteLine();

                            Automobile automobile = getAutomobile();

                            ObjectHelper helper = new ObjectHelper();

                            List<DisplayLine> properties = helper.GetAllPropertiesOld(automobile);

                            foreach (DisplayLine displayline in properties)
                            {
                                string indentation = string.Concat(Enumerable.Repeat(" ", displayline.Indent));
                                if (displayline.Value.Kind == PropertyKind.Complex)
                                    Console.WriteLine("{0}{1}:", indentation, displayline.Value.Name);
                                else
                                    Console.WriteLine("{0}{1} = {2}", indentation, displayline.Value.Name, displayline.Value.Value);
                            }
                        }
                        break;

                    #endregion
                    case "5":
                        #region Single-Method recursion - technique 2
                        {
                            Console.WriteLine("Single-Method Recursion");
                            Console.WriteLine();

                            Automobile automobile = getAutomobile();

                            ObjectHelper helper = new ObjectHelper();

                            List<DisplayLine> properties = helper.GetAllPropertiesNew(automobile);

                            foreach (DisplayLine displayline in properties)
                            {
                                string indentation = string.Concat(Enumerable.Repeat(" ", displayline.Indent));
                                if (displayline.Value.Kind == PropertyKind.Complex)
                                    Console.WriteLine("{0}{1}:", indentation, displayline.Value.Name);
                                else
                                    Console.WriteLine("{0}{1} = {2}", indentation, displayline.Value.Name, displayline.Value.Value);
                            }
                        }
                        break;

                    #endregion
                    case "6":
                        #region Single-Method recursion - technique 2
                        {
                            Console.WriteLine("Single-Method Recursion");
                            Console.WriteLine();

                            Automobile automobile = getAutomobile();

                            ObjectHelper helper = new ObjectHelper();

                            List<DisplayLine> properties = helper.GetAllPropertiesAlternative(automobile);

                            foreach (DisplayLine displayline in properties)
                            {
                                string indentation = string.Concat(Enumerable.Repeat(" ", displayline.Indent));
                                if (displayline.Value.Kind == PropertyKind.Complex)
                                    Console.WriteLine("{0}{1}:", indentation, displayline.Value.Name);
                                else
                                    Console.WriteLine("{0}{1} = {2}", indentation, displayline.Value.Name, displayline.Value.Value);
                            }
                        }
                        break;

                    #endregion
                    case "7":
                        break;
                    case "8":
                        #region Code Injection Recursive Walk
                        {
                            rw.Automobile automobile = new rw.Automobile()
                            {
                                Make = "Ford",
                                Model = "Mustang",
                                Variant = "GT Convertible",
                                Year = 2008,
                                Color = "Black",
                                FrontTires = new rw.Tire()
                                {
                                    Make = "Michelin",
                                    Model = "Pilot Super Sport",
                                    Dimensions = new rw.TireSize()
                                    {
                                        Width = 265,
                                        AspectRatio = 35,
                                        WheelSize = 19
                                    }
                                },
                                RearTires = new rw.Tire()
                                {
                                    Make = "Michellin",
                                    Model = "Pilot Super Sport",
                                    Dimensions = new rw.TireSize()
                                    {
                                        Width = 295,
                                        AspectRatio = 30,
                                        WheelSize = 19
                                    }
                                },
                                PowerSpecs = new rw.DynoInfo()
                                {
                                    Horsepower = 665,
                                    Torque = 606
                                }
                            };

                            automobile.CleanAll();

                            #region working code

                            automobile.Model = "Pinto";
                            automobile.RearTires.Dimensions.WheelSize = 14;
                            automobile.PowerSpecs.Horsepower = 77;

                            #endregion

                            if (automobile.IsAnythingDirty())
                            {
                                Console.WriteLine("Something inside 'automobile' is dirty.");
                                Console.WriteLine();

                                Console.WriteLine("Dirty types in 'automobile':");
                                ListDirtyTypes(automobile);
                                Console.WriteLine();

                                Console.WriteLine("Dirty properties in 'automobile':");
                                ListDirtyProperties(automobile);
                                Console.WriteLine();
                            }
                            else
                                Console.WriteLine("Nothing inside 'automobile' is dirty.");
                        }
                        break;
                        #endregion
                    case "0":
                        exit = true;
                        break;
                }
                Console.WriteLine();
            }
        }

        static Automobile getAutomobile()
        {
            Automobile automobile = new Automobile()
            {
                Make = "Ford",
                Model = "Mustang",
                Variant = "GT Convertible",
                Year = 2008,
                Color = "Black",
                FrontTires = new Tire()
                {
                    Make = "Michelin",
                    Model = "Pilot Super Sport",
                    Dimensions = new TireSize()
                    {
                        Width = 265,
                        AspectRatio = 35,
                        WheelSize = 19
                    }
                },
                RearTires = new Tire()
                {
                    Make = "Michellin",
                    Model = "Pilot Super Sport",
                    Dimensions = new TireSize()
                    {
                        Width = 295,
                        AspectRatio = 30,
                        WheelSize = 19
                    }
                },
                PowerSpecs = new DynoInfo()
                {
                    Horsepower = 665,
                    Torque = 606
                }
            };

            return automobile;
        }

        static void ListDirtyTypes(ObjectBase obj)
        {
            List<ObjectBase> dirtyObjects = obj.GetDirtyObjects();
            dirtyObjects.ForEach(item =>
            {
                Console.WriteLine("   property of type {0}", item.GetType().Name);
            });
        }


        static void ListDirtyProperties(ObjectBase obj)
        { 
            List<ConsoleLine> properties = GetAllDirtyProperties(obj);

            foreach (ConsoleLine displayline in properties)
            {
                string indentation = string.Concat(Enumerable.Repeat(" ", displayline.Indent));
                Console.WriteLine("   {0}{1}", indentation, displayline.Value.Name);
            }
        }
        
        static List<ConsoleLine> GetAllDirtyProperties(ObjectBase obj)
        {
            List<ConsoleLine> allProperties = new List<ConsoleLine>();

            Action<ObjectBase, int> getProperties = null;

            getProperties = (o, indent) =>
            {
                List<PropertyItem> properties = o.GetProperties();
                foreach (PropertyItem propertyItem in properties)
                {
                    if (propertyItem.Kind == PropertyKind.Complex)
                    {
                        ObjectBase complexProp = (ObjectBase)propertyItem.Value;
                        if (complexProp.IsDirty)
                        {
                            ConsoleLine displayLine = new ConsoleLine()
                            {
                                Indent = indent,
                                Value = propertyItem
                            };

                            allProperties.Add(displayLine);
                        }

                        getProperties(complexProp, indent + 3);
                    }
                }
            };

            getProperties(obj, 0);

            return allProperties;
        }
    }

    public class ConsoleLine
    {
        public int Indent { get; set; }
        public PropertyItem Value { get; set; }
    }
}
