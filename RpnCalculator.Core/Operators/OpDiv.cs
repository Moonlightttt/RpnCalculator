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
    
    
    public override decimal Evaluate(params Operand[] operand)
    {
        throw new NotImplementedException();
    }
}