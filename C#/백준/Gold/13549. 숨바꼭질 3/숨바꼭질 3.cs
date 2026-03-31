using System;

class Program
{
    static void Main()
    {
        var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = input[0];
        int k = input[1];
        
        int max = 100001;
        int[] dist = new int[max];
        Array.Fill(dist, int.MaxValue);
        dist[n] = 0;
        
        var deque = new LinkedList<int>();
        deque.AddFirst(n);
        
        while(deque.Count > 0)
        {
            int cur = deque.First.Value;
            deque.RemoveFirst();
            
            if(cur == k) break;
            
            int next = cur * 2;
            if(next < max && dist[next] > dist[cur])
            {
                dist[next] = dist[cur];
                deque.AddFirst(next);
            }
                
            
            int[] moves = {cur - 1, cur + 1};
            foreach(var nx in moves)
            {
                if(nx >= 0 && nx < max && dist[nx] > dist[cur] + 1)
                {
                    dist[nx] = dist[cur] + 1;
                    deque.AddLast(nx);
                }
            }
        }
        
        Console.WriteLine(dist[k]);
    }
}