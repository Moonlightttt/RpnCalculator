namespace RpnCalculator.Core.Operators;

/// <summary>
/// 撤销
/// </summary>
public class Undo : OperatorBase
{
    public Undo(string value, int position) : base(value, position)
    {
        OperandCount = 0;
    }

    protected override decimal InternalEvaluate(List<Operand> operands)
    {
        throw new NotImplementedException();
    }
}