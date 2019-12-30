using System;

namespace 二叉排序树_链式存储
{
    class Program
    {
        static void Main(string[] args)
        {
            BSTree tree = new BSTree();
            int[] data = { 62, 58, 88, 47, 73, 99, 35, 51, 93, 37 };   //添加的顺序要按照层序遍历
            foreach (var t in data)
            {
                tree.Add(t);
            }
            tree.MiddleTraversal();
            Console.WriteLine();
            Console.WriteLine(tree.Find(99));
            Console.WriteLine(tree.Find(100));
            tree.Delete(35);
            tree.MiddleTraversal();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
