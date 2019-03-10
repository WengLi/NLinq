using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbMemberExpression : DbExpression
    {
        public EntityProperty EntityProperty;

        public DbMemberExpression(EntityProperty property)
            : base(DbExpressionKind.Member)
        {
            this.EntityProperty = property;
        }

        [System.Diagnostics.DebuggerNonUserCode]
        public override T Visit<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
