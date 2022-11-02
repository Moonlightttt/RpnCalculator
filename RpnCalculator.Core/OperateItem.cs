namespace RpnCalculator.Core;

/// <summary>
/// 操作项
/// </summary>
public abstract class OperateItem
{
    /// <summary>
    /// 原始数据
    /// </summary>
    public string Value { get; }

    protected OperateItem(string value)
    {
        Value = value;
    }
}