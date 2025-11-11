using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorPro.Core
{
    public sealed class CalculatorEngine : ICalculatorEngine
    {
        private readonly ExpressionNormalizer _normalizer = new ExpressionNormalizer();
        private readonly ExpressionTokenizer _tokenizer = new ExpressionTokenizer();
        private readonly ExpressionEvaluator _evaluator = new ExpressionEvaluator();
        private readonly LinearEvaluator _linearEvaluator;
        private readonly EquationSolver _equationSolver;

        public CalculatorEngine()
        {
            _linearEvaluator = new LinearEvaluator(_evaluator);
            _equationSolver = new EquationSolver(_evaluator, _linearEvaluator);
        }

        public CalculatorResult Evaluate(string input, CalculatorOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            // 1. 正規化
            var normalized = _normalizer.Normalize(input);
            if (string.IsNullOrEmpty(normalized))
            {
                return new CalculatorResult(
                    input,
                    normalized,
                    null,
                    Array.Empty<string>(),
                    "Expression is empty.");
            }

            // 2. トークン化
            List<Token> tokens;
            try
            {
                tokens = _tokenizer.Tokenize(normalized);
            }
            catch (Exception ex)
            {
                return new CalculatorResult(input, normalized, null, Array.Empty<string>(), ex.Message);
            }

            // 3. 方程式か数式か判定
            bool hasEquals = tokens.Any(t => t.Kind == TokenKind.Equals);
            bool hasVariable = tokens.Any(t => t.Kind == TokenKind.VariableX);

            if (hasEquals)
            {
                // 方程式モード
                return _equationSolver.SolveEquation(tokens, normalized, options);
            }
            else if (hasVariable)
            {
                // x があっても = がない → エラー
                return new CalculatorResult(
                    input,
                    normalized,
                    null,
                    Array.Empty<string>(),
                    "Variable x found but no equals sign. Use x = ... for equations.");
            }
            else
            {
                // 通常の数式モード
                return _evaluator.EvaluateTokens(tokens, normalized, options);
            }
        }
    }
}