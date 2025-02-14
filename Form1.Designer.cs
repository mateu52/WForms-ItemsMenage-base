namespace ItemsMenage
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnDodaj = new Button();
            btnUsun = new Button();
            btnSzukaj = new Button();
            txtTytul = new TextBox();
            txtAutor = new TextBox();
            txtRok = new TextBox();
            cmbTyp = new ComboBox();
            txtSzukaj = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(24, 96);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(419, 298);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(449, 58);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(75, 28);
            btnDodaj.TabIndex = 1;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // btnUsun
            // 
            btnUsun.Location = new Point(24, 400);
            btnUsun.Name = "btnUsun";
            btnUsun.Size = new Size(46, 28);
            btnUsun.TabIndex = 2;
            btnUsun.Text = "Usuń";
            btnUsun.UseVisualStyleBackColor = true;
            btnUsun.Click += btnUsun_Click;
            // 
            // btnSzukaj
            // 
            btnSzukaj.Location = new Point(368, 462);
            btnSzukaj.Name = "btnSzukaj";
            btnSzukaj.Size = new Size(75, 28);
            btnSzukaj.TabIndex = 3;
            btnSzukaj.Text = "Szukaj";
            btnSzukaj.UseVisualStyleBackColor = true;
            btnSzukaj.Click += btnSzukaj_Click;
            // 
            // txtTytul
            // 
            txtTytul.Location = new Point(160, 29);
            txtTytul.Name = "txtTytul";
            txtTytul.Size = new Size(139, 23);
            txtTytul.TabIndex = 4;
            txtTytul.Text = "Tytuł";
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(160, 58);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(139, 23);
            txtAutor.TabIndex = 5;
            txtAutor.Text = "Autor";
            // 
            // txtRok
            // 
            txtRok.Location = new Point(380, 58);
            txtRok.Name = "txtRok";
            txtRok.Size = new Size(63, 23);
            txtRok.TabIndex = 6;
            txtRok.Text = "Rok";
            // 
            // cmbTyp
            // 
            cmbTyp.FormattingEnabled = true;
            cmbTyp.Items.AddRange(new object[] { "Książka", "Film", "Muzyka" });
            cmbTyp.Location = new Point(305, 58);
            cmbTyp.Name = "cmbTyp";
            cmbTyp.Size = new Size(69, 23);
            cmbTyp.TabIndex = 7;
            // 
            // txtSzukaj
            // 
            txtSzukaj.Location = new Point(236, 462);
            txtSzukaj.Multiline = true;
            txtSzukaj.Name = "txtSzukaj";
            txtSzukaj.Size = new Size(126, 28);
            txtSzukaj.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(236, 444);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 9;
            label1.Text = "Podaj szukany tytuł:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 653);
            Controls.Add(label1);
            Controls.Add(txtSzukaj);
            Controls.Add(cmbTyp);
            Controls.Add(txtRok);
            Controls.Add(txtAutor);
            Controls.Add(txtTytul);
            Controls.Add(btnSzukaj);
            Controls.Add(btnUsun);
            Controls.Add(btnDodaj);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnDodaj;
        private Button btnUsun;
        private Button btnSzukaj;
        private TextBox txtTytul;
        private TextBox txtAutor;
        private TextBox txtRok;
        private ComboBox cmbTyp;
        private TextBox txtSzukaj;
        private Label label1;
    }
}
