using System.Diagnostics;


// Optimized approach using Dynamic Programming
namespace algorithm2
{
    internal class Program
    {
        
        static bool IsMatch(string s, string p)
        {
            int m = s.Length, n = p.Length;
            bool[,] dp = new bool[m + 1, n + 1];

            // Base case: empty string matches empty pattern
            dp[0, 0] = true;

            // Handle cases where pattern starts with '*' (can match zero characters)
            for (int j = 1; j <= n; ++j)
            {
                if (p[j - 1] == '*')
                {
                    dp[0, j] = dp[0, j - 2];
                }
            }

            for (int i = 1; i <= m; ++i)
            {
                for (int j = 1; j <= n; ++j)
                {
                    if (p[j - 1] == '*')
                    {
                        // Two options: 0 times or 1+ times
                        dp[i, j] = dp[i, j - 2] ||
                                   ((p[j - 2] == '.' || p[j - 2] == s[i - 1]) && dp[i - 1, j]);
                    }
                    else
                    {
                        // Normal match with '.' or exact character
                        dp[i, j] = (p[j - 1] == '.' || p[j - 1] == s[i - 1]) && dp[i - 1, j - 1];
                    }
                }
            }
            return dp[m, n];
        }
        static void Test(string s, string p, string testName)
        {
            var stopwatch = Stopwatch.StartNew();
            bool result = IsMatch(s, p);
            stopwatch.Stop();

            Console.WriteLine($"{testName}: s=\"{s}\", p=\"{p}\" → {result}");
            Console.WriteLine($"Time taken: {stopwatch.Elapsed.TotalMilliseconds} ms\n");
            
        }
        static void Main(string[] args)
            {
            // Test Case 1 (original)
            Test("aa", "a*", "DP Test 1");

            // Test Case 2 
            Test("mississippi", "mis*is*p*.", "DP Test 2");

            // Test Case 3 
            Test("aab", "c*a*b", "DP Test 3");

            // Test Case 4 
            Test("aaa", "a*a", "DP Test 4");
        }
        }
    }

