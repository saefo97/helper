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
    public partial class Mess : Form
    {
        public Mess()
        {
            InitializeComponent();
        }

        private void Mess_Load(object sender, EventArgs e)
        {
            fromDate.Text = AppsHelper.GetNowDate();
            toDate.Text = AppsHelper.GetNowDate();

            AppsHelper.EnableStyle(dataGridView1);

            AppsHelper.SetControl("select UserName from Users",userName);
            userName.Items.Add("الكل");
            userName.Items.Remove(Primary.p.m.userName.Text);

            type.Text = "وارد";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string MID;
            if (userName.Text!="الكل")
            {
                AppsHelper.InsertQuery("Mess", "FromUser+" + Primary.p.m.userName.Text, "ToUser+" + userName.Text, "Date+" + AppsHelper.GetNowDate_SQL(), "Time+" + AppsHelper.GetNowTime(),"Mes+"+MesText.Text);
                MID = AppsHelper.ReturnValue("select max(MID) from Mess where FromUser=N'"+ Primary.p.m.userName.Text + "'");
                AppsHelper.InsertQuery("MessRec","MID+"+MID,"R+false","ToUser+"+userName.Text);
            }
            else
            {
                AppsHelper.InsertQuery("Mess", "FromUser+" + Primary.p.m.userName.Text, "ToUser+" + "الكل", "Date+" + AppsHelper.GetNowDate_SQL(), "Time+" + AppsHelper.GetNowTime(), "Mes+" + MesText.Text);
                MID = AppsHelper.ReturnValue("select max(MID) from Mess where FromUser=N'" + Primary.p.m.userName.Text + "'");
                for (int i = 0; i < userName.Items.Count-1; i++)
                {
                    AppsHelper.InsertQuery("MessRec", "MID+" + MID, "R+false", "ToUser+" + userName.Items[i].ToString());
                }
            }
            userName.SelectedIndex = -1;
            MesText.Text = "";
            MessageBox.Show("تم الارسال بنجاح");
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (type.Text=="وارد")
            {
                AppsHelper.SetControl(@"SELECT        Mess.MID, Mess.FromUser AS من, Mess.ToUser AS إلى, Mess.Date AS التاريخ, Mess.Time AS الساعة, Mess.Mes AS الرسالة
FROM            Mess INNER JOIN
                         MessRec ON Mess.MID = MessRec.MID
WHERE        (MessRec.ToUser = N'"+Primary.p.m.userName.Text+"') AND (Mess.Date >= '"+DateTime.Parse(fromDate.Text).ToString("yyyy/MM/dd")+"' and Mess.Date <= '"+ DateTime.Parse(toDate.Text).ToString("yyyy/MM/dd") + "')", dataGridView1);



                AppsHelper.SendQuery(@"update    MessRec     
set MessRec.R='true' from Mess INNER JOIN MessRec 
ON Mess.MID = MessRec.MID 
WHERE        (MessRec.ToUser = N'" + Primary.p.m.userName.Text + "') AND (Mess.Date >= '" + DateTime.Parse(fromDate.Text).ToString("yyyy/MM/dd") + "' and Mess.Date <= '" + DateTime.Parse(toDate.Text).ToString("yyyy/MM/dd") + "')");


            }
            else
            {
                AppsHelper.SetControl(@"SELECT        MID, FromUser AS من, ToUser AS إلى, Date AS التاريخ, Time AS الساعة, Mes AS الرسالة
FROM            Mess
WHERE         (Mess.Date >= '" + DateTime.Parse(fromDate.Text).ToString("yyyy/MM/dd") + "' and Mess.Date <= '" + DateTime.Parse(toDate.Text).ToString("yyyy/MM/dd") + "')", dataGridView1);
            }


            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;


            a.Text = dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch
            {

            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form3 f3 = new Form3();
            f3.MID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            f3.ShowDialog();
        }

        private void Type_Click(object sender, EventArgs e)
        {

        }
    }
}
