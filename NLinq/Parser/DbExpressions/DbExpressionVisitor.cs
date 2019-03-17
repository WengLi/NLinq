using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.DbExpressions
{
    public abstract class DbExpressionVisitor<T>
    {
        public abstract T Visit(DbAndAlsoExpression dbExpression);
        public abstract T Visit(DbCompareExpression dbExpression);
        public abstract T Visit(DbConstantExpression dbExpression);
        public abstract T Visit(DbEntitySetExpression dbExpression);
        public abstract T Visit(DbMemberExpression dbExpression);
        public abstract T Visit(DbNewExpression dbExpression);
        public abstract T Visit(DbOrElseExpression dbExpression);
        public abstract T Visit(DbParameterExpression dbExpression);
        public abstract T Visit(DbReferenceExpression dbExpression);
        public abstract T Visit(DbSelectExpression dbExpression);
        public abstract T Visit(DbWhereExpression dbExpression);
    }
}
