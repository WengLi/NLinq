using NLinq.Parser.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbEntitySetExpression : DbProjectExpression
    {
        public EntitySet EntitySet;

        public DbEntitySetExpression(EntitySet entity, DbParameterExpression parameter)
            : base(null, null, DbExpressionKind.EntitySet, new EntityType(entity))
        {
            this.EntitySet = entity;
            this.Input = new DbExpressionBinding(this, parameter);
        }

        [System.Diagnostics.DebuggerNonUserCode]
        public override T Visit<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
