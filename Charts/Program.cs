using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charts
{
    static class Program
    {
        public static List<Levels> levels = new List<Levels>();    
        public static List<Energiaszintek> energy = new List<Energiaszintek>();
        public static List<Eredmenyek> eredmeny = new List<Eredmenyek>();
        public static List<Eredmenyek2> eredmeny2 = new List<Eredmenyek2>();
        public static Form_nyito form_nyito = null;
        public static Form_Levels form_chart_level = null;

       
        /// <summary>
        ///     A gerjesztett atommag bomlása során kibocsátott gamma‑sugárzások intenzitás‑összegét 
        ///     és azok becsült hibáit  ellenőrző a program
        /// </summary>
        [STAThread]
        static void Main()
        {

           




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form_nyito = new Form_nyito();
            form_chart_level = new Form_Levels();
            Application.Run(form_nyito);

        }
    }
}
