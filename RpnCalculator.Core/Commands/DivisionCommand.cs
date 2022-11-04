namespace RpnCalculator.Core.Commands;

/// <summary>
/// 除法命令
/// </summary>
public class DivisionCommand:OperateSymbol
{
    public DivisionCommand(string value, int position) : base(value, position)
    {
        RequiredOperands = 2;
    }

    protected override decimal ImplementedEvaluate(List<OperateNumber> operands)
    {
        return operands[1].Value / operands[0].Value;
    }
}