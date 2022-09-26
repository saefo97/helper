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
    public partial class Primary : Form
    {
        public byte x = 0;
        public byte y = 0;

        public Master mm;

        public static Primary p;

        public Primary()
        {
            InitializeComponent();
        }

        private void Primary_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (x == 0)
            {
                if (MessageBox.Show(
                "هل أنت متأكد من أنك تود إغلاق البرنامج",
                "رسالة تنبيه",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.RightAlign
                ) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SignIn();
        }

        private void Primary_Load(object sender, EventArgs e)
        {
            p = this;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
        public void SignIn()
        {
            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("الرجاء ادخال اسم المستخدم و كلمة المرور");
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("الرجاء ادخال اسم المستخدم");
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("الرجاء ادخال كلمة المرور");
            }
            else
            {
                string a = AppsHelper.ReturnValue("select UserPassword from Users where UserName=N'" + textBox1.Text + "'");
                string b = AppsHelper.ReturnValue("select UserRole from Users where UserName=N'" + textBox1.Text + "'");

                if (string.IsNullOrEmpty(a))
                {
                    MessageBox.Show("الرجاء التأكد من اسم المستخدم");
                }
                else
                {
                    if (a != textBox2.Text)
                    {
                        MessageBox.Show("الرجاء التأكد من كلمة المرور");
                    }
                    else
                    {
                        if (y == 0)
                        {
                            mm = new Master();
                        }
                        else
                        {
                            y = 0;
                        }
                        mm.userName.Text = textBox1.Text;
                        mm.userRole.Text = b;
                        mm.Show();
                        AppsHelper.NewHistory(textBox1.Text, "تسجيل الدخول", "قام المستخدم بتسجيل الدخول إلى البرنامج");
                        this.Hide();
                    }

                }

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.ActiveControl = textBox2;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.SignIn();
            }
        }
    }
}
