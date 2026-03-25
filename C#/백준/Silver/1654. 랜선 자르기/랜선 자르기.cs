using System;

class Program
{
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        
        String[] kn = sr.ReadLine().Split();
        int k = int.Parse(kn[0]);
        int n = int.Parse(kn[1]);
        long[] arr = new long[k];
        long max = 0;
        
        for(int i = 0; i < k; i++)
        {
            arr[i] = long.Parse(sr.ReadLine());
            
            if (arr[i] > max)
                max = arr[i];
        }
        
        long result = BinarySearch(arr, max, n);
        Console.WriteLine(result.ToString());
    }
    
    static long BinarySearch(long[] arr, long max, int n)
    {
        long left = 1;
        long right = max;
        long answer = 0;
        
        while(left <= right)
        {
            long mid = (left + right) / 2;
            long sumDivide = 0;
            
            foreach(var num in arr)
            {
                sumDivide += num / mid;
            }
            
            if(sumDivide >= n)
            {
                answer = mid;
                left = mid + 1;
            }
            else
                right = mid - 1;
        }
        
        return answer;
    }
}