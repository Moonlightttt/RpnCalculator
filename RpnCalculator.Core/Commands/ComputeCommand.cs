namespace RpnCalculator.Core.Commands;

/// <summary>
/// 计算命令
/// </summary>
public interface IComputeCommand : ICommand
{
    /// <summary>
    /// 撤销
    /// </summary>
    void Undo(Calculator calculator);
}