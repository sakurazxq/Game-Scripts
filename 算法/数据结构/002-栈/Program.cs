using System;
using System.Collections;
using System.Collections.Generic;

namespace _002_栈
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stack<char> stack = new Stack<char>();
            //使用自定义的顺序栈：
            //IStackDS<char> stack = new SeqStack<char>();
            //使用自定义的链栈：
            IStackDS<char> stack = new LinkStack<char>();

            stack.Push('a');
            stack.Push('b');
            stack.Push('c');
            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.Pop());   //找到栈顶元素并删除
            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.Peek());  //找到栈顶元素但不删除
            Console.WriteLine(stack.Count);
            stack.Clear();
            Console.WriteLine(stack.Count);
            Console.ReadKey();
        }
    }
}
