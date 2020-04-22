using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Charts
{
    class Energiaszintek
    {
        //Ei Jpi_i ->  Jpi_f Energy          Intensity Alpha     Delta Mult
        //------------------------------------------------------------------------------

        public int Ei;
        public string Jpi_i;
        public string Jpi_f;
        public double Energy;
        public double Intensity;
        public double Intensity_err;


        public Energiaszintek(string sor)
        {
            this.Ei = int.Parse(sor.Substring(0, 9).Trim());
            this.Jpi_i = sor.Substring(10, 8).Trim();
            this.Jpi_f = sor.Substring(19, 9).Trim();
            string szam = sor.Substring(29, 12).Split('(')[0].Trim();
            this.Energy = double.Parse(szam.Replace(".", ","));
            string[] tomb = sor.Substring(42, 12).Trim().Split('(');
            this.Intensity = double.Parse(tomb[0].Replace(".", ",").Trim());

            this.Intensity_err = double.Parse(tomb[1].Replace(".", ",").Trim(')'));
        }
        //public Energiaszintek(string sor)
        //{
        //    RegexOptions options = RegexOptions.None;
        //    Regex regex = new Regex("[ ]{2,}", options);
        //    sor = regex.Replace(sor.Trim(), " ");   //-- A kettőnél több szóközt egyre cseréljük
        //    string[] line = sor.Split(); //-- Az egyes szóközök mentén szeleteli a string-et

        //    int resz = 0;
        //    this.Ei = int.Parse(line[resz++]);
        //    int intensity = 0;
        //    if (line[resz].Contains("+") || line[resz].Contains("-"))
        //    {
        //        this.Jpi_i = line[resz++];
        //    }
        //    else
        //    {
        //        intensity++;
        //    }
        //    if (line[resz].Contains("+") || line[resz].Contains("-"))
        //    {
        //        this.Jpi_f = line[intensity + resz++];
        //    }
        //    string szam = line[resz++].Split('(')[0];
        //    this.Energy = double.Parse(szam.Replace(".", ","));
        //    string[] tomb = line[resz++].Split('(');
        //    this.Intensity = double.Parse(tomb[0].Replace(".", ","));

        //    this.Intensity_err = double.Parse(tomb[1].Replace(".", ",").Trim(')'));
        //}


    }
}
