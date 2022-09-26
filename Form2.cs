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
    public partial class Form2 : Form
    {
        public string className;
        public string yearName;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                AppsHelper.EnableStyle(dataGridView1);

                AppsHelper.SetControl(@"SELECT        Students.Name AS الاسم, Students.FatherName AS [اسم الأب], Students.MotherName AS [اسم الام], Students.Mobile AS [موبايل الطالب], Students.FatherMobile AS [موبايل الأب], Students.MotherMobile AS [موبايل الأم], Regs.Price AS مستحق, 
                         Regs.Sold AS حسم, Regs.Paid AS مدفوع, Regs.Remain AS متبقي
FROM            Regs INNER JOIN
                         Prices ON Regs.CYID = Prices.CYID INNER JOIN
                         Years ON Prices.YID = Years.YID INNER JOIN
                         Students ON Regs.SID = Students.SID INNER JOIN
                         Classes ON Prices.CID = Classes.CID
WHERE        (Years.YearName = '" + yearName+"') AND (Classes.ClassName = N'"+className+"')", dataGridView1);

                dataGridView1.Columns[6].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[7].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[8].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[9].DefaultCellStyle.Format = "N0";

            }
            catch
            {

            }
        }
    }
}
