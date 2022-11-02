using RpnCalculator.Core.Exceptions;

namespace RpnCalculator.Core;

/// <summary>
/// 运算符基类
/// </summary>
public abstract class OperatorBase : OperateItem
{
    /// <summary>
    /// 原始数据
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// 运算符所需操作数的个数
    /// </summary>
    public int OperandCount { get; protected set; }

    /// <summary>
    /// 运算符位置
    /// </summary>
    public int Position { get; protected set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="value"></param>
    /// <param name="position"></param>
    protected OperatorBase(string value, int position)
    {
        Value = value;
        Position = position;
    }

    /// <summary>
    /// 执行计算
    /// </summary>
    /// <param name="operands"></param>
    /// <returns></returns>
    public decimal Evaluate(List<Operand> operands)
    {
        Validate(operands);

        return InternalEvaluate(operands);
    }

    /// <summary>
    /// 执行计算
    /// </summary>
    /// <param name="operands"></param>
    /// <returns></returns>
    protected abstract decimal InternalEvaluate(List<Operand> operands);

    /// <summary>
    /// 验证
    /// </summary>
    /// <param name="operands"></param>
    /// <returns></returns>
    protected virtual void Validate(List<Operand> operands)
    {
        if (operands.Count != OperandCount)
        {
            throw new InsufficientException(this);
        }
    }

    public override string ToString()
    {
        return Value;
    }
}