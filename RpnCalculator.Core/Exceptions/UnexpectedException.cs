namespace RpnCalculator.Core.Exceptions;

/// <summary>
/// 预期外字符异常
/// </summary>
public class UnexpectedException : Exception
{
    private string UnexpectedString { get; }

    public UnexpectedException(string unexpectedString)
    {
        UnexpectedString = unexpectedString;
    }

    public override string ToString()
    {
        return $"unexpected string: {UnexpectedString}";
    }
}