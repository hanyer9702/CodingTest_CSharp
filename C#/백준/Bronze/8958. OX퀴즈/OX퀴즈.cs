using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; i++)
        {
            string s = Console.ReadLine();
            int sum = 0;
            int cnt = 0;
            for(int j = 0; j < s.Length; j++)
            {
                char c = s[j];
                if(c == 'O')
                {
                    cnt++;
                    sum += cnt;
                }
                else
                {
                    cnt = 0;
                }
            }
            Console.WriteLine(sum);
        }
    }
}