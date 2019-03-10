using System;
using System.Collections.Generic;
using System.Text;
using NLinq.Parser.DbExpressions;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;

namespace NLinq.Parser.Translators
{
    internal abstract class Translator
    {
        public ExpressionType[] ExpressionTypes;

        public Translator(params ExpressionType[] expressionTypes)
        {
            this.ExpressionTypes = expressionTypes;
        }

        public abstract DbExpression Translate(ExpressionParser parser, Expression expr);
    }

    internal abstract class Translator<T>: Translator where T : Expression
    {
        public Translator(params ExpressionType[] expressionTypes) : base(expressionTypes) { }

        public override DbExpression Translate(ExpressionParser parser, Expression expr)
        {
            return TypeTranslate(parser, (T)expr);
        }

        public abstract DbExpression TypeTranslate(ExpressionParser parser, T expr);
    }

    internal class AndAlsoTranslator : Translator<BinaryExpression>
    {
        public AndAlsoTranslator() : base(ExpressionType.AndAlso) { }

        public override DbExpression TypeTranslate(ExpressionParser parser, BinaryExpression expr)
        {
            DbExpression left = parser.Parse(expr.Left);
            DbExpression right = parser.Parse(expr.Right);
            return new DbAndAlsoExpression(left, right);
        }
    }

    internal class ConstantTranslator : Translator<ConstantExpression>
    {
        public ConstantTranslator() : base(ExpressionType.Constant) { }

        public override DbExpression TypeTranslate(ExpressionParser parser, ConstantExpression expr)
        {
            ObjectQuery objectQuery = expr.Value as ObjectQuery;
            if (objectQuery != null)
            {
                if (WorkSpace.EntitySetCache.TryGetValue(objectQuery.ElementType, out EntitySet entitySet))
                {
                    return new DbEntitySetExpression(entitySet);
                }
                throw new NotSupportedException();
            }
            else
            {
                return new DbConstantExpression(expr.Value);
            }
        }
    }

    internal class MemberAccessTranslator : Translator<MemberExpression>
    {
        public MemberAccessTranslator() : base(ExpressionType.MemberAccess) { }

        public override DbExpression TypeTranslate(ExpressionParser parser, MemberExpression expr)
        {
            if (WorkSpace.EntitySetCache.TryGetValue(expr.Expression.Type, out EntitySet entitySet))
            {
                var property = entitySet.EntityProperties.Find(o => o.PropertyInfo == expr.Member);
                return new DbMemberExpression(property);
            }
            throw new Exception();
        }
    }

    internal class MethodCallTranslator : Translator<MethodCallExpression>
    {
        public MethodCallTranslator() : base(ExpressionType.Call) { }

        private static readonly Dictionary<MethodKind, MethodTranslator> _translators = InitializeTranslators();

        private static Dictionary<MethodKind, MethodTranslator> InitializeTranslators()
        {
            var translators = new Dictionary<MethodKind, MethodTranslator>();
            foreach (var translator in GetTranslators())
            {
                foreach (var kind in translator.MethodKinds)
                {
                    translators.Add(kind, translator);
                }
            }

            return translators;
        }

        private static IEnumerable<MethodTranslator> GetTranslators()
        {
            yield return new SelectMethodTranslator();
            yield return new WhereMethodTranslator();
        }

        private MethodKind GetMethodKind(MethodInfo method)
        {
            return (MethodKind)Enum.Parse(typeof(MethodKind), method.Name);
        }

        public override DbExpression TypeTranslate(ExpressionParser parser, MethodCallExpression expr)
        {
            if (_translators.TryGetValue(GetMethodKind(expr.Method), out MethodTranslator translator))
            {
                return translator.Translate(parser, expr);
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }

    internal class NewTranslator : Translator<NewExpression>
    {
        public NewTranslator() : base(ExpressionType.New) { }

        public override DbExpression TypeTranslate(ExpressionParser parser, NewExpression expr)
        {
            List<DbExpression> expressions = expr.Arguments.Select(o => parser.Parse(o)).ToList();
            return new DbNewExpression(expressions, expr);
        }
    }

    internal class OrElseTranslator : Translator<BinaryExpression>
    {
        public OrElseTranslator() : base(ExpressionType.OrElse) { }

        public override DbExpression TypeTranslate(ExpressionParser parser, BinaryExpression expr)
        {
            DbExpression left = parser.Parse(expr.Left);
            DbExpression right = parser.Parse(expr.Right);
            return new DbOrElseExpression(left, right);
        }
    }

    internal class ParameterTranslator : Translator<ParameterExpression>
    {
        public ParameterTranslator() : base(ExpressionType.Parameter) { }

        public override DbExpression TypeTranslate(ExpressionParser parser, ParameterExpression expr)
        {
            return new DbParameterExpression(parser.ParameterAliasGenerator.GetName(), expr.Type);
        }
    }

    internal class QuoteTranslator : Translator<UnaryExpression>
    {
        public QuoteTranslator() : base(ExpressionType.Quote) { }

        public override DbExpression TypeTranslate(ExpressionParser parser, UnaryExpression expr)
        {
            return parser.Parse(expr.Operand);
        }
    }

    internal class CompareTranslator : Translator<BinaryExpression>
    {
        public CompareTranslator()
            : base(ExpressionType.Equal, ExpressionType.NotEqual,
                  ExpressionType.GreaterThan, ExpressionType.GreaterThanOrEqual,
                  ExpressionType.LessThan, ExpressionType.LessThanOrEqual)
        {
        }

        public override DbExpression TypeTranslate(ExpressionParser parser, BinaryExpression expr)
        {
            DbExpression left = parser.Parse(expr.Left);
            DbExpression right = parser.Parse(expr.Right);
            DbExpressionKind kind;
            switch (expr.NodeType)
            {
                case ExpressionType.Equal: kind = DbExpressionKind.Equal;break;
                case ExpressionType.NotEqual:kind = DbExpressionKind.NotEqual;break;
                case ExpressionType.GreaterThan:kind=DbExpressionKind.GreaterThan;break;
                case ExpressionType.GreaterThanOrEqual:kind = DbExpressionKind.GreaterThanOrEqual;break;
                case ExpressionType.LessThan: kind = DbExpressionKind.LessThan;break;
                default: throw new NotSupportedException();
            }
            return new DbCompareExpression(left, right, kind);
        }
    }
}
