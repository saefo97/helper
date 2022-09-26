using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Training.Classes
{
    class AppsHelper
    {
        public static string userName;

        public static string sc = @"Server=SAEFO\SAEFO ; DataBase=testing ; User ID=sa ; PassWord=saefomomo@gmail.com";

        public static string ReturnValue(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = sc;
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
                return null;
            }

        }

        public static void SendQuery(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = sc;
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = query;
                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = com;

                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("تم إدخال القيم بنجاح");

            }
            catch
            {
                MessageBox.Show("E60");
            }
        }

        public static void Just(TextBox tbs)
        {
            tbs.KeyPress += new KeyPressEventHandler(SmartCode);
        }

        private static void SmartCode(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57)
                && e.KeyChar != 13
                && e.KeyChar != 8
                )
                e.Handled = true;
        }

        public static void InsertQuery(string tableName,string fv, string sv, string tv)
        {
            string query = "insert into " + tableName + " values (" + fv + "," + sv + "," + tv +")";
            SendQuery(query);
        }

    }
}
