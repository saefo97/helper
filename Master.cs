using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mall
{
    public partial class Master : Form
    {
        public Master()
        {
            InitializeComponent();
        }
        public List<int> myList = new List<int>();

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            for (int i = xtraTabbedMdiManager1.Pages.Count - 1; i >=0 ; i--)
            {
                xtraTabbedMdiManager1.Pages[i].MdiChild.Close();
            }
            MainPic mp = new MainPic();
            mp.MdiParent = this;
            mp.Text = "الرئيسية";
            mp.Show();
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Tahoma", 8, FontStyle.Bold);
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ImageOptions.Image = imageList1.Images[0];
        }

        private void Master_Load(object sender, EventArgs e)
        {
            {
                MainPic mp = new MainPic();
                mp.MdiParent = this;
                mp.Text = "الرئيسية";
                mp.Show();
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Tahoma", 8, FontStyle.Bold);
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ImageOptions.Image = imageList1.Images[0];

            }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            Bills b = new Bills();
            b.MdiParent = this;
            b.Text = "فاتورة جديدة";
            b.Show();
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Tahoma", 8, FontStyle.Bold);
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ImageOptions.Image = imageList1.Images[2];
        }

        private void ToolStripButton13_Click(object sender, EventArgs e)
        {
            for (int i = xtraTabbedMdiManager1.Pages.Count - 1; i >= 1; i--)
            {
                xtraTabbedMdiManager1.Pages[i].MdiChild.Close();
            }
        }

        private void ToolStripButton12_Click(object sender, EventArgs e)
        {
            Card C = new Card();
            C.Show();
        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.MdiParent = this;
            f1.Text = "الجرد المالي";
            f1.Show();
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Tahoma", 8, FontStyle.Bold);
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ImageOptions.Image = imageList1.Images[3];

        }
        int i = 0;
        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            Form2 f3 = new Form2();
            f3.MdiParent = this;
            if (myList.Count > 0)
            {
                f3.Text = "مراجعة المخزون " + (myList[0]);
                myList.RemoveAt(0);
            }
            else
            {
                f3.Text = "مراجعة المخزون " + (i + 1);
                i++;
            }
            f3.Show();
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Tahoma", 8, FontStyle.Bold);
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ImageOptions.Image = imageList1.Images[4];
        }

        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            Calculator calc = new Calculator();
            calc.Show();
        }

        private void ToolStripButton3_Click_1(object sender, EventArgs e)
        {
            Notes no = new Notes();
            no.MdiParent = this;
            no.Text = "ملاحظات";
            no.Show();
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Tahoma", 8, FontStyle.Bold);
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ImageOptions.Image = imageList1.Images[12];
        }

        private void ToolStripButton10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripButton8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                                "هل أنت متأكد من أنك تود إيقاف البرنامج مؤقتاً",
                                "رسالة تنبيه",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2,
                                MessageBoxOptions.RightAlign
                                ) == DialogResult.Yes)
            {
                Primary.p.textBox1.Enabled = false;
                Primary.p.textBox2.Enabled = true;
                Primary.p.textBox2.Text = "";
                Primary.p.ActiveControl = Primary.p.textBox2;
                Primary.p.y = 1;
                this.Hide();
                Primary.p.Show();
                AppsHelper.NewHistory(userName.Text, "إغلاق البرنامج", "قام المستخدم بإيقاف البرنامج مؤقتاً");

            }
        }

        private void ToolStripButton9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                                 "هل أنت متأكد من أنك تود تسجيل الخروج من البرنامج",
                                 "رسالة تنبيه",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Warning,
                                 MessageBoxDefaultButton.Button2,
                                 MessageBoxOptions.RightAlign
                                 ) == DialogResult.Yes)
            {
                Primary.p.textBox1.Enabled = true;
                Primary.p.textBox1.Text = "";
                Primary.p.textBox2.Enabled = true;
                Primary.p.textBox2.Text = "";
                Primary.p.ActiveControl = Primary.p.textBox1;
                Primary.p.x = 1;
                this.Close();
                Primary.p.Show();
                Primary.p.x = 0;
                AppsHelper.NewHistory(userName.Text, "تسجيل الخروج", "قام المستخدم بتسجيل الخروج من البرنامج");
            }
        }

        private void Master_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Primary.p.x == 0)
                {
                    if (MessageBox.Show(
                "هل أنت متأكد من أنك تود إغلاق البرنامج",
                "رسالة تنبيه",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.RightAlign
                ) == DialogResult.Yes)
                    {
                        Primary.p.x = 1;
                        AppsHelper.NewHistory(userName.Text, "إيقاف البرنامج", "قام المستخدم بإغلاق البرنامج");
                        Application.Exit();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    Primary.p.x = 0;
                }
            }
            catch
            {
            }

        }

        private void ToolStripButton11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("برمجة جدوع السنونو");
        }

        private void تغييركلمةالمرورToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Password pw = new Password();
            pw.ShowDialog();
        }

        private void ضبطالصلاحياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Roles rol = new Roles();
            rol.MdiParent = this;
            rol.Text = "ضبط الصلاحيات";
            rol.Show();
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Tahoma", 8, FontStyle.Bold);
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ImageOptions.Image = imageList1.Images[7];
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            History his = new History();
            his.MdiParent = this;
            his.Text = "المراقبات";
            his.Show();
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Tahoma", 8, FontStyle.Bold);
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ImageOptions.Image = imageList1.Images[14];
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            Mess mes = new Mess();
            mes.MdiParent = this;
            mes.Text = "الإشعارات";
            mes.Show();
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Tahoma", 8, FontStyle.Bold);
            xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ImageOptions.Image = imageList1.Images[9];
        }
    }
}
