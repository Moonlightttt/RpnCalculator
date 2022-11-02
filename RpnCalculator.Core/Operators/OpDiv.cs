namespace RpnCalculator.Core.Operators;

/// <summary>
/// 除
/// </summary>
public class OpDiv : OperatorBase
{
    public OpDiv(string value) : this(value, 2)
    {
    }

    private OpDiv(string value, int operandCount) : base(value, operandCount)
    {
    }
    
    
    public override decimal Evaluate(List<Operand> operands)
    {
        return operands[1].NumberValue / operands[0].NumberValue;
    }
}