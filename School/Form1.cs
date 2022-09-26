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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppsHelper.SetControl("select yearName from Years",yearName);

            AppsHelper.EnableStyle(dataGridView1);
        }

        private void yearName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AppsHelper.SetControl(@"SELECT        Classes.ClassName AS الصف, count(Regs.RID) as [عدد الطلاب], SUM(Regs.Price) AS مستحق, SUM(Regs.Sold1) AS [حسم نقابة], SUM(Regs.Sold2) AS [حسم شقيق], SUM(Regs.Sold3) AS [حسم تفوق], SUM(Regs.Sold4) AS [حسم خاص], 
                         SUM(Regs.Sold) AS [حسم نهائي], SUM(Regs.Paid) AS مدفوع, SUM(Regs.Remain) AS متبقي
FROM            Classes INNER JOIN
                         Prices ON Classes.CID = Prices.CID INNER JOIN
                         Years ON Prices.YID = Years.YID INNER JOIN
                         Regs ON Prices.CYID = Regs.CYID
GROUP BY Classes.ClassName, Years.YearName
HAVING        (Years.YearName = '"+yearName.Text+"')",dataGridView1);

                dataGridView1.Columns[2].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[3].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[4].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[5].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[6].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[7].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[8].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[9].DefaultCellStyle.Format = "N0";

                AppsHelper.SetControl(@"SELECT       COUNT(Regs.RID)
FROM            Classes INNER JOIN
                         Prices ON Classes.CID = Prices.CID INNER JOIN
                         Years ON Prices.YID = Years.YID INNER JOIN
                         Regs ON Prices.CYID = Regs.CYID
where        (Years.YearName = '" + yearName.Text + "')", v1);

                AppsHelper.SetControl(@"SELECT       sum(Regs.price)
FROM            Classes INNER JOIN
                         Prices ON Classes.CID = Prices.CID INNER JOIN
                         Years ON Prices.YID = Years.YID INNER JOIN
                         Regs ON Prices.CYID = Regs.CYID
where        (Years.YearName = '" + yearName.Text + "')", v2);

                AppsHelper.SetControl(@"SELECT       sum(Regs.sold1)
FROM            Classes INNER JOIN
                         Prices ON Classes.CID = Prices.CID INNER JOIN
                         Years ON Prices.YID = Years.YID INNER JOIN
                         Regs ON Prices.CYID = Regs.CYID
where        (Years.YearName = '" + yearName.Text + "')", v3);

                AppsHelper.SetControl(@"SELECT       sum(Regs.sold2)
FROM            Classes INNER JOIN
                         Prices ON Classes.CID = Prices.CID INNER JOIN
                         Years ON Prices.YID = Years.YID INNER JOIN
                         Regs ON Prices.CYID = Regs.CYID
where        (Years.YearName = '" + yearName.Text + "')", v4);
                AppsHelper.SetControl(@"SELECT       sum(Regs.sold3)
FROM            Classes INNER JOIN
                         Prices ON Classes.CID = Prices.CID INNER JOIN
                         Years ON Prices.YID = Years.YID INNER JOIN
                         Regs ON Prices.CYID = Regs.CYID
where        (Years.YearName = '" + yearName.Text + "')", v5);

                AppsHelper.SetControl(@"SELECT       sum(Regs.sold4)
FROM            Classes INNER JOIN
                         Prices ON Classes.CID = Prices.CID INNER JOIN
                         Years ON Prices.YID = Years.YID INNER JOIN
                         Regs ON Prices.CYID = Regs.CYID
where        (Years.YearName = '" + yearName.Text + "')", v6);

                AppsHelper.SetControl(@"SELECT       sum(Regs.sold)
FROM            Classes INNER JOIN
                         Prices ON Classes.CID = Prices.CID INNER JOIN
                         Years ON Prices.YID = Years.YID INNER JOIN
                         Regs ON Prices.CYID = Regs.CYID
where        (Years.YearName = '" + yearName.Text + "')", v7);

                AppsHelper.SetControl(@"SELECT       sum(Regs.paid)
FROM            Classes INNER JOIN
                         Prices ON Classes.CID = Prices.CID INNER JOIN
                         Years ON Prices.YID = Years.YID INNER JOIN
                         Regs ON Prices.CYID = Regs.CYID
where        (Years.YearName = '" + yearName.Text + "')", v8);

                AppsHelper.SetControl(@"SELECT       sum(Regs.remain)
FROM            Classes INNER JOIN
                         Prices ON Classes.CID = Prices.CID INNER JOIN
                         Years ON Prices.YID = Years.YID INNER JOIN
                         Regs ON Prices.CYID = Regs.CYID
where        (Years.YearName = '" + yearName.Text + "')", v9);


                AppsHelper.WithDecimal(v1);
                AppsHelper.WithDecimal(v2);
                AppsHelper.WithDecimal(v3);
                AppsHelper.WithDecimal(v4);
                AppsHelper.WithDecimal(v5);
                AppsHelper.WithDecimal(v6);
                AppsHelper.WithDecimal(v7);
                AppsHelper.WithDecimal(v8);
                AppsHelper.WithDecimal(v9);

            }
            catch
            {

              
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Form2 f2 = new Form2();
                f2.yearName = yearName.Text;
                f2.className = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                f2.Text = f2.yearName + "-" + f2.className;
                f2.v1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                f2.v2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                f2.v3.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                f2.v4.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                f2.v5.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                AppsHelper.WithDecimal(f2.v1);
                AppsHelper.WithDecimal(f2.v2);
                AppsHelper.WithDecimal(f2.v3);
                AppsHelper.WithDecimal(f2.v4);
                AppsHelper.WithDecimal(f2.v5);
                f2.ShowDialog();
            }
            catch
            {

            }
        }
    }
}
