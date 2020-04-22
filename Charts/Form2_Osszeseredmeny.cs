using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;

namespace Charts
{
    public partial class Form2_Osszeseredmeny : Form
    {
        public Form2_Osszeseredmeny()
        {
            InitializeComponent();
        }

        private string Kiirat()
        {
            

            //----datagridproba---
            ///első lépés: 0.elem kiiratás
            ///második lépés: valamilyen ciklussal sokszorosítás

            int sorszam = 0;
            int kivalaszt = 0;
            int sor_index = 0;
            
            for (int i = 0; i < Program.eredmeny.Count; i++)
            {
                kivalaszt = Program.eredmeny[i].Ei;
                sor_index = dataGridView_Eredmeny.Rows.Add();
                dataGridView_Eredmeny.Rows[sor_index].Cells["Nívószint"].Value = "Nívószint:";
                dataGridView_Eredmeny.Rows[sor_index].Cells["Jpi_i"].Value = Program.eredmeny[i].Ei;
                sor_index = dataGridView_Eredmeny.Rows.Add();
                dataGridView_Eredmeny.Rows[sor_index].Cells["Nívószint"].Value = "Nívószint spin-paritás értéke:";
                dataGridView_Eredmeny.Rows[sor_index].Cells["Jpi_i"].Value = Program.eredmeny[i].Jpi_i;
                sor_index = dataGridView_Eredmeny.Rows.Add();
                dataGridView_Eredmeny.Rows[sor_index].Cells["Nívószint"].Value = "Konklúzió:";
                dataGridView_Eredmeny.Rows[sor_index].Cells["Jpi_i"].Value = Program.eredmeny[i].Intenzitas_eredmeny_osszegzes;
                sor_index = dataGridView_Eredmeny.Rows.Add();
                dataGridView_Eredmeny.Rows[sor_index].Cells["Nívószint"].Value = "Intenzitás összegek különbsége:";
                dataGridView_Eredmeny.Rows[sor_index].Cells["Jpi_i"].Value = Program.eredmeny[i].Kulonbseg;
                sor_index = dataGridView_Eredmeny.Rows.Add();
                dataGridView_Eredmeny.Rows[sor_index].Cells["Nívószint"].Value = "Elfolyó gamma-sugárzás:";
                sor_index = dataGridView_Eredmeny.Rows.Add();
                dataGridView_Eredmeny.Rows[sor_index].Cells["Nívószint"].Value = "Energiája";
                dataGridView_Eredmeny.Rows[sor_index].Cells["Jpi_i"].Value = "Intenzitása";
                Eredmenyek kiv = Program.eredmeny.Find(a => a.Ei == kivalaszt);
                foreach (Folyo item in kiv.Elfolyok)
                {
                    sor_index = dataGridView_Eredmeny.Rows.Add();
                    dataGridView_Eredmeny.Rows[sor_index].Cells["Nívószint"].Value = item.Energy;
                    dataGridView_Eredmeny.Rows[sor_index].Cells["Jpi_i"].Value = item.Intensity;
                }
                sor_index = dataGridView_Eredmeny.Rows.Add();
                dataGridView_Eredmeny.Rows[sor_index].Cells["Nívószint"].Value = "Intenzitás összeg:";
                dataGridView_Eredmeny.Rows[sor_index].Cells["Jpi_i"].Value = kiv.Elfolyo_intensity_ossz;

                sor_index = dataGridView_Eredmeny.Rows.Add();
                dataGridView_Eredmeny.Rows[sor_index].Cells["Nívószint"].Value = "Ráfolyó gamma-sugárzás:";
                sor_index = dataGridView_Eredmeny.Rows.Add();
                dataGridView_Eredmeny.Rows[sor_index].Cells["Nívószint"].Value = "Energiája";
                dataGridView_Eredmeny.Rows[sor_index].Cells["Jpi_i"].Value = "Intenzitása";

                foreach (Folyo item in kiv.Rafolyok)
                {
                    sor_index = dataGridView_Eredmeny.Rows.Add();
                    dataGridView_Eredmeny.Rows[sor_index].Cells["Nívószint"].Value = item.Energy;
                    dataGridView_Eredmeny.Rows[sor_index].Cells["Jpi_i"].Value = item.Intensity;
                }
                sor_index = dataGridView_Eredmeny.Rows.Add();
                dataGridView_Eredmeny.Rows[sor_index].Cells["Nívószint"].Value = "Intenzitás összeg:";
                dataGridView_Eredmeny.Rows[sor_index].Cells["Jpi_i"].Value = kiv.Rafolyo_intensity_ossz;

                sor_index = dataGridView_Eredmeny.Rows.Add();
                dataGridView_Eredmeny.Rows[sor_index].Cells["Nívószint"].Value = "";
                dataGridView_Eredmeny.Rows[sor_index].Cells["Jpi_i"].Value = "";
                sorszam++;

            }
            return null;
        }       //metódus??

