using System;
using System.Collections.Generic;
using System.Text;
using NLinq.DataType;

namespace NLinq.DbExpressions
{
    public enum DbExpressionKind
    {
        Select,
        Where,
        Parameter,
        Constant,
        Member,
        Table,
        Column,
        AndAlso,
        New,
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        GroupBy
    }

    public abstract class DbExpression 
    {
        public BaseType ResultType { get; set; }

        public DbExpressionKind ExpressionKind { get; set; }

        public DbExpression(DbExpressionKind kind, BaseType type)
        {
            this.ExpressionKind = kind;
            this.ResultType = type;
        }

        public abstract IEnumerable<DbMemberExpression> Members { get; }
    }
}
