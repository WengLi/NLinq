using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.DataType
{
    public class EntityType : BaseType
    {
        public EntitySet EntitySet { get; set; }

        public override DataTypeKind TypeKind => DataTypeKind.EntityType;

        public EntityType(EntitySet entitySet)
            : base(entitySet.EntityType)
        {
            this.EntitySet = entitySet;
        }

        public override string ToString()
        {
            return EntitySet.TableName;
        }
    }
}
