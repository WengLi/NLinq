using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbWhereExpression : DbProjectExpression
    {
        public DbWhereExpression(DbProjectExpression input, DbExpression body) :
            base(input, body, DbExpressionKind.Where)
        { }

        [System.Diagnostics.DebuggerNonUserCode]
        public override T Visit<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
