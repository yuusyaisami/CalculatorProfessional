using System;

namespace CalculatorPro.Core
{
    internal sealed class ExpressionNormalizer
    {
        public string Normalize(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                return string.Empty;
            }

            // スペース削除
            var normalized = raw.Replace(" ", "").Replace("　", "");

            // 全角→半角
            normalized = normalized
                .Replace("＋", "+")
                .Replace("ー", "-")
                .Replace("・", "*")
                .Replace("÷", "/")
                .Replace("％", "%")
                .Replace("（", "(")
                .Replace("）", ")")
                .Replace("＝", "=")
                .Replace("π", "π") // πはすでに半角
                .Replace("Π", "π")
                .Replace("√", "√");

            // 関数名統一
            normalized = normalized
                .Replace("SIN", "sin")
                .Replace("Sin", "sin")
                .Replace("COS", "cos")
                .Replace("Cos", "cos")
                .Replace("TAN", "tan")
                .Replace("Tan", "tan")
                .Replace("ROOT", "root")
                .Replace("Root", "root");

            return normalized;
        }
    }
}