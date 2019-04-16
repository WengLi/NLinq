using System;
using System.Collections.Generic;
using System.Text;
using NLinq.DataType;

namespace NLinq.DbExpressions
{
    public class DbSelectExpression: DbProjectExpression
    {
        public DbSelectExpression(DbExpressionBinding bind, DbExpression body, BaseType type)
            : base(bind, body, DbExpressionKind.Select, type)
        { }

        public override IEnumerable<DbMemberExpression> Members => Body.Members;
    }
}
