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
    
    
    public override decimal Evaluate(params Operand[] operand)
    {
        throw new NotImplementedException();
    }
}