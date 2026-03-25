using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var nm = Console.ReadLine().Split();
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);
        
        long[] arr = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        List<long> heap = new List<long>();
        
        for(int i = 0; i < n; i++)
        {
            Push(heap, arr[i]);
        }
        
        for(int i = 0; i < m; i++)
        {
            long x = Pop(heap);
            long y = Pop(heap);
        
            Push(heap, x + y);
            Push(heap, x + y);
        }
        
        long sum = 0;
        foreach(var num in heap)
            sum += num;
        
        Console.WriteLine(sum);
    }
    
    static void Push(List<long> heap, long value)
    {
        heap.Add(value);
        int i = heap.Count - 1;
        
        while(i > 0)
        {
            int parent = (i - 1) / 2;
            
            if(heap[parent] <= heap[i])
                break;
            
            (heap[parent], heap[i]) = (heap[i], heap[parent]);
            i = parent;
        }
    }
    
    static long Pop(List<long> heap)
    {
        int last = heap.Count - 1;
        long rtNum = heap[0];
        heap[0] = heap[last];
        heap.RemoveAt(last);
        int i = 0;
        
        while(true)
        {
            int left = i * 2 + 1;
            int right = i * 2 + 2;
            int smallest = i;
            
            if(left < heap.Count && heap[left] < heap[smallest])
                smallest = left;
            if(right < heap.Count && heap[right] < heap[smallest])
                smallest = right;
            if(smallest == i) break;
            
            (heap[smallest], heap[i]) = (heap[i], heap[smallest]);
            i = smallest;
        }
        
        return rtNum;
    }
}