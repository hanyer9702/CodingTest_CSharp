using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[] arr = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        int count = 0;
        
        Array.Sort(arr);
        
        for(int i = 0; i < n; i++)
        {
            long left = 0;
            long right = arr.Length - 1;  
            
            while(left < right)
            {
                if(left == i || right == i)
                {
                    if(left == i)
                        left++;
                    else if(right == i)
                        right --;
                }
                else
                {
                    long sum = arr[left] + arr[right];
                
                    if(arr[i] == sum)
                    {
                        count++;
                        break;
                    }
                    else if(arr[i] > sum)
                        left++;
                    else
                        right--;
                }
            }
        }
        
        Console.WriteLine(count);
    }
}