using System;

namespace CalculatorPro.Core
{
    public enum AngleUnit
    {
        Degree,
        Radian
    }

    public sealed class CalculatorOptions
    {
        public bool RoundResult { get; set; }
        public int RoundDigits { get; set; } = 2;
        public bool CaptureSteps { get; set; } = true;
        public AngleUnit AngleUnit { get; set; } = AngleUnit.Degree;
    }
}