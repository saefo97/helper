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
using System.Globalization;
using System.Net;
using System.IO.Ports;
namespace School
{
    public static class AppsHelper
    {
       
        private static SqlConnection con = new SqlConnection();

        private static string k1 = "hk845YJg#$p8^*";

  
        public static void BackUP()
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "bak Files|*.bak";
            s.ShowDialog();
            AppsHelper.SendQuery(@"BACKUP DATABASE [School] 
                                TO  DISK = N'" + s.FileName + @"' 
                                WITH NOFORMAT, NOINIT,  NAME = N'Clinc-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
 ");
            MessageBox.Show("تم النسخ الاحتياطي بنجاح");
        }
        public static void Restore()
        {

            OpenFileDialog op1 = new OpenFileDialog();
            op1.Filter = "bak Files|*.bak";
            op1.ShowDialog();
            AppsHelper.SendQuery(@"use master");

            AppsHelper.SendQuery(@"
                                    alter database School
                                    set single_user with rollback immediate;
                                    alter database School
                                    set multi_user
                                    ;");
            AppsHelper.SendQuery(@"alter database School
                                    set offline with rollback immediate


                                    alter database School
                                    set online;alter database School
                                    set single_user with rollback immediate;
                                    alter database School
                                    set multi_user
                                    ;RESTORE DATABASE School  
                                       FROM DISK = '" + op1.FileName + "' WITH REPLACE;  ");
            MessageBox.Show("تمت الاستعادة بنجاح");
        }
        public static bool SetSetting(string Server, string Database, string UserID, string Password)
        {
            try
            {
                con.ConnectionString = "Server=" + Server + ";DataBase=" + Database + ";User ID=" + UserID + ";Password=" + Password + ";MultipleActiveResultSets=true;";
                //con.ConnectionString = string.Format("Server={0};DataBase={1};User ID={2};Password={3};MultipleActiveResultSets=true;",Server,Database,UserID,Password);
                con.Open();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SetSettingWithMessage(string Server, string Database, string UserID, string Password)
        {
            try
            {
                con.ConnectionString = "Server=" + Server + ";DataBase=" + Database + ";User ID=" + UserID + ";Password=" + Password + ";Connect Timeout=1;MultipleActiveResultSets=true;";
                //con.ConnectionString = string.Format("Server={0};DataBase={1};User ID={2};Password={3};MultipleActiveResultSets=true;",Server,Database,UserID,Password);
                con.Open();
                con.Close();
                MessageBox.Show("تم الاتصال بمخدم البيانات بنجاح");
                return true;
            }
            catch
            {
                MessageBox.Show("فشل الاتصال بمخدم البيانات");
                return false;
            }
        }
        public static bool SetSettingWithFailedMessage(string Server, string Database, string UserID, string Password)
        {
            try
            {
                con.ConnectionString = "Server=" + Server + ";DataBase=" + Database + ";User ID=" + UserID + ";Password=" + Password + ";Connect Timeout=1;MultipleActiveResultSets=true;";
                //con.ConnectionString = string.Format("Server={0};DataBase={1};User ID={2};Password={3};MultipleActiveResultSets=true;",Server,Database,UserID,Password);
                con.Open();
                con.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("فشل الاتصال بمخدم البيانات");
                return false;
            }
        }

        public static void SetControl(string query, DataGridView dgv)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                DataTable dt = new DataTable();

                ada.Fill(dt);

                dgv.DataSource = null;
                dgv.DataSource = dt;

                com.Dispose();
                ada.Dispose();
                dt.Dispose();
            }
            catch
            {
                MessageBox.Show("Error:01");
            }
        }
        public static void SetControl(string query, TextBox te)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                DataTable dt = new DataTable();

                ada.Fill(dt);

                te.Text = dt.Rows[0][0].ToString();

                com.Dispose();
                ada.Dispose();
                dt.Dispose();
            }
            catch
            {
                MessageBox.Show("Error:02");
            }
        }
        public static void SetControl(string query, ToolStripTextBox te)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                DataTable dt = new DataTable();

                ada.Fill(dt);

                te.Text = dt.Rows[0][0].ToString();

