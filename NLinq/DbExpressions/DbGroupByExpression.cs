using NLinq.DataType;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.DbExpressions
{
    public class DbGroupByExpression : DbProjectExpression
    {
        public DbExpression Having { get; set; }
        public DbGroupByExpression(DbExpressionBinding bind, DbExpression body, BaseType type)
           : base(bind, body, DbExpressionKind.GroupBy, type)
        {
        }

        public override IEnumerable<DbMemberExpression> Members => Body.Members;
    }
}
