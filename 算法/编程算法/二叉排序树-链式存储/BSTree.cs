 using System;
using System.Collections.Generic;
using System.Text;

namespace 二叉排序树_链式存储
{
    class BSTree
    {
        BSNode root = null;

        public void Add(int item)
        {
            BSNode newNode = new BSNode(item);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                BSNode temp = root;
                while (true)
                {
                    if (item >= temp.Data)   //放在temp的右边
                    {
                        if (temp.RightChild == null)
                        {
                            temp.RightChild = newNode;
                            newNode.Parent = temp;
                            break;
                        }
                        else
                        {
                            temp = temp.RightChild;
                        }
                    }
                    else  //放在temp的左边
                    {
                        if (temp.LeftChild == null)
                        {
                            temp.LeftChild = newNode;
                            newNode.Parent = temp;
                            break;
                        }
                        else
                        {
                            temp = temp.LeftChild;
                        }
                    }
                }
            }
        }

        public void MiddleTraversal()
        {
            MiddleTraversal(root);
        }
        private void MiddleTraversal(BSNode node)  //中序遍历
        {
            if (node == null)
            {
                return;
            }
            MiddleTraversal(node.LeftChild);
            Console.Write(node.Data + " ");
            MiddleTraversal(node.RightChild);
        }

        public bool Find(int item)
        {
            //return Find(item, root);

            BSNode temp = root;
            while (true)
            {
                if (temp == null) return false;
                if (temp.Data == item) return true;
                if (item > temp.Data)
                    temp = temp.RightChild;
                else
                    temp = temp.LeftChild;
            }
        }
        private bool Find(int item,BSNode node)
        {
            if (node == null) return false;
            if (node.Data == item)
            {
                return true;
            }
            else if(item > node.Data)
            {
                return Find(item, node.RightChild);
            }
            else
            {
                return Find(item, node.LeftChild);
            }
        }

        public bool Delete(int item)
        {
            BSNode temp = root;
            while (true)
            {
                if (temp == null) return false;
                if (temp.Data == item)
                {
                    Delete(temp);
                    return true;
                }
                if (item > temp.Data)
                    temp = temp.RightChild;
                else
                    temp = temp.LeftChild;
            }
        }

        public void Delete(BSNode node)
        {
            if (node.LeftChild == null && node.RightChild == null)  //该节点是叶子节点时
            {
                if (node.Parent == null)
                {
                    root = null;
                }else if(node.Parent.LeftChild == node)
                {
                    node.Parent.LeftChild = null;
                }else if(node.Parent.RightChild == node)
                {
                    node.Parent.RightChild = null;
                }
                return;
            }
            if (node.LeftChild == null && node.RightChild != null)  //该节点只有右孩子时，好像有问题
            {
                node.Data = node.RightChild.Data;
                node.RightChild = null;
                return;
            }
            if (node.LeftChild != null && node.RightChild == null)  //该节点只有左孩子时
            {
                node.Data = node.LeftChild.Data;
                node.LeftChild = null;
                return;
            }

            BSNode temp = node.RightChild;   //该节点左右孩子都有时，取其右子树上的最小值补在该节点
            while (true)
            {
                if (temp.LeftChild != null)
                {
                    temp = temp.LeftChild;
                }
                else
                {
                    break;
                }
            }
            node.Data = temp.Data;
            Delete(temp);
        }
    }
}
