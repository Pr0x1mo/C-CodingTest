using System;
using System.IO;
using System.Linq;

public class HelloWorld
{
    static public void Main()
    {
        String line;
        line = Console.ReadLine();
        int N = Convert.ToInt32(line);
        line = Console.ReadLine();
        int K = Convert.ToInt32(line);
        line = Console.ReadLine();
        int[] cost = new int[N];
        cost = line.Split().Select(str => int.Parse(str)).ToArray();
        line = Console.ReadLine();
        int[] sell = new int[N];
        sell = line.Split().Select(str => int.Parse(str)).ToArray();

        long out_ = solution(N, K, cost, sell);
        Console.Out.WriteLine(out_);
    }

    static long solution(int N, int K, int[] cost, int[] sell)
    {
        long currentMoney = K;
        long totalProfit = 0;

        // Calculate profit for each item
        var items = new (int cost, int sell, int profit)[N];
        for (int i = 0; i < N; i++)
        {
            items[i] = (cost[i], sell[i], sell[i] - cost[i]);
        }

        // Sort items based on profit in descending order
        var profitableItems = items.Where(item => item.profit > 0)
                                   .OrderByDescending(item => item.profit)
                                   .ToArray();

        // Process each item to maximize the profit
        foreach (var item in profitableItems)
        {
            if (currentMoney >= item.cost) // Can buy this item
            {
                currentMoney -= item.cost;   // Buy item
                currentMoney += item.sell;   // Sell item
                totalProfit += item.profit;  // Increase total profit
            }
        }

        return totalProfit;
    }
}
