using LogicaNegocio;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormListPrestEnProc : Form
    {
        private LNSala lnSala;
        public FormListPrestEnProc()
        {
            InitializeComponent();
        }

        public FormListPrestEnProc(LNSala lnS)
        {
            this.lnSala = lnS;
            InitializeComponent();
        }

        private void FormListPrestEnProc_Load(object sender, EventArgs e)
        {
            List<Prestamo> prestamos = lnSala.ObtenerPrestamosEnProceso();
            BindingSource bdatos = new BindingSource();

            this.bsDatos = bdatos;
            this.bsDatos.DataSource = prestamos;
        }
    }
}
