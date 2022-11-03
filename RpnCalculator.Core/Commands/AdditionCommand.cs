namespace RpnCalculator.Core.Commands;

/// <summary>
/// 加法命令
/// </summary>
public class AdditionCommand : OperateSymbol
{
    public AdditionCommand(string value, int position) : base(value, position)
    {
        OperandCount = 2;
    }

    protected override decimal ImplementedEvaluate(List<OperateNumber> operands)
    {
        return operands[1].Value + operands[0].Value;
    }
}