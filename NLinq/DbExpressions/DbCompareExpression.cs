using NLinq.DataType;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.DbExpressions
{
    public class DbCompareExpression : DbExpression
    {
        public DbExpression Left;
        public DbExpression Right;

        public DbCompareExpression(DbExpression left, DbExpression right, DbExpressionKind kind)
            : base(kind, PrimitiveType.BooleanType)
        {
            this.Left = left;
            this.Right = right;
        }
    }
}
