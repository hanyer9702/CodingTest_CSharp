using System;

class Program
{
    static void Main()
    {
        var nk = Console.ReadLine().Split();
        int n = int.Parse(nk[0]);
        int k = int.Parse(nk[1]);
        
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] result = new int[n - k + 1];
        Array.Fill(result, 0);
        int i = 0;
        while(i < k)
        {
            result[0] += arr[i];
            i++;
        }
        
        for(int j = 1; j < n - k + 1; j++)
        {
            result[j] = result[j - 1] + arr[i] - arr[i - k];
            i++;
        }
        
        Console.WriteLine(result.Max());
    }
}