namespace RpnCalculator.Core.Exceptions;

public class InsufficientException : Exception
{
    private OperateSymbol Operator { get; set; }

    public InsufficientException(OperateSymbol @operator)
    {
        Operator = @operator;
    }

    public override string ToString()
    {
        return $"operator {Operator.ToString()} (position: {Operator.Position}): insufficient parameters";
    }
}