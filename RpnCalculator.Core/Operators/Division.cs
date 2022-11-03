﻿namespace RpnCalculator.Core.Operators;

/// <summary>
/// 除法
/// </summary>
public class Division : OperateSymbol
{
    public Division(string value, int position) : base(value, position)
    {
        OperandCount = 2;
    }

    protected override decimal InternalEvaluate(List<OperateNumber> operands)
    {
        return operands[1].Value / operands[0].Value;
    }
}