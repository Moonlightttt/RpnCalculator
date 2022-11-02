namespace RpnCalculator.Core.Operators;

/// <summary>
/// 清空
/// </summary>
public class Clear : OperatorBase
{
    public Clear(string value, int position) : base(value, position)
    {
        OperandCount = 0;
    }

    protected override decimal InternalEvaluate(List<Operand> operands)
    {
        throw new NotImplementedException();
    }
}