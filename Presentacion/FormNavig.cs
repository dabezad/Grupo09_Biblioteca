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
    public partial class FormNavig : Form
    {
        public ToolStripButton BtPrimero
        {
            get { return this.btPrimero; }
        }
        public ToolStripButton BtAnterior
        {
            get { return this.btAnterior; }
        }
        public ToolStripButton BtSiguiente
        {
            get { return this.btSiguiente; }
        }
        public ToolStripButton BtUltimo
        {
            get { return this.btUltimo; }
        }
        public BindingNavigator BnDatos
        {
            get { return this.bnDatos; }
        }

        public Label LbClave
        {
            get { return this.lbClave; }
        }

        public TextBox TbClave
        {
            get { return this.tbClave; }
        }

        public ToolStripTextBox PsItem
        {
            get { return this.psItem; }
        }
        public FormNavig()
        {
            InitializeComponent();
        }

        
    }
}
