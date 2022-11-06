using RpnCalculator.Core;
using RpnCalculator.Core.Exceptions;
using Shouldly;
using Xunit;

namespace RpnCalculator.Tests;

public class CalculatorTest
{
    [Theory(DisplayName = "加法计算")]
    [InlineData("1 2 +", "buffer: 3")]
    [InlineData("1 2 + 3 4 +", "buffer: 3 7")]
    [InlineData("1 2 + 3 + 4 +", "buffer: 10")]
    [InlineData("-1 2 +", "buffer: 1")]
    [InlineData("-1 2 + 3 -4 +", "buffer: 1 -1")]
    [InlineData("-1 2 + 3 + -4 +", "buffer: 0")]
    [InlineData("-1 -2 +", "buffer: -3")]
    [InlineData("-1 -2 + -3 -4 +", "buffer: -3 -7")]
    [InlineData("-1 -2 + -3 + -4 +", "buffer: -10")]
    [InlineData("0 0 +", "buffer: 0")]
    [InlineData("-1 0 +", "buffer: -1")]
    [InlineData("1 0 +", "buffer: 1")]
    public void AdditionShouldSuccess(string input, string output)
    {
        var calculator = new Calculator();

        var result = calculator.Evaluate(input);

        result.ShouldBe(output);
    }

    [Theory(DisplayName = "减法计算")]
    [InlineData("1 2 -", "buffer: -1")]
    [InlineData("1 2 - 3 4 -", "buffer: -1 -1")]
    [InlineData("1 2 - 3 - 4 -", "buffer: -8")]
    [InlineData("-1 2 -", "buffer: -3")]
    [InlineData("-1 2 - 3 -4 -", "buffer: -3 7")]
    [InlineData("-1 2 - 3 - -4 -", "buffer: -2")]
    [InlineData("-1 -2 -", "buffer: 1")]
    [InlineData("-1 -2 - -3 -4 -", "buffer: 1 1")]
    [InlineData("-1 -2 - -3 - -4 -", "buffer: 8")]
    [InlineData("0 0 -", "buffer: 0")]
    [InlineData("-1 0 -", "buffer: -1")]
    [InlineData("1 0 -", "buffer: 1")]
    public void SubtractionShouldSuccess(string input, string output)
    {
        var calculator = new Calculator();

        var result = calculator.Evaluate(input);

        result.ShouldBe(output);
    }

    [Theory(DisplayName = "乘法计算")]
    [InlineData("1 2 *", "buffer: 2")]
    [InlineData("1 2 * 3 4 *", "buffer: 2 12")]
    [InlineData("1 2 * 3 * 4 *", "buffer: 24")]
    [InlineData("-1 2 *", "buffer: -2")]
    [InlineData("-1 2 * 3 -4 *", "buffer: -2 -12")]
    [InlineData("-1 2 * 3 * -4 *", "buffer: 24")]
    [InlineData("-1 -2 *", "buffer: 2")]
    [InlineData("-1 -2 * -3 -4 *", "buffer: 2 12")]
    [InlineData("-1 -2 * -3 * -4 *", "buffer: 24")]
    [InlineData("0 0 *", "buffer: 0")]
    [InlineData("-1 0 *", "buffer: 0")]
    [InlineData("1 0 *", "buffer: 0")]
    public void MultiplicationShouldSuccess(string input, string output)
    {
        var calculator = new Calculator();

        var result = calculator.Evaluate(input);

        result.ShouldBe(output);
    }

    [Theory(DisplayName = "除法计算")]
    [InlineData("1 2 /", "buffer: 0.5")]
    [InlineData("1 2 / 3 4 /", "buffer: 0.5 0.75")]
    [InlineData("1 2 / 3 / 4 /", "buffer: 0.0416666667")]
    [InlineData("-1 2 /", "buffer: -0.5")]
    [InlineData("-1 2 / 3 -4 /", "buffer: -0.5 -0.75")]
    [InlineData("-1 2 / 3 / -4 /", "buffer: 0.0416666667")]
    [InlineData("-1 -2 /", "buffer: 0.5")]
    [InlineData("-1 -2 / -3 -4 /", "buffer: 0.5 0.75")]
    [InlineData("-1 -2 / -3 / -4 /", "buffer: 0.0416666667")]
    [InlineData("0 -1 /", "buffer: 0")]
    [InlineData("0 1 /", "buffer: 0")]
    public void DivisionShouldSuccess(string input, string output)
    {
        var calculator = new Calculator();

        var result = calculator.Evaluate(input);

        result.ShouldBe(output);
    }

