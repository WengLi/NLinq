using NLinq.Parser.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbConstantExpression : DbExpression
    {
        public readonly object Value;
        public DbConstantExpression(object value, BaseType type)
            : base(DbExpressionKind.Constant, type)
        {
            this.Value = value;
        }

        [System.Diagnostics.DebuggerNonUserCode]
        public override T Visit<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
