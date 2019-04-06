using NLinq.Parser.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public abstract class DbExpression
    {
        public DbExpressionKind ExpressionKind;
        public BaseType ResultType;

        public DbExpression(DbExpressionKind kind, BaseType type)
        {
            this.ExpressionKind = kind;
            this.ResultType = type;
        }

        public abstract T Visit<T>(DbExpressionVisitor<T> visitor);
    }
}
