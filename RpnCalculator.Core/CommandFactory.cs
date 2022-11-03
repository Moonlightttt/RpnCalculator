using RpnCalculator.Core.Commands;

namespace RpnCalculator.Core;

public static class CommandFactory
{
    public static ICommand GetCommand(string str, int position)
    {
        return str switch
        {
            "+" => new AdditionCommand(str, position),
            "-" => new SubtractionCommand(str, position),
            "*" => new MultiplicationCommand(str, position),
            "/" => new DivisionCommand(str, position),
            "sqrt" => new SqrtCommand(str, position),
            "undo" => new UndoCommand(),
            "clear" => new ClearCommand(),
            _ => new NumberCommand(str),
        };
    }
}