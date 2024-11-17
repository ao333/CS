/*There is a company that has a very creative way of managing its accounts. Everytime they want to write down a number, they shuffle its digits the following way:
they alternately write one digit from the front of the number and one digit from the back, then the second digit from the front and the second from the back,
and so on until the length of the shuffled number is the same as that of the original.

Write a function class Solution{ public int solution(int A); } that, given a positive integerA, returns its shuffled representation.
For example, given A = 123456 the function should return 162534. Given A = 130 the function should return 103.
Assume that A is an integer within the range [0..100,000,000].*/

class Solution {
    public int solution(int A) {
        string str = A.ToString();
        int left = 0;
        int right = digStr.Length - 1;
        char[] shuffled = new char[str.Length];
        int i = 0;
        
        while(left <= right) {
            shuffled[i++] = str[left];
            if(left != right)
                shuffled[i++] = str[right];
            left++;
            right--;
        }
        int sol = int.Parse(new string(shuffled));
        return sol;
    }
}