using NLinq.Parser.DbExpressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public abstract class DbProjectExpression: DbExpression
    {
        public DbExpressionBinding Input;
        public DbExpression Body;

        public DbProjectExpression(DbExpressionBinding input, DbExpression body,DbExpressionKind kind)
            :base(kind)
        {
            this.Input = input;
            this.Body = body;
        }
    }
}
