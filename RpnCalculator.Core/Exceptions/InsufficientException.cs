namespace RpnCalculator.Core.Exceptions;

public class InsufficientException : Exception
{
    private OperatorBase Operator { get; set; }

    public InsufficientException(OperatorBase @operator)
    {
        Operator = @operator;
    }

    public override string ToString()
    {
        return $"operator {Operator.ToString()} (position: {Operator.Position}): insufficient parameters";
    }
}