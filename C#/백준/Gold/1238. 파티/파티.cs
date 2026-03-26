using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        
        var NMX = sr.ReadLine().Split();
        int n = int.Parse(NMX[0]);
        int m = int.Parse(NMX[1]);
        int x = int.Parse(NMX[2]) - 1;
        
        List<(int to, int cost)>[] graphGo = new List<(int, int)>[n];
        List<(int to, int cost)>[] graphBack = new List<(int, int)>[n];
        for(int i = 0; i < n; i++)
        {
            graphGo[i] = new List<(int, int)>();
            graphBack[i] = new List<(int, int)>();
        }
        
        for(int i = 0; i < m; i++)
        {
            var MMD = sr.ReadLine().Split();
            int m1 = int.Parse(MMD[0]) - 1;
            int m2 = int.Parse(MMD[1]) - 1;
            int dist = int.Parse(MMD[2]);
            
            graphGo[m2].Add((m1, dist));
            graphBack[m1].Add((m2, dist));
        }
        
        int[] go = Dijkstra(graphGo, n, x);
        int[] back = Dijkstra(graphBack, n, x);
        int[] sum = new int[n];

        for(int i = 0; i < n; i++)
        {
            sum[i] = go[i] + back[i];
        }

        Console.WriteLine(sum.Max().ToString());
    }
    
    static int[] Dijkstra(List<(int to, int cost)>[] graph, int n, int start)
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
        
        return dist;
    }
}