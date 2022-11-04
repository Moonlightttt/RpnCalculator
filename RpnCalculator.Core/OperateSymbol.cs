using RpnCalculator.Core.Commands;
using RpnCalculator.Core.Exceptions;

namespace RpnCalculator.Core;

/// <summary>
/// 运算符基类
/// </summary>
public abstract class OperateSymbol : IComputeCommand
{
    /// <summary>
    /// 运算符
    /// </summary>
    private string Value { get; }

    /// <summary>
    /// 运算符所需操作数的个数
    /// </summary>
    protected int RequiredOperands { get; set; }

    /// <summary>
    /// 运算符位置
    /// </summary>
    public int Position { get; }

    /// <summary>
    /// 撤销记录
    /// </summary>
    private List<OperateNumber> UndoStore { get; set; } = new();

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="value"></param>
    /// <param name="position"></param>
    protected OperateSymbol(string value, int position)
    {
        Value = value;
        Position = position;
    }

    /// <summary>
    /// 通用计算逻辑
    /// </summary>
    /// <param name="operands"></param>
    /// <returns></returns>
    private decimal CommonEvaluate(List<OperateNumber> operands)
    {
        Validate(operands);

        UndoStore = operands;

        return ImplementedEvaluate(operands);
    }

    /// <summary>
    /// 计算实现
    /// </summary>
    /// <param name="operands"></param>
    /// <returns></returns>
    protected abstract decimal ImplementedEvaluate(List<OperateNumber> operands);

    /// <summary>
    /// 验证
    /// </summary>
    /// <param name="stack"></param>
    /// <returns></returns>
    protected virtual void Validate(List<OperateNumber> stack)
    {
        if (stack.Count != RequiredOperands)
        {
            throw new InsufficientException(this);
        }
    }

    /// <summary>
    /// 执行命令
    /// </summary>
    /// <param name="calculator"></param>
    public void Execute(Calculator calculator)
    {
        calculator.CommandExecute(this, RequiredOperands, CommonEvaluate);
    }

    /// <summary>
    /// 执行撤销命令
    /// </summary>
    /// <param name="calculator"></param>
    public void Undo(Calculator calculator)
    {
        calculator.Undo(UndoStore);
    }

    public override string ToString()
    {
        return Value;
    }
}