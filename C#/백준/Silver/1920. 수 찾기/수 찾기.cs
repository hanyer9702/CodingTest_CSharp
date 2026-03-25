using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arrA = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        
        int m = int.Parse(Console.ReadLine());
        int[] arrB = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        HashSet<int> set = new HashSet<int>(arrA);
        
        StringBuilder sb = new StringBuilder();
        
        foreach(var num in arrB)
        {
            if(set.Contains(num))
                sb.AppendLine("1");
            else
                sb.AppendLine("0");
        }
        
        Console.WriteLine(sb.ToString());
    }
}