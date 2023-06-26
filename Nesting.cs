/*
A string S consisting of N characters is called properly nested if:

S is empty;
S has the form "(U)" where U is a properly nested string;
S has the form "VW" where V and W are properly nested strings.
For example, string "(()(())())" is properly nested but string "())" isn't.

Write a function:

class Solution { public int solution(string S); }

that, given a string S consisting of N characters, returns 1 if string S is properly nested and 0 otherwise.

For example, given S = "(()(())())", the function should return 1 and given S = "())", the function should return 0, as explained above.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [0..1,000,000];
string S is made only of the characters '(' and/or ')'.
*/
using System;
using System.Collections.Generic;

class Solution
{
    public int solution(string S)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in S)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                if (stack.Count == 0 || stack.Peek() != '(')
                {
                    return 0;  // Invalid nesting
                }

                stack.Pop();
            }
        }

        if (stack.Count == 0)
        {
            return 1;  // Properly nested
        }
        else
        {
            return 0;  // Invalid nesting
        }
    }
}
