namespace RpnCalculator.Core.Operators;

/// <summary>
/// 乘法
/// </summary>
public class Multiplication : OperatorBase
{
    public Multiplication(string value, int position) : base(value, position)
    {
        OperandCount = 2;
    }


    protected override decimal InternalEvaluate(List<Operand> operands)
    {
        return operands[1].NumberValue * operands[0].NumberValue;
    }
}