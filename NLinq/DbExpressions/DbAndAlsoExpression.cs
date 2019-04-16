using NLinq.DataType;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
