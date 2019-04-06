using NLinq.Parser.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbParameterExpression: DbExpression
    {
        public string ParameterName;

        public DbParameterExpression(string name, BaseType t)
            :base(DbExpressionKind.Parameter, t)
        {
            this.ParameterName = name;
        }

        [System.Diagnostics.DebuggerNonUserCode]
        public override T Visit<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
