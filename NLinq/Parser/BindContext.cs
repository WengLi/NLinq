using NLinq.Parser.DbExpressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

namespace NLinq.Parser
{
    internal class BindContext
    {
        private class Binding
        {
            public DbExpression dbExpression { get; set; }
            public Expression expression { get; set; }

            public Binding(Expression e, DbExpression db)
            {
                this.expression = e;
                this.dbExpression = db;
            }
        }

        private Stack<Binding> bindings = new Stack<Binding>();

        public void Push(Expression expression, DbExpression dbExpression)
        {
            bindings.Push(new Binding(expression, dbExpression));
        }

        public void Pop()
        {
            bindings.Pop();
        }

        public bool TryGetDbExpression(Expression e, out DbExpression db)
        {
            db = bindings.Where(o => o.expression == e).Select(o => o.dbExpression).FirstOrDefault();
            return db != null;
        }
    }
}
