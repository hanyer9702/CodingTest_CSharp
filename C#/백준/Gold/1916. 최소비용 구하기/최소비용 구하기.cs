using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        
        int n = int.Parse(sr.ReadLine());
        int m = int.Parse(sr.ReadLine());
        List<(int to, int cost)>[] graph = new List<(int, int)>[n];

        for(int i = 0; i < n; i++)
        {
            graph[i] = new List<(int, int)>();
        }
        
        for(int i = 0; i < m; i++)
        {
            var input = sr.ReadLine().Split();
            int startnode = int.Parse(input[0])  - 1;
            int stopnode = int.Parse(input[1]) - 1;
            int dist = int.Parse(input[2]);
            graph[startnode].Add((stopnode, dist));
        }
        
        var inputStop = sr.ReadLine().Split();
        int start = int.Parse(inputStop[0]);
        int stop = int.Parse(inputStop[1]);
        
        int result = Dijkstra(graph, n, start - 1, stop - 1);
        Console.Write(result.ToString());
    }
    
    static int Dijkstra(List<(int to, int cost)>[] graph, int n, int start, int stop)
    {
        int[] dist = new int[n];
        bool[] visited = new bool[n];
        
        for(int i = 0; i < n; i++)
            dist[i] = int.MaxValue;
        
        dist[start] = 0;
        
        for(int i = 0; i < graph.Length; i++)
        {
            int minDist = int.MaxValue;
            int cur = -1;
            
            for(int j = 0; j < graph.Length; j++)
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
        
        return dist[stop];
    }
}