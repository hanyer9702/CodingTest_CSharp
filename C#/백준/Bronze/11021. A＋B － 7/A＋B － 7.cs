using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; i++)
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int a = arr[0];
            int b = arr[1];
            
            Console.WriteLine("Case #" + (i + 1) + ": " + (a + b));
        }
    }
}