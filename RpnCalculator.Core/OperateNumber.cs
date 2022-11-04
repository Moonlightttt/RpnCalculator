using RpnCalculator.Core.Exceptions;

namespace RpnCalculator.Core;

/// <summary>
/// 操作数
/// </summary>
public class OperateNumber
{
    /// <summary>
    /// 数据值
    /// </summary>
    public decimal Value { get; }

    protected OperateNumber(string value)
    {
        Value = decimal.TryParse(value, out var result)
            ? result
            : throw new UnexpectedException(value);
    }

    public OperateNumber(decimal value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return $"{Value:0.##########}";
    }
}