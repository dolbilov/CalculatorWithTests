using System;
using CalculatorBase.Interfaces;

namespace CalculatorBase.Models;

public class Calculator : ICalculator
{
    public const double Epsilon = 1e-6;
    public static readonly string InvalidDividerValueMessage =
        $"Absolute value of divider can't be less than {Epsilon:g2}";
    
    public double Add(double a, double b) => a + b;

    public double Subtract(double a, double b) => a - b;

    public double Multiply(double a, double b) => a * b;

    public double Divide(double a, double b)
    {
        if (Math.Abs(b) < Epsilon)
            throw new DivideByZeroException(InvalidDividerValueMessage);

        return a / b;
    }
}