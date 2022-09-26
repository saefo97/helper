using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Utils;
using System.Net;
using GsmComm.PduConverter;
using GsmComm.PduConverter.SmartMessaging;
using GsmComm.GsmCommunication;
using GsmComm.Interfaces;
using GsmComm.Server;
using System.IO;
using System.IO.Ports;
using eiad=Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using ZXing;
using Gma.QrCodeNet.Encoding.Windows.Forms;

namespace Mall
{
    static class AppsHelper
    {
        public static void Insert_Image(string path, string PID)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = cs;
            FileStream fs;
            fs = new FileStream(@path, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            connection.Open();
            string query;
            query = "update Products set pic=@pic where PID="+PID;
            SqlParameter picparameter = new SqlParameter();
            picparameter.SqlDbType = SqlDbType.Image;
            picparameter.ParameterName = "pic";
            picparameter.Value = picbyte;
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(picparameter);
            cmd.ExecuteNonQuery();
            connection.Close();

        }
        public static void Read_Image1(string query, PictureBox p)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = cs;
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                SqlCommand cc = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cc);
                DataSet ds = new DataSet("MyImages");
                byte[] MyData = new byte[0];
                adapter.Fill(ds, "MyImages");
                DataRow myRow;
                myRow = ds.Tables["MyImages"].Rows[0];
                MyData = (byte[])myRow["Pic"];
                MemoryStream stream = new MemoryStream(MyData);
                p.Image = Image.FromStream(stream);


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        public static void Read_Image2(string query, PictureBox p)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = cs;
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                SqlCommand cc = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cc);
                DataSet ds = new DataSet("MyImages");
                byte[] MyData = new byte[0];
                adapter.Fill(ds, "MyImages");
                DataRow myRow;
                myRow = ds.Tables["MyImages"].Rows[0];
                MyData = (byte[])myRow["Pic2"];
                MemoryStream stream = new MemoryStream(MyData);
                p.Image = Image.FromStream(stream);


            }
            catch
            {
            }
        }
        public static void Insert_Image2(string path, string PID)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = cs;
            FileStream fs;
            fs = new FileStream(@path, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            connection.Open();
            string query;
            query = "update Products set pic2=@pic2 where PID=" + PID;
            SqlParameter picparameter = new SqlParameter();
            picparameter.SqlDbType = SqlDbType.Image;
            picparameter.ParameterName = "pic2";
            picparameter.Value = picbyte;
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(picparameter);
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public static string userName;

        public static string cs = @"Server=SAEFO\SAEFO ; DataBase=Mall ; User ID=sa ; PassWord=saefomomo@gmail.com";
        public static void SetControl(string query,object o,params string[] WithOut)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cs;
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = query;
            SqlDataAdapter ada = new SqlDataAdapter();
            ada.SelectCommand = com;
            DataTable dt = new DataTable();
            ada.Fill(dt);

            DataGridView dgv;
            ListBox lb;
            CheckedListBox clb;
            ComboBox cb;
            ToolStripComboBox tcb;
            Label l;
            ToolStripLabel tl;
            ToolStripStatusLabel tsl;
            TextBox t;
            ToolStripTextBox tt;


            if (o is DataGridView)
            {
                dgv = ((DataGridView)o);
                dgv.DataSource = null;
                dgv.DataSource = dt;

                int space1 = query.IndexOf(" ");
                int space2 = query.IndexOf(" ",space1+1);
                int space3 = query.IndexOf(" ",space2+1);
                string tableName = query.Substring(space3+1,query.Length-space3-1);

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    try
                    {
                        string type = AppsHelper.ReturnValue(@"SELECT DATA_TYPE 
FROM INFORMATION_SCHEMA.COLUMNS
WHERE 
     TABLE_NAME = '" + tableName + @"' AND 
     COLUMN_NAME = '" + dgv.Columns[i].Name + @"'
");
                        if (type == "int" || type == "float")
                        {
                            for (int j = 0; j < WithOut.Length; j++)
                            {
                                if (dgv.Columns[i].Name == WithOut[j])
                                {
                                    goto end;
                                }
                            }
                            dgv.Columns[i].DefaultCellStyle.Format = "N0";
                        }
                        end:;
                    }
                    catch
                    {

                       
                    }
                 
                }


                ToolTipController x = new ToolTipController();
                x.SetTitle(dgv, "CPC");
                x.SetToolTip(dgv, "eiad arja");


            }
            else if (o is ListBox)
            {
                lb = ((ListBox)o);
                lb.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lb.Items.Add(dt.Rows[i][0].ToString());
                }
            }
            else if (o is CheckedListBox)
            {
                clb = ((CheckedListBox)o);
                clb.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clb.Items.Add(dt.Rows[i][0].ToString());
                }

            }
            else if (o is ComboBox)
            {
                cb = ((ComboBox)o);
                cb.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cb.Items.Add(dt.Rows[i][0].ToString());
                }

            }
            else if (o is ToolStripComboBox)
            {
                tcb = ((ToolStripComboBox)o);
                tcb.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tcb.Items.Add(dt.Rows[i][0].ToString());
                }

            }
            else if (o is Label)
            {
                l = ((Label)o);
                l.Text = dt.Rows[0][0].ToString();
            }
            else if (o is ToolStripLabel)
            {
                tl = ((ToolStripLabel)o);
                tl.Text = dt.Rows[0][0].ToString();
            }
            else if (o is ToolStripStatusLabel)
            {
                tsl = ((ToolStripStatusLabel)o);
                tsl.Text = dt.Rows[0][0].ToString();
            }
            else if (o is TextBox)
            {
                t = ((TextBox)o);
                t.Text = dt.Rows[0][0].ToString();
            }
            else if (o is ToolStripTextBox)
            {
                tt = ((ToolStripTextBox)o);
                tt.Text = dt.Rows[0][0].ToString();
            }
        }
        public static void EnableStyle(params DataGridView[] dgv)
        {
            for (int i = 0; i < dgv.Length; i++)
            {
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
                dgv[i].AllowUserToAddRows = false;
                dgv[i].AllowUserToDeleteRows = false;
                dgv[i].AllowUserToResizeRows = false;
                dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dgv[i].AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
                dgv[i].AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
                dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
                dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgv[i].ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
                dgv[i].ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
                dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dgv[i].SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

                dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
                dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                dgv[i].DefaultCellStyle = dataGridViewCellStyle3;
                dgv[i].EnableHeadersVisualStyles = false;
                dgv[i].MultiSelect = false;
                dgv[i].ReadOnly = true;
                dgv[i].RowHeadersVisible = false;
                dgv[i].TabIndex = 0;
            }
          
        }
        public static void WithDecimal(string t,object o)
        {
            try
            {
                decimal x = decimal.Parse(t);

                Label la;
                ToolStripLabel tsl;
                ToolStripStatusLabel tssl;
                TextBox te;
                ToolStripTextBox tst;

                if (o is Label)
                {
                    la = ((Label)o);
                    la.Text = string.Format("{0:N0}", x);
                }
                else if (o is ToolStripLabel)
                {
                    tsl = ((ToolStripLabel)o);
                    tsl.Text = string.Format("{0:N0}", x);
                }
                else if (o is ToolStripStatusLabel)
                {
                    tssl = ((ToolStripStatusLabel)o);
                    tssl.Text = string.Format("{0:N0}", x);
                }
                else if (o is TextBox)
                {
                    te = ((TextBox)o);
                    te.Text = string.Format("{0:N0}", x);
                }
                else if (o is ToolStripTextBox)
                {
                    tst = ((ToolStripTextBox)o);
                    tst.Text = string.Format("{0:N0}", x);
                }
            }
            catch
            {
                MessageBox.Show("E01");
            }
        }
        public static void WithDecimal(decimal t, object o)
        {
            try
            {
                Label la;
                ToolStripLabel tsl;
                ToolStripStatusLabel tssl;
                TextBox te;
                ToolStripTextBox tst;

                if (o is Label)
                {
                    la = ((Label)o);
                    la.Text = string.Format("{0:N0}", t);
                }
                else if (o is ToolStripLabel)
                {
                    tsl = ((ToolStripLabel)o);
                    tsl.Text = string.Format("{0:N0}", t);
                }
                else if (o is ToolStripStatusLabel)
                {
                    tssl = ((ToolStripStatusLabel)o);
                    tssl.Text = string.Format("{0:N0}", t);
                }
                else if (o is TextBox)
                {
                    te = ((TextBox)o);
                    te.Text = string.Format("{0:N0}", t);
                }
                else if (o is ToolStripTextBox)
                {
                    tst = ((ToolStripTextBox)o);
                    tst.Text = string.Format("{0:N0}", t);
                }
            }
            catch
            {
                MessageBox.Show("E01");
            }
        }
        public static void WithDecimal(StatusStrip s)
        {
            ToolStripStatusLabel t;
            for (int i = 0; i < s.Items.Count; i++)
            {
                if (s.Items[i] is ToolStripStatusLabel)
                {
                    t = ((ToolStripStatusLabel)s.Items[i]);
                    try
                    {
                        decimal x = decimal.Parse(t.Text);
                        t.Text = string.Format("{0:N0}",x);
                    }
                    catch
                    {

                   
                    }
                }
            }
        }
        public static void WithDecimal(object o)
        {
            Panel p;
            ToolStrip t;

            if (o is Panel)
            {
                p = ((Panel)o);
                TextBox te;
                for (int i = 0; i < p.Controls.Count; i++)
                {
                    if (p.Controls[i] is TextBox)
                    {
                        te = ((TextBox)p.Controls[i]);
                        te.TextChanged += new System.EventHandler(SmartCode);
                    }
                }
            }
            else if (o is ToolStrip)
            {
                t = ((ToolStrip)o);
                ToolStripTextBox te;
                for (int i = 0; i < t.Items.Count; i++)
                {
                    if (t.Items[i] is ToolStripTextBox)
                    {
                        te = ((ToolStripTextBox)t.Items[i]);
                        te.TextChanged += new System.EventHandler(SmartCode);
                    }
                }
            }



           
        }
        private static void SmartCode(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                try
                {
                    decimal x = decimal.Parse(((TextBox)sender).Text);
                    ((TextBox)sender).Text = string.Format("{0:N0}", x);
                    ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                }
                catch
                {


                }
            }
            else if (sender is ToolStripTextBox)
            {
                try
                {
                    decimal x = decimal.Parse(((ToolStripTextBox)sender).Text);
                    ((ToolStripTextBox)sender).Text = string.Format("{0:N0}", x);
                    ((ToolStripTextBox)sender).SelectionStart = ((ToolStripTextBox)sender).Text.Length;
                }
                catch
                {


                }
            }
        }
        static byte x = 0;
        public static void Just(params TextBox[] tbs)
        {
           

            for (int i = 0; i < tbs.Length; i++)
            {
                tbs[i].KeyPress += new KeyPressEventHandler(SmartCode2);
            }

        }
        private static void SmartCode2(object sender, KeyPressEventArgs e)
        {

            switch (((TextBox)sender).Tag.ToString())
            {
                case "en": x = 0; break;
                case "ar": x = 1; break;
                case "ens": x = 2; break;
                case "enc": x = 3; break;
                case "num": x = 4; break;
                case "sym": x = 5; break;
            }



            switch (x)
            {
                case 0:
                    if ((e.KeyChar<65 || (e.KeyChar>90 && e.KeyChar<97) || e.KeyChar>122)
                        && e.KeyChar!=13
                        && e.KeyChar != 8
                        && e.KeyChar != 32
                        )
                    {
                        e.Handled = true;
                    }
                    ; break;
                case 1:

                    if (e.KeyChar==1571 || e.KeyChar==1573 || e.KeyChar==1570)
                    {
                        e.KeyChar = (char)1575;
                    }


                    if ((e.KeyChar<1575 || e.KeyChar>1610)
                        && e.KeyChar != 13
                        && e.KeyChar != 8
                        && e.KeyChar != 32

                        )
                    {
                        e.Handled = true;
                    }
                    break;

                case 2:

                    if (e.KeyChar>=65 && e.KeyChar<=90)
                    {
                        e.KeyChar = (char)(e.KeyChar + 32);
                    }

                    if ((e.KeyChar < 97 || e.KeyChar > 122)
                        && e.KeyChar != 13
                        && e.KeyChar != 8
                        && e.KeyChar != 32

                        )
                    {
                        e.Handled = true;
                    }
                    ; break;


                case 3:

                    if (e.KeyChar >= 97 && e.KeyChar <= 122)
                    {
                        e.KeyChar = (char)(e.KeyChar - 32);
                    }

                    if ((e.KeyChar < 65 || e.KeyChar > 90)
                        && e.KeyChar != 13
                        && e.KeyChar != 8
                        && e.KeyChar != 32

                        )
                    {
                        e.Handled = true;
                    }
                    ; break;

                case 4:

                    if ((e.KeyChar < 48 || e.KeyChar > 57)
                        && e.KeyChar != 13
                        && e.KeyChar != 8
                        && e.KeyChar != 44
                        && e.KeyChar != 46

                        )
                    {
                        e.Handled = true;
                    }
                    ; break;
                case 5:
                    if ((e.KeyChar < 65 || (e.KeyChar > 90 && e.KeyChar < 97) || e.KeyChar > 122)
                        && (e.KeyChar < 48 || e.KeyChar > 57)
                        && e.KeyChar != 13
                        && e.KeyChar != 8
                        && e.KeyChar != 46
                        && e.KeyChar != 64
                        && e.KeyChar != 95
                        )
                    {
                        e.Handled = true;
                    }
                    ; break;
            }
            
        }
        public static bool Check(Panel p)
        {
            int v = 0;

            string mes = "";

            string[] x = new string[p.Controls.Count/2];

            TextBox te;
            ComboBox cb;

            for (int i = 0; i < p.Controls.Count; i++)
            {
                if (p.Controls[i] is TextBox)
                {
                    te = ((TextBox)p.Controls[i]);
                    if (te.Tag!= null && string.IsNullOrEmpty(te.Text))
                    {
                            int score = te.Tag.ToString().IndexOf("-");
                            int num = int.Parse(te.Tag.ToString().Substring(0, score));
                            string word = te.Tag.ToString().Substring(score + 1, te.Tag.ToString().Length - score-1);
                            x[num] = word;
                            v++;
                    }
                }
                else if (p.Controls[i] is ComboBox)
                {
                    cb = ((ComboBox)p.Controls[i]);
                    if (!string.IsNullOrEmpty(cb.Tag.ToString()) && string.IsNullOrEmpty(cb.Text))
                    {
                            int score = cb.Tag.ToString().IndexOf("-");
                            int num = int.Parse(cb.Tag.ToString().Substring(0, score));
                            string word = cb.Tag.ToString().Substring(score + 1, cb.Tag.ToString().Length - score-1);
                            x[num] = word;
                            v++;
                    }
                }
            }

            if (v==0)
            {
                return true;
            }
            else
            {
                if (v>1)
                {
                    mes += (":" + "الرجاء ملئ الخانات التالية" + "\n");
                }
                else if (v==1)
                {
                    mes += (  "الرجاء ملئ الخانة التالية" + ":" + " ");
                }
                for (int i = 0; i < x.Length; i++)
                {
                    if (!string.IsNullOrEmpty(x[i]))
                    {
                        mes += x[i] + "\n";
                        if (v == 1)
                        {
                            break;
                        }
                    }
                }
                MessageBox.Show(mes,"رسالة تنبيه",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign);
                return false;
            }
        }
        public static string ReturnValue(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = cs;
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;
                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;
                DataTable dt = new DataTable();
                ada.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0][0].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                //MessageBox.Show("E20");
                return null;
            }
        }
        public static int ReturnInt(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = cs;
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;
                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;
                DataTable dt = new DataTable();
                ada.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return int.Parse(dt.Rows[0][0].ToString());
                }
                else
                {
                    MessageBox.Show("لا توجد قيمة لتتم اعادتها");
                    return -1;
                }
            }
            catch
            {
                MessageBox.Show("E21");
                return -1;
            }

        }
        public static float ReturnFloat(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = cs;
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;
                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;
                DataTable dt = new DataTable();
                ada.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return float.Parse(dt.Rows[0][0].ToString());
                }
                else
                {
                    MessageBox.Show("لا توجد قيمة لتتم اعادتها");
                    return -1.0f;
                }
            }
            catch
            {
                MessageBox.Show("E21");
                return -1.0f;
            }

        }
        public static DataTable ReturnDataTable(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = cs;
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;
                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;
                DataTable dt = new DataTable();
                ada.Fill(dt);
                return dt;
            }
            catch
            {
                MessageBox.Show("E24");
                return null;
            }
        }
        public static void SendQuery(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = cs;
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;
                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("E60");
            }
        }
        public static void InsertQuery(string TableName,params string[] x)
        {
            try
            {
                string columnName;
                string columnValue;
                string columnType;
                int plus;
            string query = "insert into "+TableName+" (";

                for (int i = 0; i < x.Length; i++)
                {
                    plus = x[i].IndexOf("+");
                    columnName = x[i].Substring(0,plus);

                    query += columnName;

                    if (i!= x.Length-1)
                    {
                        query += ",";
                    }
                }


                query += ") values (";

                for (int i = 0; i < x.Length; i++)
                {
                     plus = x[i].IndexOf("+");
                     columnName = x[i].Substring(0, plus);
                     columnValue = x[i].Substring(plus+1, x[i].Length-plus-1);
                     columnType= AppsHelper.ReturnValue(@"SELECT DATA_TYPE 
FROM INFORMATION_SCHEMA.COLUMNS
WHERE 
     TABLE_NAME = '" + TableName + @"' AND 
     COLUMN_NAME = '" + columnName + @"'
");
                    if (columnType=="char" || columnType == "varchar" || columnType == "date" || columnType == "time")
                    {
                        query += "'"+columnValue+"'";
                    }
                    else if (columnType == "nchar" || columnType == "nvarchar")
                    {
                        query += "N'" + columnValue + "'";
                    }
                    else
                    {
                        query +=  columnValue ;
                    }

                    if (i != x.Length - 1)
                    {
                        query += ",";
                    }
                }

                query += ")";

                SendQuery(query);
            }
            catch 
            {
                MessageBox.Show("E90");
                
            }
        }
        public static void UpdateQuery(string TableName,params string[] x)
        {
            try
            {
                string query = "update "+TableName+" set ";

                string columnName;
                string columnValue;
                string columnType;
                int plus;

                for (int i = 0; i < x.Length; i++)
                {
                    plus = x[i].IndexOf("+");
                    columnName = x[i].Substring(0, plus);
                    columnValue = x[i].Substring(plus + 1, x[i].Length - plus - 1);
                    columnType = AppsHelper.ReturnValue(@"SELECT DATA_TYPE 
FROM INFORMATION_SCHEMA.COLUMNS
WHERE 
     TABLE_NAME = '" + TableName + @"' AND 
     COLUMN_NAME = '" + columnName + @"'
");

                    query += columnName + "=";

                    if (columnType == "char" || columnType == "varchar" || columnType == "date" || columnType == "time")
                    {
                        query += "'" + columnValue + "'";
                    }
                    else if (columnType == "nchar" || columnType == "nvarchar")
                    {
                        query += "N'" + columnValue + "'";
                    }
                    else
                    {
                        query += columnValue;
                    }



                    if (i<x.Length-2)
                    {
                        query += ",";
                    }
                    else if (i==x.Length-2)
                    {
                        query += " where ";
                    }

                }

                AppsHelper.SendQuery(query);
            }
            catch
            {
                MessageBox.Show("E110");
              
            }
        }
        public static string ConvertToArabic(long x)
        {
            try
            {
                ToWord t = new ToWord();
                CurrencyInfo c = new CurrencyInfo(CurrencyInfo.Currencies.Syria);
                return t.ConvertToArabic(x, c);
            }
            catch 
            {
                return "-";
            }
        }
        public static void BackUP()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "BAK Files|*.bak";
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                AppsHelper.SendQuery(@"BACKUP DATABASE [Mall] 
                                TO  DISK = N'" + saveFileDialog1.FileName + @"' 
                                WITH NOFORMAT, NOINIT,  NAME = N'Clinc-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10");

                MessageBox.Show("تم النسخ بنجاح");
            }
            else
            {
                MessageBox.Show("تم الغاء عملية النسخ الاحتياطي");
            }
        }
        public static void Restore()
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Filter = "BAK Files|*.bak";
            if (op1.ShowDialog() == DialogResult.OK)
            {
                AppsHelper.SendQuery(@"alter database Mall
                                    set offline with rollback immediate
                                    alter database Mall
                                    set online;alter database Mall
                                    set single_user with rollback immediate;
                                    alter database Mall
                                    set multi_user
                                    ;RESTORE DATABASE Mall  
                                       FROM DISK = '" + op1.FileName + "' WITH REPLACE; ");

                MessageBox.Show("تمت الاستعادة بنجاح");
            }
            else
            {
                MessageBox.Show("تم الغاء عملية النسخ الاحتياطي");
            }
        }
        public static string GetDate_PC_SQL()
        {
            string x = DateTime.Now.ToString("yyyy/MM/dd");
            return x;
        }
        public static string GetDate_PC_Normal()
        {
            string x = DateTime.Now.ToString("dd/MM/yyyy");
            return x;
        }
        public static string GetTime_PC()
        {
            string x = DateTime.Now.ToString("hh:mm:ss tt");
            return x;
        }
        public static string GetDate_Server_Normal()
        {
            string x = DateTime.Parse(ReturnValue("select getDate()")).ToString("dd/MM/yyyy");
            return x;
        }
        public static string GetDate_Server_SQL()
        {
            string x = DateTime.Parse(ReturnValue("select getDate()")).ToString("yyyy/MM/dd");
            return x;
        }
        public static string GetTime_Server()
        {
            string x = DateTime.Parse(ReturnValue("select getDate()")).ToString("hh:mm:ss tt");
            return x;
        }
        public static void NewHistory(string k,string Details)
        {
            try
            {
                InsertQuery("History","UserName+"+userName,"k+"+k,"Details+"+Details,"Date+"+GetDate_Server_SQL(),"Time+"+GetTime_Server());
            }
            catch
            {
                MessageBox.Show("E100");
            }
        }
        public static bool CheckRole(string R)
        {
            try
            {
                string RoleName = ReturnValue("select RoleName from Roles where R='"+R+"'");
                string x = ReturnValue("select "+R+" from Users where userName=N'"+userName+"'");
                if (string.IsNullOrEmpty(x) || x=="False")
                {
                    MessageBox.Show("ليس لديك الصلاحية "+RoleName);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("E200");
                return false;
            }
        }
    }
}
