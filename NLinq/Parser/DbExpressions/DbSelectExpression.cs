using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbSelectExpression : DbProjectExpression
    {
        public DbSelectExpression(DbProjectExpression input, DbExpression body)
            : base(input, body, DbExpressionKind.Select)
        { }

        [System.Diagnostics.DebuggerNonUserCode]
        public override T Visit<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
