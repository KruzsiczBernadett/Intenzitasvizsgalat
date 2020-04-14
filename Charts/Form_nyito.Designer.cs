namespace Charts
{
    partial class Form_nyito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_nyito));
            this.data_Columns = new System.Windows.Forms.DataGridView();
            this.label_Letrehozas_datum = new System.Windows.Forms.Label();
            this.label_Utolso_modositas_datum = new System.Windows.Forms.Label();
            this.button_Betolt = new System.Windows.Forms.Button();
            this.label_fajl = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_Chart_Level = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView_Eredmenyek = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button_letolt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_Columns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Eredmenyek)).BeginInit();
            this.SuspendLayout();
            // 
            // data_Columns
            // 
            this.data_Columns.AllowUserToAddRows = false;
            this.data_Columns.AllowUserToDeleteRows = false;
            this.data_Columns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_Columns.Dock = System.Windows.Forms.DockStyle.Right;
            this.data_Columns.Location = new System.Drawing.Point(536, 0);
            this.data_Columns.Margin = new System.Windows.Forms.Padding(4);
            this.data_Columns.Name = "data_Columns";
            this.data_Columns.ReadOnly = true;
            this.data_Columns.RowHeadersWidth = 51;
            this.data_Columns.Size = new System.Drawing.Size(531, 606);
            this.data_Columns.TabIndex = 1;
            // 
            // label_Letrehozas_datum
            // 
            this.label_Letrehozas_datum.AutoSize = true;
            this.label_Letrehozas_datum.Location = new System.Drawing.Point(35, 71);
            this.label_Letrehozas_datum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Letrehozas_datum.Name = "label_Letrehozas_datum";
            this.label_Letrehozas_datum.Size = new System.Drawing.Size(74, 17);
            this.label_Letrehozas_datum.TabIndex = 4;
            this.label_Letrehozas_datum.Text = "letrehozas";
            // 
            // label_Utolso_modositas_datum
            // 
            this.label_Utolso_modositas_datum.AutoSize = true;
            this.label_Utolso_modositas_datum.Location = new System.Drawing.Point(35, 98);
            this.label_Utolso_modositas_datum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Utolso_modositas_datum.Name = "label_Utolso_modositas_datum";
            this.label_Utolso_modositas_datum.Size = new System.Drawing.Size(72, 17);
            this.label_Utolso_modositas_datum.TabIndex = 5;
            this.label_Utolso_modositas_datum.Text = "modositas";
            // 
            // button_Betolt
            // 
            this.button_Betolt.Location = new System.Drawing.Point(160, 15);
            this.button_Betolt.Margin = new System.Windows.Forms.Padding(4);
            this.button_Betolt.Name = "button_Betolt";
            this.button_Betolt.Size = new System.Drawing.Size(100, 28);
            this.button_Betolt.TabIndex = 6;
            this.button_Betolt.Text = "Kiválaszt";
            this.button_Betolt.UseVisualStyleBackColor = true;
            this.button_Betolt.Click += new System.EventHandler(this.button_Betolt_Click);
            // 
            // label_fajl
            // 
            this.label_fajl.AutoSize = true;
            this.label_fajl.Location = new System.Drawing.Point(35, 44);
            this.label_fajl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_fajl.Name = "label_fajl";
            this.label_fajl.Size = new System.Drawing.Size(71, 17);
            this.label_fajl.TabIndex = 7;
            this.label_fajl.Text = "forrásfájl: ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_Chart_Level
            // 
            this.button_Chart_Level.Location = new System.Drawing.Point(160, 155);
            this.button_Chart_Level.Margin = new System.Windows.Forms.Padding(4);
            this.button_Chart_Level.Name = "button_Chart_Level";
            this.button_Chart_Level.Size = new System.Drawing.Size(100, 28);
            this.button_Chart_Level.TabIndex = 8;
            this.button_Chart_Level.Text = "Ábrázol";
            this.button_Chart_Level.UseVisualStyleBackColor = true;
            this.button_Chart_Level.Click += new System.EventHandler(this.button_Chart_Level_Click);
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(38, 219);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 24);
            this.comboBox.TabIndex = 9;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // dataGridView_Eredmenyek
            // 
            this.dataGridView_Eredmenyek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Eredmenyek.Location = new System.Drawing.Point(38, 249);
            this.dataGridView_Eredmenyek.Name = "dataGridView_Eredmenyek";
            this.dataGridView_Eredmenyek.RowHeadersWidth = 51;
            this.dataGridView_Eredmenyek.RowTemplate.Height = 24;
            this.dataGridView_Eredmenyek.Size = new System.Drawing.Size(455, 293);
            this.dataGridView_Eredmenyek.TabIndex = 10;
            // 
            // button_letolt
            // 
            this.button_letolt.Location = new System.Drawing.Point(158, 563);
            this.button_letolt.Name = "button_letolt";
            this.button_letolt.Size = new System.Drawing.Size(102, 31);
            this.button_letolt.TabIndex = 11;
            this.button_letolt.Text = "Letöltés";
            this.button_letolt.UseVisualStyleBackColor = true;
            this.button_letolt.Click += new System.EventHandler(this.button_letolt_Click);
            // 
            // Form_nyito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 606);
            this.Controls.Add(this.button_letolt);
            this.Controls.Add(this.dataGridView_Eredmenyek);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.button_Chart_Level);
            this.Controls.Add(this.label_fajl);
            this.Controls.Add(this.button_Betolt);
            this.Controls.Add(this.label_Utolso_modositas_datum);
            this.Controls.Add(this.label_Letrehozas_datum);
            this.Controls.Add(this.data_Columns);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_nyito";
            this.Text = "Gamma‑sugárzások vizsgálata";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_Columns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Eredmenyek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView data_Columns;
        private System.Windows.Forms.Label label_Letrehozas_datum;
        private System.Windows.Forms.Label label_Utolso_modositas_datum;
        private System.Windows.Forms.Button button_Betolt;
        private System.Windows.Forms.Label label_fajl;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_Chart_Level;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.DataGridView dataGridView_Eredmenyek;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button_letolt;
    }
}

