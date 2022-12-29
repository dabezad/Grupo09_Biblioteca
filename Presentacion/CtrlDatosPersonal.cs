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
    public partial class CtrlDatosPersonal : UserControl
    {

        public TextBox TbRol
        {
            get { return this.tbRol; }
        }

        public CtrlDatosPersonal()
        {
            InitializeComponent();
        }

        public CtrlDatosPersonal(int top, int left)
        {
            this.Top = top;
            this.Left = left;
            InitializeComponent();
        }
    }
}
