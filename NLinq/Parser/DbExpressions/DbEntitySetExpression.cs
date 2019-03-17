using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbEntitySetExpression: DbProjectExpression
    {
        public EntitySet EntitySet;

        public DbEntitySetExpression(EntitySet entity)
            : base(null, null, DbExpressionKind.EntitySet)
        {
            this.EntitySet = entity;
        }

        [System.Diagnostics.DebuggerNonUserCode]
        public override T Visit<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
