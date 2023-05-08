using CalculatorBase.Interfaces;
using CalculatorBase.Models;

namespace Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator = new();

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(1, -2, -1)]
    [InlineData(-1, 3, 2)]
    [InlineData(-1, -2, -3)]
    [InlineData(-1, 0, -1)]
    [InlineData(0, 1, 1)]
    [InlineData(0, -1, -1)]
    [InlineData(1, 0, 1)]
    [InlineData(0, 0, 0)]
    public void Add_ShouldReturnExpected(double a, double b, double expected)
    {
        var result = _calculator.Add(a, b);

        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(1, 2, -1)]
    [InlineData(1, -2, 3)]
    [InlineData(-1, 3, -4)]
    [InlineData(-1, -2, 1)]
    [InlineData(1, 0, 1)]
    [InlineData(-1, 0, -1)]
    [InlineData(0, -1, 1)]
    [InlineData(0, 1, -1)]
    [InlineData(0, 0, 0)]
    public void Subtract_ShouldReturnExpected(double a, double b, double expected)
    {
        var result = _calculator.Subtract(a, b);

        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(1, -2, -2)]
    [InlineData(-1, 3, -3)]
    [InlineData(-1, -2, 2)]
    [InlineData(1, 0, 0)]
    [InlineData(-1, 0, 0)]
    [InlineData(0, -1, 0)]
    [InlineData(0, 1, 0)]
    [InlineData(0, 0, 0)]
    public void Multiply_ShouldReturnExpected(double a, double b, double expected)
    {
        var result = _calculator.Multiply(a, b);

        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(1, 2, 0.5)]
    [InlineData(2, 1, 2)]
    [InlineData(1, 3, 0.333333)]
    [InlineData(2.67, 1.35, 1.97777778)]
    [InlineData(-2.56, 1, -2.56)]
    [InlineData(2.78, -7.89, -0.35234474)]
    public void Divide_ShouldReturnExpected(double a, double b, double expected)
    {
        var result = _calculator.Divide(a, b);

        result.Should().BeApproximately(expected, 1e-4);
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(1.5, 0)]
    [InlineData(0, 0)]
    [InlineData(1, ICalculator.Epsilon / 10)]
    [InlineData(1.5, ICalculator.Epsilon / 10)]
    [InlineData(-1, 0)]
    [InlineData(-1, ICalculator.Epsilon / 10)]
    public void Divide_ShouldThrowException_WhenDividerLessThanEpsilon(double a, double b)
    {
        var act = () => _calculator.Divide(a, b);

        act.Should().ThrowExactly<DivideByZeroException>();
    }
}