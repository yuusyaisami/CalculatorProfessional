namespace CalculatorPro.Core
{
    public interface ICalculatorEngine
    {
        CalculatorResult Evaluate(string input, CalculatorOptions options);
    }
}