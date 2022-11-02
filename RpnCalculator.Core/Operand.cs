namespace RpnCalculator.Core;

/// <summary>
/// 操作数
/// </summary>
public class Operand : OperateItem
{
    /// <summary>
    /// 数据值
    /// </summary>
    public decimal NumberValue { get; }

    public Operand(string value) : base(value)
    {
        NumberValue = decimal.TryParse(value, out var result)
            ? result
            : throw new ArgumentException("unexpected string");
    }
}