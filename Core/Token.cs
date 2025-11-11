namespace CalculatorPro.Core
{
    internal sealed class Token
    {
        public TokenKind Kind { get; }
        public string Text { get; }
        public double? NumberValue { get; }
        public Linear? LinearValue { get; }

        public Token(TokenKind kind, string text, double? numberValue = null, Linear? linearValue = null)
        {
            Kind = kind;
            Text = text;
            NumberValue = numberValue;
            LinearValue = linearValue;
        }
    }
}