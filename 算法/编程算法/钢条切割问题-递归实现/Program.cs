using System;

namespace 钢条切割问题_递归实现
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;  //要切割的钢条的长度
            int[] p = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }; //索引代表钢条的长度，值代表价格

            Console.WriteLine(UpDown(0, p));
            Console.WriteLine(UpDown(1, p));
            Console.WriteLine(UpDown(2, p));
            Console.WriteLine(UpDown(3, p));
            Console.WriteLine(UpDown(4, p));
            Console.WriteLine(UpDown(5, p));
            Console.WriteLine(UpDown(6, p));
            Console.WriteLine(UpDown(7, p));
            Console.WriteLine(UpDown(8, p));
            Console.WriteLine(UpDown(9, p));
            Console.WriteLine(UpDown(10, p));
            Console.ReadKey();
        }

        public static int UpDown(int n,int[] p)  //求得长度为n的钢条的最大收益
        {
            if (n == 0) return 0;
            int tempMaxPrice = 0;
            for (int i = 1; i <= n; i++)
            {
                int maxPrice = p[i] + UpDown(n - i, p);  //从钢条的左边切下长度为i的一段，只对右边剩下长度为n-i的一段继续进行切割
                if (maxPrice > tempMaxPrice)
                {
                    tempMaxPrice = maxPrice;
                }
            }
            return tempMaxPrice;
        }
    }
}
