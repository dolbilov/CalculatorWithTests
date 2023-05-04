namespace CalculatorBase.Interfaces;

public interface ICalculator
{
    public const double Epsilon = 1e-6;
    
    public double Add(double a, double b);
    public double Subtract(double a, double b);
    public double Multiply(double a, double b);
    public double Divide(double a, double b);
}