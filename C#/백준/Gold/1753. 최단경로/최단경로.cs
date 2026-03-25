using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        var sb = new StringBuilder();
        
        var ve = sr.ReadLine().Split();
        int v = int.Parse(ve[0]);
        int e = int.Parse(ve[1]);
        int k = int.Parse(sr.ReadLine());
        
        List<(int to, int cost)>[] graph = new List<(int, int)>[v];
        for(int i = 0; i < v; i++)
            graph[i] = new List<(int, int)>();
        
        for(int i = 0; i < e; i++)
        {
            var uvw = sr.ReadLine().Split();
            int u = int.Parse(uvw[0]) - 1;
            int v2 = int.Parse(uvw[1]) - 1;
            int w = int.Parse(uvw[2]);
            
            graph[u].Add((v2, w));
        }
        
        int[] dist = new int[v];
        bool[] visited = new bool[v];
        
        for(int i = 0; i < v; i++)
        {
            dist[i] = int.MaxValue;
        }
        
        dist[k - 1] = 0;
        
        for(int i = 0; i < v; i++)
        {
            int minDist = int.MaxValue;
            int cur = -1;
            
            for(int j = 0; j < v; j++)
            {
                if(!visited[j] && dist[j] < minDist)
                {
                    minDist = dist[j];
                    cur = j;
                }
            }
            
            if(cur == -1) continue;
            visited[cur] = true;
            
            foreach(var next in graph[cur])
            {
                int nextnode = next.to;
                int cost = next.cost;
                
                if(dist[nextnode] > dist[cur] + cost)
                    dist[nextnode] = dist[cur] + cost;
            }
        }
        
        foreach(var num in dist)
        {
            if(num == int.MaxValue)
                sb.AppendLine("INF");
            else
                sb.AppendLine(num.ToString());
        }
        
        Console.Write(sb.ToString());
    }
}