    [Fact(DisplayName = "操作数不足")]
    public void OperatorShouldShowInsufficient()
    {
        var calculator = new Calculator();

        var result = calculator.Evaluate("1 +");

        result.ShouldBe($"operator + (position: 1): insufficient parameters{Environment.NewLine}buffer: 1");
    }

    [Theory(DisplayName = "样例验证")]
    [InlineData("1 2", "buffer: 1 2")]
    [InlineData("4 2 3 5 4 + - * /", "buffer: -0.3333333333")]
    [InlineData("3 4 2 * 3 + 1 -", "buffer: 3 10")]
    [InlineData("6 3 1 + 5 * undo + ", "buffer: 10")]
    [InlineData("3 4 + clear 1", "buffer: 1")]
    [InlineData("2 3 undo", "buffer: 2")]
    public void SampleInputOutputTest(string input, string output)
    {
        var calculator = new Calculator();

        var result = calculator.Evaluate(input);

        result.ShouldBe(output);
    }

    [Fact(DisplayName = "连续输入")]
    public void ContinuousInputShouldSuccess()
    {
        var calculator = new Calculator();

        var result = calculator.Evaluate("6 5 4 3");

        result.ShouldBe("buffer: 6 5 4 3");

        result = calculator.Evaluate("undo undo *");

        result.ShouldBe("buffer: 30");

        result = calculator.Evaluate("10 *");

        result.ShouldBe("buffer: 300");

        result = calculator.Evaluate("undo");

        result.ShouldBe("buffer: 30");
    }
    
    [Fact(DisplayName = "连续输入2")]
    public void ContinuousInput2ShouldSuccess()
    {
        var calculator = new Calculator();

        var result = calculator.Evaluate("1 2 3 4 5");
        
        result.ShouldBe("buffer: 1 2 3 4 5");

        result = calculator.Evaluate("+");
        
        result.ShouldBe("buffer: 1 2 3 9");

        result = calculator.Evaluate("+");
        
        result.ShouldBe("buffer: 1 2 12");
        
        result = calculator.Evaluate("+");
        
        result.ShouldBe("buffer: 1 14");
        
        result = calculator.Evaluate("undo");

        result.ShouldBe("buffer: 1 2");
        
        result = calculator.Evaluate("undo");

        result.ShouldBe("buffer: 1");
    }

    [Theory(DisplayName = "清理")]
    [InlineData("1 2 clear", "buffer: ")]
    [InlineData("1 2 clear 3 4", "buffer: 3 4")]
    public void ClearShouldSuccess(string input, string output)
    {
        var calculator = new Calculator();

        var result = calculator.Evaluate(input);

        result.ShouldBe(output);
    }

    [Theory(DisplayName = "撤销")]
    [InlineData("1 2 undo", "buffer: 1")]
    [InlineData("1 2 undo 3 4", "buffer: 1 3 4")]
    [InlineData("1 2 * undo", "buffer: 1")]
    [InlineData("1 2 * undo 3 4 undo", "buffer: 1 3")]
    [InlineData("1 2 3 4 5 6 7 + - * / undo", "buffer: 1 2 3")]
    public void UndoShouldSuccess(string input, string output)
    {
        var calculator = new Calculator();

        var result = calculator.Evaluate(input);

        result.ShouldBe(output);
    }

    [Fact(DisplayName = "算术溢出")]
    public void ArithmeticOverflowShouldFail()
    {
        var calculator = new Calculator();

        var result = calculator.Evaluate($"{decimal.MaxValue} {decimal.MaxValue} *");

        result.ShouldBe($"Value was either too large or too small for a Decimal.{Environment.NewLine}buffer: {decimal.MaxValue} {decimal.MaxValue}");
    }

    [Fact(DisplayName = "除以零")]
    public void DivisionZeroShouldFail()
    {
        var calculator = new Calculator();

        var result=calculator.Evaluate("1 0 /");
        
        result.ShouldBe($"Attempted to divide by zero.{Environment.NewLine}buffer: 1 0");
    }

    [Fact(DisplayName = "预期外字符")]
    public void UnexpectedStringShouldFail()
    {
        var calculator = new Calculator();

        var result=calculator.Evaluate("1 0 / a");
        
        result.ShouldBe($"unexpected string: a{Environment.NewLine}buffer: ");
        
        result=calculator.Evaluate("clear 1 2 / 888-");
        
        result.ShouldBe($"unexpected string: 888-{Environment.NewLine}buffer: ");
    }
}