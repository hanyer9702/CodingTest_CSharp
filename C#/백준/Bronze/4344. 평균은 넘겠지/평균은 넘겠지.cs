using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int c = int.Parse(Console.ReadLine());
        for(int i = 0; i < c; i++)
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0];
            double avg = (double)(input.Sum() - n) / (double)n;
            int cnt = 0;

            for(int j = 1; j < n + 1; j++)
            {
                if(input[j] > avg)
                    cnt++;
            }
            
            double result = (double)cnt / (double)n * 100;
            Console.WriteLine(result.ToString("N3") + "%");
        }
    }
}