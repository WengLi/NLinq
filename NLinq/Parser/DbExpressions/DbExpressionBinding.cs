using NLinq.Parser.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbExpressionBinding
    {
        public DbExpression Input;
        public DbParameterExpression Parameter;

        public DbExpressionBinding(DbExpression input, DbParameterExpression p)
        {
            this.Input = input;
            this.Parameter = p;
        }

        public BaseType ResultType => Input.ResultType;
    }
}
