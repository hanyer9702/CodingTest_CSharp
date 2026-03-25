using System;
class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        
        string[] numbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        long num1 = long.Parse(numbers[0]);
        long num2 = long.Parse(numbers[1]);
        long num3 = long.Parse(numbers[2]);
        
        long sum = num1 + num2 + num3;
        
        Console.WriteLine(sum);
    }
}