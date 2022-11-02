using RpnCalculator.Core.Operators;

namespace RpnCalculator.Core;

/// <summary>
/// 操作项工厂
/// </summary>
public static class OperateItemFactory
{
    public static OperateItem GetInstance(string str)
    {
        return str switch
        {
            "+" => new OpPlus(str),
            "-" => new OpSub(str),
            "*" => new OpMulti(str),
            "/" => new OpDiv(str),
            "undo" => new OpUndo(str),
            "clear" => new OpClear(str),
            _ => new Operand(str),
        };
    }
}