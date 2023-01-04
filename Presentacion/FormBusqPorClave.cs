using LogicaNegocio;
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
    public partial class FormBusqPorClave : Form
    {
        private LNBiblioteca lnB;
        public ComboBox CbClave
        {
            get { return this.cbClave; }
        }

        public BindingSource BsClave
        {
            get { return this.bsClave; }
        }

        public Label LbClave
        {
            get { return this.lbClave; }
        }

        public FormBusqPorClave()
        {
            InitializeComponent();
        }

        public FormBusqPorClave(LNBiblioteca lnB)
        {
            this.lnB = lnB;
            InitializeComponent();
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
