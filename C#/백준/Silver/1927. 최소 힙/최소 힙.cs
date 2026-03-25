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
                if (heap.Count == 0) 
                {
                    sb.AppendLine("0");
                }
                else
                {
                    sb.AppendLine(heap[0].ToString());
                    Pop(heap);
                }
            }
            else
                Push(heap, x);
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
            
            if(heap[i] >= heap[parent]) break;   
            
            (heap[parent], heap[i]) = (heap[i], heap[parent]);
            i = parent;
        }
    }
    
    static void Pop(List<int> heap)
    {
        int last = heap.Count - 1;
        
        heap[0] = heap[last];
        heap.RemoveAt(last);
        
        Heapify(heap, 0);
    }
    
    static void Heapify(List<int> heap, int i)
    {
        while(true)
        {
            int left = i * 2 + 1;
            int right = i * 2 + 2;
            int largest = i;
            
            if(left < heap.Count && heap[left] < heap[largest])
                largest = left;
            if(right < heap.Count && heap[right] < heap[largest])
                largest = right;
            
            if(largest == i) break;
            
            (heap[largest], heap[i]) = (heap[i], heap[largest]);
            i = largest;
        }
    }
}