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
    public partial class CtrlRegistroPersonal : UserControl
    {
        public TextBox TbNombre
        {
            get { return this.tbNombre; }
        }

        public TextBox TbContraseña
        {
            get { return this.tbContraseña; }
        }

        public ComboBox CbRol
        {
            get { return this.cbRol; }
        }
        public CtrlRegistroPersonal()
        {
            InitializeComponent();
            
        }

        public CtrlRegistroPersonal(int top, int left)
        {
            this.Top = top;
            this.Left = left;
            
            InitializeComponent();
        }
    }
}
