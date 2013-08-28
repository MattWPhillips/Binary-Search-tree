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
        public void add(int data)
        {
            if (top == null)
            {
                Node newNode = new Node(data);
                top = newNode;
                return;
            }
            Node currentNode = top;
            bool nodeAdded = false;
            do
            {
                if (data < currentNode.data)
                {
                    if (currentNode.low == null)
                    {
                        Node newNode = new Node(data);
                        currentNode.low = newNode;
                        nodeAdded = true;
                    }
                    else
                    {
                        currentNode = currentNode.low;
                    }
                }
                if (data >= currentNode.data)
                {
                    if (currentNode.high == null)
                    {
                        Node newNode = new Node(data);
                        currentNode.high = newNode;
                        nodeAdded = true;
                    }
                    else
                    {
                        currentNode = currentNode.high;
                    }
                }
            } while (!nodeAdded);
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

        public void PrintBinaryTree(Node N, ref string s)
        {
            if (N == null)
            {
                N = top;
            }
            if (N.low != null)
            {
                PrintBinaryTree(N.low, ref s);
                s = s + N.data.ToString().PadLeft(3);
            }
            else
            {
                s = s + N.data.ToString().PadLeft(3);
            }
            if (N.high != null)
            {
                PrintBinaryTree(N.high, ref s);
            }
        }
    }
}
