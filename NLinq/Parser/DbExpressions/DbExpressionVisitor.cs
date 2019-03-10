using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public abstract class DbExpressionVisitor<T>
    {
        public abstract T Visit(DbExpression dbExpression);
    }
}
