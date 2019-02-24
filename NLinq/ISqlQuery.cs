using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NLinq
{
    public interface ISqlQuery
    {
        Type ElementType { get; }
        Expression Expression { get; }
        ISqlQueryProvider Provider { get; }
    }

    public interface ISqlQuery<T> : ISqlQuery
    {
        IEnumerator<T> GetEnumerator();
    }
}
