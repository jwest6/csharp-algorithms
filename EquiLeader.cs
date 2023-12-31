/*
A non-empty array A consisting of N integers is given.

The leader of this array is the value that occurs in more than half of the elements of A.

An equi leader is an index S such that 0 ≤ S < N − 1 and two sequences A[0], A[1], ..., A[S] and A[S + 1], A[S + 2], ..., A[N − 1] have leaders of the same value.

For example, given array A such that:

    A[0] = 4
    A[1] = 3
    A[2] = 4
    A[3] = 4
    A[4] = 4
    A[5] = 2
we can find two equi leaders:

0, because sequences: (4) and (3, 4, 4, 4, 2) have the same leader, whose value is 4.
2, because sequences: (4, 3, 4) and (4, 4, 2) have the same leader, whose value is 4.
The goal is to count the number of equi leaders.

Write a function:

class Solution { public int solution(int[] A); }

that, given a non-empty array A consisting of N integers, returns the number of equi leaders.

For example, given:

    A[0] = 4
    A[1] = 3
    A[2] = 4
    A[3] = 4
    A[4] = 4
    A[5] = 2
the function should return 2, as explained above.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [1..100,000];
each element of array A is an integer within the range [−1,000,000,000..1,000,000,000].
*/
using System;

class Solution
{
    public int solution(int[] A)
    {
        int candidate = -1;  // Candidate for the leader
        int count = 0;  // Count of the candidate

        // Find a candidate for the leader
        foreach (int num in A)
        {
            if (count == 0)
            {
                candidate = num;
                count++;
            }
            else if (candidate == num)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        // Check if the candidate is the leader
        int leader = -1;
        int leaderCount = 0;

        foreach (int num in A)
        {
            if (num == candidate)
            {
                leaderCount++;
            }
        }

        if (leaderCount <= A.Length / 2)
        {
            return 0;  // No leader, so no equi leaders
        }

        int equiLeaderCount = 0;
        int leftLeaderCount = 0;
        int rightLeaderCount = leaderCount;

        for (int i = 0; i < A.Length - 1; i++)
        {
            if (A[i] == candidate)
            {
                leftLeaderCount++;
                rightLeaderCount--;
            }

            if (leftLeaderCount > (i + 1) / 2 && rightLeaderCount > (A.Length - i - 1) / 2)
            {
                equiLeaderCount++;
            }
        }

        return equiLeaderCount;
    }
}
