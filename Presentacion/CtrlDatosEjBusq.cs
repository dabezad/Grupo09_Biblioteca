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
    public partial class CtrlDatosEjBusq : UserControl
    {
        public TextBox TbIsbn
        {
            get { return this.tbIsbn; }
        }

        public ComboBox CbEstadoEj
        {
            get { return this.cbEstadoEj; }
        }

        public Button BtVerLibro
        {
            get { return this.btVerLibro; }
        }


        public CtrlDatosEjBusq()
        {
            InitializeComponent();
        }

        public CtrlDatosEjBusq(int top, int left)
        {
            Top = top;
            Left = left;
            InitializeComponent();
        }
    }
}
