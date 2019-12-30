using System;
using System.Collections.Generic;
using System.Text;

namespace 二叉排序树_链式存储
{
    class BSNode
    {
        public BSNode LeftChild { get; set; }
        public BSNode RightChild { get; set; }
        public BSNode Parent { get; set; }
        public int Data { get; set; }

        public BSNode()
        {

        }

        public BSNode(int item)
        {
            this.Data = item;
        }
    }
}
