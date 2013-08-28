using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTreeMattPhillips
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tree tree = new Tree();
            string treeString = "";

            tree.addRc(5);
            tree.addRc(80);
            tree.addRc(52);
            tree.addRc(15);
            tree.addRc(64);
            tree.addRc(73);
            tree.addRc(100);
            tree.addRc(4);
            tree.addRc(96);

            tree.PrintBinaryTree(null, ref treeString);
            Console.WriteLine(treeString);
        }
    }
}
