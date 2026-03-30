using System;

class Program
{
    static void Main()
    {
        var nm = Console.ReadLine().Split();
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        
        int result = BinarySearch(arr, n, m);

        Console.WriteLine(result.ToString());
    }
    
    static int BinarySearch(int[] arr, int n, int m)
    {
        int left = 0;
        int right = 0;
        foreach(var num in arr)
        {
            if(num > right)
                right = num;
        }
        
        int result = 0;
        
        while(left <= right)
        {
            int mid = (left + right) / 2;
            int min = arr[0];
            int max = arr[0];
            int cnt = 1;
            
            for(int i = 0; i < n - 1; i++)
            {
                if(arr[i + 1] < min)
                    min = arr[i + 1];
                if(arr[i + 1] > max)
                    max = arr[i + 1];
                
                if(max - min > mid)
                {
                    cnt++;
                    max = arr[i + 1];
                    min = arr[i + 1];
                }
            }
            
            if(cnt <= m)
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