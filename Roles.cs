using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mall
{
    public partial class Roles : Form
    {
        public Roles()
        {
            InitializeComponent();
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            AppsHelper.SetControl(@"select UserName from Users", userName);
        }
        int x = 0;
        private void userName_SelectedIndexChanged(object sender, EventArgs e)
        {
            x = 1;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is CheckBox)
                {
                    string R = ((CheckBox)tableLayoutPanel1.Controls[i]).Name.ToString();
                    string data = AppsHelper.ReturnValue("select " + R + " from Users where UserName=N'" + userName.Text + "'");
                    if (string.IsNullOrEmpty(data) || data == "False")
                    {
                        ((CheckBox)tableLayoutPanel1.Controls[i]).Checked = false;
                    }
                    else
                    {
                        ((CheckBox)tableLayoutPanel1.Controls[i]).Checked = true;

                    }
                }
            }
            x = 0;
        }

        private void R1_CheckedChanged(object sender, EventArgs e)
        {
            if (x == 0)
            {
                try
                {
                    string R = ((CheckBox)sender).Name.ToString();

                    if (((CheckBox)sender).Checked)
                    {
                        AppsHelper.UpdateQuery("Users", R + "+1", "UserName+" + userName.Text);
                    }
                    else
                    {
                        AppsHelper.UpdateQuery("Users", R + "+0", "UserName+" + userName.Text);
                    }
                }
                catch
                {

                }
            }


        }
    }
}
