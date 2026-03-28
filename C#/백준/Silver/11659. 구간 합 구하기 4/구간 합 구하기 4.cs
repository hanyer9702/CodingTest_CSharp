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
        
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] arrStart = new int[m];
        int[] arrEnd = new int[m];
        
        for(int i = 0; i < m; i++)
        {
            var startEnd = sr.ReadLine().Split();
            arrStart[i] = int.Parse(startEnd[0]) - 1;
            arrEnd[i] = int.Parse(startEnd[1]) - 1;
        }
        
        int[] sum = new int[n];
        sum[0] = arr[0];
        if(n > 1) sum[1] = arr[0] + arr[1];
        
        for(int i = 1; i < n; i++)
        {
            sum[i] = sum[i - 1] + arr[i];
        }
        
        for(int i = 0; i < m; i++)
        {
            int start = arrStart[i];
            int end = arrEnd[i];
            
            if(start == 0)
                sb.AppendLine(sum[end].ToString());
            else
                sb.AppendLine((sum[end] - sum[start - 1]).ToString());
        }
        
        Console.Write(sb.ToString());
    }
}