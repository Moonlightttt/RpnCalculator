namespace RpnCalculator.Core.Commands;

/// <summary>
/// 乘法命令
/// </summary>
public class MultiplicationCommand : OperateSymbol
{
    public MultiplicationCommand(string value, int position) : base(value, position)
    {
        OperandCount = 2;
    }


    protected override decimal ImplementedEvaluate(List<OperateNumber> operands)
    {
        return operands[1].Value * operands[0].Value;
    }
}