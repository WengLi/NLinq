using NLinq.DataType;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NLinq.DbExpressions
{
    public class DbColumnExpression: DbExpression
    {
        public EntityProperty EntityProperty { get; }

        public DbColumnExpression(EntityProperty property)
            : base(DbExpressionKind.Column, new EntityPropertyType(property))
        {
            this.EntityProperty = property;
        }

        public override IEnumerable<DbMemberExpression> Members => Enumerable.Empty<DbMemberExpression>();
    }
}
