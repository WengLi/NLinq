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
            yield return new LambdaTranslator();
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
    }
}
