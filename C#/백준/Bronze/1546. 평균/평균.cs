using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int max = arr.Max();
        double sum = 0;

        for(int i = 0; i < n; i++)
            sum += (double)arr[i] / (double)max * 100;
            
        Console.WriteLine(sum / n);
    }
}