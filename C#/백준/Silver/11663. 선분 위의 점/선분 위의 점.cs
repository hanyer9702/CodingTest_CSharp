using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        var sb = new StringBuilder();
        
        var nm = sr.ReadLine().Split();
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);
        
        long[] arr = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
        Array.Sort(arr);
        
        for(int i = 0; i < m; i++)
        {
            var x = sr.ReadLine().Split();
            long x1 = long.Parse(x[0]);
            long x2 = long.Parse(x[1]);
            int result = UpperBound(arr, x2) - LowerBound(arr, x1);
            
            sb.AppendLine(result.ToString());
        }
        
        Console.Write(sb.ToString());
    }
        
    static int LowerBound(long[] arr, long x)
    {
        int left = 0;
        int right = arr.Length;
        
        while(left < right)
        {
            int mid = (left + right) / 2;
            
            if(arr[mid] >= x)
                right = mid;
            else
                left = mid + 1;
        }
        
        return left;
    }
    
    static int UpperBound(long[] arr, long x)
    {
        int left = 0;
        int right = arr.Length;
        
        while(left < right)
        {
            int mid = (left + right) / 2;
            
            if(arr[mid] > x)
                right = mid;
            else
                left = mid + 1;
        }
        
        return left;
    }
}