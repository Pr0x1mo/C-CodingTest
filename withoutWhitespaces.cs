using System;
using System.IO;
using System.Linq;

public class HelloWorld
{
    static public void Main()
    {
        String line;
        line = Console.ReadLine();
        int[] input = line.Split().Select(str => int.Parse(str)).ToArray();
        int N = input[0];
        int C = input[1];
        int K = input[2];
        String S = Console.ReadLine();

        long out_ = Count(N, C, K, S);
        Console.Out.WriteLine(out_);
    }

    static long Count(int N, int C, int K, String S)
    {
        long[] dp = new long[N + 1];
        dp[0] = 1;  // Base case: one way to split an empty string
        long MOD = (long)Math.Pow(10, K);

        for (int i = 1; i <= N; i++)
        {
            dp[i] = 0;
            for (int j = 1; j <= Math.Min(i, 10); j++)  // Consider numbers up to 10 digits
            {
                if (S[i-j] == '0' && j > 1) continue;  // Skip if segment starts with zero and is not a single digit

                // Extract the substring and compare directly to C without converting to long
                string currentNumber = S.Substring(i-j, j);
                if (currentNumber.Length < 10 || (currentNumber.Length == 10 && currentNumber.CompareTo("2147483647") <= 0))
                {
                    int num = int.Parse(currentNumber);
                    if (num > C) continue;
                }
                else
                {
                    continue;
                }

                dp[i] = (dp[i] + dp[i-j]) % MOD;  // Update the number of ways
            }
        }

        return dp[N] % MOD;
    }
}
