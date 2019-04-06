using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.Metadata
{
    public abstract class BaseType
    {
        public Type ClrType { get; set; }

        public BaseType(Type clrType)
        {
            this.ClrType = clrType;
        }
    }
}
