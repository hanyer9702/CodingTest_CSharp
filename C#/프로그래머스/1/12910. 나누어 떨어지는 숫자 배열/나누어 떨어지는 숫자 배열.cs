using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] arr, int divisor) {
        List<int> list = new List<int>();
        
        foreach(var num in arr)
        {
            if(num % divisor == 0)
            {
                list.Add(num);
            }
        }
        
        if(list.Count == 0)
            list.Add(-1);
        
        list.Sort();
        
        int[] answer = list.ToArray();
        return answer;
    }
}
