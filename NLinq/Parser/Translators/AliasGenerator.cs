using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NLinq.Parser.Translators
{
    internal sealed class AliasGenerator
    {
        private volatile int Index = 0;
        private readonly string prefix;

        public AliasGenerator(string pre)
        {
            prefix = pre ?? string.Empty;
        }

        internal string GetName()
        {
            return prefix + Interlocked.Increment(ref Index);
        }
    }
}
