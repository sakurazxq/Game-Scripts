using System;

namespace _008_快速排序
{
    class Program
    {
        //对数组中索引从left到right之间的数做排序
        static void QuickSort(int[] dataArray,int left,int right)
        {
            if (left < right)
            {
                int x = dataArray[left];   //基准数
                int i = left;
                int j = right;

                while (i<j)  //当i=j时说明找到的中间位置，循环结束
                {
                    //从后往前比较，找一个比x小或者相等的数字，放在位于i位置的坑里
                    while (i < j)
                    {                       
                        if (dataArray[j] <= x)
                        {
                            dataArray[i] = dataArray[j];
                            break;
                        }
                        else
                        {
                            j--;
                        }
                    }

                    //从前往后比较，找一个比x大的数字，放在位于j位置的坑里
                    while (i < j)
                    {
                        if (dataArray[i] > x)
                        {
                            dataArray[j] = dataArray[i];
                            break;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }

                dataArray[i] = x;  //现在i=j是中间位置
                QuickSort(dataArray, left,i - 1);   //递归
                QuickSort(dataArray, i + 1, right);
            }
        }

        static void Main(string[] args)
        {
            int[] data = new int[] { 42, 58, 34, 27, 8, 53, 42 };
            QuickSort(data, 0, data.Length - 1);
            foreach (var temp in data)
            {
                Console.WriteLine(temp);
            }
            Console.ReadKey();
        }
    }
}
