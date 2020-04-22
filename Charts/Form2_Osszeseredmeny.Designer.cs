namespace Charts
{
    partial class Form2_Osszeseredmeny
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2_Osszeseredmeny));
            this.dataGridView_Eredmeny = new System.Windows.Forms.DataGridView();
            this.button_Letolt_ossz = new System.Windows.Forms.Button();
            this.saveFileDialog_mentes = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Eredmeny)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Eredmeny
            // 
            this.dataGridView_Eredmeny.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Eredmeny.Location = new System.Drawing.Point(211, 31);
            this.dataGridView_Eredmeny.Name = "dataGridView_Eredmeny";
            this.dataGridView_Eredmeny.RowHeadersWidth = 51;
            this.dataGridView_Eredmeny.RowTemplate.Height = 24;
            this.dataGridView_Eredmeny.Size = new System.Drawing.Size(722, 523);
            this.dataGridView_Eredmeny.TabIndex = 4;
            // 
            // button_Letolt_ossz
            // 
            this.button_Letolt_ossz.Location = new System.Drawing.Point(40, 60);
            this.button_Letolt_ossz.Name = "button_Letolt_ossz";
            this.button_Letolt_ossz.Size = new System.Drawing.Size(92, 44);
            this.button_Letolt_ossz.TabIndex = 5;
            this.button_Letolt_ossz.Text = "Mentés";
            this.button_Letolt_ossz.UseVisualStyleBackColor = true;
            this.button_Letolt_ossz.Click += new System.EventHandler(this.button_Letolt_ossz_Click);
            // 
            // saveFileDialog_mentes
            // 
            this.saveFileDialog_mentes.CheckFileExists = true;
            this.saveFileDialog_mentes.ValidateNames = false;
            this.saveFileDialog_mentes.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_mentes_FileOk);
            // 
            // Form2_Osszeseredmeny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 566);
            this.Controls.Add(this.button_Letolt_ossz);
            this.Controls.Add(this.dataGridView_Eredmeny);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2_Osszeseredmeny";
            this.Text = "Összes Eredmény";
            this.Load += new System.EventHandler(this.Form2_Osszeseredmeny_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Eredmeny)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_Eredmeny;
        private System.Windows.Forms.Button button_Letolt_ossz;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_mentes;
    }
}