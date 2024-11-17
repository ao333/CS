/*Charlemagne, the King of Frankia, is considering building some castles on the border with Servia. The border is divided into N segments.
The King knows the height of the terrain in each segment of the border. The height of each segment of terrain is stored in array A,
with A[P] denoting the height of the P-th segment of the border. The King has decided to build a castle on top of every hill and in the bottom of every valley.
Let[P..Q] denote a group of consecutive segments from P to Q inclusive such that (0<=P<=Q<=N-1).
Segments [P..Q] form a hill or a valley if all the following conditions are satisfied:

The terrain height of each segment from P to Q is the same (A[P] = A[P+1] =... = A[Q]);
If P > 0 then A[P-1] < A[P] (for a hill) or A[P-1] > A[P] (for a valley);
If Q < N-1 then A[Q+1] < A[Q] (for a hill) or A[Q+1] > A[Q] (for a valley);

That is, a hill is higher than its surroundings and a valley is lower than its surroundings.
Note that if the surroundings on either side of the hill or valley don't exist (i.e. at the edges of the area under consideration, where P=0 or Q=N-1),
then the condition is considered satisified for that side of the hill/valley. The king is wondering how many castles is he going to build.

For example, consider the following array A=[2,2,3,4,3,3,2,2,1,1,2,5]. There are two hills:[3..3] and [11..11].
There are also two valleys: [0..1] and [8..9]. There are no other suitable places for castles.

Write a c# function: class Solution {public int solution(int[] A); } that,
given an array A consisting of N intergers, as explained above, returns the total number of hills and valleys.

For example, given array A as described above, the function should return 4. Given array A = [-3, -3] describing segments with a terrain height below 0,
segment [0..1] forms both a hill and a valley, and only one castle can be built, so the function should return 1.*/

class Solution {
    public int solution(int[] A) {
        int len = A.Length;
        if (len == 0) return 0;
        
        int castle = 0;
        int prev = A[0];
        for (int i = 1; i < len - 1; i++)
            if (((A[i] - prev) * (A[i + 1] - A[i])) < 0) {
                castle++;
                prev = A[i];
            }
        if (castle == 0) {
            if (A[0] == A[len - 1])
                return 1;
            return 2;
        }
        return castle + 2;
    }
}