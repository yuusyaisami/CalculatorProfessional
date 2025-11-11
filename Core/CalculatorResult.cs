using System.Collections.Generic;

namespace CalculatorPro.Core
{
    public sealed class CalculatorResult
    {
        public string InputExpression { get; }
        public string NormalizedExpression { get; }
        public double? NumericResult { get; }
        public IReadOnlyList<string> Steps { get; }
        public bool HasError => ErrorMessage != null;
        public string ErrorMessage { get; }

        public CalculatorResult(
            string inputExpression,
            string normalizedExpression,
            double? numericResult,
            IReadOnlyList<string> steps,
            string errorMessage)
        {
            InputExpression = inputExpression;
            NormalizedExpression = normalizedExpression;
            NumericResult = numericResult;
            Steps = steps ?? new List<string>();
            ErrorMessage = errorMessage;
        }
    }
}