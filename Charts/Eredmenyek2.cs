using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charts
{
    class Eredmenyek2
    {
        int Ei;
        double rafolyo_int_ossz;

        public Eredmenyek2(int ei, double rafolyo_int_ossz)
        {
            Ei = ei;
            this.rafolyo_int_ossz = rafolyo_int_ossz;
        }

        public int Ei1 { get => Ei; set => Ei = value; }
        public double Rafolyo_int_ossz { get => rafolyo_int_ossz; set => rafolyo_int_ossz = value; }
    }
}
