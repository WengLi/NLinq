using NLinq.Parser.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbEntitySetExpression: DbExpression
    {
        public EntitySet EntitySet;

        public DbEntitySetExpression(EntitySet entity)
            : base(DbExpressionKind.EntitySet,new EntityType(entity))
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
