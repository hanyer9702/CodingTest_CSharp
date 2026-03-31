public class Solution {
    public int solution(int num) {
        int count = 0;
        
        while(num > 1)
        {
            if(num % 2 == 0)
                num = num / 2;
            else
                num = num * 3 + 1;
            
            count++;
            
            if(count > 500)
                break;
        }
        
        if(num != 1)
            count = -1;
        
        return count;
    }
}