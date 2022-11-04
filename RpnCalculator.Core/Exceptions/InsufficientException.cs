namespace RpnCalculator.Core.Exceptions;

/// <summary>
/// 操作数不足异常
/// </summary>
public class InsufficientException : Exception
{
    private OperateSymbol Operator { get; }

    public InsufficientException(OperateSymbol @operator)
    {
        Operator = @operator;
    }

    public override string ToString()
    {
        return $"operator {Operator.ToString()} (position: {Operator.Position}): insufficient parameters";
    }
}