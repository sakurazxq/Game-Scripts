﻿using System;

namespace 最大子数组问题_分治法
{
    class Program
    {
        struct SubArray  //最大子数组的结构体
        {
            public int startIndex;
            public int endIndex;
            public int total;
        }

        static void Main(string[] args)
        {
            int[] priceArray = { 100, 113, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97 };
            int[] pf = new int[priceArray.Length - 1];  //价格波动表
            for (int i = 1; i < priceArray.Length; i++)
            {
                pf[i - 1] = priceArray[i] - priceArray[i - 1];
            }

            SubArray subArray = GetMaxSubArray(0, pf.Length - 1, pf);
            Console.WriteLine(subArray.startIndex);
            Console.WriteLine(subArray.endIndex);
            Console.ReadKey();
        }

        static SubArray GetMaxSubArray(int low,int high,int[] array)   //取得数组从low到high索引的最大子数组
        {
            if (low == high)
            {
                SubArray subarray ;
                subarray.startIndex = low;
                subarray.endIndex = high;
                subarray.total = array[low];
                return subarray;
            }

            int mid = (low + high) / 2;
            SubArray subArray1 = GetMaxSubArray(low, mid, array);  //从低区间找最大子数组
            SubArray subArray2 = GetMaxSubArray(mid + 1, high, array);  //从高区间找最大子数组

            //从【low，mid】找到最大子数组【i，mid】
            int total1 = array[mid];
            int startIndex = mid;
            int totalTemp = 0;
            for (int i = mid; i >= low; i--)
            {
                totalTemp += array[i];
                if (totalTemp > total1)
                {
                    total1 = totalTemp;
                    startIndex = i;
                }
            }

            //从【mid+1，high】找到最大子数组【mid+1，j】
            int total2 = array[mid + 1];
            int endIndex = mid + 1;
            totalTemp = 0;
            for (int j = mid +1; j <=high; j++)
            {
                totalTemp += array[j];
                if (totalTemp > total2)
                {
                    total2 = totalTemp;
                    endIndex = j;
                }
            }
            
            //比较三种情况
            SubArray subArray3;
            subArray3.startIndex = startIndex;
            subArray3.endIndex = endIndex;
            subArray3.total = total1 + total2;
            if (subArray1.total >= subArray2.total&&subArray1.total >= subArray3.total)
            {
                return subArray1;
            }
            else if (subArray2.total >= subArray1.total && subArray2.total >= subArray3.total)
            {
                return subArray2;
            }
            else
            {
                return subArray3;
            }
        }
    }
}
