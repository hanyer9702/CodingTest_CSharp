using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[] arr = new long[n + 1];
        arr[1] = 1;
        
        if(n > 1)
            arr[2] = 2;
            
        if(n > 2)
        {
            for(int i = 3; i <= n; i++)
            {
                arr[i] = (arr[i - 2] + arr[i - 1]) % 10007;
            }
        }

        Console.WriteLine(arr[n]);
    }
}