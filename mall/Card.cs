using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mall
{
    public partial class Card : Form
    {
        public Card()
        {
            InitializeComponent();
        }
        public void plus()
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("قم بكتابة الباركود أولاً");
                goto end;
            }

            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                if (((PictureBox)flowLayoutPanel1.Controls[i]).Tag.ToString() == textBox1.Text)
                {
                    MessageBox.Show("الباركود مكرر مسبقاً");
                    goto end;
                }
            }



            PictureBox p = new PictureBox();
            AppsHelper.BarCode(textBox1.Text, p);
            p.Width = (flowLayoutPanel1.Width / 2) - 8;
            p.Height = (flowLayoutPanel1.Height / 4) - 14;
            p.Tag = textBox1.Text;
            flowLayoutPanel1.Controls.Add(p);
            textBox1.Text = "";

        end:;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            plus();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                if (((PictureBox)flowLayoutPanel1.Controls[i]).Tag.ToString() == textBox1.Text)
                {
                    flowLayoutPanel1.Controls.RemoveAt(i);
                    break;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                plus();
            }
        }

        private void toolStripStatusLabel10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int v = 0;
        private void Card_Load(object sender, EventArgs e)
        {
            if (v == 0)
            {
                AppsHelper.SetControl("select ClassName from Classes", className);

                button8.Text = ((char)0x221A).ToString();
            }
            this.ActiveControl = label1;


            AppsHelper.Read_Image1("select pic from Products where ProductName=N'" + textBox15.Text + "'", pictureBox1);
            AppsHelper.Read_Image2("select pic2 from Products where ProductName=N'" + textBox15.Text + "'", pictureBox2);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.ShowDialog();
            pictureBox1.ImageLocation = op1.FileName;
            AppsHelper.Insert_Image(op1.FileName, AppsHelper.ReturnValue("select PID from Products where ProductName=N'" + textBox15.Text + "'"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.ShowDialog();
            pictureBox2.ImageLocation = op1.FileName;
            AppsHelper.Insert_Image2(op1.FileName, AppsHelper.ReturnValue("select PID from Products where ProductName=N'" + textBox15.Text + "'"));
        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }
    }
}
