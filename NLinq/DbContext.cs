using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NLinq
{
    public abstract class DbContext
    {
        protected DbSet<T> Set<T>() where T:class
        {
            return new DbSet<T>();
        }
    }
}
