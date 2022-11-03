namespace RpnCalculator.Core.Commands;

/// <summary>
/// 数字压入栈命令
/// </summary>
public class NumberCommand : OperateNumber, IComputeCommand
{
    public NumberCommand(string value) : base(value)
    {
    }

    public void Execute(Calculator calculator) 
    {
        calculator.SetNumber(this);
    }

    public void Undo(Calculator calculator)
    {
        calculator.Undo(new List<OperateNumber> { });
    }
}