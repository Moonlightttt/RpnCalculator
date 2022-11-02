namespace RpnCalculator.Core;

/// <summary>
/// 运算符基类
/// </summary>
public abstract class OperatorBase : OperateItem
{
    /// <summary>
    /// 运算符所需操作数的个数
    /// </summary>
    public int OperandCount { get; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="value"></param>
    /// <param name="operandCount"></param>
    protected OperatorBase(string value, int operandCount = 0) : base(value)
    {
        OperandCount = operandCount;
    }

    /// <summary>
    /// 执行计算
    /// </summary>
    /// <param name="operand"></param>
    /// <returns></returns>
    public abstract decimal Evaluate(params Operand[] operand);
}