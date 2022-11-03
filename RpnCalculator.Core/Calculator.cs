using System.Globalization;
using RpnCalculator.Core.Commands;
using RpnCalculator.Core.Exceptions;
using RpnCalculator.Core.Operators;

namespace RpnCalculator.Core;

/// <summary>
/// 计算器
/// </summary>
public class Calculator
{
    private Stack<OperateNumber> _operandStack = new Stack<OperateNumber>();
    private Stack<ICommand> _undoStack = new Stack<ICommand>();

    /// <summary>
    /// 构造函数
    /// </summary>
    public Calculator()
    {
    }

    public string Evaluate(string input)
    {
        var inputData = input.Resolve();

        foreach (var item in inputData)
        {
            switch (item)
            {
                case NumberCommand number:
                    _operandStack.Push(number);
                    _undoStack.Push(number);
                    break;
                case ClearCommand:
                    _operandStack.Clear();
                    _undoStack.Clear();
                    break;
                case UndoCommand:

                    break;
                case IComputeCommand compute:
                    compute.Execute(this);
                    break;
            }
        }

        return this.ToString();
    }

    public void CommandExecute(int operateCount, Func<List<OperateNumber>, decimal> func)
    {
        var currentList = new List<OperateNumber>();

        while (operateCount > 0)
        {
            if (_operandStack.TryPop(out var topOperand))
            {
                currentList.Add(topOperand);

                operateCount--;
            }
            else
            {
                break;
            }
        }

        try
        {
            var result = func(currentList);

            _operandStack.Push(new OperateNumber(result));
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

    public override string ToString()
    {
        return string.Join(" ", _operandStack.Select(x => x.ToString()).Reverse());
    }
}