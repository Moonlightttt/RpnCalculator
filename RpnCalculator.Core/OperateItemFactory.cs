using RpnCalculator.Core.Operators;

namespace RpnCalculator.Core;

/// <summary>
/// 操作项工厂
/// </summary>
public static class OperateItemFactory
{
    public static OperateItem GetInstance(string str, int position)
    {
        return str switch
        {
            "+" => new Addition(str, position),
            "-" => new Subtraction(str, position),
            "*" => new Multiplication(str, position),
            "/" => new Division(str, position),
            "undo" => new Undo(str, position),
            "clear" => new Clear(str, position),
            _ => new Operand(str),
        };
    }
}