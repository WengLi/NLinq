using System;
using System.Collections.Generic;
using System.Text;
using NLinq.DataType;

namespace NLinq.DbExpressions
{
    public class DbTableExpression : DbProjectExpression
    {
        public EntitySet EntitySet { get; }

        public DbTableExpression(EntitySet entity)
            : base(null, null, DbExpressionKind.Table, new EntityType(entity))
        {
            this.EntitySet = entity;
        }
    }
}
