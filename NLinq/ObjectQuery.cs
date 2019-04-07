using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using NLinq.Parser;

namespace NLinq
{
    internal abstract class ObjectQuery : ISqlQuery
    {
        public DbContext Context;

        public ObjectQuery(DbContext context)
        {
            this.Context = context;
        }

        public Type ElementType => GetElementType();

        public Expression Expression => GetExpression();

        public ISqlQueryProvider Provider => GetProvider();

        public abstract Type GetElementType();
        public abstract Expression GetExpression();
        public abstract ISqlQueryProvider GetProvider();
    }

    internal class ObjectQuery<TEntity> : ObjectQuery, ISqlQuery<TEntity>
    {
        private Expression _expression = null;
        private ISqlQueryProvider _provider = null;

        public ObjectQuery(ISqlQueryProvider provider, Expression expression, DbContext context)
            : base(context)
        {
            _provider = provider;
            _expression = expression;
        }

        public override Type GetElementType()
        {
            return typeof(TEntity);
        }

        public override Expression GetExpression()
        {
            if (_expression == null)
            {
                _expression = Expression.Constant(this);
            }
            return _expression;
        }

        public override ISqlQueryProvider GetProvider()
        {
            if (_provider == null)
            {
                _provider = new ObjectQueryProvider(this);
            }
            return _provider;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            var dbExpression = new ExpressionParser().Parse(_expression);
            return new List<TEntity>().GetEnumerator();
        }
    }
}
