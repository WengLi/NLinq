using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbReferenceExpression : DbExpression
    {
        public DbExpression Reference;
        public DbParameterExpression Parameter;
        public DbReferenceExpression(DbExpression refer, DbParameterExpression parameter)
            : base(DbExpressionKind.Reference, null)
        {
            this.Reference = refer;
            this.Parameter = parameter;
        }

        [System.Diagnostics.DebuggerNonUserCode]
        public override T Visit<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
