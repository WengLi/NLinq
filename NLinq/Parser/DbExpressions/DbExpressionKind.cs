using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public enum DbExpressionKind
    {
        Select,
        Where,
        Parameter,
        Constant,
        Member,
        EntitySet,
        AndAlso,
        New,
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual
    }
}
