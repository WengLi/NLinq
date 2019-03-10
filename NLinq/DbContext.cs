using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NLinq
{
    public abstract class DbContext
    {
        public DbContext()
        {
            new DbSetDiscoveryService(this).InitializeSets();
        }

        protected DbSet<T> Set<T>() where T:class
        {
            return new DbSet<T>(this);
        }
    }
}
