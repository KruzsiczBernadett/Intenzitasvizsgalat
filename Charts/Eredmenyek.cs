using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charts
{
    class Eredmenyek
    {
        int ei;
        string jpi_i;
        double elfolyo_intensity_ossz;
        double rafolyo_intensity_ossz;
        List<Folyo> rafolyok = new List<Folyo>();
        List<Folyo> elfolyok = new List<Folyo>();
        string intenzitas_eredmeny_osszegzes;
        double kulonbseg;


        public int Ei { get => ei; set => ei = value; }
        public string Jpi_i { get => jpi_i; set => jpi_i = value; }
        public double Elfolyo_intensity_ossz { get => elfolyo_intensity_ossz; set => elfolyo_intensity_ossz = value; }
        public double Rafolyo_intensity_ossz { get => rafolyo_intensity_ossz; set => rafolyo_intensity_ossz = value; }
        public string Intenzitas_eredmeny_osszegzes { get => intenzitas_eredmeny_osszegzes; set => intenzitas_eredmeny_osszegzes = value; }
        public double Kulonbseg { get => kulonbseg; set => kulonbseg = value; }
        internal List<Folyo> Rafolyok { get => rafolyok; set => rafolyok = value; }
        internal List<Folyo> Elfolyok { get => elfolyok; set => elfolyok = value; }
    }
}
