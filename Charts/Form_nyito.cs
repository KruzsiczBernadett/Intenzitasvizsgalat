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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                adatforras = openFileDialog1.FileName;
                label_fajl.Text = adatforras;
                label_Utolso_modositas_datum.Text = "Utolsó módosítás: " + File.GetCreationTime(adatforras).ToString("yyyy-MM-dd");
                label_Letrehozas_datum.Text = "Létrehozás: " + File.GetLastWriteTime(adatforras).ToString("yyyy-MM-dd");
                data_Columns.Rows.Clear();
                if (Beolvas(adatforras))
                {
                    /* --tanarur
                    foreach (Levels item in Program.levels)
                     {
                         int sor_index = data_Columns.Rows.Add();
                         data_Columns.Rows[sor_index].Cells["Level"].Value = Program.levels[sor_index].Level_value;
                         data_Columns.Rows[sor_index].Cells["Energy"].Value = Program.levels[sor_index].Energy;

                     }*/
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

                    /// combobox probálkozás
                    comboBox.Items.Add("Mindet megjelenít");
                    comboBox.Items.Add(Program.energy[0].Ei);
                   
                    
                    for (int i = 1; i < index; i++)
                    {
                        if (Program.energy[i - 1].Ei != Program.energy[i].Ei)
                        {
                            comboBox.Items.Add(Program.energy[i].Ei);
                            
                        }
                    }
                    /// még nincs megadva, hogy mit jelenit meg mindent megjelenít esetben
                    /// 
                    int[] azonen = new int[comboBox.Items.Count - 1];
                    azonen[0] = Program.energy[0].Ei;
                    for (int i = 1; i < azonen.Length; i++)
                    {
                        if (Program.energy[i - 1].Ei != Program.energy[i].Ei)
                        {
                           
                            azonen[i] = Program.energy[i].Ei;
                        }
                      
                    }

                    //---- 

                    //nivorol elfolyo intenzitas osszegek kiszamitasa es eltarolasa ezt a részt nem tudom hová kéne tenni, így azt sem tudom, 
                    //hogy jó-e ténylegesen az elve. ill., hogy az osszeget milyen típusu adatként kellene eltárolnii, hogy a gridben is látható lehgyen,
                    //és ki tudjam iratni a kiválasztottat  ----




                    double elf = 0.00;
                    double raf = 0.00;
                    int f = 0;


                   /* --- ez jó az elfolyó intenzitásokra!! ---*/
                    for (int j = 0; j < azonen.Length; j++)
                    {  
                        while (azonen[j]== Program.energy[f].Ei)
                        {
                         elf += Program.energy[f].Intensity;     //103Rh fájl-ra nem jó
                        }
                     Program.eredmeny.Add(new Eredmenyek(azonen[j], elf));
                     elf = 0;
                    }

                  /*  for (int j = 1; j < azonen.Length; j++)
                    {
                        for (int i = 0; i < Program.energy.Count; i++)
                        { if (azonen[j] == Program.energy[i].Ei) //--- átgondol
                            {
                                for (int k = 0; k < Program.energy.Count; k++)
                                {
                                    if (Program.energy[i].Jpi_i == Program.energy[k].Jpi_f || Program.energy[k].Ei - Math.Round(Program.energy[k].Energy) == Program.energy[i].Ei)
                                    {
                                        //if (Program.energy[k].Ei - Math.Round(Program.energy[k].Energy) == Program.energy[i].Ei)          
                                        //{
                                            raf += Program.energy[k].Intensity;
                                       // }
                                    }
                                }
                            }
                        }
                        Program.eredmeny2.Add(new Eredmenyek2(azonen[j], raf));
                        raf = 0;
                    }
                    */





                    /// ráeső gammák intenzitás összegének számítása
                    /// kiválasztott Ei-hez tartozok

                    // tfh. az első,vagyis Ei[0]-ra nézzük.

                    /*
                     for (int i = 0; i < Program.energy.Count; i++)
                     {
                         if(Program.energy[0].Jpi_i==Program.energy[i].Jpi_f)
                         {
                            if( Program.energy[i].Ei-Math.Round(Program.energy[i].Energy) == Program.energy[0].Ei)           // kérdéses számomra h a különbség, mivel int-double, mit ad? nekünk int kellene. a double-t kéne kerekíteni. vagy jó ez a kerekítés?
                             {
                                 raeso_int_ossz0 += Program.energy[i].Intensity;
                             }
                         }
                     }
                     */
                    /// általánosítás
                    /// ehhez raeso_int_ossz0-t tombbe kell alakitani
                    /// kell mégegy for



                }
            }
        }






        bool Beolvas(string forras)
        {
            int page = 1;
            bool feldolgozni = false;
            bool feld_energy = false;
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
                                case 3:
                                    //--    Test of Gamma-ray and Level Energies
                                    break;
                                case 4:
                                    //--    Test of Gamma-ray Energy Sums
                                    break;
                                case 5:
                                    //--    Test of Gamma Ray Intensity Sums
                                    break;
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
        }





        private void Form1_Load(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + @"..\..";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Adatfájl kiválasztása";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "measurement data (*.dat)|*.dat|txt files (*.txt)|*.txt|All files (*.*)|*.*";

            data_Columns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_Columns.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data_Columns.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            data_Columns.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            data_Columns.ColumnHeadersDefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
            data_Columns.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            data_Columns.MultiSelect = false;
            data_Columns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //--Savefiledialog proba
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + @"..\..";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Eredmények mentése";
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.FileName = "eredmeny";
            saveFileDialog1.Filter = "result data (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;

            //-- Az id oszlop --------------------------------------------------
            /* -- tanarur 
            DataGridViewColumn column_x = new DataGridViewColumn();
             {
                 column_x.Name = "Level";
                 column_x.DataPropertyName = "Level";
                 column_x.CellTemplate = new DataGridViewTextBoxCell();
             }
             data_Columns.Columns.Insert(0, column_x);

             DataGridViewColumn column_y = new DataGridViewColumn();
             {
                 column_y.Name = "Energy";
                 column_y.DataPropertyName = "Energy";
                 column_y.CellTemplate = new DataGridViewTextBoxCell();
             }



             data_Columns.Columns.Insert(1, column_y);*/

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






            // eredmenyeket kiirato tablazat probalkozas


            DataGridViewColumn column_a = new DataGridViewColumn();
            {
                column_a.Name = "Nívószint";
                column_a.DataPropertyName = "Nívószint";
                column_a.CellTemplate = new DataGridViewTextBoxCell();
            }
            dataGridView_Eredmenyek.Columns.Insert(0, column_a);

            DataGridViewColumn column_b = new DataGridViewColumn();
            {
                column_b.Name = "Jpi_i";
                column_b.DataPropertyName = "Jpi_i";
                column_b.CellTemplate = new DataGridViewTextBoxCell();
            }

            dataGridView_Eredmenyek.Columns.Insert(1, column_b);



            DataGridViewColumn column_c = new DataGridViewColumn();
            {
                column_c.Name = "Ráfolyó Energia";
                column_c.DataPropertyName = "Ráfolyó Energia";
                column_c.CellTemplate = new DataGridViewTextBoxCell();
            }
            dataGridView_Eredmenyek.Columns.Insert(2, column_c);

            DataGridViewColumn column_d = new DataGridViewColumn();
            {
                column_d.Name = "Ráfolyó Intenzitás";
                column_d.DataPropertyName = "Ráfolyó Intenzitás";
                column_d.CellTemplate = new DataGridViewTextBoxCell();
            }
            dataGridView_Eredmenyek.Columns.Insert(3, column_d);

            
                 DataGridViewColumn column_gr = new DataGridViewColumn();
            {
                column_gr.Name = "Ráfolyó Intenzitás Összeg";
                column_gr.DataPropertyName = "Ráfolyó Intenzitás Összeg";
                column_gr.CellTemplate = new DataGridViewTextBoxCell();
            }
            dataGridView_Eredmenyek.Columns.Insert(4, column_gr);

            DataGridViewColumn column_e = new DataGridViewColumn();
            {
                column_e.Name = "Elfolyó Energia";
                column_e.DataPropertyName = "Elfolyó Energia";
                column_e.CellTemplate = new DataGridViewTextBoxCell();
            }
            dataGridView_Eredmenyek.Columns.Insert(5, column_e);

            DataGridViewColumn column_f = new DataGridViewColumn();
            {
                column_f.Name = "Elfolyó Intenzitás";
                column_f.DataPropertyName = "Elfolyó Intenzitás";
                column_f.CellTemplate = new DataGridViewTextBoxCell();
            }
            dataGridView_Eredmenyek.Columns.Insert(6, column_f);

            DataGridViewColumn column_pr = new DataGridViewColumn();
            {
                column_pr.Name = "Elfolyó Intenzitás Összeg";
                column_pr.DataPropertyName = "Elfolyó Intenzitás Összeg";
                column_pr.CellTemplate = new DataGridViewTextBoxCell();
            }
            dataGridView_Eredmenyek.Columns.Insert(7, column_pr);


        }

        private void button_Chart_Level_Click(object sender, EventArgs e)
        {
            Program.form_chart_level.Show();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // nem tudom még hogyan választok ki konkrétat, de valahol itt lesz majd a feltöltés gondolom


            // Program.energy[].Ei  --> ehhez keressük a elfolyó intenzitásokat
            dataGridView_Eredmenyek.Rows.Clear();
            int kivalaszt = int.Parse(comboBox.Text);
            int kiv = 0;
            for (int i = 0; i < Program.eredmeny.Count; i++)
            {


                if (kivalaszt == Program.eredmeny[i].Ei1)
                {
                    kiv = i;
                    continue;
                }
           }
            for (int k = 0; k < Program.energy.Count; k++)
            {
               if (kivalaszt == Program.energy[k].Ei)
                {
                    int i = dataGridView_Eredmenyek.Rows.Add();
                    dataGridView_Eredmenyek.Rows[i].Cells["Nívószint"].Value =Program.energy[k].Ei;
                    dataGridView_Eredmenyek.Rows[i].Cells["Jpi_i"].Value = Program.energy[k].Jpi_i;
                    dataGridView_Eredmenyek.Rows[i].Cells["Elfolyó Energia"].Value = Program.energy[k].Energy;
                    dataGridView_Eredmenyek.Rows[i].Cells["Elfolyó Intenzitás"].Value = Program.energy[k].Intensity;
                    dataGridView_Eredmenyek.Rows[i].Cells["Elfolyó Intenzitás Összeg"].Value = Program.eredmeny[kiv].Elfolyo_int_ossz;
                    dataGridView_Eredmenyek.Rows[i].Cells["Ráfolyó Intenzitás"].Value = Program.energy[kiv].Intensity;
                    dataGridView_Eredmenyek.Rows[i].Cells["Ráfolyó Energia"].Value = Program.energy[kiv].Energy;
                 //   dataGridView_Eredmenyek.Rows[i].Cells["Ráfolyó Intenzitás Összeg"].Value = Program.eredmeny2[kiv].Rafolyo_int_ossz;
                }

            }


           



            

           
           



        }

        private void button_letolt_Click(object sender, EventArgs e)
        {
           /* 
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string eredmeny = saveFileDialog1.FileName;
                using (StreamWriter wr = new StreamWriter(eredmeny,Encoding.UTF8))
                {
                    while(wr!=Program.eredmeny2.Count)
                    wr.WriteLine("{0} {1}",Program.eredmeny, Program.eredmeny);

                }

            }*/
        }
    }
        
}
