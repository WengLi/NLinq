using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NLinq
{
    public class DbSet<TEntity> : ISqlQuery<TEntity> where TEntity : class
    {
        private ObjectQuery<TEntity> _objectQuery;

        public DbSet(DbContext context)
        {
            _objectQuery = new ObjectQuery<TEntity>(null, null, context);
        }

        public Type ElementType => typeof(TEntity);

        public Expression Expression => _objectQuery.Expression;

        public ISqlQueryProvider Provider => _objectQuery.Provider;

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _objectQuery.GetEnumerator();
        }
    }
}
