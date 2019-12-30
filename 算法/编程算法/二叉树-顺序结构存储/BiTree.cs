using System;
using System.Collections.Generic;
using System.Text;

namespace 二叉树_顺序结构存储
{  //如果节点是空的，则这个节点所在的数组位置，设置为-1
    class BiTree<T>
    {
        private T[] data;
        private int count = 0;

        public BiTree(int capacity)   //这个参数是容量
        {
            data = new T[capacity];
        }

        public bool Add(T item)
        {
            if (count >= data.Length)
            {
                return false;
            }
            data[count] = item;
            count++;
            return true;
        }

        public void FirstTraversal()
        {
            FirstTraversal(0);
        }

        private  void FirstTraversal(int index)
        {
            if (index >= count) return;
            int number = index + 1;  //得到要遍历的这个节点的编号
            if (data[index].Equals(-1)) return;
            Console.Write(data[index] + " ");
            int leftNumber = number * 2;  //得到左子节点的编号
            int rightNumber = number * 2 + 1;  //得到右子节点的编号
            FirstTraversal(leftNumber - 1);
            FirstTraversal(rightNumber - 1);
        }

        public void MiddleTraversal()
        {
            MiddleTraversal(0);
        }

        private void MiddleTraversal(int index)
        {
            if (index >= count) return;
            int number = index + 1;  //得到要遍历的这个节点的编号
            if (data[index].Equals(-1)) return;
            int leftNumber = number * 2;  //得到左子节点的编号
            int rightNumber = number * 2 + 1;  //得到右子节点的编号
            MiddleTraversal(leftNumber - 1);
            Console.Write(data[index] + " ");
            MiddleTraversal(rightNumber - 1);
        }

        public void LastTraversal()
        {
            LastTraversal(0);
        }

        private void LastTraversal(int index)
        {
            if (index >= count ) return;
            int number = index + 1;  //得到要遍历的这个节点的编号
            if (data[index].Equals(-1)) return;
            int leftNumber = number * 2;  //得到左子节点的编号
            int rightNumber = number * 2 + 1;  //得到右子节点的编号
            LastTraversal(leftNumber - 1);
            LastTraversal(rightNumber - 1);
            Console.Write(data[index] + " ");
        }

        public void LayerTraversal()
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(-1)) continue;
                Console.Write(data[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
