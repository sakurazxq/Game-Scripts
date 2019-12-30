using System;

namespace _01背包问题_递归实现_不带备忘的自顶向下法_
{
    class Program
    {
        static void Main(string[] args)
        {
            int m;  //背包容量
            int[] w = { 0, 3, 4, 5 }; //每个物品重量
            int[] p = { 0, 4, 5, 6 }; //每个物品价值
            Console.WriteLine(UpDown(10, 3, w, p));
            Console.WriteLine(UpDown(3, 3, w, p));
            Console.WriteLine(UpDown(4, 3, w, p));
            Console.WriteLine(UpDown(5, 3, w, p));
            Console.WriteLine(UpDown(7, 3, w, p));
            Console.ReadKey();
        }

        public static int UpDown(int m,int i,int[] w,int[] p)  //返回值是m可以存储的最大价值
        {
            if (i == 0 || m == 0) return 0;
            if (w[i] > m)
            {
                return UpDown(m, i - 1, w, p);
            }
            else
            {
                int maxValue1 = UpDown(m - w[i], i - 1, w, p) + p[i];
                int maxValue2 = UpDown(m, i - 1, w, p);
                if (maxValue1 > maxValue2)
                {
                    return maxValue1;
                }
                return maxValue2;
            }
        }
    }
}
