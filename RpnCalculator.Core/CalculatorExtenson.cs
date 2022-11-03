using RpnCalculator.Core.Commands;

namespace RpnCalculator.Core;

public static class CalculatorExtension
{
    /// <summary>
    /// 解析字符串
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static List<ICommand> Resolve(this string str)
    {
        return str.Trim().Split(" ").Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(CommandFactory.GetCommand).ToList();
    }
}