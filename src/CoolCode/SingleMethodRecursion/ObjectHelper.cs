using System;
using System.Collections.Generic;
using System.Linq;

namespace CoolCode.SingleMethodRecursion
{
    public class ObjectHelper
    {
        #region multi-method way (old)

        public List<DisplayLine> GetAllPropertiesOld(object obj)
        {
            List<DisplayLine> allProperties = new List<DisplayLine>();

            GetAllPropertiesWorker(allProperties, obj, 0);

            return allProperties;
        }

        void GetAllPropertiesWorker(List<DisplayLine> allProperties, object obj, int indent)
        {
            List<PropertyItem> properties = obj.GetProperties();
            foreach (PropertyItem propertyItem in properties)
            {
                if (propertyItem.Name != "IsDirty")
                {
                    DisplayLine displayLine = new DisplayLine()
                    {
                        Indent = indent,
                        Value = propertyItem
                    };

                    allProperties.Add(displayLine);
                    if (propertyItem.Kind == PropertyKind.Complex)
                    {
                        GetAllPropertiesWorker(allProperties, propertyItem.Value, indent + 3);
                    }
                }
            }
        }

        #endregion

        #region single-method (new)

        public List<DisplayLine> GetAllPropertiesNew(object obj)
        {
            List<DisplayLine> allProperties = new List<DisplayLine>();

            Action<object, int> getProperties = null;

            getProperties = (o, indent) =>
            {
                List<PropertyItem> properties = o.GetProperties();
                foreach (PropertyItem propertyItem in properties)
                {
                    if (propertyItem.Name != "IsDirty")
                    {
                        DisplayLine displayLine = new DisplayLine()
                        {
                            Indent = indent,
                            Value = propertyItem
                        };

                        allProperties.Add(displayLine);
                        if (propertyItem.Kind == PropertyKind.Complex)
                        {
                            getProperties(propertyItem.Value, indent + 3);
                        }
                    }
                }
            };

            getProperties(obj, 0);

            return allProperties;
        }

        #endregion

        #region single-method (alternative)

        public List<DisplayLine> GetAllPropertiesAlternative(object obj)
        {
            List<DisplayLine> allProperties = new List<DisplayLine>();

            void getProperties(object o, int indent)
            {
                List<PropertyItem> properties = o.GetProperties();
                foreach (PropertyItem propertyItem in properties)
                {
                    if (propertyItem.Name != "IsDirty")
                    {
                        DisplayLine displayLine = new DisplayLine()
                        {
                            Indent = indent,
                            Value = propertyItem
                        };

                        allProperties.Add(displayLine);
                        if (propertyItem.Kind == PropertyKind.Complex)
                        {
                            getProperties(propertyItem.Value, indent + 3);
                        }
                    }
                }
            }

            getProperties(obj, 0);

            return allProperties;
        }

        #endregion
    }

    public class DisplayLine
    {
        public int Indent { get; set; }
        public PropertyItem Value { get; set; }
    }
}
