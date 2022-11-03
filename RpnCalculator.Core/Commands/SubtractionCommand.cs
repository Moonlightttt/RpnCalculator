namespace RpnCalculator.Core.Commands;

/// <summary>
/// 减法命令
/// </summary>
public class SubtractionCommand : OperateSymbol
{
    public SubtractionCommand(string value, int position) : base(value, position)
    {
        OperandCount = 2;
    }


    protected override decimal ImplementedEvaluate(List<OperateNumber> operands)
    {
        return operands[1].Value - operands[0].Value;
    }
}