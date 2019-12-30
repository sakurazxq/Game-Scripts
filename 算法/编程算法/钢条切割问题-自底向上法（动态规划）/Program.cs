using System;

namespace 钢条切割问题_自底向上法_动态规划_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] result = new int[11];//保存子问题的解
            int[] p = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }; //索引代表钢条的长度，值代表价格

            Console.WriteLine(ButtomUp(0, p, result));
            Console.WriteLine(ButtomUp(1, p, result));
            Console.WriteLine(ButtomUp(2, p, result));
            Console.WriteLine(ButtomUp(3, p, result));
            Console.WriteLine(ButtomUp(4, p, result));
            Console.WriteLine(ButtomUp(5, p, result));
            Console.WriteLine(ButtomUp(6, p, result));
            Console.WriteLine(ButtomUp(7, p, result));
            Console.WriteLine(ButtomUp(8, p, result));
            Console.WriteLine(ButtomUp(9, p, result));
            Console.WriteLine(ButtomUp(10, p, result));
            Console.ReadKey();
        }

        public static int ButtomUp(int n,int[] p,int[] result)
        {
            for (int i = 1; i <= n; i++)
            {
                //下面取得钢条长度为i时的最大收益
                int tempMaxPrice = -1;
                for (int j = 1; j <= i; j++)
                {
                    int maxPrice = p[j] + result[i - j];
                    if (maxPrice > tempMaxPrice)
                    {
                        tempMaxPrice = maxPrice;
                    }
                }
                result[i] = tempMaxPrice;
            }
            return result[n];
        }
    }
}
