using NLinq.DataType;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;

namespace NLinq.DbExpressions
{
    public class DbNewExpression : DbExpression
    {
        public NewExpression Expression;

        public IEnumerable<DbMemberExpression> NewMembers { get; }

        public override IEnumerable<DbMemberExpression> Members => NewMembers;

        public DbNewExpression(RowType type,params DbMemberExpression[] args)
            : base(DbExpressionKind.New, type)
        {
            this.NewMembers = args;
        }
    }
}
