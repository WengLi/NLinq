using NLinq.Parser.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbSelectExpression : DbProjectExpression
    {
        public DbSelectExpression(DbExpressionBinding input, DbExpression body, BaseType type)
            : base(input, body, DbExpressionKind.Select, type)
        { }

        [System.Diagnostics.DebuggerNonUserCode]
        public override T Visit<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
