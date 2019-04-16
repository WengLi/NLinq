namespace NLinq.DbExpressions
{
    public class DbExpressionBinding
    {
        public DbProjectExpression Expression { get; set; }

        public DbParameterExpression Parameter { get; set; }

        public DbExpressionBinding(DbProjectExpression e, DbParameterExpression p)
        {
            this.Expression = e;
            this.Parameter = p;
        }
    }
}