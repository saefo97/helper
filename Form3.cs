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
    public partial class Form3 : Form
    {
        public string MID;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            AppsHelper.EnableStyle(dataGridView1);


            AppsHelper.SetControl(@"SELECT        ToUser AS إلى, R AS الحالة
FROM            MessRec
WHERE        (MID = "+MID+")", dataGridView1);
        }
    }
}
