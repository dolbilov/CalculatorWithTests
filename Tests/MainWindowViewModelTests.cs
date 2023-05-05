using System.Collections;
using CalculatorBase.Interfaces;
using CalculatorBase.Models;
using CalculatorBase.ViewModels;

namespace Tests;

public class MainWindowViewModelTests
{
    private readonly MainWindowViewModel _vm = new();


    #region HasErrors

    [Fact]
    public void HasErrors_ShouldBeTrue_WhenDividerIsLessThanEpsilon()
    {
        _vm.FirstArgument = 1;
        _vm.SecondArgument = ICalculator.Epsilon / 10;
        _vm.SelectedOperation = Operation.Divide;

        _vm.HasErrors.Should().BeTrue();
    }

    [Theory]
    [InlineData(1.5, 3.4, Operation.Add)]
    [InlineData(1.2, 3.7, Operation.Subtract)]
    [InlineData(1, 8.9, Operation.Multiply)]
    [InlineData(1, 3.5, Operation.Divide)]
    public void HasErrors_ShouldBeFalse_WhenNumbersAndOperationAreValid(double firstArgument, double secondArgument, Operation operation)
    {
        _vm.FirstArgument = firstArgument;
        _vm.SecondArgument = secondArgument;
        _vm.SelectedOperation = operation;

        _vm.HasErrors.Should().BeFalse();
    }

    #endregion


    #region GetErrors

    [Fact]
    public void GetErrors_ShouldReturnNotEmptyCollection_WhenDividerIsLessThanEpsilon()
    {
        _vm.FirstArgument = 1;
        _vm.SecondArgument = ICalculator.Epsilon / 10;
        _vm.SelectedOperation = Operation.Divide;

        (_vm.GetErrors(nameof(_vm.Result)) as ICollection)?.Should().NotBe(0);
    }

    [Theory]
    [InlineData(1.5, 3.4, Operation.Add)]
    [InlineData(1.2, 3.7, Operation.Subtract)]
    [InlineData(1, 8.9, Operation.Multiply)]
    [InlineData(1, 3.5, Operation.Divide)]
    public void GetErrors_ShouldReturnEmptyCollection_WhenNumbersAndOperationAreValid(double firstArgument, double secondArgument, Operation operation)
    {
        _vm.FirstArgument = firstArgument;
        _vm.SecondArgument = secondArgument;
        _vm.SelectedOperation = operation;

        (_vm.GetErrors() as ICollection)?.Count.Should().Be(0);
    }

    #endregion


    #region Result

    [Fact]
    public void Result_ShouldBeNull_WhenDividerIsLessThanEpsilon()
    {
        _vm.FirstArgument = 1;
        _vm.SecondArgument = ICalculator.Epsilon / 10;
        _vm.SelectedOperation = Operation.Divide;

        _vm.Result.Should().BeNull();
    }

    [Theory]
    [InlineData(3, 4, "7")]
    [InlineData(3, -4, "-1")]
    [InlineData(-3, 4, "1")]
    [InlineData(-3, -4, "-7")]
    [InlineData(3.5, 4.2, "7.7")]
    [InlineData(3, 0, "3")]
    [InlineData(0, 4, "4")]
    [InlineData(0, 0, "0")]
    [InlineData(1.1234, 1.4321, "2.5555")]
    public void Result_ShouldBeExpected_WhenSumTwoNumbers(double firstArgument, double secondArgument, string expected)
    {
        _vm.FirstArgument = firstArgument;
        _vm.SecondArgument = secondArgument;
        _vm.SelectedOperation = Operation.Add;

        _vm.Result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(3, 4, "-1")]
    [InlineData(3, -4, "7")]
    [InlineData(-3, 4, "-7")]
    [InlineData(-3, -4, "1")]
    [InlineData(3.5, 4.2, "-0.7")]
    [InlineData(3, 0, "3")]
    [InlineData(0, 4, "-4")]
    [InlineData(0, 0, "0")]
    [InlineData(1.1234, 1.4321, "-0.3087")]
    public void Result_ShouldBeExpected_WhenSubtractTwoNumbers(double firstArgument, double secondArgument, string expected)
    {
        _vm.FirstArgument = firstArgument;
        _vm.SecondArgument = secondArgument;
        _vm.SelectedOperation = Operation.Subtract;

        _vm.Result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(3, 4, "12")]
    [InlineData(3, -4, "-12")]
    [InlineData(-3, 4, "-12")]
    [InlineData(-3, -4, "12")]
    [InlineData(3.5, 4.2, "14.7")]
    [InlineData(3, 0, "0")]
    [InlineData(0, 4, "0")]
    [InlineData(0, 0, "0")]
    [InlineData(1.1234, 1.4321, "1.6088")]
    public void Result_ShouldBeExpected_WhenMultiplyTwoNumbers(double firstArgument, double secondArgument, string expected)
    {
        _vm.FirstArgument = firstArgument;
        _vm.SecondArgument = secondArgument;
        _vm.SelectedOperation = Operation.Multiply;

        _vm.Result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(3, 4, "0.75")]
    [InlineData(3, -4, "-0.75")]
    [InlineData(-3, 4, "-0.75")]
    [InlineData(-3, -4, "0.75")]
    [InlineData(4, 3, "1.3333")]
    [InlineData(4, -3, "-1.3333")]
    [InlineData(-4, 3, "-1.3333")]
    [InlineData(-4, -3, "1.3333")]
    [InlineData(3.5, 4.2, "0.8333")]
    [InlineData(0, 4, "0")]
    [InlineData(1.1234, 1.4321, "0.7844")]
    [InlineData(0.1234, 0.5678, "0.2173")]
    public void Result_ShouldBeExpected_WhenDivideTwoNumbers(double firstArgument, double secondArgument, string expected)
    {
        _vm.FirstArgument = firstArgument;
        _vm.SecondArgument = secondArgument;
        _vm.SelectedOperation = Operation.Divide;

        _vm.Result.Should().Be(expected);
    }

    #endregion
    
}