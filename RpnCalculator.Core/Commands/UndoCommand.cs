namespace RpnCalculator.Core.Commands;

/// <summary>
/// 撤销命令
/// </summary>
public class UndoCommand:INonComputeCommand
{
    public void Execute(Calculator calculator)
    {
        calculator.Undo();
    }
}