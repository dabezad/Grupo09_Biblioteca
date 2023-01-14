using LogicaNegocio;
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
            //Application.Run(new FormAdquisiciones(new ModeloDominio.PersonalAdquisiciones("Pepa", "123")));
            //Application.Run(new FormSala(new ModeloDominio.PersonalSala("Jose", "321")));
            FormInicial login = new FormInicial();
            Application.Run(login);

            while (login.AutentificacionCorrecta)
            {

                DialogResult d = login.FormGestion.ShowDialog();
                if (d == DialogResult.Abort)
                {
                    login = new FormInicial();
                    login.ShowDialog();
                } else
                {
                    login.FormGestion.Close();
                    break;
                }
            }
            login.FormGestion.Dispose();


        }
    }
}
