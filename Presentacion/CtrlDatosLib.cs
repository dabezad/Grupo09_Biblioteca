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
    public partial class CtrlDatosLib : UserControl
    {
        public TextBox TbTitulo
        {
            get { return tbTitulo;  }
        }

        public TextBox TbAutor
        {
            get { return tbAutor; }
        }

        public TextBox TbEditorial
        {
            get { return tbEditorial; }
        }

        public Button BtAniadirEj
        {
            get { return btAniadirEj;  }
        }
        public CtrlDatosLib()
        {
            InitializeComponent();
        }

        public CtrlDatosLib(int top, int left)
        {
            this.Top = top;
            this.Left = left;
            InitializeComponent();
        }

        private void btAniadirEj_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            if (f is FormDatos)
            {
                FormDatos fDatos = (f as FormDatos);
                if (fDatos.TbClave.Text != "")
                {
                    FormAdquisiciones fAdq = (FormAdquisiciones) Application.OpenForms["FormAdquisiciones"];
                    fAdq.MostrarFormAltaEj(fDatos.TbClave.Text);
                }
                
            }
        }
    }
}
