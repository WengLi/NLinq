using NLinq.DataType;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.DbExpressions
{
    public class DbParameterExpression : DbExpression
    {
        public string Name { get; set; }

        public DbParameterExpression(string name, BaseType type)
            : base(DbExpressionKind.Parameter, type)
        {
            this.Name = name;
        }
    }
}
