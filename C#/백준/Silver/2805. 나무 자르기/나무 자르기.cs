using System;

class Program
{
    static void Main()
    {
        var nm = Console.ReadLine().Split();
        int n = int.Parse(nm[0]);
        long m = long.Parse(nm[1]);
        
        long[] arr = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long max = 0;
        
        foreach(var num in arr)
        {
            if (num > max)
                max = num;
        }
        
        long result = BinarySearch(arr, max, m);
        Console.WriteLine(result.ToString());
    }
    
    static long BinarySearch(long[] arr, long max, long m) 
    {
        long left = 1;
        long right = max;
        long answer = 0;
        
        while(left <= right)
        {
            long mid = (left + right) / 2;
            long sum = 0;
            
            foreach(var num in arr)
            {
                if(num - mid > 0)
                    sum += num - mid;
            }
                
            if(sum >= m)
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