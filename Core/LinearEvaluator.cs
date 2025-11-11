using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorPro.Core
{
    internal struct Linear
    {
        public double A;    // x の係数
        public double B;    // 定数項
        public bool Valid;  // 線形でない場合 false

        public Linear(double a, double b, bool valid = true)
        {
            A = a;
            B = b;
            Valid = valid;
        }
    }

    internal sealed class LinearEvaluator
    {
        private readonly ExpressionEvaluator _numericEvaluator;

        public LinearEvaluator(ExpressionEvaluator numericEvaluator)
        {
            _numericEvaluator = numericEvaluator;
        }

        public Linear EvaluateLinear(IReadOnlyList<Token> tokens, AngleUnit angleUnit)
        {
            var workTokens = new List<Token>(tokens);
            StripOuterParentheses(workTokens);

            while (workTokens.Count > 1)
            {
                int index = FindHighestPriorityIndex(workTokens);
                if (index == -1)
                {
                    return new Linear(0, 0, false); // エラー
                }

                ApplyOperation(workTokens, index, angleUnit);
            }

            if (workTokens.Count == 1)
            {
                return FromToken(workTokens[0]);
            }

            return new Linear(0, 0, false);
        }

        private Linear FromToken(Token t)
        {
            if (t.LinearValue.HasValue)
            {
                return t.LinearValue.Value;
            }

            switch (t.Kind)
            {
                case TokenKind.Number:
                    return new Linear(0.0, t.NumberValue ?? 0.0, true);
                case TokenKind.VariableX:
                    return new Linear(1.0, 0.0, true);
                default:
                    return new Linear(0, 0, false);
            }
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
                    continue;
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
                    return 5;
                case TokenKind.Function:
                    return 4;
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
            if (index >= tokens.Count - 1 || (tokens[index + 1].Kind != TokenKind.Number && tokens[index + 1].Kind != TokenKind.VariableX))
            {
                throw new Exception("Invalid unary operator usage.");
            }

            var value = FromToken(tokens[index + 1]);
            if (tokens[index].Kind == TokenKind.UnaryMinus)
            {
                value.A = -value.A;
                value.B = -value.B;
            }

            tokens[index + 1] = new Token(TokenKind.Number, value.ToString(), value.B, value);
            tokens.RemoveAt(index);
        }

        private void ApplyBinary(List<Token> tokens, int index)
        {
            if (index <= 0 || index >= tokens.Count - 1)
            {
                throw new Exception("Invalid binary operator position.");
            }

            var left = FromToken(tokens[index - 1]);
            var right = FromToken(tokens[index + 1]);

            Linear result;
            switch (tokens[index].Kind)
            {
                case TokenKind.Plus:
                    result = new Linear(left.A + right.A, left.B + right.B, left.Valid && right.Valid);
                    break;
                case TokenKind.Minus:
                    result = new Linear(left.A - right.A, left.B - right.B, left.Valid && right.Valid);
                    break;
                case TokenKind.Multiply:
                    if (left.A != 0 && right.A != 0)
                    {
                        result = new Linear(0, 0, false); // x^2
                    }
                    else
                    {
                        result = new Linear(left.A * right.B + right.A * left.B, left.B * right.B, left.Valid && right.Valid);
                    }
                    break;
                case TokenKind.Divide:
                    if (right.A != 0)
                    {
                        result = new Linear(0, 0, false); // 分母に x
                    }
                    else if (right.B == 0)
                    {
                        throw new Exception("Division by zero.");
                    }
                    else
                    {
                        result = new Linear(left.A / right.B, left.B / right.B, left.Valid && right.Valid);
                    }
                    break;
                case TokenKind.Power:
                    if (left.A != 0 || right.A != 0)
                    {
                        result = new Linear(0, 0, false); // 非線形
                    }
                    else
                    {
                        result = new Linear(0, Math.Pow(left.B, right.B), left.Valid && right.Valid);
                    }
                    break;
                case TokenKind.Percent:
                    if (left.A != 0 || right.A != 0)
                    {
                        result = new Linear(0, 0, false);
                    }
                    else if (right.B == 0)
                    {
                        throw new Exception("Modulo by zero.");
                    }
                    else
                    {
                        result = new Linear(0, left.B % right.B, left.Valid && right.Valid);
                    }
                    break;
                default:
                    throw new Exception("Unknown binary operator.");
            }

            tokens[index - 1] = new Token(TokenKind.Number, result.ToString(), result.B, result);
            tokens.RemoveRange(index, 2);
        }

        private void ApplyFunction(List<Token> tokens, int funcIndex, AngleUnit angleUnit)
        {
            int argStart, argEnd;
            FindFunctionArgumentRange(tokens, funcIndex, out argStart, out argEnd);

            var argLinear = EvaluateLinear(tokens.GetRange(argStart, argEnd - argStart + 1), angleUnit);
            if (!argLinear.Valid || argLinear.A != 0)
            {
                // 引数に x が含まれる → 非線形
                var invalidResult = new Linear(0, 0, false);
                tokens[funcIndex] = new Token(TokenKind.Number, "0", 0, invalidResult);
                tokens.RemoveRange(funcIndex + 1, argEnd - funcIndex);
                return;
            }

            // 引数が定数 → 数値評価
            double argValue = argLinear.B;
            double resultValue;
            string name = tokens[funcIndex].Text;

            switch (name)
            {
                case "sin":
                    resultValue = Math.Sin(angleUnit == AngleUnit.Degree ? argValue * Math.PI / 180.0 : argValue);
                    break;
                case "cos":
                    resultValue = Math.Cos(angleUnit == AngleUnit.Degree ? argValue * Math.PI / 180.0 : argValue);
                    break;
                case "tan":
                    resultValue = Math.Tan(angleUnit == AngleUnit.Degree ? argValue * Math.PI / 180.0 : argValue);
                    break;
                case "√":
                case "root":
                    if (argValue < 0.0) throw new Exception("Square root of negative value.");
                    resultValue = Math.Sqrt(argValue);
                    break;
                default:
                    throw new Exception($"Unknown function: {name}");
            }

            var result = new Linear(0, resultValue, true);
            tokens[funcIndex] = new Token(TokenKind.Number, resultValue.ToString(), resultValue, result);
            tokens.RemoveRange(funcIndex + 1, argEnd - funcIndex);
        }

        private void FindFunctionArgumentRange(List<Token> tokens, int funcIndex, out int argStart, out int argEnd)
        {
            argStart = funcIndex + 1;
            if (argStart >= tokens.Count)
            {
                throw new Exception("Missing function argument.");
            }

            var first = tokens[argStart];

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

            argEnd = ScanPrimary(tokens, argStart);
        }

        private int ScanPrimary(List<Token> tokens, int startIndex)
        {
            if (startIndex >= tokens.Count)
                throw new Exception("Missing expression.");

            var kind = tokens[startIndex].Kind;

            if (kind == TokenKind.UnaryMinus || kind == TokenKind.UnaryPlus)
            {
                if (startIndex + 1 >= tokens.Count)
                    throw new Exception("Invalid unary expression.");
                return ScanPrimary(tokens, startIndex + 1);
            }

            if (kind == TokenKind.Number || kind == TokenKind.VariableX)
            {
                return startIndex;
            }

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

            if (kind == TokenKind.Function)
            {
                int argStart, argEnd;
                FindFunctionArgumentRange(tokens, startIndex, out argStart, out argEnd);
                return argEnd;
            }

            throw new Exception($"Unexpected token in expression: {tokens[startIndex].Text}");
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

                        if (depth == 0 && i < tokens.Count - 1)
                        {
                            isMatching = false;
                            break;
                        }
                    }

                    if (isMatching && depth == 0)
                    {
                        tokens.RemoveAt(tokens.Count - 1);
                        tokens.RemoveAt(0);
                        changed = true;
                    }
                }

            } while (changed);
        }
    }
}