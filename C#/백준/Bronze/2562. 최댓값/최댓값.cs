using System;

class Program
{
    static void Main()
    {
        int max = 0;
        int pos = 0;
        for(int i = 0; i < 9; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if(num > max)
            {
                max = num;
                pos = i + 1;
            }
        }
        Console.WriteLine(max);
        Console.WriteLine(pos);
    }
}