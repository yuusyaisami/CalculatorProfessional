using System;
using System.Collections.Generic;

namespace CalculatorPro.Core
{
    internal sealed class ExpressionTokenizer
    {
        public List<Token> Tokenize(string normalized)
        {
            var tokens = new List<Token>();
            int i = 0;
            Token lastToken = null;

            while (i < normalized.Length)
            {
                char c = normalized[i];

                if (char.IsDigit(c) || c == '.')
                {
                    int start = i;
                    while (i < normalized.Length && (char.IsDigit(normalized[i]) || normalized[i] == '.'))
                    {
                        i++;
                    }
                    string numStr = normalized.Substring(start, i - start);
                    if (!double.TryParse(numStr, out double val))
                    {
                        throw new Exception($"Invalid number: {numStr}");
                    }

                    var t = new Token(TokenKind.Number, numStr, val);
                    tokens.Add(t);
                    lastToken = t;
                }
                else if (c == '+')
                {
                    bool isUnary = IsUnaryPosition(lastToken);
                    var kind = isUnary ? TokenKind.UnaryPlus : TokenKind.Plus;
                    var t = new Token(kind, "+");
                    tokens.Add(t);
                    lastToken = t;
                    i++;
                }
                else if (c == '-')
                {
                    bool isUnary = IsUnaryPosition(lastToken);
                    var kind = isUnary ? TokenKind.UnaryMinus : TokenKind.Minus;
                    var t = new Token(kind, "-");
                    tokens.Add(t);
                    lastToken = t;
                    i++;
                }
                else if (c == '*')
                {
                    var t = new Token(TokenKind.Multiply, "*");
                    tokens.Add(t);
                    lastToken = t;
                    i++;
                }
                else if (c == '/')
                {
                    var t = new Token(TokenKind.Divide, "/");
                    tokens.Add(t);
                    lastToken = t;
                    i++;
                }
                else if (c == '%')
                {
                    var t = new Token(TokenKind.Percent, "%");
                    tokens.Add(t);
                    lastToken = t;
                    i++;
                }
                else if (c == '^')
                {
                    var t = new Token(TokenKind.Power, "^");
                    tokens.Add(t);
                    lastToken = t;
                    i++;
                }
                else if (c == '(')
                {
                    var t = new Token(TokenKind.LeftParen, "(");
                    tokens.Add(t);
                    lastToken = t;
                    i++;
                }
                else if (c == ')')
                {
                    var t = new Token(TokenKind.RightParen, ")");
                    tokens.Add(t);
                    lastToken = t;
                    i++;
                }
                else if (c == '=')
                {
                    var t = new Token(TokenKind.Equals, "=");
                    tokens.Add(t);
                    lastToken = t;
                    i++;
                }
                else if (c == 'π')
                {
                    // π は Number 扱い（Text だけ "π" にしておけば表示もそれっぽい）
                    var t = new Token(TokenKind.Number, "π", Math.PI);
                    tokens.Add(t);
                    lastToken = t;
                    i++;
                }
                else if (c == 'x' || c == 'X')
                {
                    var t = new Token(TokenKind.VariableX, "x");
                    tokens.Add(t);
                    lastToken = t;
                    i++;
                }
                else if (i + 3 <= normalized.Length && normalized.Substring(i, 3) == "sin")
                {
                    var t = new Token(TokenKind.Function, "sin");
                    tokens.Add(t);
                    lastToken = t;
                    i += 3;
                }
                else if (i + 3 <= normalized.Length && normalized.Substring(i, 3) == "cos")
                {
                    var t = new Token(TokenKind.Function, "cos");
                    tokens.Add(t);
                    lastToken = t;
                    i += 3;
                }
                else if (i + 3 <= normalized.Length && normalized.Substring(i, 3) == "tan")
                {
                    var t = new Token(TokenKind.Function, "tan");
                    tokens.Add(t);
                    lastToken = t;
                    i += 3;
                }
                else if (c == '√')
                {
                    var t = new Token(TokenKind.Function, "√");
                    tokens.Add(t);
                    lastToken = t;
                    i++;
                }
                else if (i + 4 <= normalized.Length && normalized.Substring(i, 4) == "root")
                {
                    var t = new Token(TokenKind.Function, "root");
                    tokens.Add(t);
                    lastToken = t;
                    i += 4;
                }
                else
                {
                    throw new Exception($"Invalid character: {c} at position {i}");
                }
            }

            InsertImplicitMultiplications(tokens);

            return tokens;
        }

        private static bool IsUnaryPosition(Token lastToken)
        {
            // 先頭 / 演算子 / 左括弧 / 関数 の直後に現れる + / - は単項とみなす
            if (lastToken == null) return true;

            switch (lastToken.Kind)
            {
                case TokenKind.Plus:
                case TokenKind.Minus:
                case TokenKind.UnaryPlus:
                case TokenKind.UnaryMinus:
                case TokenKind.Multiply:
                case TokenKind.Divide:
                case TokenKind.Percent:
                case TokenKind.Power:
                case TokenKind.LeftParen:
                case TokenKind.Equals:
                case TokenKind.Function:
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsValueLike(TokenKind kind)
        {
            return kind == TokenKind.Number ||
                   kind == TokenKind.VariableX ||
                   kind == TokenKind.RightParen;
        }

        private static bool IsValueLikeOrFuncOrLeftParen(TokenKind kind)
        {
            return kind == TokenKind.Number ||
                   kind == TokenKind.VariableX ||
                   kind == TokenKind.LeftParen ||
                   kind == TokenKind.Function;
        }

        private void InsertImplicitMultiplications(List<Token> tokens)
        {
            for (int j = 0; j < tokens.Count - 1; j++)
            {
                var current = tokens[j];
                var next = tokens[j + 1];

                // 2π, 2x, (1+2)sin30 など → 暗黙の *
                if (IsValueLike(current.Kind) && IsValueLikeOrFuncOrLeftParen(next.Kind))
                {
                    tokens.Insert(j + 1, new Token(TokenKind.Multiply, "*"));
                    j++; // 挿入した分をスキップ
                }
            }
        }
    }
}