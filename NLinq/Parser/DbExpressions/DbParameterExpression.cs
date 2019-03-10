using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbParameterExpression: DbExpression
    {
        public string ParameterName;
        public Type Type;

        public DbParameterExpression(string name, Type type)
            :base(DbExpressionKind.Parameter)
        {
            this.ParameterName = name;
            this.Type = type;
        }

        [System.Diagnostics.DebuggerNonUserCode]
        public override T Visit<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