                com.Dispose();
                ada.Dispose();
                dt.Dispose();
            }
            catch
            {
                MessageBox.Show("Error:03");
            }
        }
        public static void SetControl(string query, Label la)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                DataTable dt = new DataTable();

                ada.Fill(dt);

                la.Text = dt.Rows[0][0].ToString();

                com.Dispose();
                ada.Dispose();
                dt.Dispose();
            }
            catch
            {
                MessageBox.Show("Error:04");
            }
        }
        public static void SetControl(string query, ToolStripLabel la)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                DataTable dt = new DataTable();

                ada.Fill(dt);

                la.Text = dt.Rows[0][0].ToString();

                com.Dispose();
                ada.Dispose();
                dt.Dispose();
            }
            catch
            {
                MessageBox.Show("Error:05");
            }
        }
        public static void SetControl(string query, ToolStripStatusLabel la)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                DataTable dt = new DataTable();

                ada.Fill(dt);

                la.Text = dt.Rows[0][0].ToString();

                com.Dispose();
                ada.Dispose();
                dt.Dispose();
            }
            catch
            {
                MessageBox.Show("Error:06");
            }
        }
        public static void SetControl(string query, ComboBox cb, bool x = true)
        {
            try
            {
                if (x == true)
                {
                    cb.Items.Clear();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                DataTable dt = new DataTable();

                ada.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cb.Items.Add(dt.Rows[i][0].ToString());
                }


                com.Dispose();
                ada.Dispose();
                dt.Dispose();
            }
            catch
            {
                MessageBox.Show("Error:07");
            }
        }
        public static void SetControl(string query, ToolStripComboBox cb, bool x = true)
        {
            try
            {
                if (x == true)
                {
                    cb.Items.Clear();
                }
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                DataTable dt = new DataTable();

                ada.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cb.Items.Add(dt.Rows[i][0].ToString());
                }


                com.Dispose();
                ada.Dispose();
                dt.Dispose();
            }
            catch
            {
                MessageBox.Show("Error:08");
            }
        }
        public static void WithDecimal(long number, Label la)
        {
            try
            {
                la.Text = string.Format("{0:N0}", number);
            }
            catch
            {
                MessageBox.Show("Error:09");
            }
        }


        public static void WithDecimal(ToolStripStatusLabel la)
        {
            try
            {
                la.Text = string.Format("{0:N0}", decimal.Parse(la.Text));
            }
            catch
            {
            }
        }
        public static void WithDecimal(long number, ToolStripLabel la)
        {
            try
            {
                la.Text = string.Format("{0:N0}", number);
            }
            catch
            {
                MessageBox.Show("Error:10");
            }
        }
        public static void WithDecimal(long number, ToolStripStatusLabel la)
        {
            try
            {
                la.Text = string.Format("{0:N0}", number);
            }
            catch
            {
                MessageBox.Show("Error:11");
            }
        }
        public static void WithDecimal(long number, TextBox te)
        {
            try
            {
                te.Text = string.Format("{0:N0}", number);
            }
            catch
            {
                MessageBox.Show("Error:12");
            }
        }
        public static void WithDecimal(long number, ToolStripTextBox te)
        {
            try
            {
                te.Text = string.Format("{0:N0}", number);
            }
            catch
            {
                MessageBox.Show("Error:13");
            }
        }
        public static void WithDecimal(TextBox te)
        {
            try
            {
                if (!string.IsNullOrEmpty(te.Text))
                {
                    te.Text = string.Format("{0:N0}", long.Parse(te.Text.Replace(",", "")));
                    te.SelectionStart = te.Text.Length;
                }
            }
            catch
            {
                MessageBox.Show("Error:14");
            }
        }
        public static void WithDecimal_floating(TextBox te)
        {
            try
            {
                if (!string.IsNullOrEmpty(te.Text))
                {
                    te.Text = string.Format("{0:N2}", double.Parse(te.Text.Replace(",", "")));
                    te.SelectionStart = te.Text.Length;
                }
            }
            catch
            {
                MessageBox.Show("Error:14");
            }
        }
        public static void WithDecimal(ToolStripTextBox te)
        {
            try
            {
                if (!string.IsNullOrEmpty(te.Text))
                {
                    te.Text = string.Format("{0:N0}", long.Parse(te.Text.Replace(",", "")));
                    te.SelectionStart = te.Text.Length;
                }
            }
            catch
            {
                MessageBox.Show("Error:15");
            }
        }
        public static void WithDecimal_SetControl(string query, DataGridView dgv)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                DataTable dt = new DataTable();

                ada.Fill(dt);

                dgv.DataSource = dt;

                //مرحلة قص اسم الجدول
                query = query.Replace("from ", "#");
                int sharp = query.IndexOf("#");
                int space = query.IndexOf(" ", sharp + 1);
                string TableName;
                if (space == -1)
                {
                    TableName = query.Substring(sharp + 1, query.Length - sharp - 1);
                }
                else
                {
                    TableName = query.Substring(sharp + 1, space - sharp - 1);
                }
                //
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    string a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + dgv.Columns[i].Name + "'");
                    if (a == "int")
                    {
                        string b = AppsHelper.ReturnValue("select columnproperty(object_id('" + TableName + "'),'" + dgv.Columns[i].Name + "','IsIdentity')");
                        if (b == "0")
                        {
                            dgv.Columns[i].DefaultCellStyle.Format = "N0";
                        }
                    }
                }

                com.Dispose();
                ada.Dispose();
                dt.Dispose();
            }
            catch
            {
                MessageBox.Show("Error:16");
            }
        }
        private static ErrorProvider[] x;
        public static bool Check(Panel p)
        {

            try
            {
                string[] m = new string[p.Controls.Count / 2];
                int v = 0;
                for (int i = 0; i < p.Controls.Count; i++)
                {
                    if (p.Controls[i] is TextBox)
                    {
                        TextBox te = (TextBox)p.Controls[i];
                        if (string.IsNullOrEmpty(te.Text) && !string.IsNullOrEmpty((string)te.Tag))
                        {
                            int a = te.Tag.ToString().IndexOf("-");
                            int b = int.Parse(te.Tag.ToString().Substring(0, a));
                            string c = te.Tag.ToString().Substring(a + 1, te.Tag.ToString().Length - a - 1);
                            m[b] = c;
                            v++;
                        }
                    }
                    if (p.Controls[i] is ComboBox)
                    {
                        ComboBox cb = (ComboBox)p.Controls[i];
                        if (string.IsNullOrEmpty(cb.Text) && !string.IsNullOrEmpty((string)cb.Tag))
                        {
                            int a = cb.Tag.ToString().IndexOf("-");
                            int b = int.Parse(cb.Tag.ToString().Substring(0, a));
                            string c = cb.Tag.ToString().Substring(a + 1, cb.Tag.ToString().Length - a - 1);
                            m[b] = c;
                            v++;
                        }
                    }
                }

                string message = "";

                if (v == 1)
                {
                    message = "الرجاء ملئ الخانة التالية: ";
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(m[i]))
                        {
                            message += m[i];
                            break;
                        }
                    }
                }
                else if (v > 1)
                {
                    int z = 0;
                    message = ":" + "الرجاء ملئ الخانات التالية" + "\n";
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(m[i]))
                        {
                            message += m[i] + "\n";
                            z++;
                            if (z == v)
                            {
                                break;
                            }
                        }
                    }
                }


                if (v > 0)
                {
                    MessageBox.Show(message, "رسالة تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Error:19");
                return true;
            }

        }
        public static bool Check(ToolStrip p)
        {

            try
            {
                string[] m = new string[p.Items.Count / 2];
                int v = 0;
                for (int i = 0; i < p.Items.Count; i++)
                {
                    if (p.Items[i] is ToolStripTextBox)
                    {
                        ToolStripTextBox te = (ToolStripTextBox)p.Items[i];
                        if (string.IsNullOrEmpty(te.Text) && !string.IsNullOrEmpty((string)te.Tag))
                        {
                            int a = te.Tag.ToString().IndexOf("-");
                            int b = int.Parse(te.Tag.ToString().Substring(0, a));
                            string c = te.Tag.ToString().Substring(a + 1, te.Tag.ToString().Length - a - 1);
                            m[b] = c;
                            v++;
                        }
                    }
                    if (p.Items[i] is ToolStripComboBox)
                    {
                        ToolStripComboBox cb = (ToolStripComboBox)p.Items[i];
                        if (string.IsNullOrEmpty(cb.Text) && !string.IsNullOrEmpty((string)cb.Tag))
                        {
                            int a = cb.Tag.ToString().IndexOf("-");
                            int b = int.Parse(cb.Tag.ToString().Substring(0, a));
                            string c = cb.Tag.ToString().Substring(a + 1, cb.Tag.ToString().Length - a - 1);
                            m[b] = c;
                            v++;
                        }
                    }
                }

                string message = "";

                if (v == 1)
                {
                    message = "الرجاء ملئ الخانة التالية: ";
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(m[i]))
                        {
                            message += m[i];
                            break;
                        }
                    }
                }
                else if (v > 1)
                {
                    int z = 0;
                    message = ":" + "الرجاء ملئ الخانات التالية" + "\n";
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(m[i]))
                        {
                            message += m[i] + "\n";
                            z++;
                            if (z == v)
                            {
                                break;
                            }
                        }
                    }
                }


                if (v > 0)
                {
                    MessageBox.Show(message, "رسالة تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Error:19");
                return true;
            }

        }

        public static ErrorProvider[] e1;
        public static bool CheckWithErrorStyle1(Panel p)
        {

            try
            {
                //
                try
                {
                    for (int i = 0; i < e1.Length; i++)
                    {
                        e1[i].Clear();
                    }
                }
                catch
                {


                }
                e1 = new ErrorProvider[p.Controls.Count / 2];
                int n = 0;
                //
                string[] m = new string[p.Controls.Count / 2];
                int v = 0;
                for (int i = 0; i < p.Controls.Count; i++)
                {
                    if (p.Controls[i] is TextBox)
                    {
                        e1[n] = new ErrorProvider();
                        TextBox te = (TextBox)p.Controls[i];
                        if (string.IsNullOrEmpty(te.Text) && !string.IsNullOrEmpty((string)te.Tag))
                        {
                            int a = te.Tag.ToString().IndexOf("-");
                            int b = int.Parse(te.Tag.ToString().Substring(0, a));
                            string c = te.Tag.ToString().Substring(a + 1, te.Tag.ToString().Length - a - 1);
                            m[b] = c;
                            v++;
                            e1[n].SetError(te, "الرجاء ملئ هذه الخانة");
                            n++;
                        }
                    }
                    if (p.Controls[i] is ComboBox)
                    {
                        e1[n] = new ErrorProvider();
                        ComboBox cb = (ComboBox)p.Controls[i];
                        if (string.IsNullOrEmpty(cb.Text) && !string.IsNullOrEmpty((string)cb.Tag))
                        {
                            int a = cb.Tag.ToString().IndexOf("-");
                            int b = int.Parse(cb.Tag.ToString().Substring(0, a));
                            string c = cb.Tag.ToString().Substring(a + 1, cb.Tag.ToString().Length - a - 1);
                            m[b] = c;
                            v++;
                            e1[n].SetError(cb, "الرجاء ملئ هذه الخانة");
                            n++;
                        }
                    }
                }

                string message = "";

                if (v == 1)
                {
                    message = "الرجاء ملئ الخانة التالية: ";
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(m[i]))
                        {
                            message += m[i];
                            break;
                        }
                    }
                }
                else if (v > 1)
                {
                    int z = 0;
                    message = ":" + "الرجاء ملئ الخانات التالية" + "\n";
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(m[i]))
                        {
                            message += m[i] + "\n";
                            z++;
                            if (z == v)
                            {
                                break;
                            }
                        }
                    }
                }


                if (v > 0)
                {
                    MessageBox.Show(message, "رسالة تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Error:20");
                return true;
            }

        }
        public static bool CheckWithErrorStyle2(Panel p)
        {

            try
            {
                //
                try
                {
                    for (int i = 0; i < e1.Length; i++)
                    {
                        e1[i].Clear();
                    }
                }
                catch
                {


                }
                e1 = new ErrorProvider[p.Controls.Count / 2];
                int n = 0;
                //
                string[] m = new string[p.Controls.Count / 2];
                int v = 0;
                for (int i = 0; i < p.Controls.Count; i++)
                {
                    if (p.Controls[i] is TextBox)
                    {
                        TextBox te = (TextBox)p.Controls[i];
                        if (string.IsNullOrEmpty(te.Text) && !string.IsNullOrEmpty((string)te.Tag))
                        {
                            int a = te.Tag.ToString().IndexOf("-");
                            int b = int.Parse(te.Tag.ToString().Substring(0, a));
                            string c = te.Tag.ToString().Substring(a + 1, te.Tag.ToString().Length - a - 1);
                            m[b] = c;
                            v++;
                        }
                    }
                    if (p.Controls[i] is ComboBox)
                    {
                        ComboBox cb = (ComboBox)p.Controls[i];
                        if (string.IsNullOrEmpty(cb.Text) && !string.IsNullOrEmpty((string)cb.Tag))
                        {
                            int a = cb.Tag.ToString().IndexOf("-");
                            int b = int.Parse(cb.Tag.ToString().Substring(0, a));
                            string c = cb.Tag.ToString().Substring(a + 1, cb.Tag.ToString().Length - a - 1);
                            m[b] = c;
                            v++;
                        }
                    }
                }

                string message = "";

                if (v == 1)
                {
                    message = "الرجاء ملئ الخانة التالية: ";
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(m[i]))
                        {
                            message += m[i];
                            break;
                        }
                    }
                }
                else if (v > 1)
                {
                    int z = 0;
                    message = ":" + "الرجاء ملئ الخانات التالية" + "\n";
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(m[i]))
                        {
                            message += m[i] + "\n";
                            z++;
                            if (z == v)
                            {
                                break;
                            }
                        }
                    }
                }


                if (v > 0)
                {
                    MessageBox.Show(message, "رسالة تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                    for (int i = 0; i < p.Controls.Count; i++)
                    {
                        if (p.Controls[i] is TextBox)
                        {
                            e1[n] = new ErrorProvider();
                            TextBox te = (TextBox)p.Controls[i];
                            if (string.IsNullOrEmpty(te.Text) && !string.IsNullOrEmpty((string)te.Tag))
                            {
                                e1[n].SetError(te, "الرجاء ملئ هذه الخانة");
                                n++;
                            }
                        }
                        if (p.Controls[i] is ComboBox)
                        {
                            e1[n] = new ErrorProvider();
                            ComboBox cb = (ComboBox)p.Controls[i];
                            if (string.IsNullOrEmpty(cb.Text) && !string.IsNullOrEmpty((string)cb.Tag))
                            {
                                e1[n].SetError(cb, "الرجاء ملئ هذه الخانة");
                                n++;
                            }
                        }

                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Error:21");
                return true;
            }

        }
        public static bool CheckWithErrorStyle3(Panel p)
        {

            try
            {
                //
                try
                {
                    for (int i = 0; i < e1.Length; i++)
                    {
                        e1[i].Clear();
                    }
                }
                catch
                {


                }
                e1 = new ErrorProvider[p.Controls.Count / 2];
                int n = 0;
                //
                string[] m = new string[p.Controls.Count / 2];
                int v = 0;
                for (int i = 0; i < p.Controls.Count; i++)
                {
                    if (p.Controls[i] is TextBox)
                    {
                        TextBox te = (TextBox)p.Controls[i];
                        if (string.IsNullOrEmpty(te.Text) && !string.IsNullOrEmpty((string)te.Tag))
                        {
                            int a = te.Tag.ToString().IndexOf("-");
                            int b = int.Parse(te.Tag.ToString().Substring(0, a));
                            string c = te.Tag.ToString().Substring(a + 1, te.Tag.ToString().Length - a - 1);
                            m[b] = c;
                            v++;
                        }
                    }
                    if (p.Controls[i] is ComboBox)
                    {
                        ComboBox cb = (ComboBox)p.Controls[i];
                        if (string.IsNullOrEmpty(cb.Text) && !string.IsNullOrEmpty((string)cb.Tag))
                        {
                            int a = cb.Tag.ToString().IndexOf("-");
                            int b = int.Parse(cb.Tag.ToString().Substring(0, a));
                            string c = cb.Tag.ToString().Substring(a + 1, cb.Tag.ToString().Length - a - 1);
                            m[b] = c;
                            v++;
                        }
                    }
                }

                string message = "";

                if (v == 1)
                {
                    message = "الرجاء ملئ الخانة التالية: ";
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(m[i]))
                        {
                            message += m[i];
                            break;
                        }
                    }
                }
                else if (v > 1)
                {
                    int z = 0;
                    message = ":" + "الرجاء ملئ الخانات التالية" + "\n";
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(m[i]))
                        {
                            message += m[i] + "\n";
                            z++;
                            if (z == v)
                            {
                                break;
                            }
                        }
                    }
                }


                if (v > 0)
                {
                    MessageBox.Show(message, "رسالة تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                    for (int i = 0; i < p.Controls.Count; i++)
                    {
                        if (p.Controls[i] is TextBox)
                        {
                            e1[n] = new ErrorProvider();
                            TextBox te = (TextBox)p.Controls[i];
                            if (string.IsNullOrEmpty(te.Text) && !string.IsNullOrEmpty((string)te.Tag))
                            {
                                int a = te.Tag.ToString().IndexOf("-");
                                int b = int.Parse(te.Tag.ToString().Substring(0, a));
                                string c = te.Tag.ToString().Substring(a + 1, te.Tag.ToString().Length - a - 1);
                                e1[n].SetError(te, "الرجاء ملئ " + c);
                                n++;
                            }
                        }
                        if (p.Controls[i] is ComboBox)
                        {
                            e1[n] = new ErrorProvider();
                            ComboBox cb = (ComboBox)p.Controls[i];
                            if (string.IsNullOrEmpty(cb.Text) && !string.IsNullOrEmpty((string)cb.Tag))
                            {
                                int a = cb.Tag.ToString().IndexOf("-");
                                int b = int.Parse(cb.Tag.ToString().Substring(0, a));
                                string c = cb.Tag.ToString().Substring(a + 1, cb.Tag.ToString().Length - a - 1);
                                e1[n].SetError(cb, "الرجاء ملئ " + c);
                                n++;
                            }
                        }

                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Error:22");
                return true;
            }

        }
        public static string GetNowDate()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }
        public static string GetNowDate_SQL()
        {
            return DateTime.Now.ToString("yyyy/MM/dd");
        }
        public static string GetNowTime()
        {
            string a = DateTime.Now.ToString("hh:mm:ss tt");
            if (a.Contains("ص"))
            {
                a = a.Replace("ص", "AM");
            }
            else if (a.Contains("م"))
            {
                a = a.Replace("م", "PM");
            }
            return a;
        }
        public static string GetNowHijireDate()
        {
            DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            HijriCalendar ca = new HijriCalendar();
            string a = ca.GetDayOfMonth(d).ToString();
            string b = ca.GetMonth(d).ToString();
            string c = ca.GetYear(d).ToString();
            return DateTime.Now.ToString(a + "/" + b + "/" + c);
        }
        public static void KeyboardInArabic()
        {
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("Arabic"))
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[i];
                }
            }
        }
        public static void KeyboardInEnglish()
        {
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("US") || InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("UK"))
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[i];
                }
            }
        }
        public static void JustArabic(KeyPressEventArgs e, TextBox te)
        {


            if ((te.Text.Length == 0 && e.KeyChar == 32)
                ||
                (te.Text.Length > 0 && e.KeyChar == 32 && te.Text[te.Text.Length - 1] == 32))
            {
                e.Handled = true;
                goto end;
            }


            if (e.KeyChar == 1571 || e.KeyChar == 1573 || e.KeyChar == 1570)
            {
                e.KeyChar = (char)1575;
            }

            if (((e.KeyChar < 1570 || e.KeyChar > 1610) || e.KeyChar == 1600)//not Arabic
                && e.KeyChar != 8//Back Space
                && e.KeyChar != 13//Enter
                && e.KeyChar != 32//Space
                && e.KeyChar != 1//Ctrl+A
                && e.KeyChar != 22//Ctrl+V
                && e.KeyChar != 26//Ctrl+Z
                && e.KeyChar != 24//Ctrl+X
                && e.KeyChar != 25//Ctrl+Y
                && e.KeyChar != 3////Ctrl+C
                )
            {
                e.Handled = true;
            }


            end:;
        }
        public static void JustEnglish(KeyPressEventArgs e, TextBox te)
        {
            if ((te.Text.Length == 0 && e.KeyChar == 32)
              ||
              (te.Text.Length > 0 && e.KeyChar == 32 && te.Text[te.Text.Length - 1] == 32))
            {
                e.Handled = true;
                goto end;
            }

            if ((e.KeyChar < 97 || e.KeyChar > 122) && (e.KeyChar < 65 || e.KeyChar > 90)//not English
                && e.KeyChar != 8//Back Space
                && e.KeyChar != 13//Enter
                && e.KeyChar != 32//Space
                && e.KeyChar != 1//Ctrl+A
                && e.KeyChar != 22//Ctrl+V
                && e.KeyChar != 26//Ctrl+Z
                && e.KeyChar != 24//Ctrl+X
                && e.KeyChar != 25//Ctrl+Y
                && e.KeyChar != 3////Ctrl+C
                )
            {
                e.Handled = true;
            }

            end:;
        }
        public static void JustNumbers(KeyPressEventArgs e)
        {

            if ((e.KeyChar < 48 || e.KeyChar > 57)//not Numbers
                && e.KeyChar != 8//Back Space
                && e.KeyChar != 13//Enter
                && e.KeyChar != 1//Ctrl+A
                && e.KeyChar != 22//Ctrl+V
                && e.KeyChar != 26//Ctrl+Z
                && e.KeyChar != 24//Ctrl+X
                && e.KeyChar != 25//Ctrl+Y
                && e.KeyChar != 3////Ctrl+C
                && e.KeyChar != 46////.
                && e.KeyChar != 44////,
                )
            {
                e.Handled = true;
            }
        }
        public static void JustEnglishWithSymbloes(KeyPressEventArgs e)
        {

            if ((e.KeyChar < 97 || e.KeyChar > 122) && (e.KeyChar < 65 || e.KeyChar > 90)//not English
                && e.KeyChar != 8//Back Space
                && e.KeyChar != 13//Enter
                && e.KeyChar != 1//Ctrl+A
                && e.KeyChar != 22//Ctrl+V
                && e.KeyChar != 26//Ctrl+Z
                && e.KeyChar != 24//Ctrl+X
                && e.KeyChar != 25//Ctrl+Y
                && e.KeyChar != 3//Ctrl+C
                && e.KeyChar != 64//@
                && e.KeyChar != 46///.
                && e.KeyChar != 95////_
                )
            {
                e.Handled = true;
            }
        }
        public static string ReturnValue(string query)
        {
            try
            {
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
                    return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:23" + "\n" + ex.Message);
                return "";
            }
        }

        public static string ReturnValueDecrypt(string query)
        {
            try
            {

                int space = query.IndexOf(" ");
                int space2 = query.IndexOf(" ", space + 1);
                string ColumnName = query.Substring(space + 1, space2 - space - 1);


                query = query.Replace(ColumnName, "convert(nvarchar,decryptbykey(" + ColumnName + "))");
                query = "open symmetric key k1 decryption by password = N'" + k1 + "';" + query;
                query = query + ";close symmetric key k1;";


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
                    return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:23" + "\n" + ex.Message);
                return "";
            }
        }
        public static int ReturnValue_int(string query)
        {
            try
            {
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
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:24" + "\n" + ex.Message);
                return 0;
            }
        }
        public static long ReturnValue_long(string query)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                DataTable dt = new DataTable();

                ada.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return long.Parse(dt.Rows[0][0].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:25" + "\n" + ex.Message);
                return 0;
            }
        }
        public static float ReturnValue_float(string query)
        {
            try
            {
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
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:26" + "\n" + ex.Message);
                return 0;
            }
        }
        public static double ReturnValue_double(string query)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                DataTable dt = new DataTable();

                ada.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return double.Parse(dt.Rows[0][0].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:27" + "\n" + ex.Message);
                return 0;
            }
        }
        public static DataTable ReturnDataTable(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;



                ada.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:28" + "\n" + ex.Message);
                return dt;
            }
        }
        public static bool CheckRole(string UserName, string R)
        {
            try
            {
                string a = AppsHelper.ReturnValue("select " + R + " from Users where UserName=N'" + UserName + "'");
                if (a == "True")
                {
                    return true;
                }
                else
                {
                    string b = AppsHelper.ReturnValue("select RoleName from Roles where R='" + R + "'");
                    MessageBox.Show("ليس لديك الصلاحية: " + b, "رسالة تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Error:29");
                return false;
            }
        }
        public static bool SendQuery(string query)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                return true;
            }
            catch
            {
                con.Close();
                MessageBox.Show("Error:30");
                return false;
            }
        }
        public static bool InsertQuery(string TableName, params object[] o)
        {
            try
            {
                try
                {
                    con.Open();
                    con.Close();
                }
                catch
                {
                    return false;
                }


                string query = "";
                //
                query += "Insert Into " + TableName + " (";
                for (int i = 0; i < o.Length; i++)
                {
                    if (o[i] is TextBox)
                    {
                        TextBox te = ((TextBox)o[i]);
                        query += te.Name;
                    }
                    if (o[i] is ToolStripTextBox)
                    {
                        ToolStripTextBox te = ((ToolStripTextBox)o[i]);
                        query += te.Name;
                    }
                    else if (o[i] is ComboBox)
                    {
                        ComboBox cb = ((ComboBox)o[i]);
                        query += cb.Name;
                    }
                    else if (o[i] is ToolStripComboBox)
                    {
                        ToolStripComboBox cb = ((ToolStripComboBox)o[i]);
                        query += cb.Name;
                    }
                    else if (o[i] is DateTimePicker)
                    {
                        DateTimePicker dtp = ((DateTimePicker)o[i]);
                        query += dtp.Name;
                    }
                    else if (o[i] is string)
                    {
                        string x = ((string)o[i]);
                        int plus = x.IndexOf("+");
                        string ColumnName = x.Substring(0, plus);
                        query += ColumnName;
                    }

                    if (i < o.Length - 1)
                    {
                        query += ",";
                    }
                }
                string a;
                query += ") Values (";

                for (int i = 0; i < o.Length; i++)
                {
                    if (o[i] is ToolStripTextBox)
                    {
                        ToolStripTextBox te = ((ToolStripTextBox)o[i]);
                        a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + te.Name + "'");
                        if (a == "nvarchar" || a == "nchar")
                        {
                            query += "N'" + te.Text + "'";
                        }
                        else if (a == "varchar" || a == "char" || a == "bit" || a == "date" || a == "time")
                        {
                            query += "'" + te.Text + "'";
                        }
                        else
                        {
                            query += te.Text.Replace(",", "");
                        }
                    }
                    if (o[i] is TextBox)
                    {
                        TextBox te = ((TextBox)o[i]);
                        a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + te.Name + "'");
                        if (a == "nvarchar" || a == "nchar")
                        {
                            query += "N'" + te.Text + "'";
                        }
                        else if (a == "varchar" || a == "char" || a == "bit" || a == "date" || a == "time")
                        {
                            query += "'" + te.Text + "'";
                        }
                        else
                        {
                            query += te.Text.Replace(",", "");
                        }
                    }
                    else if (o[i] is ComboBox)
                    {
                        ComboBox cb = ((ComboBox)o[i]);
                        a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + cb.Name + "'");
                        if (a == "nvarchar" || a == "nchar")
                        {
                            query += "N'" + cb.Text + "'";
                        }
                        else if (a == "varchar" || a == "char" || a == "bit" || a == "date" || a == "time")
                        {
                            query += "'" + cb.Text + "'";
                        }
                        else
                        {
                            query += cb.Text.Replace(",", "");
                        }
                    }
                    else if (o[i] is ToolStripComboBox)
                    {
                        ToolStripComboBox cb = ((ToolStripComboBox)o[i]);
                        a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + cb.Name + "'");
                        if (a == "nvarchar" || a == "nchar")
                        {
                            query += "N'" + cb.Text + "'";
                        }
                        else if (a == "varchar" || a == "char" || a == "bit" || a == "date" || a == "time")
                        {
                            query += "'" + cb.Text + "'";
                        }
                        else
                        {
                            query += cb.Text.Replace(",", "");
                        }
                    }
                    else if (o[i] is DateTimePicker)
                    {
                        DateTimePicker dtp = ((DateTimePicker)o[i]);
                        a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + dtp.Name + "'");
                        if (a == "date")
                        {
                            query += "'" + dtp.Value.ToString("yyyy/MM/dd") + "'";
                        }
                        else if (a == "time")
                        {
                            query += "'" + dtp.Value.ToString("hh:mm:ss tt") + "'";
                        }
                        else if (a == "datetime")
                        {
                            query += "'" + dtp.Value.ToString("yyyy/MM/dd hh:mm:ss tt") + "'";
                        }
                    }
                    else if (o[i] is string)
                    {
                        string x = ((string)o[i]);
                        int plus = x.IndexOf("+");
                        string ColumnName = x.Substring(0, plus);
                        string ColumnValue = x.Substring(plus + 1, x.Length - plus - 1);
                        a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + ColumnName + "'");
                        if (a == "nvarchar" || a == "nchar")
                        {
                            query += "N'" + ColumnValue + "'";
                        }
                        else if (a == "varchar" || a == "char" || a == "bit" || a=="date" || a=="time")
                        {
                            query += "'" + ColumnValue + "'";
                        }
                        else
                        {
                            query += ColumnValue.Replace(",", "");
                        }
                    }


                    if (i < o.Length - 1)
                    {
                        query += ",";
                    }

                }
                query += ")";
                //
                if (SendQuery(query) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Error:30");
                return false;
            }
        }
        //public static bool InsertQuery2(string TableName, params string[] o)
        //{
        //    try
        //    {
        //        try
        //        {
        //            con.Open();
        //            con.Close();
        //        }
        //        catch
        //        {
        //            return false;
        //        }

        //        string query = "";
        //        //
        //        query += "Insert Into " + TableName + " (";
        //        for (int i = 0; i < o.Length; i++)
        //        {
        //            int plus = o[i].IndexOf("+");
        //            string ColumnName = o[i].Substring(0, plus);
        //            query += ColumnName;

        //            if (i < o.Length - 1)
        //            {
        //                query += ",";
        //            }
        //        }
        //        string a;
        //        query += ") Values (";

        //        for (int i = 0; i < o.Length; i++)
        //        {
        //            int plus = o[i].IndexOf("+");
        //            string ColumnName = o[i].Substring(0, plus);
        //            string ColumnValue = o[i].Substring(plus + 1, o[i].Length - plus - 1);
        //            a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + ColumnName + "'");
        //            if (a == "nvarchar" || a == "nchar")
        //            {
        //                query += "N'" + ColumnValue + "'";
        //            }
        //            else if (a == "varchar" || a == "char")
        //            {
        //                query += "'" + ColumnValue + "'";
        //            }
        //            else
        //            {
        //                query += ColumnValue;
        //            }

        //            if (i < o.Length - 1)
        //            {
        //                query += ",";
        //            }
        //        }
        //        query += ")";
        //        //
        //        if (SendQuery(query) == true)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error:27");
        //        return false;
        //    }

        //}
        public static bool UpdateQuery(string TableName, params object[] o)
        {
            try
            {
                string a;
                try
                {
                    con.Open();
                    con.Close();
                }
                catch
                {
                    return false;
                }
                string query = "Update " + TableName + " set ";
                for (int i = 0; i < o.Length; i++)
                {
                    if (o[i] is TextBox)
                    {
                        TextBox te = ((TextBox)o[i]);
                        a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + te.Name + "'");
                        if (a == "nvarchar" || a == "nchar")
                        {
                            query += te.Name + "=" + "N'" + te.Text + "'";
                        }
                        else if (a == "varchar" || a == "char" || a == "date" || a == "time" || a=="bit")
                        {
                            query += te.Name + "=" + "'" + te.Text + "'";
                        }
                        else
                        {
                            query += te.Name + "=" + te.Text.Replace(",", "");
                        }
                    }
                    if (o[i] is ToolStripTextBox)
                    {
                        ToolStripTextBox te = ((ToolStripTextBox)o[i]);
                        a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + te.Name + "'");
                        if (a == "nvarchar" || a == "nchar")
                        {
                            query += te.Name + "=" + "N'" + te.Text + "'";
                        }
                        else if (a == "varchar" || a == "char" || a == "date" || a == "time" || a == "bit")
                        {
                            query += te.Name + "=" + "'" + te.Text + "'";
                        }
                        else
                        {
                            query += te.Name + "=" + te.Text.Replace(",", "");
                        }
                    }
                    else if (o[i] is ComboBox)
                    {
                        ComboBox cb = ((ComboBox)o[i]);
                        a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + cb.Name + "'");
                        if (a == "nvarchar" || a == "nchar")
                        {
                            query += cb.Name + "=" + "N'" + cb.Text + "'";
                        }
                        else if (a == "varchar" || a == "char" || a == "date" || a == "time" || a == "bit")
                        {
                            query += cb.Name + "=" + "'" + cb.Text + "'";
                        }
                        else
                        {
                            query += cb.Name + "=" + cb.Text.Replace(",", "");
                        }
                    }
                    else if (o[i] is ToolStripComboBox)
                    {
                        ToolStripComboBox cb = ((ToolStripComboBox)o[i]);
                        a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + cb.Name + "'");
                        if (a == "nvarchar" || a == "nchar")
                        {
                            query += cb.Name + "=" + "N'" + cb.Text + "'";
                        }
                        else if (a == "varchar" || a == "char" || a == "date" || a == "time" || a == "bit")
                        {
                            query += cb.Name + "=" + "'" + cb.Text + "'";
                        }
                        else
                        {
                            query += cb.Name + "=" + cb.Text.Replace(",", "");
                        }
                    }
                    else if (o[i] is DateTimePicker)
                    {
                        DateTimePicker dtp = ((DateTimePicker)o[i]);
                        a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + dtp.Name + "'");
                        if (a == "date")
                        {
                            query += dtp.Name + "=" + "'" + dtp.Value.ToString("yyyy/MM/dd") + "'";
                        }
                        else if (a == "time")
                        {
                            query += dtp.Name + "=" + "'" + dtp.Value.ToString("hh:mm:ss tt") + "'";
                        }
                        else if (a == "datetime")
                        {
                            query += dtp.Name + "=" + "'" + dtp.Value.ToString("yyyy/MM/dd hh:mm:ss tt") + "'";
                        }
                    }
                    else if (o[i] is string)
                    {
                        string x = ((string)o[i]);
                        int plus = x.IndexOf("+");
                        string ColumnName = x.Substring(0, plus);
                        string ColumnValue = x.Substring(plus + 1, x.Length - plus - 1);
                        a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + ColumnName + "'");
                        if (a == "nvarchar" || a == "nchar")
                        {
                            query += ColumnName + "=" + "N'" + ColumnValue + "'";
                        }
                        else if (a == "varchar" || a == "char" || a == "date" || a == "time" || a == "bit")
                        {
                            query += ColumnName + "=" + "'" + ColumnValue + "'";
                        }
                        else
                        {
                            query += ColumnName + "=" + ColumnValue.Replace(",", "");
                        }
                    }
                    if (i == o.Length - 2)
                    {
                        query += " Where ";
                    }

                    if (i < o.Length - 2)
                    {
                        query += ",";
                    }
                }

                if (SendQuery(query) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                MessageBox.Show("Error:31");
                return false;
            }
        }
        //public static bool UpdateQuery2(string TableName, params string[] o)
        //{
        //    try
        //    {
        //        string a;
        //        try
        //        {
        //            con.Open();
        //            con.Close();
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //        string query = "Update " + TableName + " set ";
        //        for (int i = 0; i < o.Length; i++)
        //        {
        //            int plus = o[i].IndexOf("+");
        //            string ColumnName = o[i].Substring(0, plus);
        //            string ColumnValue = o[i].Substring(plus + 1, o[i].Length - plus - 1);
        //            a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + ColumnName + "'");
        //            if (a == "nvarchar" || a == "nchar")
        //            {
        //                query += ColumnName + "=" + "N'" + ColumnValue + "'";
        //            }
        //            else if (a == "varchar" || a == "char")
        //            {
        //                query += ColumnName + "=" + "'" + ColumnValue + "'";
        //            }
        //            else
        //            {
        //                query += ColumnName + "=" + ColumnValue;
        //            }



        //            if (i == o.Length - 2)
        //            {
        //                query += " Where ";
        //            }

        //            if (i < o.Length - 2)
        //            {
        //                query += ",";
        //            }
        //        }

        //        if (SendQuery(query) == true)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error:28");
        //        return false;
        //    }
        //}
        public static bool NewHistory(string UserName, string K, string Details, string N = "")
        {
            try
            {
                try
                {
                    con.Open();
                    con.Close();
                }
                catch
                {
                    return false;
                }
                if (AppsHelper.InsertQuery("History", "UserName+" + UserName,
                    "Date+"+DateTime.Now.ToString("yyyy/MM/dd"),
                    "Time+"+DateTime.Now.ToString("hh:mm:ss tt"),
                    "K+" + K, 
                    "Details+" + Details, "N+" + N) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Error:32");
                return false;
            }
        }
        public static void EnableStyle(DataGridView dgv)
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle3;
            dgv.EnableHeadersVisualStyles = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        }
        public static void AutoComplete(string query, TextBox te)
        {
            try
            {
                te.AutoCompleteCustomSource.Clear();
                te.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                te.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                DataTable dt = new DataTable();

                ada.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    te.AutoCompleteCustomSource.Add(dt.Rows[i][0].ToString());
                }

                com.Dispose();
                ada.Dispose();
                dt.Dispose();
            }
            catch
            {
                MessageBox.Show("Error:33");
            }

        }
        public static void AutoComplete(string query, ComboBox cb)
        {
            try
            {
                SetControl(query, cb);

                cb.AutoCompleteCustomSource.Clear();
                cb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                cb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                DataTable dt = new DataTable();

                ada.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cb.AutoCompleteCustomSource.Add(dt.Rows[i][0].ToString());
                }

                com.Dispose();
                ada.Dispose();
                dt.Dispose();
            }
            catch
            {
                MessageBox.Show("Error:34");
            }

        }

        public static bool Encrypt(string TableName, string ColumnName, string Where, string Data2)
        {
            try
            {
                string Data;
                string a = AppsHelper.ReturnValue("select Data_Type from Information_Schema.Columns where TABLE_NAME='" + TableName + "' and column_Name='" + Where + "'");
                if (a == "int")
                {
                    Data = AppsHelper.ReturnValue("select " + ColumnName + " from " + TableName + " where " + Where + "=" + Data2);
                }
                else
                {
                    Data = AppsHelper.ReturnValue("select " + ColumnName + " from " + TableName + " where " + Where + "=N'" + Data2 + "'");
                }


                string query;
                if (a == "int")
                {
                    query = "open symmetric key k1 decryption by password = N'hk845YJg#$p8^*'; Update " + TableName + " set " + ColumnName + "=(" + "encryptbykey(KEY_Guid('k1'),N'" + Data + "')" + ") where " + Where + "=" + Data2 + ";close symmetric key k1";
                }
                else
                {
                    query = "open symmetric key k1 decryption by password = N'hk845YJg#$p8^*'; Update " + TableName + " set " + ColumnName + "=(" + "encryptbykey(KEY_Guid('k1'),N'" + Data + "')" + ") where " + Where + "=N'" + Data2 + "';close symmetric key k1";
                }
                if (SendQuery(query) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Error:35");
                return false;
            }
        }
    }

}
