using System;
using System.Collections.Generic;
using System.Text;
using NLinq.DataType;

namespace NLinq.DbExpressions
{
    public class DbTableExpression : DbProjectExpression
    {
        public EntitySet EntitySet { get; }

        public DbTableExpression(EntitySet entity, DbParameterExpression p)
            : base(null, null, DbExpressionKind.Table, new EntityType(entity))
        {
            this.EntitySet = entity;
            this.Source = new DbExpressionBinding(this, p);
        }

        public override IEnumerable<DbMemberExpression> Members
        {
            get
            {
                foreach(var p in EntitySet.EntityProperties)
                {
                    DbColumnExpression column = new DbColumnExpression(p);
                    yield return new DbMemberExpression(column, p.PropertyInfo);
                }
            }
        }
    }
}