        private void Form2_Osszeseredmeny_Load_1(object sender, EventArgs e)
        {
            dataGridView_Eredmeny.Columns.Clear();

            dataGridView_Eredmeny.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Eredmeny.ColumnHeadersVisible = false;
            dataGridView_Eredmeny.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Eredmeny.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView_Eredmeny.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_Eredmeny.ColumnHeadersDefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
            dataGridView_Eredmeny.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView_Eredmeny.MultiSelect = false;
            dataGridView_Eredmeny.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewColumn column_x = new DataGridViewColumn();
            {
                column_x.Name = "Nívószint";
                column_x.DataPropertyName = "Nívószint";
                column_x.CellTemplate = new DataGridViewTextBoxCell();
            }
            dataGridView_Eredmeny.Columns.Insert(0, column_x);

            DataGridViewColumn column_y = new DataGridViewColumn();
            {
                column_y.Name = "Jpi_i";
                column_y.DataPropertyName = "Jpi_i";
                column_y.CellTemplate = new DataGridViewTextBoxCell();
            }

            dataGridView_Eredmeny.Columns.Insert(1, column_y);

            //--SaveFileDialog előkészítés--
            saveFileDialog_mentes.InitialDirectory = @"..\..";
            saveFileDialog_mentes.RestoreDirectory = true;
            saveFileDialog_mentes.Title = "Minden eredmény mentése";
            saveFileDialog_mentes.DefaultExt = "txt";
            saveFileDialog_mentes.FileName = "*.txt";
            saveFileDialog_mentes.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog_mentes.CheckFileExists = true;
            saveFileDialog_mentes.CheckPathExists = true;

            Kiirat();
        }

        private void button_Letolt_ossz_Click(object sender, EventArgs e)
        {
            
            if (saveFileDialog_mentes.ShowDialog() == DialogResult.OK)
                {

                Stream fs = saveFileDialog_mentes.OpenFile();

                StreamWriter wr = new StreamWriter(fs);
                for (int i = 0; i < Program.eredmeny.Count; i++)
                {
                    wr.WriteLine("Nívószint:" + Program.eredmeny[i].Ei);
                    wr.WriteLine("Nívószint spin-paritás értéke:" + Program.eredmeny[i].Jpi_i);
                    wr.WriteLine("Intenzitás összegek Különbsége:" + Program.eredmeny[i].Kulonbseg);
                    wr.WriteLine("Konklúzió:" + Program.eredmeny[i].Intenzitas_eredmeny_osszegzes);
                    wr.WriteLine("\n");
                    Eredmenyek kiv = Program.eredmeny.Find(a => a.Ei == Program.eredmeny[i].Ei);
                    foreach (Folyo item in kiv.Elfolyok)
                    {
                        wr.WriteLine("Energia: {0}\t", item.Energy);
                        wr.WriteLine("Intenzitás: {0}\t", item.Intensity);
                        wr.WriteLine("\n");

                    }
                    wr.WriteLine("Elfolyó intenzitások összege:" + Program.eredmeny[i].Elfolyo_intensity_ossz);
                    foreach (Folyo item in kiv.Rafolyok)
                    {
                        wr.WriteLine("Energia: {0}\t", item.Energy);
                        wr.WriteLine("Intenzitás: {0}\t", item.Intensity);
                        wr.WriteLine("\n");
                    }
                     
                    wr.WriteLine("Ráfolyó intenzitások összege:" + Program.eredmeny[i].Rafolyo_intensity_ossz);
                    wr.WriteLine("\n");
                    wr.WriteLine("\n");
                }
               
                wr.Close();
                fs.Close();

                
                }
        }

        private void saveFileDialog_mentes_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
