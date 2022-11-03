namespace RpnCalculator.Core.Commands;

public interface ICommand
{
    /// <summary>
    /// 执行
    /// </summary>
    void Execute(Calculator calculator);
}