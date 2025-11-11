using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorPro.Core
{
    internal sealed class ExpressionEvaluator
    {
        public CalculatorResult EvaluateTokens(
            IReadOnlyList<Token> originalTokens,
            string normalizedExpression,
            CalculatorOptions options)
        {
            var tokens = new List<Token>(originalTokens);
            var steps = new List<string>();

            // ★ 外側だけを囲っている括弧を剥がす
            StripOuterParentheses(tokens);

            while (tokens.Count > 1)
            {
                if (options.CaptureSteps)
                {
                    steps.Add(string.Join("", tokens.Select(t => t.Text)));
                }

                int index = FindHighestPriorityIndex(tokens);
                if (index == -1)
                {
                    return new CalculatorResult(
                        normalizedExpression,
                        normalizedExpression,
                        null,
                        steps,
                        "Calculation error: No operator found.");
                }

                ApplyOperation(tokens, index, options.AngleUnit);
            }

            if (tokens.Count == 1 && tokens[0].Kind == TokenKind.Number)
            {
                return new CalculatorResult(
                    normalizedExpression,
                    normalizedExpression,
                    tokens[0].NumberValue,
                    steps,
                    null);
            }

            return new CalculatorResult(
                normalizedExpression,
                normalizedExpression,
                null,
                steps,
                "Calculation error: Result is not a number.");
        }

        private int FindHighestPriorityIndex(List<Token> tokens)
        {
            int maxPriority = -1;
            int index = -1;
            int parenDepth = 0;

            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                if (token.Kind == TokenKind.LeftParen)
                {
                    parenDepth++;
                    continue;
                }

                if (token.Kind == TokenKind.RightParen)
                {
                    parenDepth--;
                    continue;
                }

                int basePriority = GetPriority(token.Kind);
                if (basePriority <= 0)
                {
                    continue; // 数値など
                }

                int priority = basePriority + parenDepth * 10;
                if (priority > maxPriority)
                {
                    maxPriority = priority;
                    index = i;
                }
            }

            return index;
        }

        private int GetPriority(TokenKind kind)
        {
            switch (kind)
            {
                case TokenKind.UnaryPlus:
                case TokenKind.UnaryMinus:
                    return 5; // 符号
                case TokenKind.Function:
                    return 4; // sin,cos,tan,√
                case TokenKind.Power:
                    return 3;
                case TokenKind.Multiply:
                case TokenKind.Divide:
                case TokenKind.Percent:
                    return 2;
                case TokenKind.Plus:
                case TokenKind.Minus:
                    return 1;
                default:
                    return 0;
            }
        }

        private void ApplyOperation(List<Token> tokens, int index, AngleUnit angleUnit)
        {
            var token = tokens[index];

            switch (token.Kind)
            {
                case TokenKind.Function:
                    ApplyFunction(tokens, index, angleUnit);
                    break;

                case TokenKind.UnaryPlus:
                case TokenKind.UnaryMinus:
                    ApplyUnary(tokens, index);
                    break;

                case TokenKind.Plus:
                case TokenKind.Minus:
                case TokenKind.Multiply:
                case TokenKind.Divide:
                case TokenKind.Power:
                case TokenKind.Percent:
                    ApplyBinary(tokens, index);
                    break;

                default:
                    throw new Exception($"Unexpected token '{token.Text}' at operator position.");
            }
        }

        private void ApplyUnary(List<Token> tokens, int index)
        {
            if (index >= tokens.Count - 1 || tokens[index + 1].Kind != TokenKind.Number)
            {
                throw new Exception("Invalid unary operator usage.");
            }

            double value = tokens[index + 1].NumberValue ?? 0.0;
            if (tokens[index].Kind == TokenKind.UnaryMinus)
            {
                value = -value;
            }

            tokens[index + 1] = new Token(TokenKind.Number, value.ToString(), value);
            tokens.RemoveAt(index);
        }

        private void ApplyBinary(List<Token> tokens, int index)
        {
            if (index <= 0 || index >= tokens.Count - 1)
            {
                throw new Exception("Invalid binary operator position.");
            }

            if (tokens[index - 1].Kind != TokenKind.Number || tokens[index + 1].Kind != TokenKind.Number)
            {
                throw new Exception("Invalid binary operator operands.");
            }

            double left = tokens[index - 1].NumberValue ?? 0.0;
            double right = tokens[index + 1].NumberValue ?? 0.0;
            double result;

            switch (tokens[index].Kind)
            {
                case TokenKind.Plus:
                    result = left + right;
                    break;
                case TokenKind.Minus:
                    result = left - right;
                    break;
                case TokenKind.Multiply:
                    result = left * right;
                    break;
                case TokenKind.Divide:
                    if (right == 0.0) throw new Exception("Division by zero.");
                    result = left / right;
                    break;
                case TokenKind.Power:
                    result = Math.Pow(left, right);
                    break;
                case TokenKind.Percent:
                    if (right == 0.0) throw new Exception("Modulo by zero.");
                    result = left % right;
                    break;
                default:
                    throw new Exception("Unknown binary operator.");
            }

            tokens[index - 1] = new Token(TokenKind.Number, result.ToString(), result);
            tokens.RemoveRange(index, 2);
        }

        private void ApplyFunction(List<Token> tokens, int funcIndex, AngleUnit angleUnit)
        {
            int argStart, argEnd;
            FindFunctionArgumentRange(tokens, funcIndex, out argStart, out argEnd);

            double argValue = EvaluateSubExpression(tokens, argStart, argEnd, angleUnit);

            double result;
            string name = tokens[funcIndex].Text;

            switch (name)
            {
                case "sin":
                    result = Math.Sin(angleUnit == AngleUnit.Degree ? argValue * Math.PI / 180.0 : argValue);
                    break;
                case "cos":
                    result = Math.Cos(angleUnit == AngleUnit.Degree ? argValue * Math.PI / 180.0 : argValue);
                    break;
                case "tan":
                    result = Math.Tan(angleUnit == AngleUnit.Degree ? argValue * Math.PI / 180.0 : argValue);
                    break;
                case "√":
                case "root":
                    if (argValue < 0.0) throw new Exception("Square root of negative value.");
                    result = Math.Sqrt(argValue);
                    break;
                default:
                    throw new Exception($"Unknown function: {name}");
            }

            var resultToken = new Token(TokenKind.Number, result.ToString(), result);
            int removeCount = argEnd - funcIndex;
            tokens[funcIndex] = resultToken;
            tokens.RemoveRange(funcIndex + 1, removeCount);
        }

        /// <summary>
        /// funcIndex で示される関数トークンの右側にある「引数」の範囲 [argStart,argEnd] を求める。
        /// 明示的括弧があれば ( ... ) 全体、それ以外は primary ひとつ分。
        /// </summary>
        private void FindFunctionArgumentRange(List<Token> tokens, int funcIndex, out int argStart, out int argEnd)
        {
            argStart = funcIndex + 1;
            if (argStart >= tokens.Count)
            {
                throw new Exception("Missing function argument.");
            }

            var first = tokens[argStart];

            // sin( ... )
            if (first.Kind == TokenKind.LeftParen)
            {
                int depth = 1;
                for (int i = argStart + 1; i < tokens.Count; i++)
                {
                    if (tokens[i].Kind == TokenKind.LeftParen) depth++;
                    else if (tokens[i].Kind == TokenKind.RightParen) depth--;
                    if (depth == 0)
                    {
                        argEnd = i;
                        return;
                    }
                }
                throw new Exception("Missing closing parenthesis for function argument.");
            }

            // sin30, sin-5, sinπ/2 など → primary ひとつ分を引数にする
            argEnd = ScanPrimary(tokens, argStart);
        }

        /// <summary>
        /// startIndex から始まる「1つの primary」
        ///   - 数値 / 変数
        ///   - 符号付き数値（UnaryPlus/UnaryMinus + Number）
        ///   - 括弧式 ( ... )
        ///   - 関数呼び出し（再帰的に）
        /// の終端インデックスを返す。
        /// </summary>
        private int ScanPrimary(List<Token> tokens, int startIndex)
        {
            if (startIndex >= tokens.Count)
                throw new Exception("Missing expression.");

            var kind = tokens[startIndex].Kind;

            // -5, +5
            if (kind == TokenKind.UnaryMinus || kind == TokenKind.UnaryPlus)
            {
                if (startIndex + 1 >= tokens.Count)
                    throw new Exception("Invalid unary expression.");

                // 符号 + 後ろの primary 全体が1つの primary
                return ScanPrimary(tokens, startIndex + 1);
            }

            // 数値 / 変数
            if (kind == TokenKind.Number || kind == TokenKind.VariableX)
            {
                return startIndex;
            }

            // 括弧式 ( ... )
            if (kind == TokenKind.LeftParen)
            {
                int depth = 1;
                for (int i = startIndex + 1; i < tokens.Count; i++)
                {
                    if (tokens[i].Kind == TokenKind.LeftParen) depth++;
                    else if (tokens[i].Kind == TokenKind.RightParen) depth--;
                    if (depth == 0)
                        return i;
                }
                throw new Exception("Unmatched parenthesis.");
            }

            // sin30, cos(1+2) など、関数呼び出し全体を primary として扱う
            if (kind == TokenKind.Function)
            {
                int argStart, argEnd;
                FindFunctionArgumentRange(tokens, startIndex, out argStart, out argEnd);
                return argEnd;
            }

            throw new Exception($"Unexpected token in expression: {tokens[startIndex].Text}");
        }

        private double EvaluateSubExpression(List<Token> tokens, int start, int end, AngleUnit angleUnit)
        {
            var slice = new List<Token>();
            for (int i = start; i <= end; i++)
            {
                slice.Add(tokens[i]);
            }

            var opts = new CalculatorOptions
            {
                RoundResult = false,
                RoundDigits = 0,
                CaptureSteps = false,
                AngleUnit = angleUnit
            };

            var exprText = string.Concat(slice.Select(t => t.Text));
            var result = EvaluateTokens(slice, exprText, opts);
            if (result.NumericResult == null)
            {
                throw new Exception(result.ErrorMessage ?? "Invalid function argument.");
            }

            return result.NumericResult.Value;
        }

        private void StripOuterParentheses(List<Token> tokens)
        {
            bool changed;
            do
            {
                changed = false;

                if (tokens.Count >= 2 &&
                    tokens[0].Kind == TokenKind.LeftParen &&
                    tokens[tokens.Count - 1].Kind == TokenKind.RightParen)
                {
                    int depth = 0;
                    bool isMatching = true;

                    for (int i = 0; i < tokens.Count; i++)
                    {
                        if (tokens[i].Kind == TokenKind.LeftParen)
                        {
                            depth++;
                        }
                        else if (tokens[i].Kind == TokenKind.RightParen)
                        {
                            depth--;
                        }

                        // 最初の '(' に対応する ')' が末尾より前に来たら
                        // 「全体を囲っている括弧ではない」ので剥がさない
                        if (depth == 0 && i < tokens.Count - 1)
                        {
                            isMatching = false;
                            break;
                        }
                    }

                    // depth==0 かつ最後まで崩れなければ、外側が丸ごと 1 ペア
                    if (isMatching && depth == 0)
                    {
                        // 先頭 '(' と末尾 ')' を削除
                        tokens.RemoveAt(tokens.Count - 1);
                        tokens.RemoveAt(0);
                        changed = true;
                    }
                }

            } while (changed);
        }
    }
}