namespace RpnCalculator.Core.Operators;

/// <summary>
/// 加
/// </summary>
public class OpPlus : OperatorBase
{
    public OpPlus(string value) : this(value, 2)
    {
    }

    private OpPlus(string value, int operandCount) : base(value, operandCount)
    {
    }

    public override decimal Evaluate(List<Operand> operands)
    {
        return operands[1].NumberValue + operands[0].NumberValue;
    }
}