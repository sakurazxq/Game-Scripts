using System;
using System.Collections.Generic;
using System.Linq;

namespace 活动选择问题_动态规划思路_自底向上_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] s = { 0, 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12, 24 };
            int[] f = { 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 24 };

            List<int>[,] result = new List<int>[13, 13];  //即c[i,j]，存储最后结果，默认值是null
            for (int m = 0; m < 13; m++)
            {
                for(int n = 0; n < 13; n++)
                {
                    result[m, n] = new List<int>(); //默认值是空list集合
                }
            }

            for(int j = 0; j < 13; j++)
            {
                for (int i = 0; i < j-1; i++)
                {
                    List<int> sij = new List<int>();
                    for(int number = 1;number < s.Length - 1; number++)
                    {
                        if (s[number] >= f[i] && f[number] <= s[j])
                        {
                            sij.Add(number);  //找到符合条件的k活动，添加到sij列表中
                        }
                    }
                    if (sij.Count > 0)
                    {
                        int maxCount = 0;
                        List<int> tempList = new List<int>();
                        foreach(int number in sij)
                        {
                            int count = result[i, number].Count + result[number, j].Count + 1;
                            if (count > maxCount)  //寻找conut的最大值
                            {
                                maxCount = count;
                                tempList = result[i, number].Union<int>(result[number, j]).ToList<int>(); //取两部分的并集
                                tempList.Add(number);  //再加上number，即取三部分的并集
                            }
                        }
                        result[i, j] = tempList;
                    }
                }
            }

            List<int> l = result[0, 12];
            foreach(int temp in l)
            {
                Console.WriteLine(temp);
            }
            Console.ReadKey();
        }
    }
}
