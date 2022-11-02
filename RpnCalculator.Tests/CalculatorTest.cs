using RpnCalculator.Core;
using RpnCalculator.Core.Exceptions;
using Shouldly;
using Xunit;

namespace RpnCalculator.Tests;

public class CalculatorTest
{
    [Fact]
    public void Test1()
    {
        var calculator = new Calculator();

        var result = calculator.Evaluate("1 2 +");

        result.ShouldBe("3");
    }

    [Fact]
    public void Test2()
    {
        var calculator = new Calculator();
        
        Should.Throw<InsufficientException>(() => { calculator.Evaluate("1 +"); },"1111");
    }
}