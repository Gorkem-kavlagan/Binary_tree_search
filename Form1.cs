using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalÖdevProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class TreeNode { 
            public int numara; 
            public TreeNode sol; 
            public TreeNode sag; 
        }

        public class BinarySearchTree
        {
            private TreeNode kok;

            public int y = 40;
            public int x=200;
            public int a = 0;
            Boolean yon = false;
            public void Insert(int numara) {
                y = 40;
                x = 200;
                a = 0;
                kok = Insert(kok, numara);
            }

            public ListBox dgmknm = new ListBox();
            private TreeNode Insert(TreeNode node, int numara)
            {

                if (node == null) {

                   Label gdugum = new Label();
                   gdugum.Text = numara.ToString();
                    if (dgmknm.Items.Contains(x.ToString()+"+"+y.ToString()))
                    {
                        
                        if (yon==false)
                        {
                            x += 20;
                        }
                        
                    }

                    if (dgmknm.Items.Contains(x.ToString() + "+" + y.ToString()))
                    {
                        if (yon == true)
                        {
                            x -= 20;
                        }
                    }
                    gdugum.Location = new Point(x,y);
                   dgmknm.Items.Add(x + "+" + y);
                    gdugum.Visible = true;
                   Form1.ActiveForm.Controls.Add(gdugum);
                    gdugum.Visible = true;
                 
                   return new TreeNode { numara = numara };
                };

                if (numara < node.numara)
                {
                    y += (40 - a * 5);
                    x -= (60 - a * 5);
                    yon = false;
                    node.sol = Insert(node.sol, numara);
                }
                else if (numara > node.numara){
                    y += (40 - a * 5);
                    x += (60-a*5);
                    yon = true;
                    node.sag = Insert(node.sag, numara);
                }

                a++;
                return node;
            }

            public bool Search(int data) { 
                return Search(kok, data); 
            }

            private bool Search(TreeNode node, int data)
            {
                if (node == null) return false;

                if (data < node.numara) return Search(node.sol, data); if (data > node.numara) return Search(node.sag, data);

                return true;
            }

            public int FindMin() {
                return FindMin(kok).numara; 
            }

            private TreeNode FindMin(TreeNode node)
            {
                if (node.sol == null) return node;

                return FindMin(node.sol);
            }

            public int FindMax() { 
                return FindMax(kok).numara; 
            }

            private TreeNode FindMax(TreeNode node)
            {
                if (node.sag == null) return node;

                return FindMax(node.sag);
            }

            public void InOrderTraversal(ref string result) { 
                InOrderTraversal(kok, ref result); 
            }

            private void InOrderTraversal(TreeNode node, ref string result)
            {
                if (node == null) return;

                InOrderTraversal(node.sol, ref result); result += node.numara + " "; InOrderTraversal(node.sag  , ref result);
            }

            public string orders;

            public void Preorder()
            {
                _Preorder(kok);
            }

            
            private void _Preorder(TreeNode node)
            {
                if (node != null)
                {
                    
                    orders += node.numara.ToString() + "-";
                    _Preorder(node.sol);
                    _Preorder(node.sag);
                }
            }

            public void Inorder()
            {
                _Inorder(kok);
            }

            private void _Inorder(TreeNode node)
            {
                if (node != null)
                {
                    _Inorder(node.sol);
                    orders += node.numara.ToString() + "-";
                    _Inorder(node.sag);
                }
            }

            public void Postorder()
            {
                _Postorder(kok);
            }

            private void _Postorder(TreeNode node)
            {
                if (node != null)
                {
                    _Postorder(node.sol);
                    _Postorder(node.sag);
                    orders += node.numara.ToString() + "-";
                }
            }
        }

        BinarySearchTree iaa = new BinarySearchTree();

        
        public int veri;
        private void button1_Click(object sender, EventArgs e)
        {
            veri = Convert.ToInt32(textBox1.Text);
            iaa.Insert(veri);
            textBox1.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           veri = Convert.ToInt32(textBox2.Text);
            if (iaa.Search(veri)==true) {
                MessageBox.Show("Var");
            }
            else
            {
                MessageBox.Show("Yok");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = iaa.FindMin().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = iaa.FindMax().ToString();
        }

        public TextBox ordrtxt;
        private void Form1_Load(object sender, EventArgs e)
        {
            iaa.x = (this.Width - 200) / 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            iaa.orders = "";
            iaa.Preorder();
            iaa.orders = iaa.orders.Substring(0, iaa.orders.Length - 1);
            textBox5.Text = iaa.orders;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            iaa.orders = "";
            iaa.Inorder();
            iaa.orders = iaa.orders.Substring(0, iaa.orders.Length - 1);
            textBox5.Text = iaa.orders;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            iaa.orders = "";
            iaa.Postorder();
            iaa.orders = iaa.orders.Substring(0, iaa.orders.Length - 1);
            textBox5.Text = iaa.orders;
        }
    }
}
