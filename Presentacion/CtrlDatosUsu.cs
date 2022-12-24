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
    public partial class CtrlDatosUsu : UserControl
    {

        public TextBox TbNombre
        {
            get { return tbNombre; }
        }
        public CtrlDatosUsu()
        {
            InitializeComponent();
        }

        public CtrlDatosUsu(int top, int left)
        {
            this.Top = top;
            this.Left = left;
            InitializeComponent();
        }
    }
}
