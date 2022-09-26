using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mall
{
    public partial class Notes : Form
    {
        public Notes()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            note.Clear();
            this.ActiveControl = note;
        }

        private void Notes_Load(object sender, EventArgs e)
        {
            this.ActiveControl = note;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AppsHelper.SaveText(note);
        }
    }
}
