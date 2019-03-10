using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq
{
    public class EntitySet
    {
        public Type EntityType { get; set; }
        public string TableName { get; set; }
        public string Schema { get; set; }
        public List<EntityProperty> EntityProperties = new List<EntityProperty>();
    }
}
