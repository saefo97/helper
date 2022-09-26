namespace School
{
    partial class Prices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Price = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.className = new System.Windows.Forms.ComboBox();
            this.yearName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Sold1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Sold4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Sold3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Sold2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Price
            // 
            this.Price.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Price.Location = new System.Drawing.Point(114, 54);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(124, 22);
            this.Price.TabIndex = 5;
            this.Price.TextChanged += new System.EventHandler(this.Price_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(26, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "الصف";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(275, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "العام";
            // 
            // className
            // 
            this.className.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.className.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.className.FormattingEnabled = true;
            this.className.Location = new System.Drawing.Point(100, 15);
            this.className.Name = "className";
            this.className.Size = new System.Drawing.Size(169, 22);
            this.className.TabIndex = 7;
            this.className.SelectedIndexChanged += new System.EventHandler(this.className_SelectedIndexChanged);
            // 
            // yearName
            // 
            this.yearName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.yearName.FormattingEnabled = true;
            this.yearName.Location = new System.Drawing.Point(325, 14);
            this.yearName.Name = "yearName";
            this.yearName.Size = new System.Drawing.Size(84, 22);
            this.yearName.TabIndex = 8;
            this.yearName.SelectedIndexChanged += new System.EventHandler(this.className_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(26, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "السعر";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(26, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "حسم نقابة";
            // 
            // Sold1
            // 
            this.Sold1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Sold1.Location = new System.Drawing.Point(114, 90);
            this.Sold1.Name = "Sold1";
            this.Sold1.Size = new System.Drawing.Size(124, 22);
            this.Sold1.TabIndex = 10;
            this.Sold1.TextChanged += new System.EventHandler(this.Price_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(26, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "حسم خاص";
            // 
            // Sold4
            // 
            this.Sold4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Sold4.Location = new System.Drawing.Point(114, 197);
            this.Sold4.Name = "Sold4";
            this.Sold4.Size = new System.Drawing.Size(124, 22);
            this.Sold4.TabIndex = 12;
            this.Sold4.TextChanged += new System.EventHandler(this.Price_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(26, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "حسم تفوق";
            // 
            // Sold3
            // 
            this.Sold3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Sold3.Location = new System.Drawing.Point(114, 161);
            this.Sold3.Name = "Sold3";
            this.Sold3.Size = new System.Drawing.Size(124, 22);
            this.Sold3.TabIndex = 14;
            this.Sold3.TextChanged += new System.EventHandler(this.Price_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(26, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "حسم شقيق";
            // 
            // Sold2
            // 
            this.Sold2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Sold2.Location = new System.Drawing.Point(114, 126);
            this.Sold2.Name = "Sold2";
            this.Sold2.Size = new System.Drawing.Size(124, 22);
            this.Sold2.TabIndex = 16;
            this.Sold2.TextChanged += new System.EventHandler(this.Price_TextChanged);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(230, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 41);
            this.button2.TabIndex = 19;
            this.button2.Text = "رجوع";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(135, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 41);
            this.button1.TabIndex = 18;
            this.button1.Text = "حفظ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(5, 94);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(5, 130);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 21;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(5, 165);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 22;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(5, 201);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 23;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.Visible = false;
            // 
            // Prices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 290);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Sold2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Sold3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Sold4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Sold1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yearName);
            this.Controls.Add(this.className);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Prices";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نافذة ضبط الأسعار";
            this.Load += new System.EventHandler(this.Prices_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Price;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox className;
        private System.Windows.Forms.ComboBox yearName;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox Sold1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox Sold4;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox Sold3;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox Sold2;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox checkBox3;
        public System.Windows.Forms.CheckBox checkBox4;
    }
}