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

        public Label LbCodigo
        {
            get { return this.lbCodigo;  }
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

    }
}
