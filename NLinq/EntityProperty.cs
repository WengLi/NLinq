using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace NLinq
{
    public class EntityProperty
    {
        public EntitySet EntitySet;
        public bool IsKey { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public string ColumnName { get; set; }
        public Type Type { get { return PropertyInfo.PropertyType; } }
    }
}
