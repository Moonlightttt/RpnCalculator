namespace RpnCalculator.Core.Commands;

/// <summary>
/// 加法命令
/// </summary>
public class AdditionCommand : OperateSymbol
{
    public AdditionCommand(string value, int position) : base(value, position)
    {
        RequiredOperands = 2;
    }

    protected override decimal ImplementedEvaluate(Stack<OperateNumber> stack)
    {
        return stack.Pop().Value + stack.Pop().Value;
    }
}