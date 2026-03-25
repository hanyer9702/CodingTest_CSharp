using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numA = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        
        int m = int.Parse(Console.ReadLine());
        int[] numB = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        
        var sb = new StringBuilder();
        
        Array.Sort(numA);
        
        for(int i = 0; i < m; i++)
        {
            sb.Append(BinarySearch(numA, numB[i]).ToString());
            
            if (i < m - 1)
                sb.Append(" ");
        }

        Console.WriteLine(sb.ToString());
    }
    
    static int BinarySearch(int[] nums, int value)
    {
        return UpperBound(nums, value) - LowerBound(nums, value);
    }
    
    static int LowerBound(int[] nums, int value)
    {
        int left = 0;
        int right = nums.Length;
        
        while(left < right)
        {
            int mid = (left + right) / 2;
            
            if(nums[mid] >= value)
                right = mid;
            else
                left = mid + 1;
        }
        
        return left;
    }
    
    static int UpperBound(int[] nums, int value)
    {
        int left = 0;
        int right = nums.Length;
        
        while(left < right)
        {
            int mid = (left + right) / 2;
            
            if(nums[mid] > value)
                right = mid;
            else
                left = mid + 1;
        }
        
        return left;
    }
}