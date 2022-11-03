using RpnCalculator.Core.Commands;
using RpnCalculator.Core.Exceptions;

namespace RpnCalculator.Core;

/// <summary>
/// 计算器
/// </summary>
public class Calculator
{
    private Stack<OperateNumber> _operandStack = new Stack<OperateNumber>();
    private Stack<IComputeCommand> _undoStack = new Stack<IComputeCommand>();

    /// <summary>
    /// 构造函数
    /// </summary>
    public Calculator()
    {
    }

    public string Evaluate(string input)
    {
        var inputData = input.Resolve();

        foreach (var command in inputData)
        {
            command.Execute(this);
        }

        return this.ToString();
    }

    public void CommandExecute(IComputeCommand command, int operateCount, Func<List<OperateNumber>, decimal> func)
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

            _undoStack.Push(command);
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

    public void SetNumber(NumberCommand number)
    {
        _operandStack.Push(number);
        _undoStack.Push(number);
    }

    public void Clear()
    {
        _operandStack.Clear();
        _undoStack.Clear();
    }

    public void Undo()
    {
        if (_undoStack.TryPop(out var topCommand))
        {
            topCommand.Undo(this);
        }
    }

    public void Undo(List<OperateNumber> data)
    {
        _operandStack.Pop();

        if (data.Count > 0)
        {
            _operandStack.Push(data.Last());
        }
    }

    public override string ToString()
    {
        return string.Join(" ", _operandStack.Select(x => x.ToString()).Reverse());
    }
}