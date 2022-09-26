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
    public partial class Master : Form
    {
        public Roles roles = new Roles();
        public History history = new History();
        public Students students = new Students();
        public Form1 f1 = new Form1();
        public Mess m = new Mess();
        public Master()
        {
            InitializeComponent();
        }
        public void HideAll()
        {
            roles.Hide();
            history.Hide();
            students.Hide();
            f1.Hide();
            m.Hide();
        }
        private void Master_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Primary.p.x==0)
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
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

        private void toolStripButton5_Click(object sender, EventArgs e)
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
                AppsHelper.NewHistory(userName.Text, "إيقاف مؤقت", "قام المستخدم بإيقاف البرنامج مؤقتاً");

            }
        }

        private void تغييركلمةالمرورToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Password p = new Password();
            p.ShowDialog();
        }

        private void Master_Load(object sender, EventArgs e)
        {
            roles.TopLevel = false;
            history.TopLevel = false;
            students.TopLevel = false;
            f1.TopLevel = false;
            m.TopLevel = false;

            panel1.Controls.Add(roles);
            panel1.Controls.Add(history);
            panel1.Controls.Add(students);
            panel1.Controls.Add(f1);
            panel1.Controls.Add(m);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            HideAll();
            students.Show();
            students.Dock = DockStyle.Fill;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            HideAll();
            history.Show();
            history.Dock = DockStyle.Fill;
        }

        private void الصلاحياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppsHelper.CheckRole(userName.Text,"R1"))
            {
                HideAll();
                roles.Show();
                roles.Dock = DockStyle.Fill;
            }
         
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (AppsHelper.CheckRole(userName.Text,"R5"))
            {
                Prices p = new Prices();
                p.ShowDialog();
            }



         
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (AppsHelper.CheckRole(userName.Text,"R4"))
            {
                HideAll();
                f1.Show();
                f1.Dock = DockStyle.Fill;
            }



        
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            HideAll();
            m.Show();
            m.Dock = DockStyle.Fill;
        }

        private void ToolStripButton10_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripButton9_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripButton8_Click(object sender, EventArgs e)
        {

        }
    }
}
