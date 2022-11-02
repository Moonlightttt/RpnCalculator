namespace RpnCalculator.Core.Operators;

/// <summary>
/// 减法
/// </summary>
public class Subtraction : OperatorBase
{
    public Subtraction(string value, int position) : base(value, position)
    {
        OperandCount = 2;
    }


    protected override decimal InternalEvaluate(List<Operand> operands)
    {
        return operands[1].NumberValue - operands[0].NumberValue;
    }
}