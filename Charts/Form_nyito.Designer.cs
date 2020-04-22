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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button_letolt = new System.Windows.Forms.Button();
            this.textBox_Ei_eredmenyei = new System.Windows.Forms.TextBox();
            this.button_mind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_Columns)).BeginInit();
            this.SuspendLayout();
            // 
            // data_Columns
            // 
            this.data_Columns.AllowUserToAddRows = false;
            this.data_Columns.AllowUserToDeleteRows = false;
            this.data_Columns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_Columns.Dock = System.Windows.Forms.DockStyle.Right;
            this.data_Columns.Location = new System.Drawing.Point(768, 0);
            this.data_Columns.Margin = new System.Windows.Forms.Padding(4);
            this.data_Columns.Name = "data_Columns";
            this.data_Columns.ReadOnly = true;
            this.data_Columns.RowHeadersWidth = 51;
            this.data_Columns.Size = new System.Drawing.Size(768, 649);
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
            this.button_Chart_Level.Location = new System.Drawing.Point(434, 15);
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
            this.comboBox.Location = new System.Drawing.Point(194, 138);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(86, 24);
            this.comboBox.TabIndex = 9;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.ValidateNames = false;
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
            // textBox_Ei_eredmenyei
            // 
            this.textBox_Ei_eredmenyei.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.textBox_Ei_eredmenyei.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ei_eredmenyei.Location = new System.Drawing.Point(38, 187);
            this.textBox_Ei_eredmenyei.Multiline = true;
            this.textBox_Ei_eredmenyei.Name = "textBox_Ei_eredmenyei";
            this.textBox_Ei_eredmenyei.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Ei_eredmenyei.Size = new System.Drawing.Size(660, 258);
            this.textBox_Ei_eredmenyei.TabIndex = 12;
            this.textBox_Ei_eredmenyei.TextChanged += new System.EventHandler(this.textBox_Ei_eredmenyei_TextChanged);
            // 
            // button_mind
            // 
            this.button_mind.Location = new System.Drawing.Point(562, 132);
            this.button_mind.Name = "button_mind";
            this.button_mind.Size = new System.Drawing.Size(109, 30);
            this.button_mind.TabIndex = 13;
            this.button_mind.Text = "Mutat";
            this.button_mind.UseVisualStyleBackColor = true;
            this.button_mind.Click += new System.EventHandler(this.button_mind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Minden eredmény megjelenítése:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nívószint kiválasztása:";
            // 
            // Form_nyito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 649);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_mind);
            this.Controls.Add(this.textBox_Ei_eredmenyei);
            this.Controls.Add(this.button_letolt);
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
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button_letolt;
        private System.Windows.Forms.TextBox textBox_Ei_eredmenyei;
        private System.Windows.Forms.Button button_mind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

