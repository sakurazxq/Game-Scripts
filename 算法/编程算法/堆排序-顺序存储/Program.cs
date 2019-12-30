using System;

namespace 堆排序_顺序存储
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 50, 10, 90, 30, 70, 40, 80, 60, 20 };
            HeapSort(data);
            foreach (var i in data)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public static void HeapSort(int[] data)
        {
            for (int i = data.Length / 2; i >= 1; i--)  //遍历树的所有非叶子节点，把这些节点对应的子树变成子大顶堆。for循环之后，二叉树变为大顶堆
            {
                HeapAjust(i, data, data.Length);
            }

            for(int i = data.Length;i > 1; i--) //将根节点和树的最后一个节点交换数据，则最大值放在树的最后一个节点，次大值放在倒数第二个节点...最后的data数组为有序序列
            {
                int temp1 = data[0];
                data[0] = data[i - 1];
                data[i - 1] = temp1;
                HeapAjust(1, data, i - 1);
                
            }
        }

        private static void HeapAjust(int numberToAjust,int[] data,int maxNumber)
        {
            int maxNodeNumber = numberToAjust;  //最大节点的编号
            int tempI = numberToAjust;
            while (true)  //上层节点的数据如果交换到下层，则需要一直向下判断是否交换
            {
                int leftChildNumber = tempI * 2;
                int rightChildNumber = leftChildNumber + 1;
                if (leftChildNumber <= maxNumber && data[leftChildNumber - 1] > data[maxNodeNumber - 1])
                {
                    maxNodeNumber = leftChildNumber;
                }
                if (rightChildNumber <= maxNumber && data[rightChildNumber - 1] > data[maxNodeNumber - 1])
                {
                    maxNodeNumber = rightChildNumber;
                }
                if (maxNodeNumber != tempI)  //如果发现了一个比i大的节点，交换i和maxNodeNumber中的数据
                {
                    int temp = data[tempI - 1];
                    data[tempI - 1] = data[maxNodeNumber - 1];
                    data[maxNodeNumber - 1] = temp;
                    tempI = maxNodeNumber;
                }
                else  //如果未交换则退出循环
                {
                    break;
                }
            }
        }
    }
}
