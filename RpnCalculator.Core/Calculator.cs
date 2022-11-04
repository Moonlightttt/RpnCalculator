using RpnCalculator.Core.Commands;
using RpnCalculator.Core.Exceptions;

namespace RpnCalculator.Core;

/// <summary>
/// 计算器
/// </summary>
public class Calculator
{
    private Stack<OperateNumber> _dataStack = new Stack<OperateNumber>();
    private Stack<IComputeCommand> _undoStack = new Stack<IComputeCommand>();

    /// <summary>
    /// 构造函数
    /// </summary>
    public Calculator()
    {
    }

    public string Evaluate(string input)
    {
        try
        {
            var inputData = input.Resolve();

            foreach (var command in inputData)
            {
                command.Execute(this);
            }

            return $"buffer: {this}";
        }
        catch (InsufficientException e)
        {
            return $"{e}{Environment.NewLine}buffer: {this}";
        }
        catch (UnexpectedException e)
        {
            return $"{e}{Environment.NewLine}buffer: {this}";
        }
    }

    /// <summary>
    /// 执行计算命令
    /// </summary>
    /// <param name="command"></param>
    /// <param name="requiredOperands"></param>
    /// <param name="func"></param>
    public void CommandExecute(IComputeCommand command, int requiredOperands, Func<Stack<OperateNumber>, decimal> func)
    {
        var evaluationStack = GetEvaluationStack(requiredOperands);

        try
        {
            var result = func(evaluationStack);

            _dataStack.Push(new OperateNumber(result));

            _undoStack.Push(command);
        }
        catch (InsufficientException)
        {
            while (evaluationStack.TryPop(out var topNumber))
            {
                _dataStack.Push(topNumber);
            }

            throw;
        }
    }

    /// <summary>
    /// 获取当前计算栈
    /// </summary>
    /// <param name="requiredOperands"></param>
    /// <returns></returns>
    private Stack<OperateNumber> GetEvaluationStack(int requiredOperands)
    {
        var evaluationStack = new Stack<OperateNumber>();

        while (requiredOperands > 0)
        {
            if (_dataStack.TryPop(out var topOperand))
            {
                evaluationStack.Push(topOperand);

                requiredOperands--;
            }
            else
            {
                break;
            }
        }

        return evaluationStack;
    }

    /// <summary>
    /// 设置数据
    /// </summary>
    /// <param name="number"></param>
    public void SetNumber(NumberCommand number)
    {
        _dataStack.Push(number);
        _undoStack.Push(number);
    }

    /// <summary>
    /// 执行清理命令
    /// </summary>
    public void Clear()
    {
        _dataStack.Clear();
        _undoStack.Clear();
    }

    /// <summary>
    /// 执行撤销命令
    /// </summary>
    public void Undo()
    {
        if (_undoStack.TryPop(out var topCommand))
        {
            topCommand.Undo(this);
        }
    }

    /// <summary>
    /// 处理撤销逻辑
    /// </summary>
    /// <param name="store"></param>
    public void Undo(List<OperateNumber> store)
    {
        _dataStack.Pop();

        if (store.Count > 0)
        {
            _dataStack.Push(store.First());
        }
    }

    /// <summary>
    /// 获取当前数据的字符串表示
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return string.Join(" ", _dataStack.Select(x => x.ToString()).Reverse());
    }
}