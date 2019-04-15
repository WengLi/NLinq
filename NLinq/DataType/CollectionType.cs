using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.DataType
{
    public class CollectionType : BaseType
    {
        public override DataTypeKind TypeKind => DataTypeKind.CollectionType;
        public BaseType Element { get; set; }
        public CollectionType(Type t)
            : base(t)
        { }
    }
}
