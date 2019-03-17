using System;
using System.Collections.Generic;
using System.Text;
using NLinq.Parser.DbExpressions;

namespace NLinq.Sql
{
    public class SqlGenerator : DbExpressionVisitor<ISqlPart>
    {
        public string Generate(DbExpression expression)
        {
            return expression.Visit(this).ToString();
        }

        public override ISqlPart Visit(DbAndAlsoExpression dbExpression)
        {
            throw new NotImplementedException();
        }

        public override ISqlPart Visit(DbCompareExpression dbExpression)
        {
            throw new NotImplementedException();
        }

        public override ISqlPart Visit(DbConstantExpression dbExpression)
        {
            throw new NotImplementedException();
        }

        public override ISqlPart Visit(DbEntitySetExpression dbExpression)
        {
            throw new NotImplementedException();
        }

        public override ISqlPart Visit(DbMemberExpression dbExpression)
        {
            throw new NotImplementedException();
        }

        public override ISqlPart Visit(DbNewExpression dbExpression)
        {
            throw new NotImplementedException();
        }

        public override ISqlPart Visit(DbOrElseExpression dbExpression)
        {
            throw new NotImplementedException();
        }

        public override ISqlPart Visit(DbParameterExpression dbExpression)
        {
            throw new NotImplementedException();
        }

        public override ISqlPart Visit(DbReferenceExpression dbExpression)
        {
            throw new NotImplementedException();
        }

        public override ISqlPart Visit(DbSelectExpression dbExpression)
        {
            throw new NotImplementedException();
        }

        public override ISqlPart Visit(DbWhereExpression dbExpression)
        {
            throw new NotImplementedException();
        }
    }
}
