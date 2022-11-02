namespace RpnCalculator.Core.Operators;

/// <summary>
/// 撤销
/// </summary>
public class OpClear : OperatorBase
{
    public OpClear(string value) : base(value)
    {
    }


    public override decimal Evaluate(List<Operand> operands)
    {
        throw new NotImplementedException();
    }
}