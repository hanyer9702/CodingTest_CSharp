using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        var sb = new StringBuilder();
        
        int n = int.Parse(sr.ReadLine());
        List<int> heap = new List<int>();
        
        for(int i = 0; i < n; i++)
        {
            int x = int.Parse(sr.ReadLine());
            
            if(x == 0)
            {
                if(heap.Count == 0)
                    sb.AppendLine("0");
                else
                {
                    sb.AppendLine(heap[0].ToString());
                    Pop(heap);
                }
            }
            else
            {
                Push(heap, x);
            }
        }
        
        Console.Write(sb.ToString());
    }
    
    static void Push(List<int> heap, int value)
    {
        heap.Add(value);
        int i = heap.Count - 1;
        
        while(i > 0)
        {
            int parent = (i - 1) / 2;
            
            if(Compare(heap[parent], heap[i]))
                break;
            
            (heap[parent], heap[i]) = (heap[i], heap[parent]);
            i = parent;
        }
    }
    
    static void Pop(List<int> heap)
    {
        int last = heap.Count - 1;
        heap[0] = heap[last];
        heap.RemoveAt(last);
        int i = 0;
        
        while(true)
        {
            int left = i * 2 + 1;
            int right = i * 2 + 2;
            int smallest = i;
            
            if(left < heap.Count && Compare(heap[left], heap[smallest]))
                smallest = left;
            if(right < heap.Count && Compare(heap[right], heap[smallest]))
                smallest = right;
            if(smallest == i) break;
            
            (heap[smallest], heap[i]) = (heap[i], heap[smallest]);
            i = smallest;
        }
    }
    
    static bool Compare(int a, int b)
    {
        int absA = Math.Abs(a);
        int absB = Math.Abs(b);
        
        if(absA < absB) return true;
        if(absA > absB) return false;
        return a < b;
    }
}