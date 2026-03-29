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
        
        List<int>[] graph = new List<int>[n + 1];
        int[] indegree = new int[n + 1];
        Array.Fill(indegree, 0);
        for(int i = 0; i <= n; i++)
            graph[i] = new List<int>();
        
        for(int i = 0; i < m; i++)
        {
            var ab = sr.ReadLine().Split();
            int a = int.Parse(ab[0]);
            int b = int.Parse(ab[1]);
            
            graph[a].Add(b);
            indegree[b]++;
        }
        
        Queue<int> q = new Queue<int>();
        int[] arr = new int[n + 1];
        Array.Fill(arr, 0);
        for(int i = 1; i <= n; i++)
        {
            if(indegree[i] == 0)
            {
                q.Enqueue(i);
                arr[i]++;
            }
        }
        
        while(q.Count > 0)
        {
            int cur = q.Dequeue();
            
            foreach(var next in graph[cur])
            {
                indegree[next]--;
                arr[next] = arr[cur] + 1;

                if(indegree[next] == 0)
                    q.Enqueue(next);
            }
        }
        
        for(int i = 1; i <= n; i++)
            Console.Write(arr[i] + " ");
    }
}