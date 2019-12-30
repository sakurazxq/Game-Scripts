using System;

namespace _006_直接插入排序
{
    class Program
    {
        static void InsertSort(int[] dataArray)
        {
            for (int i = 1; i < dataArray.Length; i++)
            {
                int iValue = dataArray[i];
                bool isInsert = false;
                for (int j = i-1; j >= 0; j--) 
                {
                    if (dataArray[j] > iValue)
                    {
                        dataArray[j + 1] = dataArray[j];
                    }
                    else
                    {//发现一个比i小的值就不动了，终止j层循环
                        dataArray[j + 1] = iValue;
                        isInsert = true;
                        break;
                    }
                }
                if (isInsert == false)//若iValue前面的元素都比它大
                {
                    dataArray[0] = iValue;
                }
            }
        }

        static void Main(string[] args)
        {
            int[] data = new int[] { 42, 58, 34, 27, 8, 53, 42 };
            InsertSort(data);
            foreach (var temp in data)
            {
                Console.WriteLine(temp);
            }
            Console.ReadKey();
        }
    }
}
