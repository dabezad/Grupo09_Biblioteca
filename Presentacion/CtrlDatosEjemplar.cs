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
    public partial class CtrlDatosEjemplar : UserControl
    {

        public TextBox TbCodigo
        {
            get { return this.tbCodigo; }
        }

        
        public ComboBox CbEstadoEj
        {
            get { return this.cbEstadoEj;  }
        }
        public CtrlDatosEjemplar()
        {
            InitializeComponent();
        }

        public CtrlDatosEjemplar(int top, int left)
        {
            this.Top = top;
            this.Left = left;
            InitializeComponent();
        }

        private void CtrlDatosEjemplar_Load(object sender, EventArgs e)
        {
            this.cbEstadoEj.SelectedIndex = 0;
        }
    }
}
