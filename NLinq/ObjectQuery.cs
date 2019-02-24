using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NLinq
{
    internal class ObjectQuery<TEntity> : ISqlQuery<TEntity>
    {
        private Expression _expression = null;
        private ISqlQueryProvider _provider = null;

        public ObjectQuery(ISqlQueryProvider provider, Expression expression)
        {
            _provider = provider;
            _expression = expression;
        }

        public Type ElementType => typeof(TEntity);

        public Expression Expression
        {
            get
            {
                if (_expression == null)
                {
                    _expression = Expression.Constant(this);
                }
                return _expression;
            }
        }

        public ISqlQueryProvider Provider
        {
            get
            {
                if (_provider == null)
                {
                    _provider = new ObjectQueryProvider();
                }
                return _provider;
            }
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
