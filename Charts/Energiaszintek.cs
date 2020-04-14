using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.Jpi_i = sor.Substring(10,8).Trim();
            this.Jpi_f = sor.Substring(19, 9).Trim();
            string szam = sor.Substring(29, 12).Split('(')[0].Trim();
            this.Energy = double.Parse(szam.Replace(".",","));          
            string[] tomb = sor.Substring(42, 12).Trim().Split('(');
            this.Intensity = double.Parse(tomb[0].Replace(".",",").Trim());

            this.Intensity_err = double.Parse(tomb[1].Replace(".",",").Trim(')'));
        }
        
        
    }
}
