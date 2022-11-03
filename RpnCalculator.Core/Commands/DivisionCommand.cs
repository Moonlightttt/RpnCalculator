namespace RpnCalculator.Core.Commands;

/// <summary>
/// 除法命令
/// </summary>
public class DivisionCommand:OperateSymbol
{
    public DivisionCommand(string value, int position) : base(value, position)
    {
        OperandCount = 2;
    }

    protected override decimal ImplementedEvaluate(List<OperateNumber> numbers)
    {
        return numbers[1].Value / numbers[0].Value;
    }
}