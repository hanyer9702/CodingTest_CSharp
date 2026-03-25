using System;
using System.IO;

class Program
{
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        
        var nm = sr.ReadLine().Split();
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);
        int[] arr = new int[n];
        int max = 0;
        long sum = 0;
        
        for(int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
            if (arr[i] > max)
                max = arr[i];
            sum += arr[i];
        }
        
        long k = BinarySearch(arr, m, max, sum);
        Console.WriteLine(k);
    }
    
    static long BinarySearch(int[] arr, int m, int max, long sum)
    {
        long left = max;
        long right = sum;
        long answer = 0;
        
        while(left <= right)
        {
            long mid = (left + right) / 2;
            long money = mid;
            int cnt = 1;
            
            for(int i = 0; i < arr.Length; i++)
            { 
                if(money < arr[i])
                {
                    cnt++;
                    money = mid;
                }
                money = money - arr[i];
                
                if(cnt > m)
                    break;
            }
            
            if(cnt <= m)
            {
                answer = mid;
                right = mid - 1;
            }
            else
                left = mid + 1;  
        }
        
        return answer;
    }
}