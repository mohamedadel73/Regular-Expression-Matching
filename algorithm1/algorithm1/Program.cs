using System.Diagnostics;


// Naive recursive approach with backtracking
namespace algorithm1
{
    internal class Program
    {
       
        static bool IsMatch(string s, string p, int i = 0, int j = 0)
        {
            // Base case pattern fully matched
            if (j == p.Length) return i == s.Length;

            // If string is exhausted, check if remaining pattern can be ignored (*)
            if (i == s.Length)
            {
                while (j < p.Length)
                {
                    if (j + 1 >= p.Length || p[j + 1] != '*') return false;
                    j += 2;
                }
                return true;
            }

            // Check if current characters match
            bool firstMatch = (p[j] == '.' || p[j] == s[i]);

            // If next in pattern is '*', two choices: 0 occurrences or 1+ occurrences
            if (j + 1 < p.Length && p[j + 1] == '*')
            {
                return IsMatch(s, p, i, j + 2) ||  // Skip the * pattern
                       (firstMatch && IsMatch(s, p, i + 1, j));  // Use * to match one more
            }

            // Normal match
            return firstMatch && IsMatch(s, p, i + 1, j + 1);
        }
        static void Test(string s, string p, string testName)
        {
            var stopwatch = Stopwatch.StartNew();
            bool result = IsMatch(s, p);
            stopwatch.Stop();

            Console.WriteLine($"{testName}: s=\"{s}\", p=\"{p}\" → {result}");
            Console.WriteLine($"Time: {stopwatch.Elapsed.TotalMilliseconds} ms\n");
        }
        static void Main(string[] args)
        {
            // Test Case 1
            Test("aa", "a*", "Naive Test 1");

            // Test Case 2 
            Test("mississippi", "mis*is*p*.", "Naive Test 2");

            // Test Case 3 
            Test("aab", "c*a*b", "Naive Test 3");

            // Test Case 4 
            Test("aaa", "a*a", "Naive Test 4");
        }
    }
}