namespace RpnCalculator.Core.Operators;

/// <summary>
/// 撤销
/// </summary>
public class OpUndo : OperatorBase
{
    public OpUndo(string value) : base(value)
    {
    }


    public override decimal Evaluate(List<Operand> operands)
    {
        throw new NotImplementedException();
    }
}