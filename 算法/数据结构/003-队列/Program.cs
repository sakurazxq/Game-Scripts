using System;
using System.Collections;
using System.Collections.Generic;

namespace _003_队列
{
    class Program
    {
        static void Main(string[] args)
        {
            //Queue<int> queue = new Queue<int>();
            //IQueue<int> queue = new SeqQueue<int>();
            IQueue<int> queue = new LinkQueue<int>();

            queue.Enqueue(12); //队首
            queue.Enqueue(45);
            queue.Enqueue(67);
            queue.Enqueue(89);  //队尾

            Console.WriteLine(queue.Count);
            int i = queue.Dequeue();   //取得队首元素并删除
            Console.WriteLine(i);
            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Peek()); //取得队首元素不删除
            Console.WriteLine(queue.Count);
            queue.Clear();
            Console.WriteLine(queue.Count);
            Console.ReadKey();
        }
    }
}
