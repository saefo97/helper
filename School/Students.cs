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
    public partial class Students : Form
    {
        public string SID;
        public Students()
        {
            InitializeComponent();
        }
        public void Ref1()
        {
            try
            {
                if (className.Text!="الكل")//صف محدد
                {
                    if (yearName.Text!="الكل")//عام محدد
                    {
                        AppsHelper.SetControl(@"SELECT        Students.SID AS الرقم, Students.Name AS الاسم, Students.Mobile AS الموبايل, Students.FatherMobile AS [موبايل الأب], Students.MotherMobile AS [موبايل الأم], Classes.ClassName AS الصف, Years.YearName AS العام
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Classes.ClassName = N'"+className.Text+"') AND (Years.YearName = '"+yearName.Text+"')", dataGridView1);

                        a2.Text = AppsHelper.ReturnValue(@"SELECT        count(distinct(Students.SID))
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Classes.ClassName = N'" + className.Text + "') AND (Years.YearName = '" + yearName.Text + "')");
                    }
                    else//كافة الاعوام
                    {
                        AppsHelper.SetControl(@"SELECT        Students.SID AS الرقم, Students.Name AS الاسم, Students.Mobile AS الموبايل, Students.FatherMobile AS [موبايل الأب], Students.MotherMobile AS [موبايل الأم], Classes.ClassName AS الصف, Years.YearName AS العام
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Classes.ClassName = N'" + className.Text + "')", dataGridView1);

                        a2.Text = AppsHelper.ReturnValue(@"SELECT        count(distinct(Students.SID))
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Classes.ClassName = N'" + className.Text + "')");
                    }
                }
                else//كافة الصفوف
                {
                    if (yearName.Text != "الكل")//عام محدد
                    {
                        AppsHelper.SetControl(@"SELECT        Students.SID AS الرقم, Students.Name AS الاسم, Students.Mobile AS الموبايل, Students.FatherMobile AS [موبايل الأب], Students.MotherMobile AS [موبايل الأم], Classes.ClassName AS الصف, Years.YearName AS العام
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE         (Years.YearName = '" + yearName.Text + "')", dataGridView1);

                        a2.Text = AppsHelper.ReturnValue(@"SELECT        count(distinct(Students.SID))
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE         (Years.YearName = '" + yearName.Text + "')");
                    }
                    else//كافة الاعوام
                    {
                        AppsHelper.SetControl(@"SELECT        Students.SID AS الرقم, Students.Name AS الاسم, Students.Mobile AS الموبايل, Students.FatherMobile AS [موبايل الأب], Students.MotherMobile AS [موبايل الأم], Classes.ClassName AS الصف, Years.YearName AS العام
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID", dataGridView1);

                        a2.Text = AppsHelper.ReturnValue(@"SELECT       count(distinct(Students.SID))
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID");
                    }
                }

                a1.Text = dataGridView1.Rows.Count.ToString();
                
            }
            catch
            {

            
            }
        }
        public void Ref2()
        {
            try
            {
                if (className.Text != "الكل")//صف محدد
                {
                    if (yearName.Text != "الكل")//عام محدد
                    {
                        AppsHelper.SetControl(@"SELECT        Students.SID AS الرقم, Students.Name AS الاسم, Students.Mobile AS الموبايل, Students.FatherMobile AS [موبايل الأب], Students.MotherMobile AS [موبايل الأم], Classes.ClassName AS الصف, Years.YearName AS العام
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Classes.ClassName = N'" + className.Text + "') AND (Years.YearName = '" + yearName.Text + "') And (Students.Name like N'%"+search.Text+"%' or Students.Mobile like '%"+search.Text+"%' or Students.FatherName like '%"+search.Text+"%' or Students.MotherName like '%"+search.Text+"%')", dataGridView1);

                        a2.Text = AppsHelper.ReturnValue(@"SELECT        count(distinct(Students.SID))
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Classes.ClassName = N'" + className.Text + "') AND (Years.YearName = '" + yearName.Text + "')  And (Students.Name like N'%" + search.Text + "%' or Students.Mobile like '%" + search.Text + "%' or Students.FatherName like '%" + search.Text + "%' or Students.MotherName like '%" + search.Text + "%')");
                    }
                    else//كافة الاعوام
                    {
                        AppsHelper.SetControl(@"SELECT        Students.SID AS الرقم, Students.Name AS الاسم, Students.Mobile AS الموبايل, Students.FatherMobile AS [موبايل الأب], Students.MotherMobile AS [موبايل الأم], Classes.ClassName AS الصف, Years.YearName AS العام
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Classes.ClassName = N'" + className.Text + "')  And (Students.Name like N'%" + search.Text + "%' or Students.Mobile like '%" + search.Text + "%' or Students.FatherName like '%" + search.Text + "%' or Students.MotherName like '%" + search.Text + "%')", dataGridView1);

                        a2.Text = AppsHelper.ReturnValue(@"SELECT        count(distinct(Students.SID))
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Classes.ClassName = N'" + className.Text + "')  And (Students.Name like N'%" + search.Text + "%' or Students.Mobile like '%" + search.Text + "%' or Students.FatherName like '%" + search.Text + "%' or Students.MotherName like '%" + search.Text + "%')");
                    }
                }
                else//كافة الصفوف
                {
                    if (yearName.Text != "الكل")//عام محدد
                    {
                        AppsHelper.SetControl(@"SELECT        Students.SID AS الرقم, Students.Name AS الاسم, Students.Mobile AS الموبايل, Students.FatherMobile AS [موبايل الأب], Students.MotherMobile AS [موبايل الأم], Classes.ClassName AS الصف, Years.YearName AS العام
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE         (Years.YearName = '" + yearName.Text + "')  And (Students.Name like N'%" + search.Text + "%' or Students.Mobile like '%" + search.Text + "%' or Students.FatherName like '%" + search.Text + "%' or Students.MotherName like '%" + search.Text + "%')", dataGridView1);

                        a2.Text = AppsHelper.ReturnValue(@"SELECT        count(distinct(Students.SID))
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE         (Years.YearName = '" + yearName.Text + "')  And (Students.Name like N'%" + search.Text + "%' or Students.Mobile like '%" + search.Text + "%' or Students.FatherName like '%" + search.Text + "%' or Students.MotherName like '%" + search.Text + "%')");
                    }
                    else//كافة الاعوام
                    {
                        AppsHelper.SetControl(@"SELECT        Students.SID AS الرقم, Students.Name AS الاسم, Students.Mobile AS الموبايل, Students.FatherMobile AS [موبايل الأب], Students.MotherMobile AS [موبايل الأم], Classes.ClassName AS الصف, Years.YearName AS العام
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID  where (Students.Name like N'%" + search.Text + "%' or Students.Mobile like '%" + search.Text + "%' or Students.FatherName like '%" + search.Text + "%' or Students.MotherName like '%" + search.Text + "%')", dataGridView1);

                        a2.Text = AppsHelper.ReturnValue(@"SELECT       count(distinct(Students.SID))
FROM            Regs INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID  where (Students.Name like N'%" + search.Text + "%' or Students.Mobile like '%" + search.Text + "%' or Students.FatherName like '%" + search.Text + "%' or Students.MotherName like '%" + search.Text + "%')");
                    }
                }

                a1.Text = dataGridView1.Rows.Count.ToString();

            }
            catch
            {


            }
        }
        private void Students_Load(object sender, EventArgs e)
        {
            AppsHelper.SetControl("select ClassName from Classes",className);
            AppsHelper.SetControl("select YearName from Years",yearName);
            className.Items.Add("الكل");
            yearName.Items.Add("الكل");
            className.Text = "الكل";
            yearName.Text = "الكل";

            AppsHelper.EnableStyle(dataGridView1);
            AppsHelper.EnableStyle(dataGridView2);
            AppsHelper.EnableStyle(dataGridView3);

        }

        private void className_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(search.Text))
                {
                    Ref1();
                }
                else
                {
                    Ref2();
                }
            }
            catch 
            {

            
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                b1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                b2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                b2.Text = b2.Text.Insert(4, "-");
                b2.Text = b2.Text.Insert(8, "-");
                SID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                row = e.RowIndex;
                Ref3();
                Ref4();
            }
            catch
            {

               
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(search.Text))
                {
                    Ref1();
                }
                else
                {
                    Ref2();
                }
            }
            catch
            {


            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (AppsHelper.CheckRole(Primary.p.m.userName.Text,"R3"))
            {
                Prices p = new Prices();
                p.Text = "نافذة تسجيل طالب";
                p.button1.Text = "تسجيل";
                p.checkBox1.Visible = true;
                p.checkBox2.Visible = true;
                p.checkBox3.Visible = true;
                p.checkBox4.Visible = true;
                p.SID = SID;
                p.ShowDialog();
            }


        
        }

        public void Ref3()
        {
            try
            {
                AppsHelper.SetControl(@"SELECT        Regs.RID,Classes.ClassName AS الصف, Years.YearName AS العام, Regs.Price AS مستحق, Regs.Sold AS حسم, Regs.Paid AS مدفوع, Regs.Remain AS متبقي
FROM            Regs INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Regs.SID = "+SID+")",dataGridView2);

                dataGridView2.Columns[0].Visible = false;

                dataGridView2.Columns[3].DefaultCellStyle.Format = "N0";
                dataGridView2.Columns[4].DefaultCellStyle.Format = "N0";
                dataGridView2.Columns[5].DefaultCellStyle.Format = "N0";
                dataGridView2.Columns[6].DefaultCellStyle.Format = "N0";

                v1.Text = dataGridView2.Rows.Count.ToString();

                v2.Text = AppsHelper.ReturnValue(@"SELECT        sum(Regs.Price)
FROM            Regs INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Regs.SID = " + SID + ")");
                v3.Text = AppsHelper.ReturnValue(@"SELECT        sum(Regs.Sold)
FROM            Regs INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Regs.SID = " + SID + ")");
                v4.Text = AppsHelper.ReturnValue(@"SELECT        sum(Regs.Paid)
FROM            Regs INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Regs.SID = " + SID + ")");
                v5.Text = AppsHelper.ReturnValue(@"SELECT        sum(Regs.Remain)
FROM            Regs INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Regs.SID = " + SID + ")");


                AppsHelper.WithDecimal(v2);
                AppsHelper.WithDecimal(v3);
                AppsHelper.WithDecimal(v4);
                AppsHelper.WithDecimal(v5);


            }
            catch
            {

             
            }
        }
        public void Ref4()
        {
            try
            {
                AppsHelper.SetControl(@"SELECT        Paids.RID,Paids.PID AS [رقم الوصل], Classes.ClassName AS الصف, Years.YearName AS العام, Paids.Amount AS المبلغ, Paids.Date AS التاريخ
FROM            Regs INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Paids ON Regs.RID = Paids.RID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Regs.SID = "+SID+")",dataGridView3);

                dataGridView3.Columns[0].Visible = false;
                dataGridView3.Columns[4].DefaultCellStyle.Format = "N0";

                z1.Text = dataGridView3.Rows.Count.ToString();

                z2.Text = AppsHelper.ReturnValue(@"SELECT       sum(Paids.Amount)
FROM            Regs INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Paids ON Regs.RID = Paids.RID INNER JOIN
                         Classes ON Prices.CID = Classes.CID INNER JOIN
                         Years ON Prices.YID = Years.YID
WHERE        (Regs.SID = " + SID + ")");


                AppsHelper.WithDecimal(z2);

            }
            catch
            {

        
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
             "هل أنت متأكد من أنك تود حذف التسجيل",
             "رسالة تنبيه",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Warning,
             MessageBoxDefaultButton.Button2,
             MessageBoxOptions.RightAlign
             ) == DialogResult.Yes)
            {
                AppsHelper.SendQuery("delete from Regs where RID="+dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                MessageBox.Show("تم الحذف بنجاح");
                Ref3();
            }
        }

        private void toolStripTextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                AppsHelper.WithDecimal(toolStripTextBox3);
            }
            catch
            {

            
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dataGridView2.SelectedRows[0].Cells[3].Value.ToString()))
            {
                MessageBox.Show("لا يمكن ادراج الدفعة");
            }
            else
            {
                string a = toolStripTextBox3.Text.Replace(",", "");
                if (string.IsNullOrEmpty(a))
                {
                    MessageBox.Show("قم بكتابة قيمة الدفعة اولاً");
                }
                else
                {
                    string RID = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    AppsHelper.InsertQuery("Paids", "RID+" + RID, "Date+" + AppsHelper.GetNowDate_SQL(), "Amount+" + a);
                    float x = float.Parse(AppsHelper.ReturnValue("select Paid from regs where RID=" + RID));
                    float y = float.Parse(AppsHelper.ReturnValue("select Remain from regs where RID=" + RID));
                    x = x + float.Parse(a);
                    y = y - float.Parse(a);
                    AppsHelper.UpdateQuery("Regs", "Paid+" + x, "Remain+" + y, "RID+" + RID);
                    MessageBox.Show("تم تخزين الدفعة بنجاح");
                    toolStripTextBox3.Text = "";
                    Ref3();
                    Ref4();
                }
            }
          
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
           "هل أنت متأكد من أنك تود حذف الدفعة"+"\n"+"التي قيمتها: "+dataGridView3.SelectedRows[0].Cells[3].Value.ToString()+"\n"+"والتي رقم الوصل لها: "+ dataGridView3.SelectedRows[0].Cells[0].Value.ToString() + "\n"+"للطالب: "+dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
           "رسالة تنبيه",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Warning,
           MessageBoxDefaultButton.Button2,
           MessageBoxOptions.RightAlign
           ) == DialogResult.Yes)
            {
                AppsHelper.NewHistory(Primary.p.m.userName.Text, "حذف دفعة", "قام المستخدم بحذف وصل دفع للطالب "+dataGridView1.SelectedRows[0].Cells[1].Value.ToString()+" الذي رقمه "+dataGridView3.SelectedRows[0].Cells[1].Value.ToString()+" وقيمته "+ dataGridView3.SelectedRows[0].Cells[4].Value.ToString());

                    string RID = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                    float x = float.Parse(AppsHelper.ReturnValue("select Paid from regs where RID=" + RID));
                    float y = float.Parse(AppsHelper.ReturnValue("select Remain from regs where RID=" + RID));
                    x = x - float.Parse(dataGridView3.SelectedRows[0].Cells[4].Value.ToString().Replace(",",""));
                    y = y + float.Parse(dataGridView3.SelectedRows[0].Cells[4].Value.ToString().Replace(",", ""));
                    AppsHelper.UpdateQuery("Regs", "Paid+" + x, "Remain+" + y, "RID+" + RID);
                    AppsHelper.SendQuery("delete from Paids where PID="+ dataGridView3.SelectedRows[0].Cells[1].Value.ToString());
                    MessageBox.Show("تم حذف الدفعة بنجاح");
                    toolStripTextBox3.Text = "";
                    Ref3();
                    Ref4();
              
            }
        
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            AppsHelper.WithDecimal(toolStripTextBox2);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox2.Text.Replace(",","")== dataGridView3.SelectedRows[0].Cells[4].Value.ToString())
            {
                MessageBox.Show("لم تقم بتعديل قيمة الدفعة");
            }
            else
            {
                AppsHelper.NewHistory(Primary.p.m.userName.Text, "تعديل دفعة", "قام المستخدم بتغغير قيمة الدفعة للطالب " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + " من المبلغ " + string.Format("{0:N0}",decimal.Parse(dataGridView3.SelectedRows[0].Cells[4].Value.ToString())) + " إلى المبلغ " + toolStripTextBox2.Text);

                float xnew = float.Parse(toolStripTextBox2.Text.Replace(",", ""));
                float xold = float.Parse(dataGridView3.SelectedRows[0].Cells[4].Value.ToString().Replace(",", ""));
                AppsHelper.UpdateQuery("Paids", "Amount+" + xnew, "PID+" + dataGridView3.SelectedRows[0].Cells[1].Value.ToString());
                string RID = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                float x = float.Parse(AppsHelper.ReturnValue("select Paid from regs where RID=" + RID));
                float y = float.Parse(AppsHelper.ReturnValue("select Remain from regs where RID=" + RID));
                float xfinal;
                if (xnew > xold)
                {
                    xfinal = xnew - xold;
                    x = x + xfinal;
                    y = y - xfinal;
                }
                else
                {
                    xfinal = xold - xnew;
                    x = x - xfinal;
                    y = y + xfinal;
                }
                AppsHelper.UpdateQuery("Regs", "Paid+" + x, "Remain+" + y, "RID+" + RID);
                Ref3();
                Ref4();
                MessageBox.Show("تم التعديل بنجاح");

                toolStripTextBox2.Text = "";
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NewEditStudent n = new NewEditStudent();
            n.Text = "نافذة ادراج طالب جديد";
            n.button1.Text = "ادراج";
            n.ShowDialog();
        }
        public int row;

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            NewEditStudent n = new NewEditStudent();
            n.Text = "نافذة تعديل بيانات الطالب " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() ;
            n.button1.Text = "تعديل";
            n.SID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            DataTable dt = AppsHelper.ReturnDataTable("select * from Students where SID="+SID);
            n.Name.Text = dt.Rows[0]["Name"].ToString();
            n.FatherName.Text = dt.Rows[0]["FatherName"].ToString();
            n.MotherName.Text = dt.Rows[0]["MotherName"].ToString();
            n.Mobile.Text = dt.Rows[0]["Mobile"].ToString();
            n.FatherMobile.Text = dt.Rows[0]["FatherMobile"].ToString();
            n.MotherMobile.Text = dt.Rows[0]["MotherMobile"].ToString();
            n.Address.Text = dt.Rows[0]["Address"].ToString();
            n.r = row;
            n.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (AppsHelper.CheckRole(Primary.p.m.userName.Text,"R2"))
            {
                if (MessageBox.Show(
       "هل أنت متأكد من أنك تود حذف بيانات الطالب نهائياً",
       "رسالة تنبيه",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Warning,
       MessageBoxDefaultButton.Button2,
       MessageBoxOptions.RightAlign
       ) == DialogResult.Yes)
                {

                    AppsHelper.SendQuery("delete from Students where SID=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    if (string.IsNullOrEmpty(search.Text))
                    {
                        Ref1();
                    }
                    else
                    {
                        Ref2();
                    }
                    MessageBox.Show("تم الحذف بنجاح");
                }
            }
         
            }
    }
}
