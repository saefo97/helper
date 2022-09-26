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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AppsHelper.EnableStyle(dataGridView1);

            AppsHelper.SetControl("select ClassName from Classes", className);
            className.Items.Add("الكل");

            className.Text = "الكل";

        }

        public void ref1()
        {
            if (className.Text != "الكل")
            {
                AppsHelper.SetControl(@"SELECT        Products.PID AS [رقم المادة], Products.ProductName AS [اسم المادة], Products.Unit AS [واحدة البيع], Products.BoxN AS [محتوى الصندوق], Products.State AS الحالة, Products.Price1 AS [ش ق], Products.Price2 AS [ش ط], Products.Price3 AS [م ق], 
                         Products.Price4 AS [م ط], Products.Price5 AS [ش ق (أعلى)], Products.Price6 AS [ش ط (أعلى)], Products.Price7 AS [م ق (أعلى)], Products.Price8 AS [م ط (أعلى)], Products.Price9 AS [ش ق (خاص)], Products.Price10 AS [ش ط (خاص)], 
                         Products.Price11 AS [م ق (خاص)], Products.Price12 AS [م ط (خاص)]
FROM            Classes INNER JOIN
                         Products ON Classes.CID = Products.CID
WHERE        (Classes.ClassName = N'" + className.Text + "')", dataGridView1);
            }
            else
            {
                AppsHelper.SetControl(@"SELECT        Products.PID AS [رقم المادة], Products.ProductName AS [اسم المادة], Products.Unit AS [واحدة البيع], Products.BoxN AS [محتوى الصندوق], Products.State AS الحالة, Products.Price1 AS [ش ق], Products.Price2 AS [ش ط], Products.Price3 AS [م ق], 
                         Products.Price4 AS [م ط], Products.Price5 AS [ش ق (أعلى)], Products.Price6 AS [ش ط (أعلى)], Products.Price7 AS [م ق (أعلى)], Products.Price8 AS [م ط (أعلى)], Products.Price9 AS [ش ق (خاص)], Products.Price10 AS [ش ط (خاص)], 
                         Products.Price11 AS [م ق (خاص)], Products.Price12 AS [م ط (خاص)]
FROM            Classes INNER JOIN
                         Products ON Classes.CID = Products.CID", dataGridView1);
            }



            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;


            toolStripStatusLabel2.Text = dataGridView1.Rows.Count.ToString();

            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[15].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[16].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }
        public void ref2()
        {
            if (className.Text != "الكل")
            {
                AppsHelper.SetControl(@"SELECT        Products.PID AS [رقم المادة], Products.ProductName AS [اسم المادة], Products.Unit AS [واحدة البيع], Products.BoxN AS [محتوى الصندوق], Products.State AS الحالة, Products.Price1 AS [ش ق], Products.Price2 AS [ش ط], Products.Price3 AS [م ق], 
                         Products.Price4 AS [م ط], Products.Price5 AS [ش ق (أعلى)], Products.Price6 AS [ش ط (أعلى)], Products.Price7 AS [م ق (أعلى)], Products.Price8 AS [م ط (أعلى)], Products.Price9 AS [ش ق (خاص)], Products.Price10 AS [ش ط (خاص)], 
                         Products.Price11 AS [م ق (خاص)], Products.Price12 AS [م ط (خاص)], Barcodes.Barcode
FROM            Classes INNER JOIN
                         Products ON Classes.CID = Products.CID INNER JOIN
                         Barcodes ON Products.PID = Barcodes.PID
WHERE        (Classes.ClassName = N'" + className.Text + "') AND ((Products.ProductName like N'%" + boxSearch.Text + "%') or (Barcodes.Barcode like '%" + boxSearch.Text + "%'))", dataGridView1);
            }
            else
            {
                AppsHelper.SetControl(@"SELECT        Products.PID AS [رقم المادة], Products.ProductName AS [اسم المادة], Products.Unit AS [واحدة البيع], Products.BoxN AS [محتوى الصندوق], Products.State AS الحالة, Products.Price1 AS [ش ق], Products.Price2 AS [ش ط], Products.Price3 AS [م ق], 
                         Products.Price4 AS [م ط], Products.Price5 AS [ش ق (أعلى)], Products.Price6 AS [ش ط (أعلى)], Products.Price7 AS [م ق (أعلى)], Products.Price8 AS [م ط (أعلى)], Products.Price9 AS [ش ق (خاص)], Products.Price10 AS [ش ط (خاص)], 
                         Products.Price11 AS [م ق (خاص)], Products.Price12 AS [م ط (خاص)], Barcodes.Barcode
FROM            Classes INNER JOIN
                         Products ON Classes.CID = Products.CID INNER JOIN
                         Barcodes ON Products.PID = Barcodes.PID
WHERE        ((Products.ProductName like N'%" + boxSearch.Text + "%') or (Barcodes.Barcode like '%" + boxSearch.Text + "%'))", dataGridView1);
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            toolStripStatusLabel2.Text = dataGridView1.Rows.Count.ToString();
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

        }

        private void className_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(boxSearch.Text))
            {
                ref1();
            }
            else
            {
                ref2();
            }
        }

        private void boxSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(boxSearch.Text))
            {
                ref1();
            }
            else
            {
                ref2();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                d1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                d2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                d3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                d4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                d5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();


                if (string.IsNullOrEmpty(d4.Text))
                {
                    d4.Text = "-";
                }

            }
            catch
            {


            }
        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            boxSearch.Text = "";

        }
    }
}