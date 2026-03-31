using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        int testcase = int.Parse(sr.ReadLine());
        
        while(testcase-- > 0)
        {
            var ndc = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int n = ndc[0];
            int d = ndc[1];
            int c = ndc[2];
            List<(int, int)>[] graph = new List<(int, int)>[n + 1];
            for(int i = 0; i < n + 1; i++)
                graph[i] = new List<(int, int)>();
            
            for(int i = 0; i < d; i++)
            {
                var abs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int a = abs[0];
                int b = abs[1];
                int s = abs[2];
                graph[b].Add((a, s));
                //Console.WriteLine("abs" + (i + 1));
            }
            
            Dijkstra(graph, n, c);
        }
    }
    
    static void Dijkstra(List<(int to, int cost)>[] graph, int n, int c)
    {
        int[] dist = new int[n + 1];
        bool[] visited = new bool[n + 1];
        Array.Fill(dist, int.MaxValue);
        dist[c] = 0;
        
        for(int i = 1; i < n + 1; i++)
        {
            int minDist = int.MaxValue;
            int cur = -1;
            
            for(int j = 1; j < n + 1; j++)
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
        
        int cnt = 0;
        int max = 0;
        for(int i = 1; i < n + 1; i++)
        {
            if(dist[i] != int.MaxValue)
            {
                cnt++;
                if(dist[i] > max)
                    max = dist[i];
            }
        }
        
        Console.WriteLine(cnt + " " + max);
    }
}