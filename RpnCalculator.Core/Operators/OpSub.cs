namespace RpnCalculator.Core.Operators;

/// <summary>
/// 减
/// </summary>
public class OpSub : OperatorBase
{
    public OpSub(string value) : this(value, 2)
    {
    }

    private OpSub(string value, int operandCount) : base(value, operandCount)
    {
    }
    
    
    public override decimal Evaluate(params Operand[] operand)
    {
        throw new NotImplementedException();
    }
}