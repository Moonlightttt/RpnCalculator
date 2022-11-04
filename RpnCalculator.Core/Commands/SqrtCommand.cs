namespace RpnCalculator.Core.Commands;

/// <summary>
/// 平方根命令
/// </summary>
public class SqrtCommand : OperateSymbol
{
    public SqrtCommand(string value, int position) : base(value, position)
    {
        RequiredOperands = 1;
    }

    protected override decimal ImplementedEvaluate(List<OperateNumber> operands)
    {
        return (decimal)Math.Sqrt((double)operands[0].Value);
    }

    /// <summary>
    /// 验证
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    protected override void Validate(List<OperateNumber> numbers)
    {
        base.Validate(numbers);

        if (numbers[0].Value < 0)
        {
            throw new ArithmeticException("负数无法计算平方根");
        }
    }
}