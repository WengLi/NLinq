using NLinq.DataType;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NLinq.DbExpressions
{
    public class DbAndAlsoExpression : DbExpression
    {
        public DbExpression Left;
        public DbExpression Right;

        public DbAndAlsoExpression(DbExpression left, DbExpression right)
            : base(DbExpressionKind.AndAlso, PrimitiveType.BooleanType)
        {
            this.Left = left;
            this.Right = right;
        }

        public override IEnumerable<DbMemberExpression> Members
        {
            get
            {
                return Left.Members.Union(Right.Members);
            }
        }
    }
}
