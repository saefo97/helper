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
    public partial class tryy3 : Form
    {
        public tryy3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppsHelper.SetControl("select * from Classes", dataGridView1);
        }

        private void Master_Load(object sender, EventArgs e)
        {
            AppsHelper.EnableStyle(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppsHelper.Export(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppsHelper.BarCode("5620054555223", pictureBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AppsHelper.QR("I LOVE YOUUUUUU SO MUCH", qrCodeImgControl1);
        }
        Word.Application oWord; Word.Document oDoc;
        private void button5_Click(object sender, EventArgs e)
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
                AppsHelper.FindReplace(oDoc, vvv, "[0]", textBox1.Text);
                AppsHelper.FindReplace(oDoc, vvv, "[1]", textBox2.Text);
                AppsHelper.FindReplace(oDoc, vvv, "[2]", textBox3.Text);

                object oRange = oDoc.Bookmarks[1].Range;
                object saveWithDocument = true;
                object missing = Type.Missing;
                string pictureName = System.Windows.Forms.Application.StartupPath + "\\2b.jpg";
                pictureBox1.Image.Save(System.Windows.Forms.Application.StartupPath + "\\2b.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                oDoc.InlineShapes.AddPicture(pictureName, ref missing, ref saveWithDocument, ref oRange);

                oDoc.Save();
                System.Threading.Thread.Sleep(50);

                oDoc.PrintOut();
                System.Threading.Thread.Sleep(70);

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
        }

        private void QrCodeImgControl1_Click(object sender, EventArgs e)
        {

        }

        private void Tryy3_Load(object sender, EventArgs e)
        {
            AppsHelper.EnableStyle(dataGridView1);
        }
    }
}
