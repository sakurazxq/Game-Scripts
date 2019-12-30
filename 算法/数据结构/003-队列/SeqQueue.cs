using System;
using System.Collections.Generic;
using System.Text;

namespace _003_队列
{//顺序队列
    class SeqQueue<T> : IQueue<T>
    {
        private T[] data;
        private int count;
        private int front;//队首,=队首元素索引-1
        private int rear;//队尾，=队尾元素索引

        public SeqQueue(int size)
        {
            data = new T[size];
            count = 0;
            front = -1;
            rear = -1;
        }

        public SeqQueue() : this(10)
        {

        }

        public int Count
        {
            get { return count; }
        }

        public void Clear()
        {
            count = 0;
            front = rear = -1;
        }

        public T Dequeue()
        {
            if (count > 0)
            {
                T temp = data[front + 1];
                front++;
                count--;
                return temp;
            }
            else
            {
                Console.WriteLine("队列为空，无法取得队首的数据");
                return default(T);
            }
        }

        public void Enqueue(T item)
        {
            if (count == data.Length)
            {
                Console.WriteLine("队列已满，不可再添加新的数据");
            }
            else
            {
                if (rear == data.Length -1)  //当队尾已满时，插入到队首
                {
                    data[0] = item;
                    rear = 0;
                }
                else
                {
                    data[rear + 1] = item;
                    rear++;
                }
                count++;
            }
        }

        public int GetLength()
        {
            return count;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public T Peek()
        {
            return data[front + 1];
        }
    }
}
