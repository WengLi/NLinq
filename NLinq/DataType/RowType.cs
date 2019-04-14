using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

namespace NLinq.DataType
{

    public class RowType : BaseType
    {
        public RowExpression RowExpression { get; set; }

        public MemberType[] Members { get; set; }

        public RowType(Type t,Expression expression, params MemberType[] memberTypes)
            : base(t)
        {
            this.RowExpression = new RowExpression(expression);
            this.Members = memberTypes;
        }

        public override string ToString()
        {
            return string.Format("row({0})", string.Join(",", Members.Select(o => o.ToString())));
        }
    }

    public class RowExpression : Expression
    {
        private Expression _expression;
        public RowExpression(Expression expression)
        {
            this._expression = expression;
        }

        public override Type Type => _expression.Type;

        public NewExpression NewExpression
        {
            get
            {
                if (_expression.NodeType == ExpressionType.New)
                {
                    return (NewExpression)_expression;
                }
                return null;
            }
        }

        public MemberInitExpression MemberInitExpression
        {
            get
            {
                if (_expression.NodeType == ExpressionType.MemberInit)
                {
                    return (MemberInitExpression)_expression;
                }
                return null;
            }
        }
    }
}
