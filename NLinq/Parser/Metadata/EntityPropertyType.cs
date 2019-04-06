using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.Metadata
{
    public class EntityPropertyType : BaseType
    {
        public EntityProperty EntityProperty;

        public EntityPropertyType(EntityProperty p)
            :base(p.Type)
        {
            this.EntityProperty = p;
        }
    }
}
