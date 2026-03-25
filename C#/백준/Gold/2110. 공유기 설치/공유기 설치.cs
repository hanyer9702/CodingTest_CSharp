using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        
        var nc = sr.ReadLine().Split();
        int n = int.Parse(nc[0]);
        int c = int.Parse(nc[1]);
        long[] arr = new long[n];
        long max = 0;
        
        for(int i = 0; i < n; i++)
        {
            arr[i] = long.Parse(sr.ReadLine());
            if(arr[i] > max)
                max = arr[i];
        }
        
        Array.Sort(arr);
        
        long result = BinarySearch(arr, max, c);
        Console.WriteLine(result.ToString());
    }
    
    static long BinarySearch(long[] arr, long max, int c)
    {
        long left = 1;
        long right = max;
        long result = max;
        
        while(left <= right)
        {
            long mid = (left + right) / 2;
            long bf = arr[0];
            long sum = 1;
            
            foreach(var num in arr)
            {
                if(num - bf >= mid)
                {
                    bf = num;
                    sum += 1;
                }
            }
            
            if(sum >= c)
            {
                result = mid;
                left = mid + 1;
            }
            else
                right = mid - 1;
        }
        
        return result;
    }
}