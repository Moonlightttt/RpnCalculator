namespace RpnCalculator.Core.Commands;

/// <summary>
/// 减法命令
/// </summary>
public class SubtractionCommand : OperateSymbol
{
    public SubtractionCommand(string value, int position) : base(value, position)
    {
        RequiredOperands = 2;
    }

    protected override decimal ImplementedEvaluate(Stack<OperateNumber> stack)
    {
        return stack.Pop().Value - stack.Pop().Value;
    }
}