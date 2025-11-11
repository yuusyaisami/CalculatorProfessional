using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorPro.Core
{
    internal sealed class EquationSolver
    {
        private readonly ExpressionEvaluator _numericEvaluator;
        private readonly LinearEvaluator _linearEvaluator;

        public EquationSolver(ExpressionEvaluator numericEvaluator, LinearEvaluator linearEvaluator)
        {
            _numericEvaluator = numericEvaluator;
            _linearEvaluator = linearEvaluator;
        }

        public CalculatorResult SolveEquation(
            IReadOnlyList<Token> tokens,
            string normalizedExpression,
            CalculatorOptions options)
        {
            // = の位置を探す
            var eqIndices = tokens.Select((t, i) => new { Token = t, Index = i })
                                  .Where(x => x.Token.Kind == TokenKind.Equals)
                                  .Select(x => x.Index)
                                  .ToList();

            if (eqIndices.Count == 0)
            {
                return new CalculatorResult(
                    normalizedExpression,
                    normalizedExpression,
                    null,
                    Array.Empty<string>(),
                    "No equals sign found in equation.");
            }

            if (eqIndices.Count > 1)
            {
                return new CalculatorResult(
                    normalizedExpression,
                    normalizedExpression,
                    null,
                    Array.Empty<string>(),
                    "Multiple equals signs are not supported.");
            }

            int eqIndex = eqIndices[0];

            var leftTokens = tokens.Take(eqIndex).ToList();
            var rightTokens = tokens.Skip(eqIndex + 1).ToList();

            // 特殊パターン: sin(x) = c
            var specialResult = TrySolveSpecialEquation(leftTokens, rightTokens, options);
            if (specialResult != null)
            {
                return specialResult;
            }

            // 線形ソルバ
            var L = _linearEvaluator.EvaluateLinear(leftTokens, options.AngleUnit);
            var R = _linearEvaluator.EvaluateLinear(rightTokens, options.AngleUnit);

            if (!L.Valid || !R.Valid)
            {
                return new CalculatorResult(
                    normalizedExpression,
                    normalizedExpression,
                    null,
                    Array.Empty<string>(),
                    "This equation is not linear in x (unsupported form).");
            }

            double A = L.A - R.A;
            double B = L.B - R.B;

            if (A == 0)
            {
                if (B == 0)
                {
                    return new CalculatorResult(
                        normalizedExpression,
                        normalizedExpression,
                        null,
                        Array.Empty<string>(),
                        "Infinite number of solutions.");
                }
                else
                {
                    return new CalculatorResult(
                        normalizedExpression,
                        normalizedExpression,
                        null,
                        Array.Empty<string>(),
                        "No solution.");
                }
            }
            else
            {
                double x = -B / A;
                return new CalculatorResult(
                    normalizedExpression,
                    normalizedExpression,
                    x,
                    Array.Empty<string>(),
                    null);
            }
        }

        private CalculatorResult TrySolveSpecialEquation(List<Token> left, List<Token> right, CalculatorOptions options)
        {
            // sin(x) = c のパターン
            double? c = null;
            bool isSinXLeft = IsSinX(left);
            bool isSinXRight = IsSinX(right);

            if (isSinXLeft && !isSinXRight)
            {
                // 右辺を数値評価
                c = EvaluateConstant(right, options);
            }
            else if (!isSinXLeft && isSinXRight)
            {
                // 左辺を数値評価
                c = EvaluateConstant(left, options);
            }

            if (c.HasValue)
            {
                if (Math.Abs(c.Value) > 1.0)
                {
                    return new CalculatorResult(
                        "",
                        "",
                        null,
                        Array.Empty<string>(),
                        $"No solution for sin(x) = {c.Value}.");
                }

                double rad = Math.Asin(c.Value);
                double deg = rad * 180.0 / Math.PI;
                return new CalculatorResult(
                    "",
                    "",
                    deg,
                    Array.Empty<string>(),
                    null);
            }

            return null;
        }

        private bool IsSinX(List<Token> tokens)
        {
            // sin(x) または sinx のパターン
            if (tokens.Count == 4 &&
                tokens[0].Kind == TokenKind.Function && tokens[0].Text == "sin" &&
                tokens[1].Kind == TokenKind.LeftParen &&
                tokens[2].Kind == TokenKind.VariableX &&
                tokens[3].Kind == TokenKind.RightParen)
            {
                return true;
            }

            if (tokens.Count == 2 &&
                tokens[0].Kind == TokenKind.Function && tokens[0].Text == "sin" &&
                tokens[1].Kind == TokenKind.VariableX)
            {
                return true;
            }

            return false;
        }

        private double? EvaluateConstant(List<Token> tokens, CalculatorOptions options)
        {
            try
            {
                var result = _numericEvaluator.EvaluateTokens(tokens, "", options);
                return result.NumericResult;
            }
            catch
            {
                return null;
            }
        }
    }
}