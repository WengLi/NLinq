using NLinq.DataType;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.DbExpressions
{
    public class DbOrderByExpression : DbProjectExpression
    {
        public bool Asc { get; }
        public DbOrderByExpression(DbExpressionBinding bind, DbExpression body, BaseType type, bool asc)
           : base(bind, body, DbExpressionKind.GroupBy, type)
        {
            this.Asc = asc;
        }


        public IEnumerable<DbMemberExpression> OrderMembers => Body.Members;

        public override IEnumerable<DbMemberExpression> Members => Source.Expression.Members;
    }
}
