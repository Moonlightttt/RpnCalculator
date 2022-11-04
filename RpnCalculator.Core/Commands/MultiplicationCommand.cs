namespace RpnCalculator.Core.Commands;

/// <summary>
/// 乘法命令
/// </summary>
public class MultiplicationCommand : OperateSymbol
{
    public MultiplicationCommand(string value, int position) : base(value, position)
    {
        RequiredOperands = 2;
    }

    protected override decimal ImplementedEvaluate(Stack<OperateNumber> stack)
    {
        return stack.Pop().Value * stack.Pop().Value;
    }
}