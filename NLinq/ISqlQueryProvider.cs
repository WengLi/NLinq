using System.Linq.Expressions;

namespace NLinq
{
    public interface ISqlQueryProvider
    {
        ISqlQuery<TElement> CreateQuery<TElement>(Expression expression);
        TResult Execute<TResult>(Expression expression);
    }
}