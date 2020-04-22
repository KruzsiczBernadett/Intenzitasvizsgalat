using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace Charts
{
    public partial class Form_nyito : Form
    {

        string adatforras = "";
        int index = 0;
        public Form_nyito()
        {
            InitializeComponent();
        }
        

        private void button_Betolt_Click(object sender, EventArgs e)
        {
            data_Columns.Rows.Clear();
            Program.energy.Clear();
            Program.eredmeny.Clear();
            Program.levels.Clear();
            comboBox.Items.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               

                adatforras = openFileDialog1.FileName;
                label_fajl.Text = adatforras;
                label_Utolso_modositas_datum.Text = "Utolsó módosítás: " + File.GetCreationTime(adatforras).ToString("yyyy-MM-dd");
                label_Letrehozas_datum.Text = "Létrehozás: " + File.GetLastWriteTime(adatforras).ToString("yyyy-MM-dd");
                data_Columns.Rows.Clear();
                if (Beolvas(adatforras))
                {
                    //Ei Jpi_i ->  Jpi_f Energy          Intensity Alpha     Delta Mult

                    foreach (Energiaszintek item in Program.energy)
                    {
                        int sor_index = data_Columns.Rows.Add();
                        data_Columns.Rows[sor_index].Cells["Nívószint"].Value = Program.energy[sor_index].Ei;
                        data_Columns.Rows[sor_index].Cells["Jpi_i"].Value = Program.energy[sor_index].Jpi_i;
                        data_Columns.Rows[sor_index].Cells["Jpi_f"].Value = Program.energy[sor_index].Jpi_f;
                        data_Columns.Rows[sor_index].Cells["Energia"].Value = Program.energy[sor_index].Energy;
                        data_Columns.Rows[sor_index].Cells["Intenzitás"].Value = Program.energy[sor_index].Intensity;
                        data_Columns.Rows[sor_index].Cells["Intenzitás_hiba"].Value = Program.energy[sor_index].Intensity_err;
                        index = sor_index;
                    }
                    //-- Megrajzolja a grafikont ----------------
                    Program.form_chart_level.Kirajzol();

                    //-- eredmények előkészítésa---
                    int ei = Program.energy[0].Ei;
                    string jpi = Program.energy[0].Jpi_i;
                    double sum_intensity = Program.energy[0].Intensity;
                    Eredmenyek uj = new Eredmenyek();
                    List<Folyo> elfolyok = new List<Folyo>();
                    elfolyok.Add(new Folyo(Convert.ToInt32(Program.energy[0].Energy), Program.energy[0].Intensity));
                    //--- eredmények osztály feltöltése, intenztitás összegek kiszámítása---
                    for (int i = 1; i < Program.energy.Count; i++)
                    {
                        if (ei != Program.energy[i].Ei)
                        {
                            uj.Ei = ei;
                            uj.Jpi_i = jpi;
                            uj.Elfolyok = elfolyok;
                            uj.Elfolyo_intensity_ossz = sum_intensity;
                            Program.eredmeny.Add(uj);
                            //-- kinullázás
                            ei = Program.energy[i].Ei;
                            jpi = Program.energy[i].Jpi_i;
                            sum_intensity = Program.energy[i].Intensity;
                            elfolyok = new List<Folyo>();
                            elfolyok.Add(new Folyo(Convert.ToInt32(Program.energy[i].Energy), Program.energy[i].Intensity));    //hozzátéve, minden ciklus első eleme miatt
                            uj = new Eredmenyek();
                            uj.Ei = ei;
                            uj.Jpi_i = jpi;
                        }
                        else
                        {
                            sum_intensity += Program.energy[i].Intensity;
                            elfolyok.Add(new Folyo(Convert.ToInt32(Program.energy[i].Energy), Program.energy[i].Intensity));
                        }

                    }
                    //--> az utolsó miatt kell:
                    uj.Ei = ei;
                    uj.Jpi_i = jpi;
                    uj.Elfolyok = elfolyok;
                    uj.Elfolyo_intensity_ossz = sum_intensity;
                    Program.eredmeny.Add(uj);

                    //--- Ráfolyó intenzitások feltöltése eredmények classba, és az intenztitások összegzése---
                    foreach (Eredmenyek item in Program.eredmeny)
                    {
                        item.Rafolyok = Rafolyo_intenzitasok_lista(item.Ei, item.Jpi_i);
                        item.Rafolyo_intensity_ossz = item.Rafolyok.Sum(a => a.Intensity);
                    }

                    //--- intenzitás összegek összehasonlítása---
                    foreach (var item in Program.eredmeny)
                    {
                        if (item.Rafolyo_intensity_ossz > item.Elfolyo_intensity_ossz)
                        {
                            item.Kulonbseg = item.Rafolyo_intensity_ossz - item.Elfolyo_intensity_ossz;
                            item.Intenzitas_eredmeny_osszegzes = "Valószínűleg nem találta meg a kiválasztott energiaszintről az összes elfolyó gamma-sugárzást!";
                        }
                        else {
                            item.Kulonbseg = item.Elfolyo_intensity_ossz - item.Rafolyo_intensity_ossz;
                            item.Intenzitas_eredmeny_osszegzes = "Nagy valószínűséggel megtalálta a kiválasztott energiaszint összes gamma-sugárzását!";
                        }
                    }

                    //--- comboBox feltöltése---
                    //comboBox.Items.Add("Mindet megjelenít");
                    foreach (var item in Program.eredmeny)
                    {
                        comboBox.Items.Add(item.Ei.ToString());
                    }

                }
            }
        }

        private List<Folyo> Rafolyo_intenzitasok_lista(int vizsgalt_ei, string spi) 
        {
            List<Folyo> ra = new List<Folyo>();
            foreach (Energiaszintek item in Program.energy.FindAll(a => !string.IsNullOrEmpty(a.Jpi_f) && a.Jpi_f.Equals(spi)))
            {
                int epsz = 1; //-- kerekítési hiba
                int ra_energy = item.Ei - Convert.ToInt32(item.Energy);
                if (ra_energy >= vizsgalt_ei-epsz && ra_energy <= vizsgalt_ei+epsz)
                {
                    ra.Add(new Folyo(Convert.ToInt32(item.Energy), item.Intensity));
                }
            }
            return ra;
        }
                     
        bool Beolvas(string forras)
        {
            int page = 1;
            bool feldolgozni = false;
            
            try
            {
                using (StreamReader sr = new StreamReader(forras))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (String.IsNullOrEmpty(line))
                        {
                            //-- öres sort olvasott
                            continue;
                        }
                        else if (line.Equals("\f"))
                        {
                            // --Lapdobát olvstunk 
                            // 1 lapdobás le vége
                            page++;
                            feldolgozni = false;
                            continue;
                        }
                        else if (line.Substring(1, 5).Equals("-----"))
                        {
                            feldolgozni = true;
                            continue;
                        }

                        if (feldolgozni)
                        {
                            switch (page)
                            {
                                case 1:
                                    //--    List of levels ------------
                                    Program.levels.Add(new Levels(line));
                                    break;
                                case 2:
                                    //--    List of transitions --------
                                    Program.energy.Add(new Energiaszintek(line));
                                    break;
                                //case 3:
                                //    //--    Test of Gamma-ray and Level Energies
                                //    break;
                                //case 4:
                                //    //--    Test of Gamma-ray Energy Sums
                                //    break;
                                //case 5:
                                //    //--    Test of Gamma Ray Intensity Sums
                                //    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }       //Metódus?

        private void Form1_Load(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + @"..\..";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Adatfájl kiválasztása";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "measurement data (*.dat)|*.dat|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.ValidateNames = false;

            data_Columns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_Columns.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data_Columns.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            data_Columns.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            data_Columns.ColumnHeadersDefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
            data_Columns.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            data_Columns.MultiSelect = false;
            data_Columns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
   

            //--Savefiledialog proba
            saveFileDialog1.InitialDirectory = @"..\..";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Eredmények mentése";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.FileName = "*.txt";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;



            //--- A beolvasott adatok megjelenítésére szolgáló oszlopok előkészítése ---

            DataGridViewColumn column_x = new DataGridViewColumn();
            {
                column_x.Name = "Nívószint";
                column_x.DataPropertyName = "Nívószint";
                column_x.CellTemplate = new DataGridViewTextBoxCell();
                
            }
            data_Columns.Columns.Insert(0, column_x);

            DataGridViewColumn column_y = new DataGridViewColumn();
            {
                column_y.Name = "Jpi_i";
                column_y.DataPropertyName = "Jpi_i";
                column_y.CellTemplate = new DataGridViewTextBoxCell();
            }

            data_Columns.Columns.Insert(1, column_y);

            DataGridViewColumn column_z = new DataGridViewColumn();
            {
                column_z.Name = "Jpi_f";
                column_z.DataPropertyName = "Jpi_f";
                column_z.CellTemplate = new DataGridViewTextBoxCell();
            }

            data_Columns.Columns.Insert(2, column_z);

            DataGridViewColumn column_k = new DataGridViewColumn();
            {
                column_k.Name = "Energia";
                column_k.DataPropertyName = "Energia";
                column_k.CellTemplate = new DataGridViewTextBoxCell();
            }
            data_Columns.Columns.Insert(3, column_k);

            DataGridViewColumn column_l = new DataGridViewColumn();
            {
                column_l.Name = "Intenzitás";
                column_l.DataPropertyName = "Intenzitás";
                column_l.CellTemplate = new DataGridViewTextBoxCell();
            }

            data_Columns.Columns.Insert(4, column_l);

            DataGridViewColumn column_m = new DataGridViewColumn();
            {
                column_m.Name = "Intenzitás_hiba";
                column_m.DataPropertyName = "Intenzitás_hiba";
                column_m.CellTemplate = new DataGridViewTextBoxCell();
            }

            data_Columns.Columns.Insert(5, column_m);




            // combobox probalkozás
            ComboBox comboBox = new ComboBox();
            comboBox.Location = new System.Drawing.Point(20, 60);
            comboBox.Name = "comboBox";
            comboBox.Size = new System.Drawing.Size(245, 25);
            comboBox.BackColor = System.Drawing.Color.White;
            comboBox.ForeColor = System.Drawing.Color.Black;






            

        }

        private void button_Chart_Level_Click(object sender, EventArgs e)
        {
            Program.form_chart_level.Show();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Program.energy[].Ei  --> ehhez iratjuk ki az eredményeket            

          kivalaszt_kiir();
                /// nem tudok görgetni az eredményekmél
                                                                   
        }
        //private void kivalasztas()
        //{
        //    List<Folyo> kivalasztott = new List<Folyo>();
        //    int kivalaszt = int.Parse(comboBox.Text);
        //    Eredmenyek kiv = Program.eredmeny.Find(a => a.Ei == kivalaszt);
        //    string kiv_ei = "Nívószint:" + kiv.Ei;
        //    string kiv_jpi = "Nívószint spin-paritás értéke:" + kiv.Jpi_i;
        //    string kiv_int_kul = "Intenzitás összegek Különbsége:" + kiv.Kulonbseg;
        //    string kiv_konkl = "Konklúzió:" + kiv.Intenzitas_eredmeny_osszegzes;
        //    //string[] kiv_elf_en = "Energia:" + item.Energy;
        //    //string[] kiv_elf_int = "Intenzitás:" + item.Intensity;
            
        //    string kiv_elf_int_ossz = "Elfolyó intenzitások összege:" + kiv.Elfolyo_intensity_ossz;
        //    //string kiv_raf_en = "Energia:" + item.Energy;
        //    //string kiv_raf_int = "Intenzitás:" + item.Intensity;
        //    string kiv_raf_int_ossz = "Ráfolyó intenzitások összege:" + kiv.Rafolyo_intensity_ossz;


        //}
        private void kivalaszt_kiir()
        {

            int kivalaszt = int.Parse(comboBox.Text);
            Eredmenyek kiv = Program.eredmeny.Find(a => a.Ei == kivalaszt);
            textBox_Ei_eredmenyei.Text = $"Ei:{kiv.Ei} \tJpi_i:{kiv.Jpi_i}\r\n ";
            textBox_Ei_eredmenyei.Text += $"\r\n";
            textBox_Ei_eredmenyei.Text += $"Konklúzió:{kiv.Intenzitas_eredmeny_osszegzes}\r\n";
            textBox_Ei_eredmenyei.Text += $"\r\n";
            textBox_Ei_eredmenyei.Text += $"Intenzitás különbség:{kiv.Kulonbseg}\r\n";
            textBox_Ei_eredmenyei.Text += $"\r\n";
            textBox_Ei_eredmenyei.Text += $"\r\n";
            textBox_Ei_eredmenyei.Text += $"Elfolyó gamma-sugárzás:\r\n ";
            foreach (Folyo item in kiv.Elfolyok)
            {
                textBox_Ei_eredmenyei.Text += $"\tEnergia:{item.Energy}, Intenzitás:{item.Intensity}\r\n ";
            }
            textBox_Ei_eredmenyei.Text += $"\tIntenzitás összeg:{kiv.Elfolyo_intensity_ossz}\r\n ";
            textBox_Ei_eredmenyei.Text += $"\r\n";

            textBox_Ei_eredmenyei.Text += $"Ráfolyó gamma-sugárzás:\r\n ";
            foreach (Folyo item in kiv.Rafolyok)
            {
                textBox_Ei_eredmenyei.Text += $"\tEnergia:{item.Energy}, Intenzitás:{item.Intensity}\r\n ";
            }
            textBox_Ei_eredmenyei.Text += $"\tIntenzitás összeg:{kiv.Rafolyo_intensity_ossz}\r\n ";
            
            
        }           //metódus?

        private void button_letolt_Click(object sender, EventArgs e)
        {
          
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                Stream stream = saveFileDialog1.OpenFile();

                StreamWriter wr = new StreamWriter(stream);
                int kivalaszt = int.Parse(comboBox.Text);
                Eredmenyek kiv = Program.eredmeny.Find(a => a.Ei == kivalaszt);

                wr.WriteLine("Nívószint:" + kiv.Ei);
                wr.WriteLine("Nívószint spin-paritás értéke:" + kiv.Jpi_i);
                wr.WriteLine("Intenzitás összegek Különbsége:" + kiv.Kulonbseg);
                wr.WriteLine("Konklúzió:" + kiv.Intenzitas_eredmeny_osszegzes);
                wr.WriteLine("\n");
               
                foreach (Folyo item in kiv.Elfolyok)
                {
                    wr.Write("Energia: {0}\t", item.Energy);
                    wr.Write("Intenzitás: {0}\t", item.Intensity);
                    wr.WriteLine("\n");
                }
                wr.WriteLine("Elfolyó intenzitások összege:" + kiv.Elfolyo_intensity_ossz);
                foreach (Folyo item in kiv.Rafolyok)
                {
                    wr.Write("Energia: {0}\t", item.Energy);
                    wr.Write("Intenzitás: {0}\t", item.Intensity);
                    wr.WriteLine("\n");
                }
                wr.WriteLine("Ráfolyó intenzitások összege:" +kiv.Rafolyo_intensity_ossz);

                wr.Close();
                stream.Close();
                
            }
        }

        private void textBox_Ei_eredmenyei_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_mind_Click(object sender, EventArgs e)
        {         
                Program.form_eredmeny.ShowDialog();
        }
    }
    
        
}
