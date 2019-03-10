using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public abstract class DbExpression
    {
        public DbExpressionKind ExpressionKind;

        public DbExpression(DbExpressionKind kind)
        {
            this.ExpressionKind = kind;
        }

        public abstract T Visit<T>(DbExpressionVisitor<T> visitor);
    }
}
