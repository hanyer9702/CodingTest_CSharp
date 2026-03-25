using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[] arr = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long m = long.Parse(Console.ReadLine());
        long max = 0;
        
        foreach(var num in arr)
        {
            if (num > max)
                max = num;
        }
        
        long budget = BinarySearch(arr, m, max);
        Console.WriteLine(budget.ToString());
    }
    
    static long BinarySearch(long[] arr, long m, long max)
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
                if(num >= mid)
                    sum += mid;
                else
                    sum += num;
                
                if(sum > m)
                    break;
            }
            
            if(sum <= m)
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