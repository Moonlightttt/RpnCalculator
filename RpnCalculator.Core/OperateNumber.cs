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
        if (value.EndsWith("+") || value.EndsWith("-"))
        {
            throw new UnexpectedException(value);
        }

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