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
    public partial class CtrlDatosPrestamo : UserControl
    {
        public TextBox TbUsuario
        {
            get { return this.tbUsuario;  }
        }

        public Button BtEjsPres
        {
            get { return this.btEjsPres;  }
        }
        public CtrlDatosPrestamo()
        {
            InitializeComponent();
        }
        public CtrlDatosPrestamo(int top, int left)
        {
            this.Top = top;
            this.Left = left;
            InitializeComponent();
        }
    }
}
