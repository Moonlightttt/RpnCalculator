namespace RpnCalculator.Core.Commands;

/// <summary>
/// 清理命令
/// </summary>
public class ClearCommand : INonComputeCommand
{
    public void Execute(Calculator calculator)
    {
        calculator.Clear();
    }
}