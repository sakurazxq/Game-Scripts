using System;

namespace _007_简单选择排序
{
    class Program
    {
        static void SelectSort(int[] dataArray)
        {
            for (int i = 0; i < dataArray.Length-1; i++)
            {
                int min = dataArray[i];  //找到的最小值
                int minIndex = i;
                for (int j = i+1; j < dataArray.Length; j++)
                {
                    if (dataArray[j]<min)
                    {
                        min = dataArray[j];
                        minIndex = j;
                    }
                }
                if (minIndex!= i)
                {
                    int temp = dataArray[i];
                    dataArray[i] = dataArray[minIndex];
                    dataArray[minIndex] = temp;
                }
            }
        }

        static void Main(string[] args)
        {
            int[] data = new int[] { 42, 58, 34, 27, 8, 53, 42 };
            SelectSort(data);
            foreach (var temp in data)
            {
                Console.WriteLine(temp);
            }
            Console.ReadKey();
        }
    }
}
