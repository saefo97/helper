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
    public partial class Prices : Form
    {
        public string CID, YID, CYID;

        public string SID;
        public Prices()
        {
            InitializeComponent();
        }

        private void className_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //جلب رقم الصف
                CID = AppsHelper.ReturnValue("select CID from Classes where ClassName=N'"+className.Text+"'");
                //جلب رقم العام
                YID = AppsHelper.ReturnValue("select YID from Years where YearName='"+yearName.Text+"'");
                //في حال وجود رقم صف ورقم عام نجلب رقم التسعير
                if (!string.IsNullOrEmpty(CID) && !string.IsNullOrEmpty(YID))
                {
                    CYID = AppsHelper.ReturnValue("select CYID from Prices where CID=" + CID + " and YID=" + YID);
                    if (!string.IsNullOrEmpty(CYID))
                    {
                        Price.Text = "";
                        Sold1.Text = "";
                        Sold2.Text = "";
                        Sold3.Text = "";
                        Sold4.Text = "";
                        DataTable dt = AppsHelper.ReturnDataTable("select * from Prices where CYID="+CYID);
                        Price.Text = dt.Rows[0]["Price"].ToString();
                        Sold1.Text = dt.Rows[0]["Sold1"].ToString();
                        Sold2.Text = dt.Rows[0]["Sold2"].ToString();
                        Sold3.Text = dt.Rows[0]["Sold3"].ToString();
                        Sold4.Text = dt.Rows[0]["Sold4"].ToString();

                    }
                }
            }
            catch
            {

           
            }
        }
        int v = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text=="حفظ")
            {
                if (string.IsNullOrEmpty(CYID))
                {
                    AppsHelper.InsertQuery("Prices",
                        "CID+" + CID,
                        "YID+" + YID
                        );
                }
                CYID = AppsHelper.ReturnValue("select CYID from Prices where CID=" + CID + " and YID=" + YID);
                if (!string.IsNullOrEmpty(Price.Text))
                {
                    AppsHelper.UpdateQuery("Prices",
                        "Price+" + Price.Text,
                        "CYID+" + CYID);
                }
                if (!string.IsNullOrEmpty(Sold1.Text))
                {
                    AppsHelper.UpdateQuery("Prices",
                        "Sold1+" + Sold1.Text,
                        "CYID+" + CYID);
                }
                if (!string.IsNullOrEmpty(Sold2.Text))
                {
                    AppsHelper.UpdateQuery("Prices",
                        "Sold2+" + Sold2.Text,
                        "CYID+" + CYID);
                }
                if (!string.IsNullOrEmpty(Sold3.Text))
                {
                    AppsHelper.UpdateQuery("Prices",
                        "Sold3+" + Sold3.Text,
                        "CYID+" + CYID);
                }
                if (!string.IsNullOrEmpty(Sold4.Text))
                {
                    AppsHelper.UpdateQuery("Prices",
                        "Sold4+" + Sold4.Text,
                        "CYID+" + CYID);
                }
                MessageBox.Show("تم الحفظ بنجاح");
                if (v==1)
                {
                    button1.Text = "تسجيل";
                    v = 0;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(CYID))
                {
                    MessageBox.Show("عذرا قم بتسعير الصف والعام أولاً");
                    button1.Text = "حفظ";
                    v = 1;
                    goto end;
                }
                float sold1=0;
                float sold2 = 0;
                float sold3 = 0;
                float sold4 = 0;
                float sold = 0;
                float price = float.Parse(Price.Text.Replace(",", ""));
                AppsHelper.InsertQuery("Regs","SID+"+SID,"CYID+"+CYID,"Price+"+Price.Text);
                string RID = AppsHelper.ReturnValue("select max(RID) from Regs where SID="+SID);
                if (checkBox1.Checked)
                {
                    AppsHelper.UpdateQuery("Regs","Sold1+"+Sold1.Text.Replace(",",""),"RID+"+RID);
                    sold1 = float.Parse(Sold1.Text.Replace(",", ""));
                }
                if (checkBox2.Checked)
                {
                    AppsHelper.UpdateQuery("Regs", "Sold2+" + Sold2.Text.Replace(",", ""), "RID+" + RID);
                    sold2 = float.Parse(Sold2.Text.Replace(",", ""));
                }
                if (checkBox3.Checked)
                {
                    AppsHelper.UpdateQuery("Regs", "Sold3+" + Sold3.Text.Replace(",", ""), "RID+" + RID);
                    sold3 = float.Parse(Sold3.Text.Replace(",", ""));
                }
                if (checkBox4.Checked)
                {
                    AppsHelper.UpdateQuery("Regs", "Sold4+" + Sold4.Text.Replace(",", ""), "RID+" + RID);
                    sold4 = float.Parse(Sold4.Text.Replace(",", ""));
                }
                sold = sold1 + sold2 + sold3 + sold4;
                float remain = price - sold - 0;
                AppsHelper.UpdateQuery("Regs", "Sold+" + sold.ToString(),"Paid+0","Remain+"+remain, "RID+" + RID);
                MessageBox.Show("تم التسجيل بنجاح");
                this.Close();
                Primary.p.m.students.Ref3();
                end:;

            }

        }

        private void Price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                AppsHelper.WithDecimal(((TextBox)sender));
            }
            catch
            {

               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Prices_Load(object sender, EventArgs e)
        {
            AppsHelper.SetControl("select ClassName from Classes", className);
            AppsHelper.SetControl("select YearName from Years", yearName);

        }
    }
}
