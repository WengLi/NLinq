using NLinq.DataType;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.DbExpressions
{
    public class DbWhereExpression: DbProjectExpression
    {
        public DbWhereExpression(DbExpressionBinding bind, DbExpression body, BaseType type)
           : base(bind, body, DbExpressionKind.Where, type)
        { }

        public override IEnumerable<DbMemberExpression> Members => Source.Expression.Members;
    }
}
