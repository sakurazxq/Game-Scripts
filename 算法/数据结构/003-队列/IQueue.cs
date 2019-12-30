using System;
using System.Collections.Generic;
using System.Text;

namespace _003_队列
{
    interface IQueue<T>
    {
        int Count { get; }
        int GetLength();
        bool IsEmpty();
        void Clear();
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}
