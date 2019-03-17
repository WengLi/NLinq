using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbOrElseExpression : DbExpression
    {
        public DbExpression Left;
        public DbExpression Right;

        public DbOrElseExpression(DbExpression left, DbExpression right)
            : base(DbExpressionKind.AndAlso)
        {
            this.Left = left;
            this.Right = right;
        }

        [System.Diagnostics.DebuggerNonUserCode]
        public override T Visit<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
