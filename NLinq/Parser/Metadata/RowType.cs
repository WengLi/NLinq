using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NLinq.Parser.Metadata
{
    public class RowType : BaseType
    {
        public NewExpression Expression;
        public RowType(NewExpression expression)
            : base(expression.Type)
        {
            this.Expression = expression;
        }
    }
}
