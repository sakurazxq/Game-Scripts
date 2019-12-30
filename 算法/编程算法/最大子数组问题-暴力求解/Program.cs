using System;

namespace 编程算法
{
    class Program
    {//暴力求解
        static void Main(string[] args)
        {
            int[] priceArray = { 100, 113, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97 };
            int[] priceFluctuationArray = new int[priceArray.Length - 1];   //价格波动表
            for (int i = 1; i < priceArray.Length; i++)
            {
                priceFluctuationArray[i - 1] = priceArray[i] - priceArray[i - 1];
            }

            int total = priceFluctuationArray[0];   //默认数组的第一个元素是最大子数组
            int startIndex = 0;
            int endIndex = 0;
            for (int i = 0; i < priceFluctuationArray.Length; i++)
            {

                for (int j = i; j < priceFluctuationArray.Length; j++)  //由i和j就确定了一个子数组
                {
                    int totalTemp = 0;  //临时最大子数组的和
                    for (int index = i; index < j+1; index++)
                    {
                        totalTemp += priceFluctuationArray[index];
                    }
                    if (totalTemp > total)
                    {
                        total = totalTemp;
                        startIndex = i;
                        endIndex = j;
                    }
                }
            }

            Console.WriteLine("startIndex:" + startIndex);
            Console.WriteLine("endIndex:" + endIndex);
            Console.ReadKey();
        }
    }
}
