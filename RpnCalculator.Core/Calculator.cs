using System.Globalization;

namespace RpnCalculator.Core;

/// <summary>
/// 计算器
/// </summary>
public class Calculator
{
    private Stack<Operand> _operandStack = new Stack<Operand>();

    private List<OperateItem> _originData = new List<OperateItem>();

    /// <summary>
    /// 构造函数
    /// </summary>
    public Calculator()
    {
    }

    public string Evaluate(string input)
    {
        _originData = input.Resolve();

        foreach (var item in _originData)
        {
            if (item is Operand operand)
            {
                _operandStack.Push(operand);
            }
            else
            {
                var @operator = item as OperatorBase;

                var currentList = new List<Operand>();

                var operandCount = @operator!.OperandCount;

                while (operandCount > 0)
                {
                    currentList.Add(_operandStack.Pop());
                    operandCount--;
                }

                var result = @operator.Evaluate(currentList);

                _operandStack.Push(new Operand(result.ToString(CultureInfo.CurrentCulture)));
            }
        }

        var list = new List<decimal>();

        while (_operandStack.Count > 0)
        {
            var operand = _operandStack.Pop();
            list.Add(operand.NumberValue);
        }

        list.Reverse();

        return string.Join(" ", list);
    }
}