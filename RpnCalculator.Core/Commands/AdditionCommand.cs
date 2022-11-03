using RpnCalculator.Core.Operators;

namespace RpnCalculator.Core.Commands;

/// <summary>
/// 加法命令
/// </summary>
public class AdditionCommand : OperateSymbol, IComputeCommand
{
    public AdditionCommand(string value, int position) : base(value, position)
    {
        OperandCount = 2;
    }

    protected override decimal InternalEvaluate(List<OperateNumber> operands)
    {
        return operands[1].Value + operands[0].Value;
    }

    public void Execute(Calculator calculator)
    {
        calculator.CommandExecute(OperandCount, Evaluate);
    }

    public void Undo(Calculator calculator)
    {
        throw new NotImplementedException();
    }
}