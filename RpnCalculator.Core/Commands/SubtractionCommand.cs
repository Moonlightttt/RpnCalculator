namespace RpnCalculator.Core.Commands;

/// <summary>
/// 减法命令
/// </summary>
public class SubtractionCommand : OperateSymbol, IComputeCommand
{
    public SubtractionCommand(string value, int position) : base(value, position)
    {
        OperandCount = 2;
    }


    protected override decimal InternalEvaluate(List<OperateNumber> operands)
    {
        return operands[1].Value - operands[0].Value;
    }

    public void Execute(Calculator calculator)
    {
        calculator.CommandExecute(this, OperandCount, Evaluate);
    }

    public void Undo(Calculator calculator)
    {
        calculator.Undo(UndoList);
    }
}