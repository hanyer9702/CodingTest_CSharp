using System;

class Program
{
    static void Main()
    {
        var nk = Console.ReadLine().Split();
        int n = int.Parse(nk[0]);
        int k = int.Parse(nk[1]);
        int[] weight = new int[n + 1];
        int[] values = new int[n + 1];
        int[,] dp = new int[n + 1, k + 1];
        
        for(int i = 1; i <= n; i++)
        {
            var wv = Console.ReadLine().Split();
            weight[i] = int.Parse(wv[0]);
            values[i] = int.Parse(wv[1]);
        }
        
        for(int i = 1; i <= n; i++)
        {
            int w = weight[i];
            int v = values[i];
            
            for(int j = 0; j <= k; j++)
            {
                dp[i, j] = dp[i - 1, j];
                
                if(j >= w)
                    dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - w] + v);
            }
        }

        Console.WriteLine(dp[n, k]);
    }
    
}