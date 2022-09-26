using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School
{
    public partial class NewEditStudent : Form
    {
        public string SID;
        public NewEditStudent()
        {
            InitializeComponent();
        }
        public int r;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text=="ادراج")
            {
                AppsHelper.InsertQuery("Students",
                    "Name+"+Name.Text,
                    "FatherName+" + FatherName.Text,
                    "MotherName+" + MotherName.Text,
                    "Mobile+" + Mobile.Text,
                    "FatherMobile+" + FatherMobile.Text,
                    "MotherMobile+" + MotherMobile.Text,
                    "Address+" + Address.Text
                    );
                string SID = AppsHelper.ReturnValue("select max(SID) from Students");

                Prices p = new Prices();
                p.Text = "نافذة تسجيل طالب";
                p.button1.Text = "تسجيل";
                p.checkBox1.Visible = true;
                p.checkBox2.Visible = true;
                p.checkBox3.Visible = true;
                p.checkBox4.Visible = true;
                p.SID = SID;
                p.ShowDialog();

                MessageBox.Show("تم انهاء عملية تسجيل الطالب بنجاح");

                if (string.IsNullOrEmpty(Primary.p.m.students.search.Text))
                {
                    Primary.p.m.students.Ref1();
                }
                else
                {
                    Primary.p.m.students.Ref2();
                }
                Primary.p.m.students.Ref3();

                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i] is TextBox)
                    {
                        ((TextBox)this.Controls[i]).Text = "";
                    }
                }
            }
            else
            {
                AppsHelper.UpdateQuery("Students",
                  "Name+" + Name.Text,
                  "FatherName+" + FatherName.Text,
                  "MotherName+" + MotherName.Text,
                  "Mobile+" + Mobile.Text,
                  "FatherMobile+" + FatherMobile.Text,
                  "MotherMobile+" + MotherMobile.Text,
                  "Address+" + Address.Text,
                  "SID+"+SID
                  );

                if (string.IsNullOrEmpty(Primary.p.m.students.search.Text))
                {
                    Primary.p.m.students.Ref1();
                }
                else
                {
                    Primary.p.m.students.Ref2();
                }
                Primary.p.m.students.Ref3();

                Primary.p.m.students.dataGridView1.Rows[r].Selected = true;

                MessageBox.Show("تم انهاء عملية تعديل بيانات الطالب بنجاح");
                this.Close();
            }
        }
    }
}
