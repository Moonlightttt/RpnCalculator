// See https://aka.ms/new-console-template for more information

do
{
    Console.Write($"please enter operands:");
    
    var str = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(str))
    {
        continue;
    }

    Console.WriteLine($"buffer: {str}");
    
} while (true);