// See https://aka.ms/new-console-template for more information

using RpnCalculator.Core;

var calculator = new Calculator();

do
{
    Console.Write($"please enter operands:");

    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        continue;
    }

    Console.WriteLine(calculator.Evaluate(input));
} while (true);