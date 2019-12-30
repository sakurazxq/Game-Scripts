using System;
using System.Collections.Generic;
using System.Text;

namespace _002_栈
{//链栈
    class LinkStack<T> : IStackDS<T>
    {
        private Node<T> top;  //栈顶元素结点
        private int count = 0;//栈中元素个数

        public int Count
        {
            get { return count; }
        }

        public void Clear()
        {
            count = 0;
            top = null;
        }

        public int GetLength()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public T Peek()
        {
            return top.Data;
        }

        public T Pop()
        {
            T data = top.Data;
            top = top.Next;
            count--;
            return data;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = top;
            top = newNode;
            count++;
        }
    }
}
