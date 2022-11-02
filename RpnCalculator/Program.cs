// See https://aka.ms/new-console-template for more information

using RpnCalculator.Core;
using RpnCalculator.Core.Exceptions;

var calculator = new Calculator();

do
{
    Console.Write($"please enter operands:");

    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        continue;
    }

    try
    {
        var result = calculator.Evaluate(input);

        Console.WriteLine($"buffer: {result}");
    }
    catch (InsufficientException e)
    {
        Console.WriteLine(e);
        Console.WriteLine($"buffer: {calculator}");
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine($"buffer: {calculator}");
    }
} while (true);