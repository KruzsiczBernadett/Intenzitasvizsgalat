using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charts
{
    class Folyo
    {
        int energy;
        double intensity;

        public Folyo(int energy, double intensity)
        {
            this.Energy = energy;
            this.Intensity = intensity;
        }

        public int Energy { get => energy; set => energy = value; }
        public double Intensity { get => intensity; set => intensity = value; }
    }
}
