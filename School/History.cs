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
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            fromDate.Text = AppsHelper.GetNowDate();
            toDate.Text = AppsHelper.GetNowDate();

            AppsHelper.SetControl("select userName from Users",userName);
            userName.Items.Add("الكل");
            AppsHelper.SetControl("select distinct(K) from history",type);
            type.Items.Add("الكل");

            AppsHelper.EnableStyle(dataGridView1);
        }
        public void Ref1()
        {
            if (userName.Text != "الكل")
            {
                if (type.Text != "الكل")//مستخدم وعملية
                {
                    AppsHelper.SetControl(@"SELECT        UserName AS [اسم المستخدم], Date AS التاريخ, Time AS الساعة, K AS [نوع العملية], Details AS [تفاصيل العملية]
FROM            History
WHERE         (Date >= '" + DateTime.Parse(fromDate.Text).ToString("yyyy/MM/dd") + "' AND Date <= '" + DateTime.Parse(toDate.Text).ToString("yyyy/MM/dd") + "') AND (K = N'" + type.Text + "') AND (UserName = N'" + userName.Text + "') ", dataGridView1);
                }
                else//مستخدم كافة العمليات
                {

                    AppsHelper.SetControl(@"SELECT        UserName AS [اسم المستخدم], Date AS التاريخ, Time AS الساعة, K AS [نوع العملية], Details AS [تفاصيل العملية]
FROM            History
WHERE         (Date >= '" + DateTime.Parse(fromDate.Text).ToString("yyyy/MM/dd") + "' AND Date <= '" + DateTime.Parse(toDate.Text).ToString("yyyy/MM/dd") + "')  AND (UserName = N'" + userName.Text + "') ", dataGridView1);

                }
            }
            else
            {
                if (type.Text != "الكل")//كافة المستخدمين عملية
                {

                    AppsHelper.SetControl(@"SELECT        UserName AS [اسم المستخدم], Date AS التاريخ, Time AS الساعة, K AS [نوع العملية], Details AS [تفاصيل العملية]
FROM            History
WHERE         (Date >= '" + DateTime.Parse(fromDate.Text).ToString("yyyy/MM/dd") + "' AND Date <= '" + DateTime.Parse(toDate.Text).ToString("yyyy/MM/dd") + "') AND (K = N'" + type.Text + "')", dataGridView1);

                }
                else//كافة المستخدمين كافة العمليات
                {

                    AppsHelper.SetControl(@"SELECT        UserName AS [اسم المستخدم], Date AS التاريخ, Time AS الساعة, K AS [نوع العملية], Details AS [تفاصيل العملية]
FROM            History
WHERE         (Date >= '" + DateTime.Parse(fromDate.Text).ToString("yyyy/MM/dd") + "' AND Date <= '" + DateTime.Parse(toDate.Text).ToString("yyyy/MM/dd") + "')", dataGridView1);

                }
            }


            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            a.Text = dataGridView1.Rows.Count.ToString();
        }

        public void Ref2()
        {
            if (userName.Text != "الكل")
            {
                if (type.Text != "الكل")//مستخدم وعملية
                {
                    AppsHelper.SetControl(@"SELECT        UserName AS [اسم المستخدم], Date AS التاريخ, Time AS الساعة, K AS [نوع العملية], Details AS [تفاصيل العملية]
FROM            History
WHERE         (Date >= '" + DateTime.Parse(fromDate.Text).ToString("yyyy/MM/dd") + "' AND Date <= '" + DateTime.Parse(toDate.Text).ToString("yyyy/MM/dd") + "') AND (K = N'" + type.Text + "') AND (UserName = N'" + userName.Text + "') and Details like N'%"+searchBox.Text+"%'", dataGridView1);
                }
                else//مستخدم كافة العمليات
                {

                    AppsHelper.SetControl(@"SELECT        UserName AS [اسم المستخدم], Date AS التاريخ, Time AS الساعة, K AS [نوع العملية], Details AS [تفاصيل العملية]
FROM            History
WHERE         (Date >= '" + DateTime.Parse(fromDate.Text).ToString("yyyy/MM/dd") + "' AND Date <= '" + DateTime.Parse(toDate.Text).ToString("yyyy/MM/dd") + "')  AND (UserName = N'" + userName.Text + "') and Details like N'%" + searchBox.Text + "%'", dataGridView1);

                }
            }
            else
            {
                if (type.Text != "الكل")//كافة المستخدمين عملية
                {

                    AppsHelper.SetControl(@"SELECT        UserName AS [اسم المستخدم], Date AS التاريخ, Time AS الساعة, K AS [نوع العملية], Details AS [تفاصيل العملية]
FROM            History
WHERE         (Date >= '" + DateTime.Parse(fromDate.Text).ToString("yyyy/MM/dd") + "' AND Date <= '" + DateTime.Parse(toDate.Text).ToString("yyyy/MM/dd") + "') AND (K = N'" + type.Text + "') and Details like N'%"+searchBox.Text+"%'", dataGridView1);

                }
                else//كافة المستخدمين كافة العمليات
                {

                    AppsHelper.SetControl(@"SELECT        UserName AS [اسم المستخدم], Date AS التاريخ, Time AS الساعة, K AS [نوع العملية], Details AS [تفاصيل العملية]
FROM            History
WHERE         (Date >= '" + DateTime.Parse(fromDate.Text).ToString("yyyy/MM/dd") + "' AND Date <= '" + DateTime.Parse(toDate.Text).ToString("yyyy/MM/dd") + "') and Details like N'%" + searchBox.Text + "%'", dataGridView1);

                }
            }


            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            a.Text = dataGridView1.Rows.Count.ToString();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Ref1();

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch
            {

              
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
            {
                Ref1();
            }
            else
            {
                Ref2();
            }
        }
    }
}
