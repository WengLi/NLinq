using NLinq.Parser.DbExpressions;
using NLinq.Parser.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public abstract class DbProjectExpression : DbExpression
    {
        public DbExpressionBinding Input;
        public DbExpression Body;

        public DbProjectExpression(DbExpressionBinding input, DbExpression body, DbExpressionKind kind, BaseType type)
            :base(kind, type)
        {
            this.Body = body;
            this.Input = input;
        }
    }
}
