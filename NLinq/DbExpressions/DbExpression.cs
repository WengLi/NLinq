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
        LessThanOrEqual
    }

    public abstract class DbExpression 
    {
        public BaseType ResultType { get; set; }

        public DbExpressionKind DbExpressionKind { get; set; }

        public DbExpression(DbExpressionKind kind, BaseType type)
        {
            this.DbExpressionKind = kind;
            this.ResultType = type;
        }
    }
}
