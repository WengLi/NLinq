using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;

namespace NLinq
{
    public class WorkSpace
    {
        public static ConcurrentDictionary<Type, EntitySet> EntitySetCache = new ConcurrentDictionary<Type, EntitySet>();
    }
}
