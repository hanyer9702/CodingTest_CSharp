using System;
using System.IO;

class Program
{
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
    
        var nmr = sr.ReadLine().Split();
        int n = int.Parse(nmr[0]);
        int m = int.Parse(nmr[1]);
        int r = int.Parse(nmr[2]);
        int[] items = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        List<(int, int)>[] graph = new List<(int, int)>[n];
        for(int i = 0; i < n; i++)
            graph[i] = new List<(int, int)>();
        
        for(int i = 0; i < r; i++)
        {
            var abl = sr.ReadLine().Split();
            int a = int.Parse(abl[0]) - 1;
            int b = int.Parse(abl[1]) - 1;
            int l = int.Parse(abl[2]);
            graph[a].Add((b, l));
            graph[b].Add((a, l));
        }
        
        int[] result = new int[n];
        for(int i = 0; i < n; i++)
            result[i] = Dijkstra(graph, i, n, m, items);
        
        Console.WriteLine(result.Max());
    }
    
    static int Dijkstra(List<(int to, int cost)>[] graph, int start, int n, int m, int[] items)
    {
        int[] dist = new int[n];
        bool[] visited = new bool[n];
        Array.Fill(dist, int.MaxValue);
        dist[start] = 0;
        
        for(int i = 0; i < n; i++)
        {
            int minDist = int.MaxValue;
            int cur = -1;
            
            for(int j = 0; j < n; j++)
            {
                if(!visited[j] && dist[j] < minDist)
                {
                    minDist = dist[j];
                    cur = j;
                }
            }
            
            if(cur == -1) break;
            visited[cur] = true;
                
            foreach(var next in graph[cur])
            {
                int nextnode = next.to;
                int cost = next.cost;
                    
                if(dist[nextnode] > dist[cur] + cost)
                    dist[nextnode] = dist[cur] + cost;
            }
        }
        
        int sum = 0;
        for(int i = 0; i < n; i++)
        {
            if(dist[i] <= m)
                sum += items[i];
        }
        
        return sum;
    }
}