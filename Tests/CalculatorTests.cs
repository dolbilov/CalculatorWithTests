using CalculatorBase.Models;

namespace Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator;
    
    public CalculatorTests()
    {
        _calculator = new Calculator();
    }
    
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
    
    // TODO: finish tests for division
}