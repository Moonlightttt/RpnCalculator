namespace RpnCalculator.Core.Operators;

/// <summary>
/// 除法
/// </summary>
public class Division : OperatorBase
{
    public Division(string value, int position) : base(value, position)
    {
        OperandCount = 2;
    }

    protected override decimal InternalEvaluate(List<Operand> operands)
    {
        return operands[1].NumberValue / operands[0].NumberValue;
    }
}