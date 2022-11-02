namespace RpnCalculator.Core;

public static class CalculatorExtension
{
    /// <summary>
    /// 解析字符串
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static List<OperateItem> Resolve(this string str)
    {
        return str.Split(" ").Select(OperateItemFactory.GetInstance).ToList();
    }
}