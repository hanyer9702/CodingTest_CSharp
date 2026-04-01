using System;
using System.IO;

class Program
{
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n];
        for(int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }
        
        int[] dp = new int[n];
        dp[0] = arr[0];
        if(n > 1) dp[1] = arr[0] + arr[1];
        if(n > 2) dp[2] = Math.Max(dp[1], Math.Max(arr[0] + arr[2], arr[1] + arr[2]));
        for(int i = 3; i < n; i++)
        {
            dp[i] = Math.Max(dp[i - 1], Math.Max(dp[i - 2] + arr[i], dp[i - 3] + arr[i - 1] + arr[i]));
        }
        
        Console.WriteLine(dp[n - 1]);
    }
}