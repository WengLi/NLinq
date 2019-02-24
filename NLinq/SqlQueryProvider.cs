using System;
using System.Linq.Expressions;

namespace NLinq
{
    public class ObjectQueryProvider : ISqlQueryProvider
    {
        public ISqlQuery<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            if (!typeof(ISqlQuery<TElement>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentException(nameof(expression));
            }
            return new ObjectQuery<TElement>(this, expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
