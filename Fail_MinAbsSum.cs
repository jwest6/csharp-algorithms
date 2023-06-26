/*
For a given array A of N integers and a sequence S of N integers from the set {−1, 1}, we define val(A, S) as follows:

val(A, S) = |sum{ A[i]*S[i] for i = 0..N−1 }|

(Assume that the sum of zero elements equals zero.)

For a given array A, we are looking for such a sequence S that minimizes val(A,S).

Write a function:

class Solution { public int solution(int[] A); }

that, given an array A of N integers, computes the minimum value of val(A,S) from all possible values of val(A,S) for all possible sequences S of N integers from the set {−1, 1}.

For example, given array:

  A[0] =  1
  A[1] =  5
  A[2] =  2
  A[3] = -2
your function should return 0, since for S = [−1, 1, −1, 1], val(A, S) = 0, which is the minimum possible value.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [0..20,000];
each element of array A is an integer within the range [−100..100].
*/


//
//  *** I can only get 54% on this. 100% Correctness but 0 Performance.
//  *** still digging into the study materials to master the time signature
// 


using System;

class Solution {
    public int solution(int[] A) {
        int N = A.Length;
        int sum = 0;
        int maxVal = int.MinValue;

        // Calculate the sum of all elements and find the maximum absolute value
        for (int i = 0; i < N; i++) {
            sum += Math.Abs(A[i]);
            maxVal = Math.Max(maxVal, Math.Abs(A[i]));
        }

        // Initialize an array to store the counts of each absolute value
        int[] count = new int[maxVal + 1];

        // Count the occurrences of each absolute value
        for (int i = 0; i < N; i++) {
            count[Math.Abs(A[i])]++;
        }

        // Initialize the dynamic programming array
        int[] dp = new int[sum + 1];

        // Calculate the minimum value of val(A, S) for all possible sequences
        for (int i = 1; i <= maxVal; i++) {
            for (int j = 0; j < sum; j++) {
                if (dp[j] > 0) {
                    dp[j + i] = Math.Max(dp[j + i], dp[j] - count[i]);
                    dp[j - i] = Math.Max(dp[j - i], dp[j] - count[i]);
                }
            }
        }

        return dp[0];
    }
}
