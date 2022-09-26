using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Mall
{
    public partial class Bills : Form
    {
        public Bills()
        {
            InitializeComponent();
        }

        private void Bills_Load(object sender, EventArgs e)
        {
            AppsHelper.EnableStyle(dataGridView1);
            AppsHelper.EnableStyle(dataGridView2);
            AppsHelper.EnableStyle(dataGridView3);

            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 7.5F, FontStyle.Bold);
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            bdate.Text = AppsHelper.GetDate_PC_Normal();
            AppsHelper.SetControl("select billType from billTypes", bType);
            bType.Text = "فاتورة بيع";

            dataGridView2.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            ref1();

            toolStripComboBox1.Text = "قطعة";

            bType.Text = "فاتورة مبيع";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void ref2()
        {
            try
            {
                AppsHelper.SetControl(@"SELECT        (distinct(Products.ProductName)) AS [اسم المادة]
FROM            Products INNER JOIN
                         Classes ON Products.CID = Classes.CID INNER JOIN
                         Barcodes ON Products.PID = Barcodes.PID
WHERE        (Barcodes.Barcode LIKE '%" + searchBox.Text + "%') or (Products.ProductName LIKE N'%" + searchBox.Text + "%')", dataGridView1);
            }
            catch
            {


            }
        }
        public void ref1()
        {
            try
            {
                AppsHelper.SetControl(@"SELECT       distinct  Products.ProductName AS [اسم المادة]
FROM            Products INNER JOIN
                         Classes ON Products.CID = Classes.CID INNER JOIN
                         Barcodes ON Products.PID = Barcodes.PID", dataGridView1);
            }
            catch
            {


            }
        }
        private void toolStripTextBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
            {
                ref1();
            }
            else
            {
                ref2();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            searchBox.Text = "";
            if (string.IsNullOrEmpty(searchBox.Text))
            {
                ref1();
            }
            else
            {
                ref2();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string x = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if (dataGridView3.Rows[i].Cells[0].Value.ToString() == x)
                    {
                        try
                        {
                            if (toolStripComboBox1.Text == "قطعة")
                            {
                                dataGridView3.Rows[i].Cells[1].Value = int.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString()) + 1;
                            }
                            else
                            {
                                dataGridView3.Rows[i].Cells[2].Value = int.Parse(dataGridView3.Rows[i].Cells[2].Value.ToString()) + 1;
                            }
                        }
                        catch
                        {
                            if (toolStripComboBox1.Text == "قطعة")
                            {
                                dataGridView3.Rows[i].Cells[1].Value = "1";
                            }
                            else
                            {
                                dataGridView3.Rows[i].Cells[2].Value = "1";
                            }
                        }

                        try
                        {
                            dataGridView3.Rows[i].Cells[5].Value = (
                                int.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString()) * int.Parse(dataGridView3.Rows[i].Cells[3].Value.ToString())
                                +
                                int.Parse(dataGridView3.Rows[i].Cells[2].Value.ToString()) * int.Parse(dataGridView3.Rows[i].Cells[4].Value.ToString())
                                ).ToString();
                        }
                        catch
                        {


                        }

                        dataGridView3.Rows[i].Cells[7].Value = (int.Parse(dataGridView3.Rows[i].Cells[5].Value.ToString()) - int.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString())).ToString();



                        goto end;
                    }
                }

                string[] s = new string[8];
                s[0] = x;
                if (toolStripComboBox1.Text == "قطعة")
                {
                    s[1] = "1";
                    s[2] = "0";

                }
                else
                {
                    s[1] = "0";
                    s[2] = "1";
                }


                //if (bType.Text.Contains("شراء"))
                //{

                //}
                //else if (bType.Text.Contains("مبيع"))
                //{
                string type = AppsHelper.ReturnValue("select Type from Products where ProductName=N'" + x + "'");
                if (type == "آخر فاتورة")
                {
                    s[3] = AppsHelper.ReturnValue("select Price3 from Products where ProductName=N'" + x + "'");
                    s[4] = AppsHelper.ReturnValue("select Price4 from Products where ProductName=N'" + x + "'");
                }
                else if (type == "أعلى فاتورة")
                {
                    s[3] = AppsHelper.ReturnValue("select Price7 from Products where ProductName=N'" + x + "'");
                    s[4] = AppsHelper.ReturnValue("select Price8 from Products where ProductName=N'" + x + "'");
                }
                else if (type == "سعر خاص")
                {
                    s[3] = AppsHelper.ReturnValue("select Price11 from Products where ProductName=N'" + x + "'");
                    s[4] = AppsHelper.ReturnValue("select Price12 from Products where ProductName=N'" + x + "'");
                }

                //}
                s[5] = (
                                     int.Parse(s[1]) * int.Parse(s[3])
                                     +
                                     int.Parse(s[2]) * int.Parse(s[4])
                                     ).ToString();
                s[6] = "0";
                s[7] = (int.Parse(s[5]) - int.Parse(s[6])).ToString();
                dataGridView3.Rows.Add(s);

            end:;



                int n1 = 0, n2 = 0, n3 = 0, n4 = 0;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    try
                    {
                        n1 += int.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString());
                    }
                    catch
                    {

                    }

                    try
                    {
                        n2 += int.Parse(dataGridView3.Rows[i].Cells[2].Value.ToString());
                    }
                    catch
                    {

                    }

                    try
                    {
                        string v = AppsHelper.ReturnValue(@"select BoxN from Products where ProductName=N'" + dataGridView3.Rows[i].Cells[0].Value.ToString() + "'");
                        n3 += int.Parse(dataGridView3.Rows[i].Cells[2].Value.ToString()) * int.Parse(v);
                    }
                    catch
                    {

                    }


                }

                try
                {
                    n4 += (n1 + n3);
                }
                catch
                {

                }

                z1.Text = "-";
                z2.Text = "-";
                z3.Text = "-";
                z4.Text = "-";

                z1.Text = n1.ToString();
                z2.Text = n2.ToString();
                z3.Text = n3.ToString();
                z4.Text = n4.ToString();

                int y = 0;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    y += int.Parse(dataGridView3.Rows[i].Cells[7].Value.ToString());
                }
                toolStripTextBox2.Text = y.ToString();



                try
                {
                    dataGridView3.SelectedRows[0].Cells[6].Value = toolStripTextBox1.ToString();
                    dataGridView3.SelectedRows[0].Cells[7].Value = (int.Parse(dataGridView3.SelectedRows[0].Cells[5].Value.ToString()) - int.Parse(dataGridView3.SelectedRows[0].Cells[6].Value.ToString())).ToString();
                    int sold = 0;
                    int ss = 0;
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        try
                        {
                            int n = int.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString());
                            ss += int.Parse(dataGridView3.Rows[i].Cells[7].Value.ToString());
                            sold += n;
                        }
                        catch
                        {


                        }
                    }

                    toolStripTextBox4.Text = sold.ToString();
                    toolStripTextBox3.Text = ss.ToString();
                }
                catch
                {
                }
            }
            catch 
            {
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            dataGridView3.SelectedRows[0].Cells[1].Value = toolStripTextBox6.Text;
            dataGridView3.SelectedRows[0].Cells[2].Value = toolStripTextBox7.Text;
            toolStripTextBox6.Text = "";
            toolStripTextBox7.Text = "";
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.SelectedRows[0].Cells[6].Value = toolStripTextBox1.ToString();
                dataGridView3.SelectedRows[0].Cells[7].Value = (int.Parse(dataGridView3.SelectedRows[0].Cells[5].Value.ToString()) - int.Parse(dataGridView3.SelectedRows[0].Cells[6].Value.ToString())).ToString();
                int sold = 0;
                int s = 0;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    try
                    {
                        int n = int.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString());
                        s += int.Parse(dataGridView3.Rows[i].Cells[7].Value.ToString());
                        sold += n;
                    }
                    catch
                    {


                    }
                }

                toolStripTextBox4.Text = sold.ToString();
                toolStripTextBox3.Text = s.ToString();
            }
            catch
            {

            }


            toolStripTextBox1.Text = "";
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable dt = AppsHelper.ReturnDataTable("select * from Products where ProductName=N'" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");
                string[] x = new string[12];
                x[0] = dt.Rows[0]["Price1"].ToString();
                x[1] = dt.Rows[0]["Price2"].ToString();
                x[2] = dt.Rows[0]["Price3"].ToString();
                x[3] = dt.Rows[0]["Price4"].ToString();
                x[4] = dt.Rows[0]["Price5"].ToString();
                x[5] = dt.Rows[0]["Price6"].ToString();
                x[6] = dt.Rows[0]["Price7"].ToString();
                x[7] = dt.Rows[0]["Price8"].ToString();
                x[8] = dt.Rows[0]["Price9"].ToString();
                x[9] = dt.Rows[0]["Price10"].ToString();
                x[10] = dt.Rows[0]["Price11"].ToString();
                x[11] = dt.Rows[0]["Price12"].ToString();
                DataTable dt2 = new DataTable();
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add(x);

                try
                {
                    AppsHelper.Read_Image1("select pic from Products where ProductName=N'" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", pictureBox1);
                    AppsHelper.Read_Image2("select pic2 from Products where ProductName=N'" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", pictureBox2);
                }
                catch
                {


                }

            }
            catch
            {

            }


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AppsHelper.InsertQuery("Bills",
                "BillType+" + bType.Text,
                "Date+" + AppsHelper.GetDate_Server_SQL(),
                "Time+" + AppsHelper.GetTime_Server(),
                "From+" + Primary.p.mm.userName.Text,
                "Amount+" + toolStripTextBox3.Text.Replace(",", ""),
                "Sold+" + toolStripTextBox4.Text.Replace(",", ""),
                "Final+" + toolStripTextBox2.Text.Replace(",", ""));

            string BID = AppsHelper.ReturnValue("select max(BID) from Bills");


            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                AppsHelper.InsertQuery("BillsInf", "BID+" + BID,
                     "x1+" + dataGridView3.Rows[i].Cells[0].Value.ToString(),
                     "x2+" + dataGridView3.Rows[i].Cells[1].Value.ToString(),
                     "x3+" + dataGridView3.Rows[i].Cells[2].Value.ToString(),
                     "x4+" + dataGridView3.Rows[i].Cells[3].Value.ToString(),
                     "x5+" + dataGridView3.Rows[i].Cells[4].Value.ToString(),
                     "x6+" + dataGridView3.Rows[i].Cells[5].Value.ToString(),
                     "x7+" + dataGridView3.Rows[i].Cells[6].Value.ToString(),
                     "x8+" + dataGridView3.Rows[i].Cells[7].Value.ToString()

                    );
            }


            MessageBox.Show("تم حفظ الفاتورة بنجاح");
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            DataTable dt = AppsHelper.ReturnDataTable("select * from Products where ProductName=N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'");
            Card c = new Card();
            c.v = 1;
            AppsHelper.SetControl("select ClassName from Classes", c.className);
            string ClassName = AppsHelper.ReturnValue("select ClassName from Classes where CID=" + dt.Rows[0]["CID"].ToString());
            c.className.Text = ClassName;
            c.textBox15.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            c.comboBox2.Text = dt.Rows[0]["Unit"].ToString();
            c.textBox16.Text = dt.Rows[0]["BoxN"].ToString();
            c.textBox14.Text = dt.Rows[0]["Provider"].ToString();
            DataTable dt2 = AppsHelper.ReturnDataTable("select BarCode from BarCodes where PID=" + dt.Rows[0]["PID"].ToString());

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                PictureBox p = new PictureBox();
                AppsHelper.BarCode(dt2.Rows[i][0].ToString(), p);
                p.Width = (c.flowLayoutPanel1.Width / 2) - 8;
                p.Height = (c.flowLayoutPanel1.Height / 4) - 14;
                p.Tag = c.textBox1.Text;
                c.flowLayoutPanel1.Controls.Add(p);
            }



            c.textBox22.Text = dt.Rows[0]["About"].ToString();


            c.textBox23.Text = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x2) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة اتلاف')");
            c.textBox21.Text = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x3) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة اتلاف')");



            string x1 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x2) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة تحويل إلى المستودع')");
            string x2 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x3) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة تحويل إلى المستودع')");
            string x3 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x2) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة تحويل من المستودع')");
            string x4 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x3) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة تحويل من المستودع')");

            c.textBox17.Text = (int.Parse(x1) - int.Parse(x3)).ToString();
            c.textBox18.Text = (int.Parse(x2) - int.Parse(x4)).ToString();



            string x11 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x2) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'غير مستلم وارد')");
            string x22 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x3) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'غير مستلم وارد')");
            string x33 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x2) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'غير مستلم صادر')");
            string x44 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x3) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'غير مستلم صادر')");

            c.textBox24.Text = (int.Parse(x11) - int.Parse(x33)).ToString();
            c.textBox25.Text = (int.Parse(x22) - int.Parse(x44)).ToString();


            string x111 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x2) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة شراء')");
            string x222 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x3) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة شراء')");
            string x333 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x2) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType like N'%تحويل من%')");
            string x444 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x3) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType like N'%تحويل من%')");
            string x555 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x2) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة مبيع')");
            string x666 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x3) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة مبيع')");
            string x777 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x2) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType like N'%تحويل إلى%')");
            string x888 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x3) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType like N'%تحويل إلى%')");
            string x999 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x2) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة مرتجع شراء')");
            string x000 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x3) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة مرتجع شراء')");
            string x0001 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x2) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة مرتجع مبيع')");
            string x0002 = AppsHelper.ReturnValue(@"SELECT        SUM(BillsInf.x3) AS Expr1
FROM            Bills INNER JOIN
                         BillsInf ON Bills.BID = BillsInf.BID
WHERE        (BillsInf.x1 = N'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "') AND (Bills.BillType = N'فاتورة مرتجع مبيع')");

            c.textBox26.Text = ((int.Parse(x111) + int.Parse(x333) - int.Parse(x999)) - (int.Parse(x555) + int.Parse(x777) - int.Parse(x0001))).ToString();
            c.textBox27.Text = ((int.Parse(x222) + int.Parse(x444) - int.Parse(x000)) - (int.Parse(x666) + int.Parse(x888) - int.Parse(x0002))).ToString();




            c.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            AppsHelper.Export(dataGridView3);
        }
        Word.Application oWord; Word.Document oDoc;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                oWord = new Word.Application();
                string vv = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                string vvv = Application.StartupPath + "\\Drafts" + "\\" + vv + ".docx";

                try
                {
                    System.IO.File.Copy(Application.StartupPath + "\\111.docx", vvv);
                }
                catch
                {

                }



                oDoc = oWord.Documents.Open(vvv);


                AppsHelper.FindReplace(oDoc, vvv, "[0]", toolStripTextBox3.Text);
                AppsHelper.FindReplace(oDoc, vvv, "[1]", bdate.Text);

                Word.Table tb6 = oDoc.Tables[2];

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    tb6.Cell(i + 1, 1).Range.Text = dataGridView3.Rows[i].Cells[0].Value.ToString();
                    tb6.Cell(i + 1, 2).Range.Text = dataGridView3.Rows[i].Cells[1].Value.ToString();
                    tb6.Cell(i + 1, 3).Range.Text = dataGridView3.Rows[i].Cells[2].Value.ToString();
                    tb6.Cell(i + 1, 4).Range.Text = dataGridView3.Rows[i].Cells[3].Value.ToString();
                    tb6.Cell(i + 1, 5).Range.Text = dataGridView3.Rows[i].Cells[4].Value.ToString();
                    tb6.Cell(i + 1, 6).Range.Text = dataGridView3.Rows[i].Cells[5].Value.ToString();
                    tb6.Cell(i + 1, 7).Range.Text = dataGridView3.Rows[i].Cells[6].Value.ToString();
                    tb6.Cell(i + 1, 8).Range.Text = dataGridView3.Rows[i].Cells[7].Value.ToString();

                }

                oDoc.Save();
                System.Threading.Thread.Sleep(50);


                oDoc.PrintOut();

                System.Threading.Thread.Sleep(70);

                oDoc.Close(false, Type.Missing, Type.Missing);
                System.Threading.Thread.Sleep(70);

                oWord.Quit(false, false, false);
                System.Threading.Thread.Sleep(70);

                oWord = null;
                System.Threading.Thread.Sleep(70);

                oDoc = null;
                System.Threading.Thread.Sleep(70);

            }
            catch (Exception ex)
            {
                oDoc.Close(false, Type.Missing, Type.Missing);
                oWord.Quit(false, false, false);
                oWord = null;
                oDoc = null;
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                oWord = new Word.Application();
                string vv = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                string vvv = Application.StartupPath + "\\Drafts" + "\\" + vv + ".docx";

                try
                {
                    System.IO.File.Copy(Application.StartupPath + "\\111.docx", vvv);
                }
                catch
                {

                }



                oDoc = oWord.Documents.Open(vvv);


                AppsHelper.FindReplace(oDoc, vvv, "[0]", toolStripTextBox3.Text);
                AppsHelper.FindReplace(oDoc, vvv, "[1]", bdate.Text);





                oDoc.Save();
                System.Threading.Thread.Sleep(50);


                oWord.Visible = true;

                System.Threading.Thread.Sleep(70);

                //oDoc.Close(false, Type.Missing, Type.Missing);
                //System.Threading.Thread.Sleep(70);

                //oWord.Quit(false, false, false);
                //System.Threading.Thread.Sleep(70);

                oWord = null;
                System.Threading.Thread.Sleep(70);

                oDoc = null;
                System.Threading.Thread.Sleep(70);

            }
            catch (Exception ex)
            {
                oDoc.Close(false, Type.Missing, Type.Missing);
                oWord.Quit(false, false, false);
                oWord = null;
                oDoc = null;
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
    }
}