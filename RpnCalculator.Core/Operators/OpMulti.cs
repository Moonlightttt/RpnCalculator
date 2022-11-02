namespace RpnCalculator.Core.Operators;

/// <summary>
/// 乘
/// </summary>
public class OpMulti : OperatorBase
{
    public OpMulti(string value) : this(value, 2)
    {
    }

    private OpMulti(string value, int operandCount) : base(value, operandCount)
    {
    }
    
    
    public override decimal Evaluate(List<Operand> operands)
    {
        return operands[1].NumberValue * operands[0].NumberValue;
    }
}