using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Program
{
    static List<int> minHeap = new List<int>();
    static List<int> maxHeap = new List<int>();
    
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        var sb = new StringBuilder();
        
        int n = int.Parse(sr.ReadLine());
        
        for(int i = 0; i < n; i++)
        {
            int num = int.Parse(sr.ReadLine());
            Push(num);
 
            if(maxHeap.Count < minHeap.Count)
            {
                int move = minHeap[0];
                PopMin(minHeap);
                HeapifyMax(maxHeap, move);
            }
            else if(maxHeap.Count > minHeap.Count + 1)
            {
                int move = maxHeap[0];
                PopMax(maxHeap);
                HeapifyMin(minHeap, move);
            }
            
            sb.AppendLine(maxHeap[0].ToString());
        }
        
        Console.Write(sb.ToString());
    }
    
    static void Push(int value)
    {
        if(maxHeap.Count == 0)
        {
            maxHeap.Add(value);
            return;
        }
        
        if(maxHeap[0] < value)
            HeapifyMin(minHeap, value);
        else
            HeapifyMax(maxHeap, value);
    }
    
    static void HeapifyMax(List<int> heap, int value)
    {
        heap.Add(value);
        int i = heap.Count - 1;
        
        while(i > 0)
        {
            int parent = (i - 1) / 2;
            
            if(heap[parent] >= heap[i])
                break;
            
            (heap[parent], heap[i]) = (heap[i], heap[parent]);
            i = parent;
        }
    }
    
    static void HeapifyMin(List<int> heap, int value)
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
    
    static void PopMax(List<int> heap)
    {
        int last = heap.Count - 1;
        heap[0] = heap[last];
        heap.RemoveAt(last);
        HeapifyDownMax(heap, 0);
    }
    
    static void PopMin(List<int> heap)
    {
        int last = heap.Count - 1;
        heap[0] = heap[last];
        heap.RemoveAt(last);
        HeapifyDownMin(heap, 0);
    }
    
    static void HeapifyDownMax(List<int> heap, int i)
    {
        while(true)
        {
            int left = i * 2 + 1;
            int right = i * 2 + 2;
            int largest = i;
            
            if(left < heap.Count && heap[left] > heap[largest])
                largest = left;
            if(right < heap.Count && heap[right] > heap[largest])
                largest = right;
            if (largest == i) break;
            
            (heap[largest], heap[i]) = (heap[i], heap[largest]);
            i = largest;
        }
    }
    
    static void HeapifyDownMin(List<int> heap, int i)
    {
        while(true)
        {
            int left = i * 2 + 1;
            int right = i * 2 + 2;
            int smallest = i;
            
            if(left < heap.Count && heap[left] < heap[smallest])
                smallest = left;
            if(right < heap.Count && heap[right] < heap[smallest])
                smallest = right;
            if (smallest == i) break;
            
            (heap[smallest], heap[i]) = (heap[i], heap[smallest]);
            i = smallest;
        }
    }
}