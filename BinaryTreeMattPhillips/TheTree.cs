using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeMattPhillips
{
    class Node
    {
        public int data;
        public Node low;
        public Node high;
        
        //ctor then tab twice for constructor
        public Node(int data)
        {
            this.data = data;
            low = null;
            high = null;
        }
    }
    class Tree
    {
        Node top;

        public Tree()
        {
            top = null;
        }

        public Tree(int data)
        {
            top = new Node(data);
        }

        public void addRc(int data)
        {
            addR(ref top, data);
        }

        private void addR(ref Node N, int data)
        {
            if (N == null)
            {
                Node newNode = new Node(data);
                N = newNode;
                return;
            }
            if (data < N.data)
            {
                addR(ref N.low, data);
                return;
            }
            if (data >= N.data)
            {
                addR(ref N.high, data);
                return;
            }
        }

        public bool IsThere(int data) // public interface
        {
            return IsThere(this.top, data);
        }

        private bool IsThere(Node rootNode, long data) // recursive worker
        {
            if (rootNode == null)
                return false;
            else if (rootNode.data == data)
                return true;
            else if (data < rootNode.data)
                return IsThere(rootNode.low, data);
            else
                return IsThere(rootNode.high, data);
        }

        //The recursive Delete method is:

        public void Delete(int data)
        {
            if (IsThere(data) == true)
            {
                Delete(ref this.top, data);
            }
        }
        
        private void Delete(ref Node rootNode, int data)
        {
            if (rootNode != null)
            {
               if (data < rootNode.data)
                    Delete(ref rootNode.low, data);
                else if (data > rootNode.data)
                    Delete(ref rootNode.high, data);
                else // valu == rootNode.data
                {
                    if (rootNode.low == null && rootNode.high == null)
                        rootNode = null;
                    else if (rootNode.low != null && rootNode.high == null)
                        rootNode = rootNode.low;
                    else if (rootNode.low == null && rootNode.high != null)
                        rootNode = rootNode.high;
                    else // two children
                    {
                        if (rootNode.high.low == null)
                        {
                            rootNode.high.low = rootNode.low;
                            rootNode = rootNode.high;
                        }
                        else
                        {
                            Node q = rootNode.high;
                            Node p = rootNode.high;
                            while (p.low.low != null)
                                p = p.low;
                            q = p.low;
                            p.low = q.high;
                            q.low = rootNode.low;
                            q.high = rootNode.high;
                            rootNode = q;
                        }
                    } // two children
                } // valu == rootNode.data
            } // rootNode != null
        }

        public void PrintBinaryTree(Node N, ref string s)
        {
            if (N == null)
            {
                N = top;
            }
            if (N.low != null)
            {
                PrintBinaryTree(N.low, ref s);
                s = s + N.data.ToString().PadLeft(4);
            }
            else
            {
                s = s + N.data.ToString().PadLeft(4);
            }
            if (N.high != null)
            {
                PrintBinaryTree(N.high, ref s);
            }
        }
    }
}
