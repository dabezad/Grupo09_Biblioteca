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
    public partial class FormDatos : Form
    {
        public Label LbClave
        {
            get { return this.lbClave;  }
        }

        public TextBox TbClave
        {
            get { return this.tbClave;  }
        }

        public Button BtAceptar
        {
            get { return this.btAceptar; }
        }

        public FormDatos()
        {
            InitializeComponent();
        }

        private void FormAlta_Load(object sender, EventArgs e)
        {

        }
    }
}
