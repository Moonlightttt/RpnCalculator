using System.Globalization;
using RpnCalculator.Core.Exceptions;
using RpnCalculator.Core.Operators;

namespace RpnCalculator.Core;

/// <summary>
/// 计算器
/// </summary>
public class Calculator
{
    private Stack<Operand> _operandStack = new Stack<Operand>();

    /// <summary>
    /// 构造函数
    /// </summary>
    public Calculator()
    {
    }

    public string Evaluate(string input)
    {
        var inputData = input.Resolve();

        var breakable = false;

        foreach (var item in inputData)
        {
            switch (item)
            {
                case Operand operand:
                    _operandStack.Push(operand);
                    break;
                case Clear:
                    _operandStack.Clear();
                    breakable = true;
                    break;
                case Undo:

                    break;
                case OperatorBase @operator:
                    EvaluateValue(@operator);
                    break;
            }

            if (breakable)
            {
                break;
            }
        }

        return this.ToString();
    }

    public override string ToString()
    {
        return string.Join(" ", _operandStack.Select(x => x.ToString()).Reverse());
    }

    private void EvaluateValue(OperatorBase @operator)
    {
        var currentList = new List<Operand>();

        var operandCount = @operator.OperandCount;

        while (operandCount > 0)
        {
            if (_operandStack.TryPop(out var topOperand))
            {
                currentList.Add(topOperand);

                operandCount--;
            }
            else
            {
                break;
            }
        }

        try
        {
            var result = @operator.Evaluate(currentList);

            _operandStack.Push(new Operand(result));
        }
        catch (InsufficientException)
        {
            for (var i = currentList.Count - 1; i >= 0; i--)
            {
                _operandStack.Push(currentList[i]);
            }

            throw;
        }
    }
}