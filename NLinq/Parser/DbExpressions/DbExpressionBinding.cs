using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public sealed class DbExpressionBinding
    {
        public DbExpression Expression;
        public DbParameterExpression DbParameter;

        public DbExpressionBinding(DbExpression expression, DbParameterExpression dbParameter)
        {
            this.Expression = expression;
            this.DbParameter = dbParameter;
        }
    }
}
