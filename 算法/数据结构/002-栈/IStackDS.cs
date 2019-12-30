using System;
using System.Collections.Generic;
using System.Text;

namespace _002_栈
{
    interface IStackDS<T>
    {
        int Count { get; }
        int GetLength();
        bool IsEmpty();
        void Clear();
        void Push(T item);
        T Pop();
        T Peek();
    }
}
