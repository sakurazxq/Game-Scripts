using System;

namespace 二叉树_顺序结构存储
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] data = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            BiTree<char> tree = new BiTree<char>(10);
            for (int i = 0; i < data.Length; i++)
            {
                tree.Add(data[i]);
            }
            tree.FirstTraversal();
            Console.WriteLine();
            tree.MiddleTraversal();
            Console.WriteLine();
            tree.LastTraversal();
            Console.WriteLine();
            tree.LayerTraversal();
            Console.ReadKey();
        }
    }
}
