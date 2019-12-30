using System;
using System.Collections.Generic;
using System.Text;

namespace _001_线性表
{//顺序表
    class SeqList<T> : IListDS<T>
    {
        private T[] data;
        private int count = 0;  //数据的个数

        public SeqList(int size)  //size是最大容量
        {
            data = new T[size];
            count = 0;
        }

        public SeqList() : this(10)   //默认构造函数，容量是10
        {

        }

        public int GetLength()  //取得数据的个数
        {
            return count;
        }

        public T this[int index]
        {
            get { return GetEle(index); }
        }

        public void Add(T item)
        {
            if (count == data.Length)
            {
                Console.WriteLine("当前顺序表已经存满，不能再存入");
            }
            else
            {
                data[count] = item;
                count++;
            }
        }

        public void Clear()  //清空数据
        {
            count = 0;
        }

        public T Delete(int index)
        {
            T temp = data[index];
            for (int i = index + 1; i < count; i++)
            {
                data[i - 1] = data[i];
            }
            count--;
            return temp;
        }

        public T GetEle(int index)
        {
            if(index >= 0&&index <= count - 1)
            {
                return data[index];
            }
            else
            {
                Console.WriteLine("索引不存在");
                return default(T);   //取得T类型数据的默认值
            }
        }        

        public void Insert(T item, int index)
        {
            for (int i = count - 1; i >= index; i--)
            {
                data[i + 1] = data[i];
            }
            data[index] = item;
            count++;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public int Locate(T value)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
