using System;

namespace 钢条切割问题_带备忘的自顶向下法_动态规划_
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = 5;  //要切割的钢条的长度
            int[] result = new int[11];//保存子问题的解
            int[] p = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }; //索引代表钢条的长度，值代表价格

            Console.WriteLine(UpDown(0, p,result));
            Console.WriteLine(UpDown(1, p,result));
            Console.WriteLine(UpDown(2, p,result));
            Console.WriteLine(UpDown(3, p,result));
            Console.WriteLine(UpDown(4, p,result));
            Console.WriteLine(UpDown(5, p,result));
            Console.WriteLine(UpDown(6, p,result));
            Console.WriteLine(UpDown(7, p,result));
            Console.WriteLine(UpDown(8, p,result));
            Console.WriteLine(UpDown(9, p,result));
            Console.WriteLine(UpDown(10, p,result));
            Console.ReadKey();
        }
        //带备忘的自顶向下法
        public static int UpDown(int n, int[] p,int[] result)   //求得长度为n的钢条的最大收益
        {
            if (n == 0) return 0;
            if (result[n] != 0)
            {
                return result[n];
            }
            int tempMaxPrice = 0;
            for (int i = 1; i <= n; i++)
            {
                int maxPrice = p[i] + UpDown(n - i, p,result);  //从钢条的左边切下长度为i的一段，只对右边剩下长度为n-i的一段继续进行切割
                if (maxPrice > tempMaxPrice)
                {
                    tempMaxPrice = maxPrice;
                }
            }
            result[n] = tempMaxPrice;
            return tempMaxPrice;
        }
    }
}
