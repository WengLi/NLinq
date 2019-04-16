using NLinq.DataType;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.DbExpressions
{
    public class DbConstantExpression : DbExpression
    {
        public readonly object Value;
        public DbConstantExpression(object value, BaseType type)
            : base(DbExpressionKind.Constant, type)
        {
            this.Value = value;
        }
    }
}
