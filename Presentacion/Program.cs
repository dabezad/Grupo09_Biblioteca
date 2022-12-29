using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormAdquisiciones(new ModeloDominio.PersonalAdquisiciones("Pepe", "123")));
            //Application.Run(new FormSala(new ModeloDominio.PersonalSala("Pepe", "123")));
        }
    }
}
