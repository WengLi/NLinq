using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using NLinq.Parser.DbExpressions;
using NLinq.Parser.Translators;

namespace NLinq.Parser
{
    internal class ExpressionParser
    {
        private BindContext bindContext;
        private static readonly Dictionary<ExpressionType, Translator> _translators = InitializeTranslators();
        public AliasGenerator ParameterAliasGenerator;

        public ExpressionParser()
        {
            bindContext = new BindContext();
            ParameterAliasGenerator = new AliasGenerator("parameter");
        }

        private static Dictionary<ExpressionType, Translator> InitializeTranslators()
        {
            var translators = new Dictionary<ExpressionType, Translator>();
            foreach (var translator in GetTranslators())
            {
                foreach (var nodeType in translator.ExpressionTypes)
                {
                    translators.Add(nodeType, translator);
                }
            }

            return translators;
        }

        private static IEnumerable<Translator> GetTranslators()
        {
            yield return new ConstantTranslator();
            yield return new MemberAccessTranslator();
            yield return new MethodCallTranslator();
            yield return new NewTranslator();
            yield return new ParameterTranslator();
            yield return new QuoteTranslator();
            yield return new CompareTranslator();
        }

        internal DbExpression Parse(Expression expr)
        {
            if (!bindContext.TryGetDbExpression(expr, out DbExpression dbExpression))
            {
                if (_translators.TryGetValue(expr.NodeType, out Translator translator))
                {
                    dbExpression = translator.Translate(this, expr);
                }
                else
                {
                    throw new NotSupportedException(nameof(expr));
                }
            }
            return dbExpression;
        }

        internal DbExpression ParseLambda(LambdaExpression lamda)
        {
            foreach (var p in lamda.Parameters)
            {
                bindContext.Push(p, Parse(p));
            }

            var dbExpression = Parse(lamda.Body);

            foreach (var p in lamda.Parameters)
            {
                bindContext.Pop();
            }
            return dbExpression;
        }

        internal LambdaExpression GetLambdaExpression(Expression argument)
        {
            if (ExpressionType.Lambda == argument.NodeType)
            {
                return (LambdaExpression)argument;
            }
            else if (ExpressionType.Quote == argument.NodeType)
            {
                return GetLambdaExpression(((UnaryExpression)argument).Operand);
            }
            else if (ExpressionType.Call == argument.NodeType)
            {
                if (typeof(Expression).IsAssignableFrom(argument.Type))
                {
                    var expressionMethod = Expression.Lambda<Func<Expression>>(argument).Compile();

                    return GetLambdaExpression(expressionMethod.Invoke());
                }
            }
            else if (ExpressionType.Invoke == argument.NodeType)
            {
                if (typeof(Expression).IsAssignableFrom(argument.Type))
                {
                    var expressionMethod = Expression.Lambda<Func<Expression>>(argument).Compile();

                    return GetLambdaExpression(expressionMethod.Invoke());
                }
            }

            throw new InvalidOperationException();
        }
    }
}
