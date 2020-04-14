using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charts
{
    class Eredmenyek
    {
        int Ei;
        double elfolyo_int_ossz;

        public Eredmenyek(int ei, double elfolyo_int_ossz)
        {
            Ei = ei;
            this.elfolyo_int_ossz = elfolyo_int_ossz;
        }

        public int Ei1 { get => Ei; set => Ei = value; }
        public double Elfolyo_int_ossz { get => elfolyo_int_ossz; set => elfolyo_int_ossz = value; }
    }
}
