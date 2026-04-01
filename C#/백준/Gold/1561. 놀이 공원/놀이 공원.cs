using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var nm = Console.ReadLine().Split();
        long n = long.Parse(nm[0]);
        int m = int.Parse(nm[1]);
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        
        int time = 1;
        int pos = 0;

        if(n <= m)
            pos = (int)n;
        else
            pos = BinarySearch(arr, n, m);

        Console.WriteLine(pos);
    }

    static int BinarySearch(int[] arr, long n, int m)
    {
        long left = 1;
        long right = n * arr.Max();
        int pos = 0;
        long time = 0;

        while(left <= right)
        {
            long mid = (left + right) / 2;
            long children = m;

            for(int i = 0; i < m; i++)
            {
                children += mid / arr[i];
            }

            if(children >= n)
            {
                time = mid;
                right = mid - 1;
            }
            else
                left = mid + 1;
        }

        long before = m;
        for(int i = 0; i < m; i++)
        {
            before += (time - 1) / arr[i];
        }

        for(int i = 0; i < m; i++)
        {
            if(time % arr[i] == 0)
            {
                if(++before == n)
                {
                    pos = i + 1;
                    break;
                }
            }
        }

        return pos;
    }
}