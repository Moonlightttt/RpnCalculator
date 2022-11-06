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
    private int _undoNumberCount = 0;

    /// <summary>
    /// 构造函数
    /// </summary>
    public Calculator()
    {
    }

    /// <summary>
    /// 解析字符串并计算
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
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
        catch (Exception e) when (e is InsufficientException or UnexpectedException)
        {
            return $"{e}{Environment.NewLine}buffer: {this}";
        }
        catch (Exception e) when (e is ArithmeticException)
        {
            return $"{e.Message}{Environment.NewLine}buffer: {this}";
        }
    }

    /// <summary>
    /// 执行计算命令
    /// </summary>
    /// <param name="command"></param>
    /// <param name="requiredOperands"></param>
    /// <param name="func"></param>
    public void CommandExecute(IComputeCommand command, int requiredOperands, Func<List<OperateNumber>, decimal> func)
    {
        var evaluationOperands = GetEvaluationOperands(requiredOperands);

        try
        {
            var result = func(evaluationOperands);

            _dataStack.Push(new OperateNumber(result));

            _undoStack.Push(command);
        }
        catch (Exception e) when (e is InsufficientException or ArithmeticException)
        {
            for (var i = evaluationOperands.Count - 1; i >= 0; i--)
            {
                _dataStack.Push(evaluationOperands[i]);
            }

            throw;
        }
    }

    /// <summary>
    /// 获取当前操作数
    /// </summary>
    /// <param name="requiredOperands"></param>
    /// <returns></returns>
    private List<OperateNumber> GetEvaluationOperands(int requiredOperands)
    {
        var evaluationOperands = new List<OperateNumber>();

        while (requiredOperands > 0)
        {
            if (_dataStack.TryPop(out var topOperand))
            {
                evaluationOperands.Add(topOperand);

                requiredOperands--;
            }
            else
            {
                break;
            }
        }

        return evaluationOperands;
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

            if (topCommand is not NumberCommand)
            {
                var os = topCommand as OperateSymbol;
                _undoNumberCount += (os!.RequiredOperands - 1);

                this.Undo();
            }
            else
            {
                _undoNumberCount--;
                
                if (_undoNumberCount <= 0)
                {
                    return;
                }

                this.Undo();
            }
        }
    }


    /// <summary>
    /// 重置撤销计数器
    /// </summary>
    public void ResetUndoCount()
    {
        _undoNumberCount = 0;
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
            for (int i = store.Count - 1; i >= 0; i--)
            {
                _dataStack.Push(store[i]);
            }
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