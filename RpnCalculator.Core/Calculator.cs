namespace RpnCalculator.Core;

public class Calculator
{
    private Stack<decimal> _stack = new Stack<decimal>();

    private List<string> _sourceList;

    public Calculator(string source)
    {
        _sourceList = source.Split(" ").ToList().Where(x => x != " ").ToList();
    }

    public string Execute()
    {
        return string.Empty;
    }
}