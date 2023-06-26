/**
Write a function:

class Solution { public int solution(int[] A); }

that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.

For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

Given A = [1, 2, 3], the function should return 4.

Given A = [−1, −3], the function should return 1.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [1..100,000];
each element of array A is an integer within the range [−1,000,000..1,000,000].
 */

using System;

class Solution
{
    public int solution(int[] A)
    {
        int N = A.Length;
        bool[] seen = new bool[N + 1];

        // Mark elements as seen
        for (int i = 0; i < N; i++)
        {
            if (A[i] > 0 && A[i] <= N)
            {
                seen[A[i]] = true;
            }
        }

        // Find the smallest positive integer that does not occur
        for (int i = 1; i <= N; i++)
        {
            if (!seen[i])
            {
                return i;
            }
        }

        // If all positive integers up to N are present, return N + 1
        return N + 1;
    }
}
