using NLinq.Parser.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public class DbNewExpression : DbExpression
    {
        public NewExpression Expression;
        public ReadOnlyCollection<DbExpression> Members;

        public DbNewExpression(IList<DbExpression> expressions, NewExpression expression, RowType type)
            : base(DbExpressionKind.New, type)
        {
            Members = new ReadOnlyCollection<DbExpression>(expressions);
            this.Expression = expression;
        }

        [System.Diagnostics.DebuggerNonUserCode]
        public override T Visit<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
