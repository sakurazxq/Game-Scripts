using System;

namespace 钱币找零问题_贪心算法
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] count = { 3, 0, 2, 1, 0, 3, 5 };
            int[] amount = { 1, 2, 5, 10, 20, 50, 100 };
            int[] result = Change(320, count, amount);
            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }

        public static int[] Change(int k,int[] count,int[] amount) //k为要换的钱数
        {
            if (k == 0) return new int[amount.Length + 1];
            int total = 0;
            int index = amount.Length - 1;  //此时要换面额钱币的索引
            int[] result = new int[amount.Length + 1];  //存储每个面额的钱币要换多少张
            while (true)
            {
                if(k <= 0 || index <= -1) break;
                if(k > count[index] * amount[index])  //该面额的钱不够换时
                {
                    result[index] = count[index];
                    k -= count[index] * amount[index];
                }
                else  //够换时
                {
                    result[index] = k / amount[index];
                    k -= result[index] * amount[index];
                }
                index--;
            }
            result[amount.Length] = k;  //result数组的最后一位存储还剩多少钱无法换
            return result;
        }
    }
}
