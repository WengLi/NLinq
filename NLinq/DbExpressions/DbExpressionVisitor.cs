using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.DbExpressions
{
    public abstract class DbExpressionVisitor<TResult>
    {
        public abstract TResult Visit(DbAndAlsoExpression expression);
        public abstract TResult Visit(DbColumnExpression expression);
        public abstract TResult Visit(DbCompareExpression expression);
        public abstract TResult Visit(DbConstantExpression expression);
        public abstract TResult Visit(DbGroupByExpression expression);
        public abstract TResult Visit(DbMemberExpression expression);
        public abstract TResult Visit(DbNewExpression expression);
        public abstract TResult Visit(DbOrderByExpression expression);
        public abstract TResult Visit(DbOrElseExpression expression);
        public abstract TResult Visit(DbParameterExpression expression);
        public abstract TResult Visit(DbSelectExpression expression);
        public abstract TResult Visit(DbTableExpression expression);
        public abstract TResult Visit(DbWhereExpression expression);
    }
}
