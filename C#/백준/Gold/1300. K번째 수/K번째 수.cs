using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long k = long.Parse(Console.ReadLine());
    
        long result = BinarySearch(n, k);
        Console.WriteLine(result.ToString());
    }
    
    static long BinarySearch(int n , long k)
    {
        long left = 1;
        long right = k;
        long result = 0;
        
        while(left <= right)
        {
            long mid = (left + right) / 2;
            long count = 0;
            
            for (int i = 1; i <= n; i++)
            {
                count += Math.Min(mid / i, n);
            }
            
            if(count >= k)
            {
                result = mid;
                right = mid - 1;
            }
            else
                left = mid + 1;
        }
        
        return result;
    }
}