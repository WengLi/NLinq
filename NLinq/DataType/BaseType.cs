using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.DataType
{
    public abstract class BaseType
    {
        public Type ClrType { get; set; }

        public abstract DataTypeKind TypeKind { get; }

        public BaseType(Type type)
        {
            this.ClrType = type;
        }
    }

    public enum DataTypeKind
    {
        CollectionType,
        EntityPropertyType,
        EntityType,
        MemberType,
        PrimitiveType,
        RowType
    }
}
