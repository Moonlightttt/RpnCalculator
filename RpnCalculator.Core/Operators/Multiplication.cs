namespace RpnCalculator.Core.Operators;

/// <summary>
/// 乘法
/// </summary>
public class Multiplication : OperateSymbol
{
    public Multiplication(string value, int position) : base(value, position)
    {
        OperandCount = 2;
    }


    protected override decimal InternalEvaluate(List<OperateNumber> operands)
    {
        return operands[1].Value * operands[0].Value;
    }
}