using System;
using CalculatorBase.Interfaces;

namespace CalculatorBase.Models;

public class Calculator : ICalculator
{
    public double Add(double a, double b) => a + b;

    public double Subtract(double a, double b) => a - b;

    public double Multiply(double a, double b) => a * b;

    public double Divide(double a, double b)
    {
        if (Math.Abs(b) < ICalculator.Epsilon)
            throw new DivideByZeroException("|divider| can't be less then 10^6");

        return a / b;
    }
}