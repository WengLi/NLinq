using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.DataType
{
    public class BaseType
    {
        public Type ClrType { get; set; }

        public BaseType(Type type)
        {
            this.ClrType = type;
        }
    }
}
