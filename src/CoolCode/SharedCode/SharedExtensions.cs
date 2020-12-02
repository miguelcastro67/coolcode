using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CoolCode
{
    public static class SharedExtensions
    {
        public static List<PropertyItem> GetProperties(this object obj)
        {
            List<PropertyItem> propertyList = new List<PropertyItem>();

            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                PropertyItem propertyItem = new PropertyItem()
                {
                    Name = property.Name,
                    Type = property.PropertyType,
                    Value = property.GetValue(obj, null)
                };

                if (property.PropertyType.IsSubclassOf(typeof(ObjectBase)))
                    propertyItem.Kind = PropertyKind.Complex;
                else
                    propertyItem.Kind = PropertyKind.Simple;

                propertyList.Add(propertyItem);
            }

            return propertyList;
        }
    }
    public class PropertyItem
    {
        public string Name { get; set; }
        public PropertyKind Kind { get; set; }
        public Type Type { get; set; }
        public object Value { get; set; }
    }
}
