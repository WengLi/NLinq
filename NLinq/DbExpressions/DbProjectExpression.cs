using NLinq.DataType;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.DbExpressions
{
    public abstract class DbProjectExpression : DbExpression
    {
        public DbExpressionBinding Source { get; set; }

        public DbExpression Body { get; set; }

        public DbProjectExpression(DbExpressionBinding bind, DbExpression body, DbExpressionKind kind, BaseType type)
            : base(kind, type)
        {
            this.Source = bind;
            this.Body = body;
        }
    }
}
